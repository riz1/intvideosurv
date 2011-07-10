namespace CameraViewer.Forms
{
    partial class AddDirection
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditbh = new DevExpress.XtraEditors.TextEdit();
            this.textEditmc = new DevExpress.XtraEditors.TextEdit();
            this.textEditjc = new DevExpress.XtraEditors.TextEdit();
            this.textEditfbh = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditbh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditjc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditfbh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "卡口编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "卡口名称：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "卡口简称：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 115);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "卡口父编号：";
            // 
            // textEditbh
            // 
            this.textEditbh.Location = new System.Drawing.Point(98, 16);
            this.textEditbh.Name = "textEditbh";
            this.textEditbh.Size = new System.Drawing.Size(89, 21);
            this.textEditbh.TabIndex = 1;
            // 
            // textEditmc
            // 
            this.textEditmc.Location = new System.Drawing.Point(98, 46);
            this.textEditmc.Name = "textEditmc";
            this.textEditmc.Size = new System.Drawing.Size(89, 21);
            this.textEditmc.TabIndex = 1;
            // 
            // textEditjc
            // 
            this.textEditjc.Location = new System.Drawing.Point(98, 79);
            this.textEditjc.Name = "textEditjc";
            this.textEditjc.Size = new System.Drawing.Size(89, 21);
            this.textEditjc.TabIndex = 1;
            // 
            // textEditfbh
            // 
            this.textEditfbh.Location = new System.Drawing.Point(98, 112);
            this.textEditfbh.Name = "textEditfbh";
            this.textEditfbh.Size = new System.Drawing.Size(89, 21);
            this.textEditfbh.TabIndex = 1;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(26, 158);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(66, 28);
            this.simpleButtonOK.TabIndex = 2;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // simpleButtonCancle
            // 
            this.simpleButtonCancle.Location = new System.Drawing.Point(133, 158);
            this.simpleButtonCancle.Name = "simpleButtonCancle";
            this.simpleButtonCancle.Size = new System.Drawing.Size(66, 28);
            this.simpleButtonCancle.TabIndex = 2;
            this.simpleButtonCancle.Text = "取消";
            this.simpleButtonCancle.Click += new System.EventHandler(this.simpleButtonCancle_Click);
            // 
            // AddDirection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 210);
            this.Controls.Add(this.simpleButtonCancle);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.textEditfbh);
            this.Controls.Add(this.textEditjc);
            this.Controls.Add(this.textEditmc);
            this.Controls.Add(this.textEditbh);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "AddDirection";
            this.Text = "添加方向";
            ((System.ComponentModel.ISupportInitialize)(this.textEditbh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditjc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditfbh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditbh;
        private DevExpress.XtraEditors.TextEdit textEditmc;
        private DevExpress.XtraEditors.TextEdit textEditjc;
        private DevExpress.XtraEditors.TextEdit textEditfbh;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancle;
    }
}