using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Xml;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;

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
        private List<MyShape> ListRedo = new List<MyShape>();
 
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
        private Pen arrowpen;
        string errMessage = "";
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

            mypen = new Pen((Color)colorEdit1.EditValue, 1);
            arrowpen = new Pen((Color)colorEdit1.EditValue, 1);
            //画箭头的笔
            float arrowWidth = 6;
            float arrowHeight = 6;
            bool arrowFill = true;
            AdjustableArrowCap myArrow = new AdjustableArrowCap(arrowWidth, arrowHeight, arrowFill);
            CustomLineCap customArrow = myArrow;
            arrowpen.EndCap = LineCap.Custom;
            arrowpen.CustomEndCap = customArrow;
            xScale = pictureEdit1.Image.Width / (float)(pictureEdit1.Width);
            yScale = pictureEdit1.Image.Height / (float)(pictureEdit1.Height);
            //初始化画笔粗细
            comboBoxEdit1.Properties.Items.Add("细");
            comboBoxEdit1.Properties.Items.Add("中");
            comboBoxEdit1.Properties.Items.Add("粗");
            comboBoxEdit1.SelectedIndex = 0;

        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEdit1.Image = treeList1.FocusedNode.GetValue(0) as Image;
            ListShapes.Clear();
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

            if ((ListShapes.Count >= 1))
            {
                MyShape temp = ListShapes.ToArray()[ListShapes.Count - 1];
                ListRedo.Add(temp);
                ListShapes.RemoveAt(ListShapes.Count - 1);
                DrawingShapes();
            }

        }

        //
        private void barButtonSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            int i;
  
            XmlDocument drawXml = new XmlDocument();
            XmlNode docNode = drawXml.CreateXmlDeclaration("1.0", "gb2312", null);
            drawXml.AppendChild(docNode);
            //recognizer
            RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByCameraId(ref errMessage, _cameraId);
            if (ri==null)
            {
                if (XtraMessageBox.Show("对不起，您使用的照片没有对应的识别器，请另选", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
                    
            }
            XmlNode recognizerNode = drawXml.CreateElement("recognizer");
            XmlAttribute recognizerAttribute = drawXml.CreateAttribute("id");
            recognizerAttribute.Value = ri.Id.ToString();
            recognizerNode.Attributes.Append(recognizerAttribute);
            drawXml.AppendChild(recognizerNode);
            //cameras
            XmlNode camerasNode = drawXml.CreateElement("cameras");
            recognizerNode.AppendChild(camerasNode);
            //camera
            XmlNode cameraNode = drawXml.CreateElement("camera");
            camerasNode.AppendChild(cameraNode);
            XmlAttribute cameraAttribute = drawXml.CreateAttribute("id");
            cameraAttribute.Value = _cameraId.ToString();
            cameraNode.Attributes.Append(cameraAttribute);
            //lines,rectangles,arrows,polygons
            XmlNode linesNode = drawXml.CreateElement("lines");
            cameraNode.AppendChild(linesNode);
            XmlNode rectanglesNode = drawXml.CreateElement("rectangles");
            cameraNode.AppendChild(rectanglesNode);
            XmlNode arrowsNode = drawXml.CreateElement("arrows");
            cameraNode.AppendChild(arrowsNode);
            XmlNode polygonsNode = drawXml.CreateElement("polygons");
            cameraNode.AppendChild(polygonsNode);

            try
            {
                if (ListShapes == null)
                {
                    return;
                }
                foreach (var v in ListShapes)
                {
                    if (v is MyLine)
                    {
                        XmlNode line = drawXml.CreateElement("line");
                        linesNode.AppendChild(line);
                        XmlAttribute lineX1 = drawXml.CreateAttribute("X1");
                        int x1 = (int)((v as MyLine).P1.X / (float)xScale);//化整
                        lineX1.Value = x1.ToString();
                        line.Attributes.Append(lineX1);
                        XmlAttribute lineY1 = drawXml.CreateAttribute("Y1");
                        int y1 = (int)((v as MyLine).P1.Y / (float)yScale);
                        lineY1.Value = y1.ToString();
                        line.Attributes.Append(lineY1);

                        XmlAttribute lineX2 = drawXml.CreateAttribute("X2");
                        lineX2.Value = ((int)((v as MyLine).P2.X / (float)xScale)).ToString();
                        line.Attributes.Append(lineX2);
                        XmlAttribute lineY2 = drawXml.CreateAttribute("Y2");
                        lineY2.Value = ((int)((v as MyLine).P2.Y / (float)yScale)).ToString();
                        line.Attributes.Append(lineY2);
                        //lineX.InnerText = listLine[i];
                    }
                    else if (v is MyRect)
                    {
                        XmlNode rectangle = drawXml.CreateElement("rectangle");
                        rectanglesNode.AppendChild(rectangle);
                        XmlAttribute X1 = drawXml.CreateAttribute("X");
                        X1.Value = ((int)((v as MyRect).P1.X / (float)xScale)).ToString();
                        rectangle.Attributes.Append(X1);
                        XmlAttribute Y1 = drawXml.CreateAttribute("Y");
                        Y1.Value = ((int)((v as MyRect).P1.Y / (float)yScale)).ToString();
                        rectangle.Attributes.Append(Y1);

                        XmlAttribute w = drawXml.CreateAttribute("W");
                        w.Value = ((int)((v as MyRect).Width / (float)xScale)).ToString();
                        rectangle.Attributes.Append(w);
                        XmlAttribute h = drawXml.CreateAttribute("H");
                        h.Value = ((int)((v as MyRect).Height / (float)yScale)).ToString();
                        rectangle.Attributes.Append(h);
                    }
                    else if (v is MyArrow)
                    {
                        XmlNode arrow = drawXml.CreateElement("arrow");
                        arrowsNode.AppendChild(arrow);
                        XmlAttribute X1 = drawXml.CreateAttribute("X1");
                        X1.Value = ((int)((v as MyArrow).P1.X / (float)xScale)).ToString();
                        arrow.Attributes.Append(X1);
                        XmlAttribute Y1 = drawXml.CreateAttribute("Y1");
                        Y1.Value = ((int)((v as MyArrow).P1.Y / (float)yScale)).ToString();
                        arrow.Attributes.Append(Y1);

                        XmlAttribute X2 = drawXml.CreateAttribute("X2");
                        X2.Value = ((int)((v as MyArrow).P2.X / (float)xScale)).ToString();
                        arrow.Attributes.Append(X2);
                        XmlAttribute Y2 = drawXml.CreateAttribute("Y2");
                        Y2.Value = ((int)((v as MyArrow).P2.Y / (float)yScale)).ToString();
                        arrow.Attributes.Append(Y2);
                    }
                    else
                    {
                        XmlNode region = drawXml.CreateElement("region");
                        XmlAttribute pointnumber = drawXml.CreateAttribute("pointnumber");
                        pointnumber.Value = (v as MyPoly).ListPoint.Count.ToString();
                        region.Attributes.Append(pointnumber);
                        for (i = 0; i < (v as MyPoly).ListPoint.Count; i++)
                        {
                            XmlNode point = drawXml.CreateElement("point");
                            polygonsNode.AppendChild(point);
                            XmlAttribute x = drawXml.CreateAttribute("X");
                            x.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].X / (float)xScale)).ToString();
                            point.Attributes.Append(x);
                            XmlAttribute y = drawXml.CreateAttribute("Y");
                            y.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].Y / (float)yScale)).ToString();
                            point.Attributes.Append(y);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
            

            String name;
            name = @"c:\" + ri.Id.ToString() + "." + _cameraId.ToString() + ".xml";//识别器和摄像头的编号
            drawXml.Save(@name);
        }

        private void DrawingShapes()
        {
            try
            {
                if (ListShapes==null)
                {
                    return;
                }
                pictureEdit1.Refresh();
                Graphics graphics = pictureEdit1.CreateGraphics();
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //画完整的图
                foreach (var v in ListShapes)
                {
                    if (v is MyLine)
                    {
                        graphics.DrawLine(v.MyPen,(v as MyLine).P1,(v as MyLine).P2);
                    }
                    else if (v is MyArrow)
                    {
                        //画箭头
                        graphics.DrawLine(arrowpen, (v as MyArrow).P1, (v as MyArrow).P2);
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
                //画最后一个不完整的多边形
                if ((currentMyPoly!=null)&& (currentMyPoly.ListPoint.Count > 1))
                {
                    graphics.DrawLines(mypen, currentMyPoly.ListPoint.ToArray());                
                }


                graphics.Dispose();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                isMouseUp = false;
                StartPoint = e.Location;
                pictureEdit1.Cursor = Cursors.Cross;


                if (_currentDrawingType == DrawingType.Polygon)
                {
                    if (currentMyPoly.IsFinished)
                    {
                        currentMyPoly.ListPoint.Clear();
                        currentMyPoly.IsFinished = false;
                    }
                    else
                    {
                        currentMyPoly.ListPoint.Add(StartPoint);  
                    }                   
                    
                }
                this.isMouseDown = true;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }



        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isMouseUp)
                {
                    return;
                }
                if (_currentDrawingType!=DrawingType.None)
                {
                    DrawingShapes(); 
                    if (isMouseDown && !isMouseUp)
                    {
                        Graphics graphics = pictureEdit1.CreateGraphics();
                        switch (_currentDrawingType)
                        {
                            case DrawingType.Rect:
                                graphics.DrawRectangle(mypen, StartPoint.X, StartPoint.Y, e.Location.X - StartPoint.X, e.Location.Y - StartPoint.Y);
                                
                                break;
                            case DrawingType.Polygon:
                                if (currentMyPoly.ListPoint.Count>1)
                                {
                                    graphics.DrawLines(mypen, currentMyPoly.ListPoint.ToArray());
                                    Point LastValidPoint = currentMyPoly.ListPoint[currentMyPoly.ListPoint.Count - 1];
                                    graphics.DrawLine(mypen, LastValidPoint,e.Location);                                
                                }
                                else if(currentMyPoly.ListPoint.Count==1)
                                    graphics.DrawLine(mypen, StartPoint, e.Location); 

                                break;

                            case DrawingType.Line:
                                graphics.DrawLine(mypen, StartPoint, e.Location); 
                                break;

                            case DrawingType.Arrow:
                                //此处添加画箭头
                                graphics.DrawLine(arrowpen, StartPoint, e.Location);
                                break;
                            default:
                                graphics.DrawLine(mypen, StartPoint, e.Location); 
                                break;
                        }
                        graphics.Dispose();
                    }
                   
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }


        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isMouseUp = true;
                isMouseDown = false;
                EndPoint = e.Location;
                Graphics graphics = pictureEdit1.CreateGraphics();
                switch (_currentDrawingType)
                {
                    case DrawingType.Line:
                        ListShapes.Add(new MyLine { MyPen = mypen, P1 = StartPoint, P2 = EndPoint });
                        //graphics.DrawLine(mypen, StartPoint, EndPoint);
                        break;

                    case DrawingType.Arrow:
                        ListShapes.Add(new MyArrow { MyPen = mypen, P1 = StartPoint, P2 = EndPoint });
                        //graphics.DrawLine(mypen, StartPoint, EndPoint);
                        break;

                    case DrawingType.Rect:
                        ListShapes.Add(new MyRect { MyPen = mypen, P1 = StartPoint, Width = EndPoint.X - StartPoint.X, Height = EndPoint.Y - StartPoint.Y });
                        //graphics.DrawRectangle(mypen, StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
                        break;

                    case DrawingType.Polygon:
                        //currentMyPoly.ListPoint.Add(EndPoint);
                        currentMyPoly.IsFinished = false;
                        //graphics.DrawLines(mypen, currentMyPoly.ListPoint.ToArray());
                        break;
                }
                StartPoint= EndPoint;
                EndPoint = Point.Empty;
                graphics.Dispose();
                DrawingShapes();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void pictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((_currentDrawingType == DrawingType.Polygon)&&e.Button == MouseButtons.Left)
            {
                if (currentMyPoly.IsFinished==false)
                {
                    //因为双击之前会先执行两次单击，因此在双击前先删除多余的两次点信息
                    //
                    currentMyPoly.ListPoint.RemoveAt(currentMyPoly.ListPoint.Count-1);
                    currentMyPoly.ListPoint.RemoveAt(currentMyPoly.ListPoint.Count - 1);
                    currentMyPoly.ListPoint.Add(e.Location);
                    currentMyPoly.IsFinished = true;
                    //List是引用，不能直接赋值
                    List<Point> newPoints = new List<Point>(currentMyPoly.ListPoint.Count);
                    foreach (var newPoint in currentMyPoly.ListPoint)
                    {
                        newPoints.Add(newPoint);
                    }
                    MyPoly myPoly = new MyPoly { IsFinished = currentMyPoly.IsFinished, ListPoint = newPoints, MyPen = currentMyPoly.MyPen };
                    ListShapes.Add(myPoly);
                    currentMyPoly.ListPoint.Clear();
                    currentMyPoly.IsFinished = false;
                    DrawingShapes();                    
                }

            }
        }
        private void ChosemyColor(object sender, EventArgs e)
        {
            mypen.Color = (Color)colorEdit1.EditValue;
            arrowpen.Color = (Color)colorEdit1.EditValue;
        }

        private void Selectindex(object sender, EventArgs e)
        {
            switch (comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    mypen.Width = 1;
                    arrowpen.Width = 1;
                    break;
                case 1:
                    mypen.Width = 2;
                    arrowpen.Width = 2;
                    break;
                case 2:
                    mypen.Width = 4;
                    arrowpen.Width = 4;
                    break;
                default:
                    break;
            }
        }

        public void Mouse_Redo(object sender, ItemClickEventArgs e)
        {

            if (ListRedo == null || ListRedo.Count <= 0)
                return;
            MyShape v = ListRedo.ToArray()[ListRedo.Count - 1];
            ListRedo.RemoveAt(ListRedo.Count - 1);
            ListShapes.Add(v);
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
        public bool IsFinished;
    }
}
