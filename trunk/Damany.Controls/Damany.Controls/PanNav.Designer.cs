namespace Damany.Controls
{
    partial class PanNav
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
            this.components = new System.ComponentModel.Container();
            this.btnDefaultPos = new DevExpress.XtraEditors.SimpleButton();
            this.up = new DevExpress.XtraEditors.SimpleButton();
            this.leftUp = new DevExpress.XtraEditors.SimpleButton();
            this.rightUp = new DevExpress.XtraEditors.SimpleButton();
            this.left = new DevExpress.XtraEditors.SimpleButton();
            this.center = new DevExpress.XtraEditors.SimpleButton();
            this.right = new DevExpress.XtraEditors.SimpleButton();
            this.leftDown = new DevExpress.XtraEditors.SimpleButton();
            this.Down = new DevExpress.XtraEditors.SimpleButton();
            this.Rightdown = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnDefaultPos
            // 
            this.btnDefaultPos.Location = new System.Drawing.Point(6, 128);
            this.btnDefaultPos.LookAndFeel.SkinName = "Black";
            this.btnDefaultPos.Name = "btnDefaultPos";
            this.btnDefaultPos.Size = new System.Drawing.Size(150, 25);
            this.btnDefaultPos.TabIndex = 5;
            this.btnDefaultPos.Text = "设置预设位置";
            // 
            // up
            // 
            this.up.Image = global::Damany.Controls.Properties.Resources.Up;
            this.up.Location = new System.Drawing.Point(61, 2);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(44, 36);
            this.up.TabIndex = 4;
            this.up.Text = "聚焦-";
            this.up.ToolTip = "云台向上";
            // 
            // leftUp
            // 
            this.leftUp.Image = global::Damany.Controls.Properties.Resources.LeftUp;
            this.leftUp.Location = new System.Drawing.Point(6, 2);
            this.leftUp.Name = "leftUp";
            this.leftUp.Size = new System.Drawing.Size(48, 36);
            this.leftUp.TabIndex = 3;
            this.leftUp.Text = "聚焦+";
            this.leftUp.ToolTip = "左上";
            // 
            // rightUp
            // 
            this.rightUp.Image = global::Damany.Controls.Properties.Resources.RightUp;
            this.rightUp.Location = new System.Drawing.Point(112, 2);
            this.rightUp.Name = "rightUp";
            this.rightUp.Size = new System.Drawing.Size(44, 36);
            this.rightUp.TabIndex = 4;
            this.rightUp.Text = "云台右上位置移动";
            // 
            // left
            // 
            this.left.Image = global::Damany.Controls.Properties.Resources.left;
            this.left.Location = new System.Drawing.Point(6, 44);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(48, 36);
            this.left.TabIndex = 3;
            this.left.Text = "聚焦+";
            this.left.ToolTip = "云台向左移动";
            // 
            // center
            // 
            this.center.Image = global::Damany.Controls.Properties.Resources.Stop;
            this.center.Location = new System.Drawing.Point(61, 44);
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(44, 36);
            this.center.TabIndex = 4;
            this.center.Text = "聚焦-";
            this.center.ToolTip = "返回到预设位置";
            // 
            // right
            // 
            this.right.Image = global::Damany.Controls.Properties.Resources.Right;
            this.right.Location = new System.Drawing.Point(112, 44);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(44, 36);
            this.right.TabIndex = 4;
            this.right.Text = "聚焦-";
            this.right.ToolTip = "云台向右移动";
            // 
            // leftDown
            // 
            this.leftDown.Image = global::Damany.Controls.Properties.Resources.LeftDown;
            this.leftDown.Location = new System.Drawing.Point(6, 86);
            this.leftDown.Name = "leftDown";
            this.leftDown.Size = new System.Drawing.Size(48, 36);
            this.leftDown.TabIndex = 3;
            this.leftDown.Text = "聚焦+";
            this.leftDown.ToolTip = "云台左下移动";
            // 
            // Down
            // 
            this.Down.Image = global::Damany.Controls.Properties.Resources.Down;
            this.Down.Location = new System.Drawing.Point(61, 86);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(44, 36);
            this.Down.TabIndex = 4;
            this.Down.Text = "云台向下移动";
            // 
            // Rightdown
            // 
            this.Rightdown.Image = global::Damany.Controls.Properties.Resources.RightDown;
            this.Rightdown.Location = new System.Drawing.Point(112, 86);
            this.Rightdown.Name = "Rightdown";
            this.Rightdown.Size = new System.Drawing.Size(44, 36);
            this.Rightdown.TabIndex = 4;
            this.Rightdown.Text = "云台右下移动";
            // 
            // PanNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDefaultPos);
            this.Controls.Add(this.Rightdown);
            this.Controls.Add(this.right);
            this.Controls.Add(this.rightUp);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.leftDown);
            this.Controls.Add(this.center);
            this.Controls.Add(this.left);
            this.Controls.Add(this.up);
            this.Controls.Add(this.leftUp);
            this.Name = "PanNav";
            this.Size = new System.Drawing.Size(169, 162);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnDefaultPos;
        public DevExpress.XtraEditors.SimpleButton up;
        public DevExpress.XtraEditors.SimpleButton leftUp;
        public DevExpress.XtraEditors.SimpleButton rightUp;
        public DevExpress.XtraEditors.SimpleButton left;
        public DevExpress.XtraEditors.SimpleButton center;
        public DevExpress.XtraEditors.SimpleButton right;
        public DevExpress.XtraEditors.SimpleButton leftDown;
        public DevExpress.XtraEditors.SimpleButton Down;
        public DevExpress.XtraEditors.SimpleButton Rightdown;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
