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
    public class AnalysisXML
    {
        public XmlDocument xmlDoc = new XmlDocument();
        private static AnalysisXML instance;
        private List<CapturePicture> list_cap = new List<CapturePicture>();
        private List<Vehicle> list_veh = new List<Vehicle>();
        private List<Face> list_face = new List<Face>();
        private List<REct> list_rect = new List<REct>();
        private List<Track> list_track = new List<Track>();
        string errMessage = "";

        public static AnalysisXML Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnalysisXML();
                }
                return instance;
            }
        }
        public void AnalysisFile()
        {
            int pictureId;
            int rectId;
            int vehicleId;
            int trackId;
            int faceId;
            xmlDoc.Load(@"c:\1.0.xml");
            XmlNodeList xml_vehicles,xml_camera,xml_vehicles_tract_rects,xml_faces;

            xml_camera = xmlDoc.SelectSingleNode("/pr/cameras").ChildNodes;
            foreach (XmlNode camitem in xml_camera)
            {

                XmlElement xcam=(XmlElement)camitem;
                CapturePicture ocap=new CapturePicture();
                ocap.CameraID = Convert.ToInt32(xcam.GetAttribute("id"));
                XmlNode xml_time = xmlDoc.SelectSingleNode("/pr/cameras/camera/timeid");
                ocap.Datetime = Convert.ToDateTime(xml_time.InnerText);
                ocap.FilePath="xml/xinxi";
                pictureId = AnalysisXMLBusiness.Instance.InsertCapturePicture(ref errMessage, ocap);
                
                xml_vehicles=xmlDoc.SelectSingleNode("/pr/cameras/camera/objects/vehicles").ChildNodes;
                foreach (XmlNode veh_item in xml_vehicles)
                {
                    XmlNode xml_vehicles_rect = xmlDoc.SelectSingleNode("/pr/cameras/camera/objects/vehicles/vehicle/rect");
                    XmlElement xml_vehicles_rect1 = (XmlElement)xml_vehicles_rect;
                    REct rect1 = new REct();
                    rect1.X = Convert.ToInt32(xml_vehicles_rect1.GetAttribute("x"));
                    rect1.Y = Convert.ToInt32(xml_vehicles_rect1.GetAttribute("y"));
                    rect1.W = Convert.ToInt32(xml_vehicles_rect1.GetAttribute("w"));
                    rect1.H = Convert.ToInt32(xml_vehicles_rect1.GetAttribute("h"));
                    rectId = AnalysisXMLBusiness.Instance.InsertREct(ref errMessage, rect1);

                    Vehicle oveh=new Vehicle();
                    XmlElement xveh=(XmlElement)veh_item;
                    oveh.VehicleID=Convert.ToInt32(xveh.GetAttribute("id"));
                    oveh.platenumber=Convert.ToString(xveh.GetAttribute("platenumber"));
                    oveh.speed=Convert.ToSingle(xveh.GetAttribute("speed"));
                    if (Convert.ToInt32(xveh.GetAttribute("stemagainst"))==1)
                    {
                        oveh.stemagainst = true;
                    } 
                    else
                    {
                        oveh.stemagainst = false;
                    }
                    if (Convert.ToInt32(xveh.GetAttribute("accident")) == 1)
                    {
                        oveh.accident = true;
                    } 
                    else
                    {
                        oveh.accident = false;
                    }
                    if (Convert.ToInt32(xveh.GetAttribute("stop")) == 1)
                    {
                        oveh.stop = true;
                    } 
                    else
                    {
                        oveh.stop = false;
                    }
                    if (Convert.ToInt32(xveh.GetAttribute("linechange")) == 1)
                    {
                        oveh.linechange = true;
                    } 
                    else
                    {
                        oveh.linechange = false;
                    }
                    oveh.platecolor=Convert.ToString(xveh.GetAttribute("platecolor"));
                    oveh.vehiclecolor=Convert.ToString(xveh.GetAttribute("vehiclecolor"));
                    oveh.PictureID = pictureId;
                    oveh.REctId = rectId;
                    vehicleId = AnalysisXMLBusiness.Instance.InsertVehicle(ref errMessage, oveh);

                    xml_vehicles_tract_rects = xmlDoc.SelectSingleNode("/pr/cameras/camera/objects/vehicles/vehicle/track").ChildNodes;
                    foreach (XmlNode xml_vehicles_tract_rects_item in xml_vehicles_tract_rects)
                    {
                        REct rect2 = new REct();
                        XmlElement xml_vehicles_tract_rects_item1 = (XmlElement)xml_vehicles_tract_rects_item;
                        rect2.X = Convert.ToInt32(xml_vehicles_tract_rects_item1.GetAttribute("x"));
                        rect2.Y = Convert.ToInt32(xml_vehicles_tract_rects_item1.GetAttribute("y"));
                        rect2.W = Convert.ToInt32(xml_vehicles_tract_rects_item1.GetAttribute("w"));
                        rect2.H = Convert.ToInt32(xml_vehicles_tract_rects_item1.GetAttribute("h"));
                        rectId = AnalysisXMLBusiness.Instance.InsertREct(ref errMessage, rect2);
                    }
                    Track track = new Track();
                    track.REct = rectId;
                    trackId = AnalysisXMLBusiness.Instance.InsertTrack(ref errMessage, track);

                }
                xml_faces = xmlDoc.SelectSingleNode("/pr/cameras/camera/objects/faces").ChildNodes;
                foreach (XmlNode xml_faces_item in xml_faces)
                {
                    //XmlElement xml_faces_item1 = (XmlElement)xml_faces_item;
                    XmlNode xml_faces_item_rect = xmlDoc.SelectSingleNode("/pr/cameras/camera/objects/faces/face/rect");
                    XmlElement xml_faces_item_rect1 = (XmlElement)xml_faces_item_rect;
                    REct rect3 = new REct();
                    rect3.X = Convert.ToInt32(xml_faces_item_rect1.GetAttribute("x"));
                    rect3.Y = Convert.ToInt32(xml_faces_item_rect1.GetAttribute("y"));
                    rect3.W = Convert.ToInt32(xml_faces_item_rect1.GetAttribute("w"));
                    rect3.H = Convert.ToInt32(xml_faces_item_rect1.GetAttribute("h"));
                    rectId = AnalysisXMLBusiness.Instance.InsertREct(ref errMessage, rect3);
                    XmlNode xml_faces_item_score = xmlDoc.SelectSingleNode("/pr/cameras/camera/objects/faces/face/score");
                    Face face = new Face();
                    face.RectID = rectId;
                    face.PictureID = pictureId;
                    face.score = Convert.ToSingle(xml_faces_item_score.InnerText);
                    faceId = AnalysisXMLBusiness.Instance.InsertFace(ref errMessage, face);
                    
                }

            }


        }

    }
}
