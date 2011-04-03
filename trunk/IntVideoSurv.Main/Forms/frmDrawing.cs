using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Xml;

namespace CameraViewer
{
    public partial class frmDrawing : XtraForm
    {

        private enum DrawingType
        {
            Line = 0,
            Arrow = 1,
            Rect = 2,
            Polygon = 4,
            None=8
        }

        private DrawingType _currentDrawingType = DrawingType.None;
        private List<MyShape> ListShapes = new List<MyShape>();
        private float xScale = 1.0f;
        private float yScale = 1.0f;

        private bool isMouseUp;
        private bool isMouseDown;

        private int _cameraId;
        private Pen mypen = new Pen(Color.Black,2.0f);

        //private 
        Queue<Point> listLine = new Queue<Point>();
        Queue<Point> listRectangle = new Queue<Point>();
        Queue<Point> listArrow = new Queue<Point>();
        Queue<Point> listPolygon = new Queue<Point>();
        //ArrayList Polygon = new ArrayList();
        ArrayList count = new ArrayList();
        int tempk;

        public frmDrawing()
        {
            mypen = new Pen(Color.Red, 1);
            InitializeComponent();
        }

        public frmDrawing(Image[] images)
        {
            InitializeComponent();
            for (int i = 0; i < images.Length; i++)
            {
                treeList1.AppendNode(new[] { images[i] }, -1);
            }
            pictureEdit1.Image = treeList1.Nodes[0].GetValue(0) as Image;
            mypen = new Pen(Color.Red, 1);
        }

        public frmDrawing(Image[] images, int cameraId)
        {
            tempk = 0;
            InitializeComponent();
            _cameraId = cameraId;
            for (int i = 0; i < images.Length; i++)
            {
                treeList1.AppendNode(new[] { images[i] }, -1);
            }
            pictureEdit1.Image = treeList1.Nodes[0].GetValue(0) as Image;
            mypen = new Pen(Color.Red, 1);
            xScale = pictureEdit1.Image.Width/(float)(pictureEdit1.Width);
            yScale = pictureEdit1.Image.Height / (float)(pictureEdit1.Height);

        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEdit1.Image = treeList1.FocusedNode.GetValue(0) as Image;
        }
        private void ResetButtonStyle()
        {
            LineButton.ButtonStyle =
                ButtonRect.ButtonStyle = barButtonDuoBX.ButtonStyle = ButtonJiantou.ButtonStyle = BarButtonStyle.Default;
        }
        private void LineButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Line;
            ResetButtonStyle();
            LineButton.ButtonStyle = BarButtonStyle.Check;
        }

        private void ButtonRect_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Rect;
            ResetButtonStyle();
            ButtonRect.ButtonStyle = BarButtonStyle.Check;
        }

        private void ButtonJiantou_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Arrow;
            ResetButtonStyle();
            ButtonJiantou.ButtonStyle = BarButtonStyle.Check;
        }
        //多边形

        MyPoly currentMyPoly;
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Polygon;
            ResetButtonStyle();
            barButtonDuoBX.ButtonStyle = BarButtonStyle.Check;
            currentMyPoly = new MyPoly() { MyPen = mypen };
        }

        private Point StartPoint= Point.Empty;
        private Point EndPoint= Point.Empty;
        private void Button_undo_Click(object sender, ItemClickEventArgs e)
        {
            if ((ListShapes.Count>=1))
            {
                ListShapes.RemoveAt(ListShapes.Count-1);
                //DrawingShapes();
            }

        }

        private void barButtonSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            int i, j;
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
                    x.Value = listPolygon.ToArray()[i + tempk].X.ToString();
                    point.Attributes.Append(x);
                    XmlAttribute y = drawXml.CreateAttribute("Y");
                    y.Value = listPolygon.ToArray()[i + tempk].Y.ToString();
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
            name = @"c:\" + "1" + ".xml";//1可换成识别器和摄像头的编号
            drawXml.Save(@name);
        }

        private void DrawingShapes()
        {
            Graphics graphics = pictureEdit1.CreateGraphics();
            foreach (var v in ListShapes)
            {
                if (v is MyLine)
                {
                    graphics.DrawLine(v.MyPen,(v as MyLine).P1,(v as MyLine).P2);
                }
                else if (v is MyArrow)
                {
                    //画箭头
                    graphics.DrawLine(v.MyPen, (v as MyArrow).P1, (v as MyArrow).P2);
                }
                else if (v is MyRect)
                {
                    graphics.DrawRectangle(v.MyPen, (v as MyRect).P1.X, (v as MyRect).P1.Y, (v as MyRect).Width, (v as MyRect).Height);
                }
                else
                {
                    graphics.DrawPolygon(v.MyPen, (v as MyPoly).ListPoint.ToArray());
                }
            }
            graphics.Dispose();
        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isMouseDown = true;
            isMouseUp = false;
            StartPoint = e.Location;
            pictureEdit1.Cursor = Cursors.Cross;


            if (_currentDrawingType == DrawingType.Polygon)
            {
                if (currentMyPoly.ListPoint.Count==0)
                {
                    currentMyPoly.ListPoint.Add(StartPoint);                    
                }
            }

        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentDrawingType!=DrawingType.None)
            {
                
                //DrawingShapes(); 
                if ((isMouseDown)&&(StartPoint!=Point.Empty)&&(!isMouseUp))
                {
                    if (_currentDrawingType==DrawingType.Rect)
                    {
                        Graphics graphics = pictureEdit1.CreateGraphics();
                        graphics.DrawRectangle(mypen, StartPoint.X, StartPoint.Y, e.Location.X - StartPoint.X, e.Location.Y - StartPoint.Y);
                        graphics.Dispose(); 
                    }
                    else
                    {
                        Graphics graphics = pictureEdit1.CreateGraphics();
                        graphics.DrawLine(mypen, StartPoint, e.Location);  
                        graphics.Dispose();                        
                    }

                   
                }
               
            }

        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseUp = true;
            isMouseDown = false;
            EndPoint = e.Location;
            Graphics graphics = pictureEdit1.CreateGraphics();
            switch (_currentDrawingType)
            {
                case DrawingType.Line:
                    ListShapes.Add(new MyLine { MyPen = mypen, P1 = StartPoint, P2 = EndPoint });
                    graphics.DrawLine(mypen, StartPoint, EndPoint);
                    break;

                case DrawingType.Arrow:
                    ListShapes.Add(new MyArrow { MyPen = mypen, P1 = StartPoint, P2 = EndPoint });
                    graphics.DrawLine(mypen, StartPoint, EndPoint);
                    break;

                case DrawingType.Rect:
                    ListShapes.Add(new MyRect { MyPen = mypen, P1 = StartPoint, Width = EndPoint.X - StartPoint.X, Height = EndPoint.Y - StartPoint.Y });
                    graphics.DrawRectangle(mypen, StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
                    break;

                case DrawingType.Polygon:
                    currentMyPoly.ListPoint.Add(EndPoint);
                    graphics.DrawLines(mypen, currentMyPoly.ListPoint.ToArray());
                    break;
            }
            StartPoint= EndPoint;
            EndPoint = Point.Empty;
            graphics.Dispose();
        }

        private void pictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_currentDrawingType == DrawingType.Polygon)
            {
                currentMyPoly.ListPoint.Add(e.Location);                
            }
        }

        private void pictureEdit1_Paint(object sender, PaintEventArgs e)
        {

            DrawingShapes();
        }


    }
    public class MyShape
    {
        public Pen MyPen; 
    }
    public class MyLine:MyShape
    {
        public Point P1;
        public Point P2;

    }
    public class MyArrow : MyShape
    {
        public Point P1;
        public Point P2;
    }

    public class MyRect : MyShape
    {
        public Point P1;
        public int Width;
        public int Height;
    }

    public class MyPoly : MyShape
    {
        public List<Point> ListPoint= new List<Point>();
    }
}
