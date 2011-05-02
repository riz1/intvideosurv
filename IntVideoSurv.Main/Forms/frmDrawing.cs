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
using CameraViewer.Forms;

namespace CameraViewer
{
    public partial class frmDrawing : XtraForm
    {
        private int DrawTrack;
        private int DrawObjs;
        private int DrawDirection;
        private int DrawROI;
        private int flagObjCount;
        private int flagDirection;
        private int flagCrossLine;
        private int flagChangeChannel;
        private int flagCongestion;
        private int flagStop;
        private int Minarea;
        private int iMaxObjNum;
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
            //初始化类型选择
            comboBoxEditTypeChoice.Properties.Items.Add("事件");
            comboBoxEditTypeChoice.Properties.Items.Add("人脸");
            comboBoxEditTypeChoice.Properties.Items.Add("车牌");

            //初始化画图按钮
            barButtonLine.Enabled = barButtonRect.Enabled = barButtonArrow.Enabled = barButtonPolygon.Enabled = false;

        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureEdit1.Image = treeList1.FocusedNode.GetValue(0) as Image;
            ListShapes.Clear();
        }
        private void ResetButtonStyle()
        {
            barButtonLine.ButtonStyle =
                barButtonRect.ButtonStyle = barButtonPolygon.ButtonStyle = barButtonArrow.ButtonStyle = BarButtonStyle.Default;
        }
        private void LineButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Line;
            ResetButtonStyle();
            barButtonLine.ButtonStyle = BarButtonStyle.Check;
        }

        private void ButtonRect_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Rect;
            ResetButtonStyle();
            barButtonRect.ButtonStyle = BarButtonStyle.Check;
        }

        private void ButtonJiantou_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Arrow;
            ResetButtonStyle();
            barButtonArrow.ButtonStyle = BarButtonStyle.Check;
        }
        //多边形

        MyPoly currentMyPoly;
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentDrawingType = DrawingType.Polygon;
            ResetButtonStyle();
            barButtonPolygon.ButtonStyle = BarButtonStyle.Check;
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
            XmlDocument drawXml = new XmlDocument();
            XmlNode docNode = drawXml.CreateXmlDeclaration("1.0", "gb2312", null);//head
            drawXml.AppendChild(docNode);
            RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByCameraId(ref errMessage, _cameraId);

            if (ri == null)
            {
                if (XtraMessageBox.Show("对不起，您使用的照片没有对应的识别器，请另选", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }

            }
            XmlNode recognizerNode = drawXml.CreateElement("pr");//pr
            XmlAttribute recognizerAttribute = drawXml.CreateAttribute("id");
            recognizerAttribute.Value = ri.Id.ToString(); //ri.Id.ToString();

            recognizerNode.Attributes.Append(recognizerAttribute);
            drawXml.AppendChild(recognizerNode);
            XmlNode camerasNode = drawXml.CreateElement("cameras");//cameras
            recognizerNode.AppendChild(camerasNode);
            XmlNode cameraNode = drawXml.CreateElement("camera");
            camerasNode.AppendChild(cameraNode);
            XmlAttribute cameraAttribute = drawXml.CreateAttribute("id");
            cameraAttribute.Value = _cameraId.ToString();
            cameraNode.Attributes.Append(cameraAttribute);
            switch (comboBoxEditTypeChoice.SelectedIndex)
            {
                case 0://event
                    //////////////////////////////camera////////////////////////////////////////
                    XmlAttribute cameraWidth = drawXml.CreateAttribute("width");
                    cameraWidth.Value = "200".ToString();
                    cameraNode.Attributes.Append(cameraWidth);
                    XmlAttribute cameraHeight = drawXml.CreateAttribute("height");
                    cameraHeight.Value = "230".ToString();
                    cameraNode.Attributes.Append(cameraHeight);
                    XmlAttribute cameraMinarea = drawXml.CreateAttribute("Minarea");
                    cameraMinarea.Value = Minarea.ToString();
                    cameraNode.Attributes.Append(cameraMinarea);
                    XmlAttribute cameraDrawTrack = drawXml.CreateAttribute("DrawTrack");
                    cameraDrawTrack.Value = DrawTrack.ToString();
                    cameraNode.Attributes.Append(cameraDrawTrack);
                    XmlAttribute cameraDrawObject = drawXml.CreateAttribute("DrawObjs");
                    cameraDrawObject.Value = DrawObjs.ToString();
                    cameraNode.Attributes.Append(cameraDrawObject);
                    XmlAttribute cameraDrawDirection = drawXml.CreateAttribute("DrawDirection");
                    cameraDrawDirection.Value = DrawDirection.ToString();
                    cameraNode.Attributes.Append(cameraDrawDirection);
                    XmlAttribute cameraDrawROI = drawXml.CreateAttribute("DrawROI");
                    cameraDrawROI.Value = DrawROI.ToString();
                    cameraNode.Attributes.Append(cameraDrawROI);
                    XmlAttribute cameraFlagObjCount = drawXml.CreateAttribute("flagObjCount");
                    cameraFlagObjCount.Value = flagObjCount.ToString();
                    cameraNode.Attributes.Append(cameraFlagObjCount);
                    XmlAttribute cameraFlagStop = drawXml.CreateAttribute("flagStop");
                    cameraFlagStop.Value = flagStop.ToString();
                    cameraNode.Attributes.Append(cameraFlagStop);
                    XmlAttribute cameraFlagDirection = drawXml.CreateAttribute("flagDirection");
                    cameraFlagDirection.Value = flagDirection.ToString();
                    cameraNode.Attributes.Append(cameraFlagDirection);
                    XmlAttribute cameraCrossLine = drawXml.CreateAttribute("flagCrossLine");
                    cameraCrossLine.Value = flagCrossLine.ToString();
                    cameraNode.Attributes.Append(cameraCrossLine);
                    XmlAttribute cameraFlagChangeChannel = drawXml.CreateAttribute("flagChangeChannel");
                    cameraFlagChangeChannel.Value = flagChangeChannel.ToString();
                    cameraNode.Attributes.Append(cameraFlagChangeChannel);
                    XmlAttribute cameraFlagConjestion = drawXml.CreateAttribute("flagConjestion");
                    cameraFlagConjestion.Value = flagCongestion.ToString();
                    cameraNode.Attributes.Append(cameraFlagConjestion);
                    XmlAttribute cameraIMaxObjNum = drawXml.CreateAttribute("iMaxObjNum");
                    cameraIMaxObjNum.Value = iMaxObjNum.ToString();
                    cameraNode.Attributes.Append(cameraIMaxObjNum);
                    //////////////////////////////////count/////////////////////////////////////
                    XmlNode cooutInfo = drawXml.CreateElement("Count");
                    cameraNode.AppendChild(cooutInfo);
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
                                cooutInfo.AppendChild(line);
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
                            }
                            else if (v is MyArrow)
                            {
                                XmlNode arrow = drawXml.CreateElement("arrow");
                                cooutInfo.AppendChild(arrow);
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
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    //////////////////////////////////Dir////////////////////////////////////////
                    XmlNode dirInfo = drawXml.CreateElement("Dir");
                    cameraNode.AppendChild(dirInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyArrow)
                            {
                                XmlNode arrow = drawXml.CreateElement("arrow");
                                dirInfo.AppendChild(arrow);
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
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    ///////////////////////////////////cross///////////////////////////////////////
                    XmlNode crossInfo = drawXml.CreateElement("Cross");
                    cameraNode.AppendChild(crossInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyLine)
                            {
                                XmlNode line = drawXml.CreateElement("line");
                                crossInfo.AppendChild(line);
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
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    /////////////////////////////////changechannel/////////////////////////////////////////
                    XmlNode changeChannelInfo = drawXml.CreateElement("ChangeChannel");
                    cameraNode.AppendChild(changeChannelInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyLine)
                            {
                                XmlNode line = drawXml.CreateElement("line");
                                changeChannelInfo.AppendChild(line);
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
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                    	XtraMessageBox.Show(ex.ToString());
                    }
                    //////////////////////////////////////ROI////////////////////////////////////
                    XmlNode ROIInfo = drawXml.CreateElement("ROI");
                    cameraNode.AppendChild(ROIInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyPoly)
                            {
                                for (i = 0; i < (v as MyPoly).ListPoint.Count; i++)
                                {
                                    XmlNode point = drawXml.CreateElement("point");
                                    ROIInfo.AppendChild(point);
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
                    break;
                case 1://face
                    XmlNode cameraRectsF = drawXml.CreateElement("Rects");
                    cameraNode.AppendChild(cameraRectsF);
                    try
                    {
                        foreach(var v in ListShapes)
                        {
                            if (v is MyRect)
                            {
                                XmlNode rectangle = drawXml.CreateElement("Rect");
                                cameraRectsF.AppendChild(rectangle);
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
                        }
                    }
                    catch (System.Exception ex)
                    {
                    	XtraMessageBox.Show(ex.ToString());
                    }
                    break;
                case 2://vehicle
                    XmlNode cameraRectsV = drawXml.CreateElement("Rects");
                    cameraNode.AppendChild(cameraRectsV);
                    try
                    {
                        foreach(var v in ListShapes)
                        {
                            if (v is MyRect)
                            {
                                XmlNode rectangle = drawXml.CreateElement("Rect");
                                cameraRectsV.AppendChild(rectangle);
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
                        }
                    }
                    catch (System.Exception ex)
                    {
                    	XtraMessageBox.Show(ex.ToString());
                    }
                    break;
                default:
                    break;
            }
            drawXml.Save(@"c:\text.xml");
            SaveXmlWithPenInfo();
        }
        public void SaveXmlWithPenInfo()
        {
            int i;
            XmlDocument drawXml = new XmlDocument();
            XmlNode docNode = drawXml.CreateXmlDeclaration("1.0", "gb2312", null);//head
            drawXml.AppendChild(docNode);
            RecognizerInfo ri = RecognizerBusiness.Instance.GetRecognizerInfoByCameraId(ref errMessage, _cameraId);

            if (ri == null)
            {
                if (XtraMessageBox.Show("对不起，您使用的照片没有对应的识别器，请另选", "提示", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }

            }
            XmlNode recognizerNode = drawXml.CreateElement("pr");//pr
            XmlAttribute recognizerAttribute = drawXml.CreateAttribute("id");
            recognizerAttribute.Value = ri.Id.ToString(); //ri.Id.ToString();
       
            recognizerNode.Attributes.Append(recognizerAttribute);
            drawXml.AppendChild(recognizerNode);
            XmlNode camerasNode = drawXml.CreateElement("cameras");//cameras
            recognizerNode.AppendChild(camerasNode);
            XmlNode cameraNode = drawXml.CreateElement("camera");
            camerasNode.AppendChild(cameraNode);
            XmlAttribute cameraAttribute = drawXml.CreateAttribute("id");
            cameraAttribute.Value = _cameraId.ToString();
            cameraNode.Attributes.Append(cameraAttribute);
            switch (comboBoxEditTypeChoice.SelectedIndex)
            {
                case 0://event
                    //////////////////////////////camera////////////////////////////////////////
                    XmlAttribute cameraWidth = drawXml.CreateAttribute("width");
                    cameraWidth.Value = "200".ToString();
                    cameraNode.Attributes.Append(cameraWidth);
                    XmlAttribute cameraHeight = drawXml.CreateAttribute("height");
                    cameraHeight.Value = "230".ToString();
                    cameraNode.Attributes.Append(cameraHeight);
                    XmlAttribute cameraMinarea = drawXml.CreateAttribute("Minarea");
                    cameraMinarea.Value = Minarea.ToString();
                    cameraNode.Attributes.Append(cameraMinarea);
                    XmlAttribute cameraDrawTrack = drawXml.CreateAttribute("DrawTrack");
                    cameraDrawTrack.Value = DrawTrack.ToString();
                    cameraNode.Attributes.Append(cameraDrawTrack);
                    XmlAttribute cameraDrawObject = drawXml.CreateAttribute("DrawObjs");
                    cameraDrawObject.Value = DrawObjs.ToString();
                    cameraNode.Attributes.Append(cameraDrawObject);
                    XmlAttribute cameraDrawDirection = drawXml.CreateAttribute("DrawDirection");
                    cameraDrawDirection.Value = DrawDirection.ToString();
                    cameraNode.Attributes.Append(cameraDrawDirection);
                    XmlAttribute cameraDrawROI = drawXml.CreateAttribute("DrawROI");
                    cameraDrawROI.Value = DrawROI.ToString();
                    cameraNode.Attributes.Append(cameraDrawROI);
                    XmlAttribute cameraFlagObjCount = drawXml.CreateAttribute("flagObjCount");
                    cameraFlagObjCount.Value = flagObjCount.ToString();
                    cameraNode.Attributes.Append(cameraFlagObjCount);
                    XmlAttribute cameraFlagStop = drawXml.CreateAttribute("flagStop");
                    cameraFlagStop.Value = flagStop.ToString();
                    cameraNode.Attributes.Append(cameraFlagStop);
                    XmlAttribute cameraFlagDirection = drawXml.CreateAttribute("flagDirection");
                    cameraFlagDirection.Value = flagDirection.ToString();
                    cameraNode.Attributes.Append(cameraFlagDirection);
                    XmlAttribute cameraCrossLine = drawXml.CreateAttribute("flagCrossLine");
                    cameraCrossLine.Value = flagCrossLine.ToString();
                    cameraNode.Attributes.Append(cameraCrossLine);
                    XmlAttribute cameraFlagChangeChannel = drawXml.CreateAttribute("flagChangeChannel");
                    cameraFlagChangeChannel.Value = flagChangeChannel.ToString();
                    cameraNode.Attributes.Append(cameraFlagChangeChannel);
                    XmlAttribute cameraFlagConjestion = drawXml.CreateAttribute("flagConjestion");
                    cameraFlagConjestion.Value = flagCongestion.ToString();
                    cameraNode.Attributes.Append(cameraFlagConjestion);
                    XmlAttribute cameraIMaxObjNum = drawXml.CreateAttribute("iMaxObjNum");
                    cameraIMaxObjNum.Value = iMaxObjNum.ToString();
                    cameraNode.Attributes.Append(cameraIMaxObjNum);
                    //////////////////////////////////count/////////////////////////////////////
                    XmlNode cooutInfo = drawXml.CreateElement("Count");
                    cameraNode.AppendChild(cooutInfo);
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
                                cooutInfo.AppendChild(line);
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
                                //添加pen的信息
                                XmlAttribute penColor = drawXml.CreateAttribute("PenColor");
                                penColor.Value = ColorTranslator.ToHtml((v as MyLine).MyPen.Color);
                                line.Attributes.Append(penColor);
                                XmlAttribute penWidth = drawXml.CreateAttribute("PenWidth");
                                penWidth.Value = (v as MyLine).MyPen.Width.ToString();
                                line.Attributes.Append(penWidth);
                            }
                            else if (v is MyArrow)
                            {
                                XmlNode arrow = drawXml.CreateElement("arrow");
                                cooutInfo.AppendChild(arrow);
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
                                //添加pen的信息
                                XmlAttribute apenColor = drawXml.CreateAttribute("PenColor");
                                apenColor.Value = ColorTranslator.ToHtml((v as MyArrow).MyPen.Color);
                                arrow.Attributes.Append(apenColor);
                                XmlAttribute apenWidth = drawXml.CreateAttribute("PenWidth");
                                apenWidth.Value = (v as MyArrow).MyPen.Width.ToString();
                                arrow.Attributes.Append(apenWidth);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    //////////////////////////////////Dir////////////////////////////////////////
                    XmlNode dirInfo = drawXml.CreateElement("Dir");
                    cameraNode.AppendChild(dirInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyArrow)
                            {
                                XmlNode arrow = drawXml.CreateElement("arrow");
                                dirInfo.AppendChild(arrow);
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
                                //添加pen的信息
                                XmlAttribute dpenColor = drawXml.CreateAttribute("PenColor");
                                dpenColor.Value = ColorTranslator.ToHtml((v as MyArrow).MyPen.Color);
                                arrow.Attributes.Append(dpenColor);
                                XmlAttribute dpenWidth = drawXml.CreateAttribute("PenWidth");
                                dpenWidth.Value = (v as MyArrow).MyPen.Width.ToString();
                                arrow.Attributes.Append(dpenWidth);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    ///////////////////////////////////cross///////////////////////////////////////
                    XmlNode crossInfo = drawXml.CreateElement("Cross");
                    cameraNode.AppendChild(crossInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyLine)
                            {
                                XmlNode line = drawXml.CreateElement("line");
                                crossInfo.AppendChild(line);
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
                                //添加pen的信息
                                XmlAttribute penColor = drawXml.CreateAttribute("PenColor");
                                penColor.Value = ColorTranslator.ToHtml((v as MyLine).MyPen.Color);
                                line.Attributes.Append(penColor);
                                XmlAttribute penWidth = drawXml.CreateAttribute("PenWidth");
                                penWidth.Value = (v as MyLine).MyPen.Width.ToString();
                                line.Attributes.Append(penWidth);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    /////////////////////////////////changechannel/////////////////////////////////////////
                    XmlNode changeChannelInfo = drawXml.CreateElement("ChangeChannel");
                    cameraNode.AppendChild(changeChannelInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyLine)
                            {
                                XmlNode line = drawXml.CreateElement("line");
                                changeChannelInfo.AppendChild(line);
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
                                //添加pen的信息
                                XmlAttribute penColor = drawXml.CreateAttribute("PenColor");
                                penColor.Value = ColorTranslator.ToHtml((v as MyLine).MyPen.Color);
                                line.Attributes.Append(penColor);
                                XmlAttribute penWidth = drawXml.CreateAttribute("PenWidth");
                                penWidth.Value = (v as MyLine).MyPen.Width.ToString();
                                line.Attributes.Append(penWidth);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    //////////////////////////////////////ROI////////////////////////////////////
                    XmlNode ROIInfo = drawXml.CreateElement("ROI");
                    cameraNode.AppendChild(ROIInfo);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyPoly)
                            {
                                for (i = 0; i < (v as MyPoly).ListPoint.Count; i++)
                                {
                                    XmlNode point = drawXml.CreateElement("point");
                                    ROIInfo.AppendChild(point);
                                    XmlAttribute x = drawXml.CreateAttribute("X");
                                    x.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].X * (float)xScale)).ToString();
                                    point.Attributes.Append(x);
                                    XmlAttribute y = drawXml.CreateAttribute("Y");
                                    y.Value = ((int)((v as MyPoly).ListPoint.ToArray()[i].Y * (float)yScale)).ToString();
                                    point.Attributes.Append(y);
                                    //添加pen的信息
                                    XmlAttribute penColor = drawXml.CreateAttribute("PenColor");
                                    penColor.Value = ColorTranslator.ToHtml((v as MyPoly).MyPen.Color);
                                    point.Attributes.Append(penColor);
                                    XmlAttribute penWidth = drawXml.CreateAttribute("PenWidth");
                                    penWidth.Value = (v as MyPoly).MyPen.Width.ToString();
                                    point.Attributes.Append(penWidth);
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    break;
                case 1://face
                    XmlNode cameraRectsF = drawXml.CreateElement("Rects");
                    cameraNode.AppendChild(cameraRectsF);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyRect)
                            {
                                XmlNode rectangle = drawXml.CreateElement("Rect");
                                cameraRectsF.AppendChild(rectangle);
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
                                //添加pen的信息
                                XmlAttribute penColor = drawXml.CreateAttribute("PenColor");
                                penColor.Value = ColorTranslator.ToHtml((v as MyRect).MyPen.Color);
                                rectangle.Attributes.Append(penColor);
                                XmlAttribute penWidth = drawXml.CreateAttribute("PenWidth");
                                penWidth.Value = (v as MyRect).MyPen.Width.ToString();
                                rectangle.Attributes.Append(penWidth);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    break;
                case 2://vehicle
                    XmlNode cameraRectsV = drawXml.CreateElement("Rects");
                    cameraNode.AppendChild(cameraRectsV);
                    try
                    {
                        foreach (var v in ListShapes)
                        {
                            if (v is MyRect)
                            {
                                XmlNode rectangle = drawXml.CreateElement("Rect");
                                cameraRectsV.AppendChild(rectangle);
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
                                //添加pen的信息
                                XmlAttribute penColor = drawXml.CreateAttribute("PenColor");
                                penColor.Value = ColorTranslator.ToHtml((v as MyRect).MyPen.Color);
                                rectangle.Attributes.Append(penColor);
                                XmlAttribute penWidth = drawXml.CreateAttribute("PenWidth");
                                penWidth.Value = (v as MyRect).MyPen.Width.ToString();
                                rectangle.Attributes.Append(penWidth);
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    break;
                default:
                    break;
            }
            drawXml.Save(@"c:\text2.xml");
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
            /*XmlNodeList xml_CapturePicture,xml_Rect,xml_camera,xml_object,xml_;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"c:\1.0.xml");
            //直线
            xml_camera = xmlDoc.SelectSingleNode("/pr/cameras").ChildNodes;
            foreach (XmlNode camitem in xml_camera)
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
                REct orect = new REct();
                xml_object = camitem.ChildNodes;




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
            }*/
        }
        public void mytest(object sender, ItemClickEventArgs e)
        {
            //readxml();
            //DrawingShapes(ListXMLShapes);
            AnalysisXML.Instance.AnalysisFile();
        }

        private void mytest()
        {
        
        }

        private void comboBoxEditTypeChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEditTypeChoice.Text)
            {
                case "事件"://事件
                    //save xml to Event
                    barButtonArrow.Enabled = true;
                    barButtonLine.Enabled = true;
                    barButtonRect.Enabled = true;
                    barButtonPolygon.Enabled = true;
                    frmEventSetting eventfrm = new frmEventSetting();
                    eventfrm.ShowDialog();
                    DrawTrack = eventfrm.DrawTrack;
                    DrawObjs = eventfrm.DrawObjs;
                    DrawDirection = eventfrm.DrawDirection;
                    barButtonPolygon.Enabled=((DrawROI = eventfrm.DrawROI)==1);
                    flagObjCount = eventfrm.flagObjCount;
                    flagDirection = eventfrm.flagDirection;
                    flagCrossLine = eventfrm.flagCrossLine;
                    flagChangeChannel = eventfrm.flagChangeChannel;
                    flagCongestion = eventfrm.flagCongestion;
                    flagStop = eventfrm.flagStop;
                    Minarea = eventfrm.Minarea;
                    iMaxObjNum = eventfrm.iMaxObjNum;
                    /*if (DrawTrack==0)
                    {

                    }*/
                    eventfrm.Close();
                    break;
                case "人脸"://人脸
                    barButtonLine.Enabled = false;
                    barButtonArrow.Enabled = false;
                    barButtonPolygon.Enabled = false;
                    barButtonRect.Enabled = true;
                    //save xml to Face
                    break;
                case "车牌"://车牌
                    barButtonLine.Enabled = false;
                    barButtonArrow.Enabled = false;
                    barButtonPolygon.Enabled = false;
                    barButtonRect.Enabled = true;
                    //save xml to Vehicle
                    break;
                default:
                    break;
            }

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
