using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CameraViewer.Forms
{
    public partial class frmEventSetting : XtraForm
    {
        public int DrawTrack;
        public int DrawObjs;
        public int DrawDirection;
        public int DrawROI;
        public int flagObjCount;
        public int flagDirection;
        public int flagCrossLine;
        public int flagChangeChannel;
        public int flagCongestion;
        public int Minarea;
        public int iMaxObjNum;
        public int flagStop;

        public frmEventSetting()
        {
            InitializeComponent();
            DrawTrack = 0;
            DrawObjs = 0;
            DrawDirection = 0;
            DrawROI = 0;
            flagObjCount = 0;
            flagDirection = 0;
            flagCrossLine = 0;
            flagChangeChannel = 0;
            flagCongestion = 0;
            flagStop = 0;
            Minarea = 10;
            iMaxObjNum = 10;
            textBoxMinarea.Text = "10";
            textBoxiMaxObjNum.Text = "10";
        }

        private void wizardControl1_Click(object sender, EventArgs e)
        {

        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (checkEditDrawTrack.Checked)
            {
                DrawTrack = 1;
            }
            else
            {
                DrawTrack = 0;
            }
            if (checkEditDrawObjs.Checked)
            {
                DrawObjs = 1;
            }
            else
            {
                DrawObjs = 0;
            }
            if (checkEditDrawDirection.Checked)
            {
                DrawDirection = 1;
            }
            else
            {
                DrawDirection = 0;
            }
            if (checkEditDrawROI.Checked)
            {
                DrawROI = 1;
             }
            else
            {
                DrawROI = 0;
            }
            if (checkEditflagObjCount.Checked)
            {
                flagObjCount = 1;
            }
            else
            {
                flagObjCount = 0;
            }
            if (checkEditflagDirection.Checked)
            {
                flagDirection = 1;
            }
            else
            {
                flagDirection = 0;
            }
            if (checkEditflagCrossLine.Checked)
            {
                flagCrossLine = 1;
            }
            else
            {
                flagCrossLine = 0;
            }
            if (checkEditflagChangeChannel.Checked)
            {
                flagChangeChannel = 1;
            }
            else
            {
                flagChangeChannel = 0;
            }
            if (checkEditflagCongestion.Checked)
            {
                flagCongestion = 1;
            }
            else
            {
                flagCongestion = 0;
            }
            if (checkEditflagStop.Checked)
            {
                flagStop = 1;
            }
            else
            {
                flagStop = 0;
            }
            Minarea = int.Parse(textBoxMinarea.Text.ToString());
            iMaxObjNum = int.Parse(textBoxiMaxObjNum.Text.ToString());
            this.Hide();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}