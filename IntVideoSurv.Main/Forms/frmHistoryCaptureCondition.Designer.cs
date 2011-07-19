namespace CameraViewer.Forms
{
    partial class frmHistoryCaptureCondition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoryCaptureCondition));
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.teStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.teEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.ccbeCameras = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbeCameras.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl11
            // 
            this.labelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl11.Location = new System.Drawing.Point(29, 56);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 14);
            this.labelControl11.TabIndex = 43;
            this.labelControl11.Text = "开始时间：";
            // 
            // labelControl12
            // 
            this.labelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl12.Location = new System.Drawing.Point(29, 94);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(60, 14);
            this.labelControl12.TabIndex = 44;
            this.labelControl12.Text = "结束时间：";
            // 
            // teStartTime
            // 
            this.teStartTime.EditValue = new System.DateTime(2011, 7, 11, 8, 0, 0, 0);
            this.teStartTime.Location = new System.Drawing.Point(108, 53);
            this.teStartTime.Name = "teStartTime";
            this.teStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartTime.Properties.Mask.EditMask = "G";
            this.teStartTime.Size = new System.Drawing.Size(145, 21);
            this.teStartTime.TabIndex = 45;
            // 
            // teEndTime
            // 
            this.teEndTime.EditValue = new System.DateTime(2011, 7, 11, 10, 0, 0, 0);
            this.teEndTime.Location = new System.Drawing.Point(108, 91);
            this.teEndTime.Name = "teEndTime";
            this.teEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndTime.Properties.Mask.EditMask = "G";
            this.teEndTime.Size = new System.Drawing.Size(145, 21);
            this.teEndTime.TabIndex = 46;
            // 
            // ccbeCameras
            // 
            this.ccbeCameras.EditValue = "请选择摄像头";
            this.ccbeCameras.Location = new System.Drawing.Point(108, 14);
            this.ccbeCameras.Name = "ccbeCameras";
            this.ccbeCameras.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbeCameras.Size = new System.Drawing.Size(145, 21);
            this.ccbeCameras.TabIndex = 42;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(29, 17);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(40, 14);
            this.labelControl13.TabIndex = 41;
            this.labelControl13.Text = "摄像头:";
            // 
            // sbOK
            // 
            this.sbOK.Location = new System.Drawing.Point(41, 128);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 23);
            this.sbOK.TabIndex = 47;
            this.sbOK.Text = "确定";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new System.Drawing.Point(164, 128);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 48;
            this.sbCancel.Text = "取消";
            // 
            // frmHistoryCaptureCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 163);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.teStartTime);
            this.Controls.Add(this.teEndTime);
            this.Controls.Add(this.ccbeCameras);
            this.Controls.Add(this.labelControl13);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHistoryCaptureCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "历史视频条件";
            ((System.ComponentModel.ISupportInitialize)(this.teStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbeCameras.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TimeEdit teStartTime;
        private DevExpress.XtraEditors.TimeEdit teEndTime;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbeCameras;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
    }
}