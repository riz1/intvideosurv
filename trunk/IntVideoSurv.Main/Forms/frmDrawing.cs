using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;

namespace CameraViewer
{
    public partial class frmDrawing : XtraForm
    {
        private int _cameraId;
        private Pen mypen;
        private int flag;
        private Point point_start;
        private Point point_end;
        private ArrayList mylist;
        private List<int> flaglist;
        private Graphics g;
        private List<Point> pointlist;

        //private 
        Queue<Point> listLine = new Queue<Point>();
        Queue<Point> listRectangle = new Queue<Point>();
        Queue<Point> listArrow = new Queue<Point>();
        Queue<Point> listPolygon = new Queue<Point>();
        //ArrayList Polygon = new ArrayList();
        ArrayList count = new ArrayList();
        int count_p;
        int tempk;
        Image myimage;

        public frmDrawing()
        {
            mylist = new ArrayList();
            pointlist = new List<Point>();
            flaglist = new List<int>();
            mypen = new Pen(Color.Red, 1);
            InitializeComponent();
        }

        public frmDrawing(Image[] images)
        {
            InitializeComponent();
            for (int i = 0; i < images.Length; i++)
            {
                treeList1.AppendNode(new[] { images[i]}, -1);
            }
            pictureBox1.Image = treeList1.Nodes[0].GetValue(0) as Image;
            mylist = new ArrayList();
            pointlist = new List<Point>();
            flaglist = new List<int>();
            mypen = new Pen(Color.Red, 1);
        }

        public frmDrawing(Image[] images,int cameraId)
        {
            count_p = 0;
            tempk = 0;
            InitializeComponent();
            _cameraId = cameraId;
            for (int i = 0; i < images.Length; i++)
            {
                treeList1.AppendNode(new[] { images[i] }, -1);
            }
            pictureBox1.Image = treeList1.Nodes[0].GetValue(0) as Image;
            mylist = new ArrayList();
            pointlist = new List<Point>();
            flaglist = new List<int>();
            mypen = new Pen(Color.Red, 1);
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = treeList1.FocusedNode.GetValue(0) as Image;
            pictureBox1.Image.Save(@"c:\tempjpg.jpg");
        }

        private void LineButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 1;//表示画直线
        }

        private void ButtonRect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 2;
        }

        private void ButtonJiantou_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 3;
        }
        //多边形
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 4;
        }
        public void DrawPicture_MouseDown(object sender, MouseEventArgs e)
        {
            point_start = new Point(e.X, e.Y);
            if (flag == 4)
            {
                pointlist.Add(point_start);
                listPolygon.Enqueue(point_start);
                
            }
        }

        public void DrawPicture_MouseUp(object sender, MouseEventArgs e)
        {
            point_end = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Right && flag == 4)
            {
                g.DrawPolygon(mypen, pointlist.ToArray());
                GraphicsPath path4 = new GraphicsPath();
                if (pointlist.Count == 0) return;
                path4.AddPolygon(pointlist.ToArray());
                
                count_p = listPolygon.Count-count_p;
                count.Add(count_p);
                //并清除polygon信息
                //listPolygon.Clear();

                mylist.Add(path4);
                pointlist.Clear();
                flaglist.Add(flag);
            }
            DrawPicture_action(sender, e);
        }
        public void DrawPicture_action(object sender, MouseEventArgs e)
        {
            pictureBox1.Refresh();
            g = Graphics.FromImage(this.pictureBox1.Image);
            //反锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;

            switch (flag)
            {
                case 1:
                    g.DrawLine(mypen, point_start, point_end);
                    //保存线点信息
                    listLine.Enqueue(point_start);
                    listLine.Enqueue(point_end);

                    GraphicsPath path1 = new GraphicsPath();
                    path1.AddLine(point_start, point_end);
                    mylist.Add(path1);
                    break;
                case 2:
                    int w, h;
                    w = point_end.X - point_start.X;
                    h = point_end.Y - point_start.Y;
                    g.DrawRectangle(mypen, point_start.X, point_start.Y, w, h);
                    Rectangle myrect = new Rectangle(point_start.X, point_start.Y, w, h);
                    //保存矩形点信息
                    listRectangle.Enqueue(point_start);
                    listRectangle.Enqueue(point_end);
                    GraphicsPath path2 = new GraphicsPath();

                    path2.AddRectangle(myrect);
                    mylist.Add(path2);
                    break;
                case 3:
                    float arrowWidth = 6;
                    float arrowHeight = 6;
                    bool arrowFill = true;
                    AdjustableArrowCap myArrow = new AdjustableArrowCap(arrowWidth, arrowHeight, arrowFill);
                    CustomLineCap customArrow = myArrow;

                    Pen p = new Pen(Color.Red, 1);
                    p.EndCap = LineCap.Custom;
                    p.CustomEndCap = customArrow;
                    g.DrawLine(p, point_start, point_end);
                    //箭头点信息
                    listArrow.Enqueue(point_start);
                    listArrow.Enqueue(point_end);
                    GraphicsPath path3 = new GraphicsPath();
                    path3.AddLine(point_start, point_end);
                    mylist.Add(path3);
                    break;
            }
            point_end = Point.Empty;
            pictureBox1.Refresh();
            flaglist.Add(flag);
        }

        private void Button_undo_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int count;
            count = mylist.Count;
            if (count == 0) return;
            mylist.RemoveAt(count - 1);

            pictureBox1.Image = Image.FromFile(@"c:\tempjpg.jpg");
            Graphics myg;
            myg = Graphics.FromImage(pictureBox1.Image);
            myg.SmoothingMode = SmoothingMode.AntiAlias;
            int j = 0;
            foreach (GraphicsPath item in mylist)
            {
                if (flaglist.ToArray()[j] == 3)
                {
                    float arrowWidth = 6;
                    float arrowHeight = 6;
                    bool arrowFill = true;
                    AdjustableArrowCap myArrow = new AdjustableArrowCap(arrowWidth, arrowHeight, arrowFill);
                    CustomLineCap customArrow = myArrow;

                    Pen p = new Pen(Color.Red, 1);
                    p.EndCap = LineCap.Custom;
                    p.CustomEndCap = customArrow;
                    myg.DrawPath(p, item);
                    continue;
                }
                myg.DrawPath(mypen, item);
            }
            pictureBox1.Image = myimage;
            pictureBox1.Refresh();
        }

        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int i,j;
            XmlDocument drawXml = new XmlDocument();
            XmlNode docNode = drawXml.CreateXmlDeclaration("1.0", "gb2312", null);
            drawXml.AppendChild(docNode);

            //recognizer
            XmlNode recognizerNode = drawXml.CreateElement("recognizer");
            XmlAttribute recognizerAttribute = drawXml.CreateAttribute("id");
            recognizerAttribute.Value = "识别器编号";//需改,用的是id号
            recognizerNode.Attributes.Append(recognizerAttribute);
            drawXml.AppendChild(recognizerNode);

            //cameras
            XmlNode camerasNode = drawXml.CreateElement("cameras");
            recognizerNode.AppendChild(camerasNode);
            //camera + 属性
            XmlNode cameraNode = drawXml.CreateElement("camera");
            camerasNode.AppendChild(cameraNode);
            XmlAttribute cameraAttribute = drawXml.CreateAttribute("id");
            cameraAttribute.Value = "摄像头编号";//需改,用的是id号
            cameraNode.Attributes.Append(cameraAttribute);

            //lines
            XmlNode linesNode = drawXml.CreateElement("lines");
            cameraNode.AppendChild(linesNode);
            for (i = 0; i < listLine.Count; i += 2)
            {
                //XmlNode  = drawXml.CreateElement("line");
                XmlNode line = drawXml.CreateElement("line");
                linesNode.AppendChild(line);
                XmlAttribute lineX1 = drawXml.CreateAttribute("X1");
                lineX1.Value = listLine.ToArray()[i].X.ToString();
                line.Attributes.Append(lineX1);
                XmlAttribute lineY1 = drawXml.CreateAttribute("Y1");
                lineY1.Value = listLine.ToArray()[i].Y.ToString();
                line.Attributes.Append(lineY1);

                XmlAttribute lineX2 = drawXml.CreateAttribute("X2");
                lineX2.Value = listLine.ToArray()[i + 1].X.ToString();
                line.Attributes.Append(lineX2);
                XmlAttribute lineY2 = drawXml.CreateAttribute("Y2");
                lineY2.Value = listLine.ToArray()[i + 1].Y.ToString();
                line.Attributes.Append(lineY2);
                //lineX.InnerText = listLine[i];
                //.GetRange(i,2).ToArray().;

            }
            listLine.Clear();

            //rectangles
            XmlNode rectanglesNode = drawXml.CreateElement("rectangles");
            cameraNode.AppendChild(rectanglesNode);
            for (i = 0; i < listRectangle.Count; i += 2)
            {
                XmlNode rectangle1 = drawXml.CreateElement("rectangle");
                rectanglesNode.AppendChild(rectangle1);
                XmlAttribute X1 = drawXml.CreateAttribute("X1");
                X1.Value = listLine.ToArray()[i].X.ToString();
                rectangle1.Attributes.Append(X1);
                XmlAttribute Y1 = drawXml.CreateAttribute("Y1");
                Y1.Value = listLine.ToArray()[i].Y.ToString();
                rectangle1.Attributes.Append(Y1);

                XmlAttribute X2 = drawXml.CreateAttribute("X2");
                X2.Value = listLine.ToArray()[i + 1].X.ToString();
                rectangle1.Attributes.Append(X2);
                XmlAttribute Y2 = drawXml.CreateAttribute("Y2");
                Y2.Value = listLine.ToArray()[i + 1].Y.ToString();
                rectangle1.Attributes.Append(Y2);
            }
            listRectangle.Clear();

            //arrow
            XmlNode arrowsNode = drawXml.CreateElement("arrows");
            cameraNode.AppendChild(arrowsNode);
            for (i = 0; i < listArrow.Count; i += 2)
            {
                //XmlNode  = drawXml.CreateElement("line");
                XmlNode arrow1 = drawXml.CreateElement("arrow");
                arrowsNode.AppendChild(arrow1);
                XmlAttribute X1 = drawXml.CreateAttribute("X1");
                X1.Value = listArrow.ToArray()[i].X.ToString();
                arrow1.Attributes.Append(X1);
                XmlAttribute Y1 = drawXml.CreateAttribute("Y1");
                Y1.Value = listArrow.ToArray()[i].Y.ToString();
                arrow1.Attributes.Append(Y1);

                XmlAttribute X2 = drawXml.CreateAttribute("X2");
                X2.Value = listArrow.ToArray()[i + 1].X.ToString();
                arrow1.Attributes.Append(X2);
                XmlAttribute Y2 = drawXml.CreateAttribute("Y2");
                Y2.Value = listArrow.ToArray()[i + 1].Y.ToString();
                arrow1.Attributes.Append(Y2);
            }
            listArrow.Clear();

            //Polygon
            XmlNode polygonsNode = drawXml.CreateElement("polygons");
            cameraNode.AppendChild(polygonsNode);
            Int32[] countToArray = (Int32[])count.ToArray(typeof(Int32));
            for (j = 0; j < count.Count; j++)
            {
                XmlNode photyon1 = drawXml.CreateElement("polygon");
                polygonsNode.AppendChild(photyon1);
                XmlAttribute number = drawXml.CreateAttribute("number");
                number.Value = countToArray[j].ToString();
                photyon1.Attributes.Append(number);
                for (i = 0; i < countToArray[j]; i++)
                {
                    XmlNode point = drawXml.CreateElement("point");
                    photyon1.AppendChild(point);
                    XmlAttribute x = drawXml.CreateAttribute("X");
                    x.Value = listPolygon.ToArray()[i+tempk].X.ToString();
                    point.Attributes.Append(x);
                    XmlAttribute y = drawXml.CreateAttribute("Y");
                    y.Value = listPolygon.ToArray()[i+tempk].Y.ToString();
                    point.Attributes.Append(y);
                }
                tempk += countToArray[j];
            }
            listPolygon.Clear();
            /*for (i = 0; i < listPolygon.Count; i++)
            {
                //XmlNode  = drawXml.CreateElement("line");

                XmlNode point = drawXml.CreateElement("point");
                photyon1.AppendChild(point);
                XmlAttribute x = drawXml.CreateAttribute("X");
                x.Value = listPolygon.ToArray()[i].X.ToString();
                point.Attributes.Append(x);
                XmlAttribute y = drawXml.CreateAttribute("Y");
                y.Value = listPolygon.ToArray()[i].Y.ToString();
                point.Attributes.Append(y);
                /*XmlAttribute Y1 = drawXml.CreateAttribute("Y1");
                Y1.Value = listLine.ToArray()[i].Y.ToString();
                photyon1.Attributes.Append(Y1);

                XmlAttribute X2 = drawXml.CreateAttribute("X2");
                X2.Value = listLine.ToArray()[i + 1].X.ToString();
                photyon1.Attributes.Append(X2);
                XmlAttribute Y2 = drawXml.CreateAttribute("Y2");
                Y2.Value = listLine.ToArray()[i + 1].Y.ToString();
                photyon1.Attributes.Append(Y2);*/
            //}
            //System.IO.File.Delete(@"c:\tempjpg.jpg");
            String name;
            name = @"c:\"+"1"+".xml";//1可换成识别器和摄像头的编号
            drawXml.Save(@name);
        }
    }
}
