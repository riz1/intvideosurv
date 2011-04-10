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
            currentMyPoly = new MyPoly() { MyPen = (Pen)(mypen.Clone()) };
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
                DrawingShapes(ListShapes);
            }

        }

        //
        private void barButtonSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            int i;
            //保存为用户的xml文件画笔，无pen信息
            XmlDocument drawXml = new XmlDocument();
            XmlNode docNode = drawXml.CreateXmlDeclaration("1.0", "gb2312", null);
            drawXml.AppendChild(docNode);
            RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByCameraId(ref errMessage, _cameraId);
            if (ri==null)
            {
                if (XtraMessageBox.Show("对不起，您使用的照片没有对应的识别器，请另选", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
                    
            }
            XmlNode recognizerNode = drawXml.CreateElement("pr");
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
            XmlNode rectanglesNode = drawXml.CreateElement("rects");
            cameraNode.AppendChild(rectanglesNode);
            XmlNode arrowsNode = drawXml.CreateElement("arrows");
            cameraNode.AppendChild(arrowsNode);
            XmlNode polygonsNode = drawXml.CreateElement("regions");
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
                        int x1 = (int)((v as MyLine).P1.X * (float)xScale);//化整
                        lineX1.Value = x1.ToString();
                        line.Attributes.Append(lineX1);
                        XmlAttribute lineY1 = drawXml.CreateAttribute("Y1");
                        int y1 = (int)((v as MyLine).P1.Y * (float)yScale);
                        lineY1.Value = y1.ToString();
                        line.Attributes.Append(lineY1);

                        XmlAttribute lineX2 = drawXml.CreateAttribute("X2");
                        lineX2.Value = ((int)((v as MyLine).P2.X * (float)xScale)).ToString();
                        line.Attributes.Append(lineX2);
                        XmlAttribute lineY2 = drawXml.CreateAttribute("Y2");
                        lineY2.Value = ((int)((v as MyLine).P2.Y * (float)yScale)).ToString();
                        line.Attributes.Append(lineY2);
                        //lineX.InnerText = listLine[i];
                    }
                    else if (v is MyRect)
                    {
                        XmlNode rectangle = drawXml.CreateElement("rectangle");
                        rectanglesNode.AppendChild(rectangle);
                        XmlAttribute X1 = drawXml.CreateAttribute("X");
                        X1.Value = ((int)((v as MyRect).P1.X * (float)xScale)).ToString();
                        rectangle.Attributes.Append(X1);
                        XmlAttribute Y1 = drawXml.CreateAttribute("Y");
                        Y1.Value = ((int)((v as MyRect).P1.Y * (float)yScale)).ToString();
                        rectangle.Attributes.Append(Y1);

                        XmlAttribute w = drawXml.CreateAttribute("W");
                        w.Value = ((int)((v as MyRect).Width * (float)xScale)).ToString();
                        rectangle.Attributes.Append(w);
                        XmlAttribute h = drawXml.CreateAttribute("H");
                        h.Value = ((int)((v as MyRect).Height * (float)yScale)).ToString();
                        rectangle.Attributes.Append(h);
                    }
                    else if (v is MyArrow)
                    {
                        XmlNode arrow = drawXml.CreateElement("arrow");
                        arrowsNode.AppendChild(arrow);
                        XmlAttribute X1 = drawXml.CreateAttribute("X1");
                        X1.Value = ((int)((v as MyArrow).P1.X * (float)xScale)).ToString();
                        arrow.Attributes.Append(X1);
                        XmlAttribute Y1 = drawXml.CreateAttribute("Y1");
                        Y1.Value = ((int)((v as MyArrow).P1.Y * (float)yScale)).ToString();
                        arrow.Attributes.Append(Y1);

                        XmlAttribute X2 = drawXml.CreateAttribute("X2");
                        X2.Value = ((int)((v as MyArrow).P2.X * (float)xScale)).ToString();
                        arrow.Attributes.Append(X2);
                        XmlAttribute Y2 = drawXml.CreateAttribute("Y2");
                        Y2.Value = ((int)((v as MyArrow).P2.Y * (float)yScale)).ToString();
                        arrow.Attributes.Append(Y2);
                    }
                    else
                    {
                        XmlNode region = drawXml.CreateElement("region");
                        XmlAttribute pointnumber = drawXml.CreateAttribute("pointnumber");
                        pointnumber.Value = (v as MyPoly).ListPoint.Count.ToString();
                        region.Attributes.Append(pointnumber);
                        polygonsNode.AppendChild(region);
                        for (i = 0; i < (v as MyPoly).ListPoint.Count; i++)
                        {
                            XmlNode point = drawXml.CreateElement("point");
                            region.AppendChild(point);
                            XmlAttribute x = drawXml.CreateAttribute("X");
                            x.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].X * (float)xScale)).ToString();
                            point.Attributes.Append(x);
                            XmlAttribute y = drawXml.CreateAttribute("Y");
                            y.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].Y * (float)yScale)).ToString();
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
            //保存为管理员xml文件，有pen信息
            XmlDocument drawXmlAdmin = new XmlDocument();
            XmlNode docNodeAdmin = drawXmlAdmin.CreateXmlDeclaration("1.0", "gb2312", null);
            drawXmlAdmin.AppendChild(docNodeAdmin);
            XmlNode recognizerNodeAdmin = drawXmlAdmin.CreateElement("pr");
            XmlAttribute recognizerAttributeAdmin = drawXmlAdmin.CreateAttribute("id");
            recognizerAttributeAdmin.Value = ri.Id.ToString();
            recognizerNodeAdmin.Attributes.Append(recognizerAttributeAdmin);
            drawXmlAdmin.AppendChild(recognizerNodeAdmin);
            XmlNode camerasNodeAdmin = drawXmlAdmin.CreateElement("cameras");
            recognizerNodeAdmin.AppendChild(camerasNodeAdmin);
            XmlNode cameraNodeAdmin = drawXmlAdmin.CreateElement("camera");
            XmlAttribute cameraAttributeAdmin = drawXmlAdmin.CreateAttribute("id");
            cameraAttributeAdmin.Value = _cameraId.ToString();
            camerasNodeAdmin.AppendChild(cameraNodeAdmin);
            cameraNodeAdmin.Attributes.Append(cameraAttributeAdmin);

            XmlNode linesNodeAdmin = drawXmlAdmin.CreateElement("lines");
            cameraNodeAdmin.AppendChild(linesNodeAdmin);
            XmlNode rectsNodeAdmin = drawXmlAdmin.CreateElement("rects");
            cameraNodeAdmin.AppendChild(rectsNodeAdmin);
            XmlNode arrowsNodeAdmin = drawXmlAdmin.CreateElement("arrows");
            cameraNodeAdmin.AppendChild(arrowsNodeAdmin);
            XmlNode regionsNodeAdmin = drawXmlAdmin.CreateElement("regions");
            cameraNodeAdmin.AppendChild(regionsNodeAdmin);
            /*RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByCameraId(ref errMessage, _cameraId);
            if (ri == null)
            {
                if (XtraMessageBox.Show("对不起，您使用的照片没有对应的识别器，请另选", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }

            }*/
            

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
                        XmlNode line = drawXmlAdmin.CreateElement("line");
                        linesNodeAdmin.AppendChild(line);
                        XmlAttribute lineX1 = drawXmlAdmin.CreateAttribute("X1");
                        int x1 = (int)((v as MyLine).P1.X * (float)xScale);//化整
                        lineX1.Value = x1.ToString();
                        line.Attributes.Append(lineX1);
                        XmlAttribute lineY1 = drawXmlAdmin.CreateAttribute("Y1");
                        int y1 = (int)((v as MyLine).P1.Y * (float)yScale);
                        lineY1.Value = y1.ToString();
                        line.Attributes.Append(lineY1);

                        XmlAttribute lineX2 = drawXmlAdmin.CreateAttribute("X2");
                        lineX2.Value = ((int)((v as MyLine).P2.X * (float)xScale)).ToString();
                        line.Attributes.Append(lineX2);
                        XmlAttribute lineY2 = drawXmlAdmin.CreateAttribute("Y2");
                        lineY2.Value = ((int)((v as MyLine).P2.Y * (float)yScale)).ToString();
                        line.Attributes.Append(lineY2);

                        XmlAttribute penColor = drawXmlAdmin.CreateAttribute("PenColor");
                        //penColor.Value = (v as MyLine).MyPen.Color.ToString();
                        penColor.Value = ColorTranslator.ToHtml((v as MyLine).MyPen.Color);

                        line.Attributes.Append(penColor);
                        XmlAttribute penWidth = drawXmlAdmin.CreateAttribute("PenWidth");
                        penWidth.Value = (v as MyLine).MyPen.Width.ToString();
                        line.Attributes.Append(penWidth);
                        //lineX.InnerText = listLine[i];
                    }
                    else if (v is MyRect)
                    {
                        XmlNode rectangle = drawXmlAdmin.CreateElement("rectangle");
                        rectsNodeAdmin.AppendChild(rectangle);
                        XmlAttribute X1 = drawXmlAdmin.CreateAttribute("X");
                        X1.Value = ((int)((v as MyRect).P1.X * (float)xScale)).ToString();
                        rectangle.Attributes.Append(X1);
                        XmlAttribute Y1 = drawXmlAdmin.CreateAttribute("Y");
                        Y1.Value = ((int)((v as MyRect).P1.Y * (float)yScale)).ToString();
                        rectangle.Attributes.Append(Y1);

                        XmlAttribute w = drawXmlAdmin.CreateAttribute("W");
                        w.Value = ((int)((v as MyRect).Width * (float)xScale)).ToString();
                        rectangle.Attributes.Append(w);
                        XmlAttribute h = drawXmlAdmin.CreateAttribute("H");
                        h.Value = ((int)((v as MyRect).Height * (float)yScale)).ToString();
                        rectangle.Attributes.Append(h);

                        XmlAttribute penColor = drawXmlAdmin.CreateAttribute("PenColor");
                        //penColor.Value = (v as MyRect).MyPen.Color.ToString();
                        penColor.Value = ColorTranslator.ToHtml((v as MyRect).MyPen.Color);
                        rectangle.Attributes.Append(penColor);
                        XmlAttribute penWidth = drawXmlAdmin.CreateAttribute("PenWidth");
                        penWidth.Value = (v as MyRect).MyPen.Width.ToString();
                        rectangle.Attributes.Append(penWidth);
                    }
                    else if (v is MyArrow)
                    {
                        XmlNode arrow = drawXmlAdmin.CreateElement("arrow");
                        arrowsNodeAdmin.AppendChild(arrow);
                        XmlAttribute X1 = drawXmlAdmin.CreateAttribute("X1");
                        X1.Value = ((int)((v as MyArrow).P1.X * (float)xScale)).ToString();
                        arrow.Attributes.Append(X1);
                        XmlAttribute Y1 = drawXmlAdmin.CreateAttribute("Y1");
                        Y1.Value = ((int)((v as MyArrow).P1.Y * (float)yScale)).ToString();
                        arrow.Attributes.Append(Y1);

                        XmlAttribute X2 = drawXmlAdmin.CreateAttribute("X2");
                        X2.Value = ((int)((v as MyArrow).P2.X * (float)xScale)).ToString();
                        arrow.Attributes.Append(X2);
                        XmlAttribute Y2 = drawXmlAdmin.CreateAttribute("Y2");
                        Y2.Value = ((int)((v as MyArrow).P2.Y * (float)yScale)).ToString();
                        arrow.Attributes.Append(Y2);

                        XmlAttribute penColor = drawXmlAdmin.CreateAttribute("PenColor");
                        //penColor.Value = (v as MyArrow).MyPen.Color.ToString();
                        penColor.Value = ColorTranslator.ToHtml((v as MyArrow).MyPen.Color);
                        arrow.Attributes.Append(penColor);
                        XmlAttribute penWidth = drawXmlAdmin.CreateAttribute("PenWidth");
                        penWidth.Value = (v as MyArrow).MyPen.Width.ToString();
                        arrow.Attributes.Append(penWidth);
                    }
                    else
                    {
                        XmlNode region = drawXmlAdmin.CreateElement("region");
                        XmlAttribute pointnumber = drawXmlAdmin.CreateAttribute("pointnumber");
                        pointnumber.Value = (v as MyPoly).ListPoint.Count.ToString();
                        region.Attributes.Append(pointnumber);
                        regionsNodeAdmin.AppendChild(region);

                        XmlAttribute penColor = drawXmlAdmin.CreateAttribute("PenColor");
                        //penColor.Value = (v as MyPoly).MyPen.Color.ToString();
                        penColor.Value = ColorTranslator.ToHtml((v as MyPoly).MyPen.Color);
                        region.Attributes.Append(penColor);
                        XmlAttribute penWidth = drawXmlAdmin.CreateAttribute("PenWidth");
                        penWidth.Value = (v as MyPoly).MyPen.Width.ToString();
                        region.Attributes.Append(penWidth);

                        for (i = 0; i < (v as MyPoly).ListPoint.Count; i++)
                        {
                            XmlNode point = drawXmlAdmin.CreateElement("point");
                            region.AppendChild(point);
                            XmlAttribute x = drawXmlAdmin.CreateAttribute("X");
                            x.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].X * (float)xScale)).ToString();
                            point.Attributes.Append(x);
                            XmlAttribute y = drawXmlAdmin.CreateAttribute("Y");
                            y.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].Y * (float)yScale)).ToString();
                            point.Attributes.Append(y);
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            } 
            String nameadmin;
            nameadmin = @"c:\" + ri.Id.ToString() + "." + _cameraId.ToString() + "admin" + ".xml";//识别器和摄像头的编号
            drawXmlAdmin.Save(@nameadmin);//保存完之后再加pen信息，保存为另一个文件

        }

        private void DrawingShapes(List<MyShape> ListShapes)
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
                        //画箭头的笔
                        float arrowWidth = 6;
                        float arrowHeight = 6;
                        bool arrowFill = true;
                        AdjustableArrowCap myArrow = new AdjustableArrowCap(arrowWidth, arrowHeight, arrowFill);
                        CustomLineCap customArrow = myArrow;
                        arrowpen.EndCap = LineCap.Custom;
                        arrowpen.CustomEndCap = customArrow;
                        arrowpen.Color = v.MyPen.Color;
                        arrowpen.Width = v.MyPen.Width;

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
                    DrawingShapes(ListShapes); 
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
                        ListShapes.Add(new MyLine { MyPen = (Pen)(mypen.Clone()), P1 = StartPoint, P2 = EndPoint });
                        //graphics.DrawLine(mypen, StartPoint, EndPoint);
                        break;

                    case DrawingType.Arrow:
                        ListShapes.Add(new MyArrow { MyPen = (Pen)(mypen.Clone()), P1 = StartPoint, P2 = EndPoint });
                        //graphics.DrawLine(mypen, StartPoint, EndPoint);
                        break;

                    case DrawingType.Rect:
                        ListShapes.Add(new MyRect { MyPen = (Pen)(mypen.Clone()), P1 = StartPoint, Width = EndPoint.X - StartPoint.X, Height = EndPoint.Y - StartPoint.Y });
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
                DrawingShapes(ListShapes);
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
                    DrawingShapes(ListShapes);                    
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
            DrawingShapes(ListShapes);
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {

        }
        //读XML文件
        private List<MyShape> ListXMLShapes = new List<MyShape>();
        public void readxml()
        {
            XmlNodeList xml_lines,xml_arrows,xml_rects,xml_regions;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"c:\1.0admin.xml");
            //直线
            xml_lines= xmlDoc.SelectSingleNode("/pr/cameras/camera/lines").ChildNodes;
            foreach (XmlNode lineitem in xml_lines)
            {

                MyLine line=new MyLine();
                line.MyPen = new Pen(Color.Red,1);
                XmlElement xe=(XmlElement)lineitem;
                line.P1.X = Convert.ToInt32(xe.GetAttribute("X1"));
                line.P1.Y = Convert.ToInt32(xe.GetAttribute("Y1"));
                line.P2.X = Convert.ToInt32(xe.GetAttribute("X2"));
                line.P2.Y = Convert.ToInt32(xe.GetAttribute("Y2"));
                line.MyPen.Color = ColorTranslator.FromHtml(xe.GetAttribute("PenColor"));
                line.MyPen.Width = Convert.ToInt32(xe.GetAttribute("PenWidth"));
                ListXMLShapes.Add(line);
            }
            //箭头
            xml_arrows = xmlDoc.SelectSingleNode("/pr/cameras/camera/arrows").ChildNodes;
            foreach (XmlNode arrowitem in xml_arrows)
            {

                MyArrow arrow = new MyArrow();
                arrow.MyPen = new Pen(Color.Red, 1);
                XmlElement xa = (XmlElement)arrowitem;
                arrow.P1.X = Convert.ToInt32(xa.GetAttribute("X1"));
                arrow.P1.Y = Convert.ToInt32(xa.GetAttribute("Y1"));
                arrow.P2.X = Convert.ToInt32(xa.GetAttribute("X2"));
                arrow.P2.Y = Convert.ToInt32(xa.GetAttribute("Y2"));
                arrow.MyPen.Color = ColorTranslator.FromHtml(xa.GetAttribute("PenColor"));
                arrow.MyPen.Width = Convert.ToInt32(xa.GetAttribute("PenWidth"));
                ListXMLShapes.Add(arrow);
            }
            //矩形
            xml_rects = xmlDoc.SelectSingleNode("/pr/cameras/camera/rects").ChildNodes;
            foreach (XmlNode rectitem in xml_rects)
            {

                MyRect rect = new MyRect();
                rect.MyPen = new Pen(Color.Red, 1);
                XmlElement xr = (XmlElement)rectitem;
                rect.P1.X = Convert.ToInt32(xr.GetAttribute("X"));
                rect.P1.Y = Convert.ToInt32(xr.GetAttribute("Y"));
                rect.Width = Convert.ToInt32(xr.GetAttribute("W"));
                rect.Height = Convert.ToInt32(xr.GetAttribute("H"));
                rect.MyPen.Color = ColorTranslator.FromHtml(xr.GetAttribute("PenColor"));
                rect.MyPen.Width = Convert.ToInt32(xr.GetAttribute("PenWidth"));
                ListXMLShapes.Add(rect);
            }
            //多边形
            xml_regions = xmlDoc.SelectSingleNode("/pr/cameras/camera/regions").ChildNodes;
            foreach (XmlNode regionitem in xml_regions)
            {
                
                MyPoly poly = new MyPoly();
                poly.MyPen = new Pen(Color.Red, 1);
                XmlElement xp = (XmlElement)regionitem;
                poly.MyPen.Color = ColorTranslator.FromHtml(xp.GetAttribute("PenColor"));
                poly.MyPen.Width = Convert.ToInt32(xp.GetAttribute("PenWidth"));
                XmlNodeList pointlist = regionitem.ChildNodes;
                foreach (XmlNode pitem in pointlist)
                {
                    Point p=new Point();
                    XmlElement test = (XmlElement)pitem;
                    p.X = Convert.ToInt32(test.GetAttribute("X"));
                    p.Y = Convert.ToInt32(test.GetAttribute("Y"));
                    poly.ListPoint.Add(p);
                }
                //IsFinished=true
                poly.IsFinished =true;
                ListXMLShapes.Add(poly);
            }
        }
        public void mytest(object sender, ItemClickEventArgs e)
        {
            readxml();
            DrawingShapes(ListXMLShapes);
        }

        private void mytest()
        {
        
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
