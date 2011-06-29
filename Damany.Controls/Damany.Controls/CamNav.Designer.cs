namespace Damany.Controls
{
    partial class CamNav
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamNav));
            this.btnCWipers = new DevExpress.XtraEditors.SimpleButton();
            this.btnAWipers = new DevExpress.XtraEditors.SimpleButton();
            this.btnCAperture = new DevExpress.XtraEditors.SimpleButton();
            this.btnAHighlghts = new DevExpress.XtraEditors.SimpleButton();
            this.btnAAperture = new DevExpress.XtraEditors.SimpleButton();
            this.btnCHighlghts = new DevExpress.XtraEditors.SimpleButton();
            this.btnAFocus = new DevExpress.XtraEditors.SimpleButton();
            this.btnCFocus = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnCWipers
            // 
            this.btnCWipers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCWipers.BackgroundImage")));
            this.btnCWipers.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCWipers.Location = new System.Drawing.Point(69, 80);
            this.btnCWipers.Name = "btnCWipers";
            this.btnCWipers.Size = new System.Drawing.Size(56, 22);
            this.btnCWipers.TabIndex = 129;
            this.btnCWipers.Text = "雨刷-";
            // 
            // btnAWipers
            // 
            this.btnAWipers.BackgroundImage = global::Damany.Controls.Properties.Resources.titlebg;
            this.btnAWipers.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnAWipers.Location = new System.Drawing.Point(3, 80);
            this.btnAWipers.Name = "btnAWipers";
            this.btnAWipers.Size = new System.Drawing.Size(56, 22);
            this.btnAWipers.TabIndex = 128;
            this.btnAWipers.Text = "雨刷+";
            // 
            // btnCAperture
            // 
            this.btnCAperture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCAperture.BackgroundImage")));
            this.btnCAperture.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCAperture.Location = new System.Drawing.Point(69, 54);
            this.btnCAperture.Name = "btnCAperture";
            this.btnCAperture.Size = new System.Drawing.Size(56, 22);
            this.btnCAperture.TabIndex = 127;
            this.btnCAperture.Text = "光圈-";
            // 
            // btnAHighlghts
            // 
            this.btnAHighlghts.BackgroundImage = global::Damany.Controls.Properties.Resources.titlebg;
            this.btnAHighlghts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnAHighlghts.Location = new System.Drawing.Point(3, 3);
            this.btnAHighlghts.Name = "btnAHighlghts";
            this.btnAHighlghts.Size = new System.Drawing.Size(56, 22);
            this.btnAHighlghts.TabIndex = 120;
            this.btnAHighlghts.Text = "聚焦+";
            // 
            // btnAAperture
            // 
            this.btnAAperture.BackgroundImage = global::Damany.Controls.Properties.Resources.titlebg;
            this.btnAAperture.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnAAperture.Location = new System.Drawing.Point(3, 54);
            this.btnAAperture.Name = "btnAAperture";
            this.btnAAperture.Size = new System.Drawing.Size(56, 22);
            this.btnAAperture.TabIndex = 126;
            this.btnAAperture.Text = "光圈+";
            // 
            // btnCHighlghts
            // 
            this.btnCHighlghts.BackgroundImage = global::Damany.Controls.Properties.Resources.titlebg;
            this.btnCHighlghts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCHighlghts.Location = new System.Drawing.Point(69, 3);
            this.btnCHighlghts.Name = "btnCHighlghts";
            this.btnCHighlghts.Size = new System.Drawing.Size(56, 22);
            this.btnCHighlghts.TabIndex = 121;
            this.btnCHighlghts.Text = "聚焦-";
            // 
            // btnAFocus
            // 
            this.btnAFocus.BackgroundImage = global::Damany.Controls.Properties.Resources.titlebg;
            this.btnAFocus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnAFocus.Location = new System.Drawing.Point(3, 28);
            this.btnAFocus.Name = "btnAFocus";
            this.btnAFocus.Size = new System.Drawing.Size(56, 22);
            this.btnAFocus.TabIndex = 123;
            this.btnAFocus.Text = "对焦+";
            // 
            // btnCFocus
            // 
            this.btnCFocus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCFocus.BackgroundImage")));
            this.btnCFocus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCFocus.Location = new System.Drawing.Point(69, 28);
            this.btnCFocus.Name = "btnCFocus";
            this.btnCFocus.Size = new System.Drawing.Size(56, 23);
            this.btnCFocus.TabIndex = 124;
            this.btnCFocus.Text = "对焦-";
            // 
            // CamNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCWipers);
            this.Controls.Add(this.btnAWipers);
            this.Controls.Add(this.btnCAperture);
            this.Controls.Add(this.btnAHighlghts);
            this.Controls.Add(this.btnAAperture);
            this.Controls.Add(this.btnCHighlghts);
            this.Controls.Add(this.btnAFocus);
            this.Controls.Add(this.btnCFocus);
            this.Name = "CamNav";
            this.Size = new System.Drawing.Size(131, 109);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnAHighlghts;
        public DevExpress.XtraEditors.SimpleButton btnCHighlghts;
        public DevExpress.XtraEditors.SimpleButton btnAFocus;
        public DevExpress.XtraEditors.SimpleButton btnCFocus;
        public DevExpress.XtraEditors.SimpleButton btnAAperture;
        public DevExpress.XtraEditors.SimpleButton btnCAperture;
        public DevExpress.XtraEditors.SimpleButton btnCWipers;
        public DevExpress.XtraEditors.SimpleButton btnAWipers;

    }
}
