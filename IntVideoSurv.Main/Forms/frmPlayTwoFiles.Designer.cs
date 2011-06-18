namespace CameraViewer.Forms
{
    partial class frmPlayTwoFiles
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
            this.components = new System.ComponentModel.Container();
            this.panelControlPlay = new DevExpress.XtraEditors.PanelControl();
            this.trackBarProgressing = new System.Windows.Forms.TrackBar();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgressing)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlPlay
            // 
            this.panelControlPlay.Location = new System.Drawing.Point(7, 9);
            this.panelControlPlay.Name = "panelControlPlay";
            this.panelControlPlay.Size = new System.Drawing.Size(673, 369);
            this.panelControlPlay.TabIndex = 0;
            // 
            // trackBarProgressing
            // 
            this.trackBarProgressing.Location = new System.Drawing.Point(7, 395);
            this.trackBarProgressing.Name = "trackBarProgressing";
            this.trackBarProgressing.Size = new System.Drawing.Size(672, 45);
            this.trackBarProgressing.TabIndex = 1;
            this.trackBarProgressing.Scroll += new System.EventHandler(this.trackBarProgressing_Scroll);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(25, 429);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(115, 27);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.Text = "播放";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(164, 429);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(115, 27);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "暂停";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(303, 429);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(115, 27);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // timerPlay
            // 
            this.timerPlay.Enabled = true;
            this.timerPlay.Interval = 25;
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPlayTwoFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 469);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.trackBarProgressing);
            this.Controls.Add(this.panelControlPlay);
            this.Name = "frmPlayTwoFiles";
            this.Text = "frmPlayTwoFiles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlayTwoFiles_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgressing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlPlay;
        private System.Windows.Forms.TrackBar trackBarProgressing;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.Timer timer1;
    }
}