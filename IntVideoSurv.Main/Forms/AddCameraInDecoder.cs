﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IntVideoSurv.Business;
using IntVideoSurv.Entity;
namespace CameraViewer.Forms
{
    public partial class AddCameraInDecoder : DevExpress.XtraEditors.XtraForm
    {
        private string errMessage = "";
        Dictionary<int, CameraInfo> addCamera;
        Dictionary<int, GroupInfo> _listGroup = null;
        public AddCameraInDecoder()
        {
            InitializeComponent();
            LoadCameraInfo();
            
        }
        public int DecoderID { set; get; }
        public int RecognizerID{ set; get;}
        public CameraViewer.Util.OptionSelect Opt1
        {
            set;
            get;
        }
        public void LoadCameraInfo()
        {
            //DecoderInfo decoder = DecoderBusiness.Instance.GetDecoderInfoByDecoderId(ref errMessage, DecoderID);
            //labelControl1.Text = "给" + decoder.Name + "添加摄像头";
            treeList1DecoderCamera.Nodes.Clear();
            _listGroup = GroupBusiness.Instance.GetAllGroupInfos(ref errMessage);
            foreach (KeyValuePair<int, GroupInfo> item in _listGroup)
            {
                TreeListNode treeListNodeGroup = treeList1DecoderCamera.AppendNode(new[] { item.Value.Name, item.Key + ";G" }, -1, 0, 3, 1, CheckState.Checked);
                treeListNodeGroup.Tag = item.Key.ToString() + ";G";
                foreach (var vDevice in item.Value.ListDevice)
                {
                    TreeListNode treeListNodeDevice = treeList1DecoderCamera.AppendNode(new[] { vDevice.Value.Name, vDevice.Key + ";D" }, treeListNodeGroup.Id, 1, 3, 1, CheckState.Checked);
                    treeListNodeDevice.Tag = vDevice.Key.ToString() + ";D";
                    foreach (var vCamera in vDevice.Value.ListCamera)
                    {
                        TreeListNode treeListNodeCamera = treeList1DecoderCamera.AppendNode(new[] { vCamera.Value.Name, vCamera.Key + ";C" }, treeListNodeDevice.Id, 1, 3, 1, CheckState.Checked);
                        treeListNodeCamera.Tag = vCamera.Key.ToString() + ";C";

                    }

                }
            }
            treeList1DecoderCamera.Columns[1].Visible = false;
            treeList1DecoderCamera.ExpandAll();

        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void simpleButton1AddCamera_Click(object sender, EventArgs e)
        {
            int cameraid;
            cameraid = int.Parse(treeList1DecoderCamera.FocusedNode.Tag.ToString().Split(';')[0]);
            switch(Opt1)
            {

                case Util.OptionSelect.Decoder:
                    int id= DecoderBusiness.Instance.InsertCamera(ref errMessage, DecoderID, cameraid);
                    if (-1==id)
                    {
                        XtraMessageBox.Show("对不起，您添加的摄像头已经被其他的解码器使用，请另选");
                    }
                    else
                    {
                        OperateLog ol = new OperateLog
                        {
                            HappenTime = DateTime.Now,
                            OperateTypeId = (int)(OperateLogTypeId.CameraAddInDecoder),
                            OperateTypeName = OperateLogTypeName.CameraAddInDecoder,
                            Content = id.ToString(),
                            OperateUserName = MainForm.CurrentUser.UserName,
                            ClientUserName = MainForm.CurrentUser.UserName,
                            ClientUserId = MainForm.CurrentUser.UserId
                        };
                        OperateLogBusiness.Instance.Insert(ref errMessage, ol);                
                    }
                    break;
                case Util.OptionSelect.Recognizer:
                    int recognizerid = RecognizerBusiness.Instance.InsertCamera(ref errMessage, RecognizerID, cameraid);
                    if (-1 == recognizerid)
                    {
                        XtraMessageBox.Show("对不起，您添加的摄像头已经被其他的识别器使用，请另选");
                    }
                    else
                    {
                        OperateLog ol = new OperateLog
                        {
                            HappenTime = DateTime.Now,
                            OperateTypeId = (int)(OperateLogTypeId.CameraAddInRecognizer),
                            OperateTypeName = OperateLogTypeName.CameraAddInRecognizer,
                            Content = recognizerid.ToString(),
                            OperateUserName = MainForm.CurrentUser.UserName,
                            ClientUserName = MainForm.CurrentUser.UserName,
                            ClientUserId = MainForm.CurrentUser.UserId
                        };
                        OperateLogBusiness.Instance.Insert(ref errMessage, ol);
                    }
                    break;
            }
            Close();
            Dispose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}