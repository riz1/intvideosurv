namespace CameraViewer.Forms
{
    partial class frmLogout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogout));
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbOK
            // 
            this.sbOK.Location = new System.Drawing.Point(43, 86);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(75, 23);
            this.sbOK.TabIndex = 0;
            this.sbOK.Text = "确定(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new System.Drawing.Point(158, 86);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(75, 23);
            this.sbCancel.TabIndex = 0;
            this.sbCancel.Text = "取消(&C)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(43, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "请输入密码:";
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(113, 30);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(109, 21);
            this.tePassword.TabIndex = 2;
            // 
            // frmLogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 134);
            this.Controls.Add(this.tePassword);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户退出";
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tePassword;
    }
}