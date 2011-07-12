namespace CameraViewer.Forms
{
    partial class AddCheDao
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTollGateName = new DevExpress.XtraEditors.TextEdit();
            this.textEditTollGateNum = new DevExpress.XtraEditors.TextEdit();
            this.textEditTollGateShorter = new DevExpress.XtraEditors.TextEdit();
            this.textEditVehicleCamera = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEditParentNum = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTollGateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTollGateNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTollGateShorter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVehicleCamera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditParentNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "卡口编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 95);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "卡口名称：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 125);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "卡口简称：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(33, 161);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "车道摄像机：";
            // 
            // textEditTollGateName
            // 
            this.textEditTollGateName.Location = new System.Drawing.Point(104, 92);
            this.textEditTollGateName.Name = "textEditTollGateName";
            this.textEditTollGateName.Size = new System.Drawing.Size(112, 21);
            this.textEditTollGateName.TabIndex = 1;
            // 
            // textEditTollGateNum
            // 
            this.textEditTollGateNum.Location = new System.Drawing.Point(104, 61);
            this.textEditTollGateNum.Name = "textEditTollGateNum";
            this.textEditTollGateNum.Size = new System.Drawing.Size(112, 21);
            this.textEditTollGateNum.TabIndex = 1;
            // 
            // textEditTollGateShorter
            // 
            this.textEditTollGateShorter.Location = new System.Drawing.Point(104, 122);
            this.textEditTollGateShorter.Name = "textEditTollGateShorter";
            this.textEditTollGateShorter.Size = new System.Drawing.Size(112, 21);
            this.textEditTollGateShorter.TabIndex = 1;
            // 
            // textEditVehicleCamera
            // 
            this.textEditVehicleCamera.Location = new System.Drawing.Point(104, 158);
            this.textEditVehicleCamera.Name = "textEditVehicleCamera";
            this.textEditVehicleCamera.Size = new System.Drawing.Size(112, 21);
            this.textEditVehicleCamera.TabIndex = 1;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(133, 198);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(86, 26);
            this.simpleButtonCancel.TabIndex = 2;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(29, 198);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(86, 26);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "确定";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(33, 31);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "卡口父编号：";
            // 
            // textEditParentNum
            // 
            this.textEditParentNum.Location = new System.Drawing.Point(104, 28);
            this.textEditParentNum.Name = "textEditParentNum";
            this.textEditParentNum.Size = new System.Drawing.Size(112, 21);
            this.textEditParentNum.TabIndex = 1;
            // 
            // AddCheDao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 246);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.textEditParentNum);
            this.Controls.Add(this.textEditTollGateNum);
            this.Controls.Add(this.textEditVehicleCamera);
            this.Controls.Add(this.textEditTollGateShorter);
            this.Controls.Add(this.textEditTollGateName);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Name = "AddCheDao";
            this.Text = "添加车道";
            ((System.ComponentModel.ISupportInitialize)(this.textEditTollGateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTollGateNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTollGateShorter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVehicleCamera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditParentNum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEditTollGateName;
        private DevExpress.XtraEditors.TextEdit textEditTollGateNum;
        private DevExpress.XtraEditors.TextEdit textEditTollGateShorter;
        private DevExpress.XtraEditors.TextEdit textEditVehicleCamera;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEditParentNum;
    }
}