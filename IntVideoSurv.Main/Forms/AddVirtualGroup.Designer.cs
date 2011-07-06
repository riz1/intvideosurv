namespace CameraViewer.Forms
{
    partial class AddVirtualGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVirtualGroup));
            this.textEditVirtualGroup = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonGroupcancle = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonGroupOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVirtualGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditVirtualGroup
            // 
            this.textEditVirtualGroup.EditValue = "";
            this.textEditVirtualGroup.Location = new System.Drawing.Point(92, 13);
            this.textEditVirtualGroup.Name = "textEditVirtualGroup";
            this.textEditVirtualGroup.Size = new System.Drawing.Size(115, 21);
            this.textEditVirtualGroup.TabIndex = 3;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(38, 16);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(48, 14);
            this.labelControl12.TabIndex = 2;
            this.labelControl12.Text = "组名称：";
            // 
            // simpleButtonGroupcancle
            // 
            this.simpleButtonGroupcancle.Location = new System.Drawing.Point(141, 58);
            this.simpleButtonGroupcancle.Name = "simpleButtonGroupcancle";
            this.simpleButtonGroupcancle.Size = new System.Drawing.Size(76, 34);
            this.simpleButtonGroupcancle.TabIndex = 8;
            this.simpleButtonGroupcancle.Text = "取消";
            this.simpleButtonGroupcancle.Click += new System.EventHandler(this.simpleButtonGroupcancle_Click);
            // 
            // simpleButtonGroupOK
            // 
            this.simpleButtonGroupOK.Location = new System.Drawing.Point(24, 58);
            this.simpleButtonGroupOK.Name = "simpleButtonGroupOK";
            this.simpleButtonGroupOK.Size = new System.Drawing.Size(76, 34);
            this.simpleButtonGroupOK.TabIndex = 7;
            this.simpleButtonGroupOK.Text = "确定";
            this.simpleButtonGroupOK.Click += new System.EventHandler(this.simpleButtonGroupOK_Click);
            // 
            // AddVirtualGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 104);
            this.Controls.Add(this.simpleButtonGroupcancle);
            this.Controls.Add(this.simpleButtonGroupOK);
            this.Controls.Add(this.textEditVirtualGroup);
            this.Controls.Add(this.labelControl12);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddVirtualGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加组";
            ((System.ComponentModel.ISupportInitialize)(this.textEditVirtualGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditVirtualGroup;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGroupcancle;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGroupOK;

    }
}