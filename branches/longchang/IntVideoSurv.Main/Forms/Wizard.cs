// Camera Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CameraViewer
{
	/// <summary>
	/// Summary description for Wizard.
	/// </summary>
	public class Wizard : System.Windows.Forms.Form
	{
		private string title;
		private int currentPage;
		private Control currentControl = null;

		private System.Windows.Forms.Panel descPannel;
		private System.Windows.Forms.Panel controlPanel;
		private DevExpress.XtraEditors.SimpleButton cancelButton;
		private DevExpress.XtraEditors.SimpleButton finishButton;
		private DevExpress.XtraEditors.SimpleButton nextButton;
		private DevExpress.XtraEditors.SimpleButton backButton;
		private System.Windows.Forms.PictureBox line1;
		private System.Windows.Forms.PictureBox line2;
        private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.PictureBox line3;
		private System.Windows.Forms.Panel workPanel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		// Constructor
		public Wizard()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.descPannel = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.workPanel = new System.Windows.Forms.Panel();
            this.nextButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.line3 = new System.Windows.Forms.PictureBox();
            this.line2 = new System.Windows.Forms.PictureBox();
            this.line1 = new System.Windows.Forms.PictureBox();
            this.finishButton = new DevExpress.XtraEditors.SimpleButton();
            this.backButton = new DevExpress.XtraEditors.SimpleButton();
            this.descPannel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1)).BeginInit();
            this.SuspendLayout();
            // 
            // descPannel
            // 
            this.descPannel.BackColor = System.Drawing.Color.White;
            this.descPannel.Controls.Add(this.descriptionLabel);
            this.descPannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.descPannel.Location = new System.Drawing.Point(0, 0);
            this.descPannel.Name = "descPannel";
            this.descPannel.Size = new System.Drawing.Size(444, 56);
            this.descPannel.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(8, 10);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(424, 40);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Hello";
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.nextButton);
            this.controlPanel.Controls.Add(this.finishButton);
            this.controlPanel.Controls.Add(this.cancelButton);
            this.controlPanel.Controls.Add(this.backButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 270);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(444, 48);
            this.controlPanel.TabIndex = 1;
            // 
            // workPanel
            // 
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(1, 57);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(443, 211);
            this.workPanel.TabIndex = 0;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Image = global::CameraViewer.Properties.Resources.btn;
            this.nextButton.Location = new System.Drawing.Point(178, 16);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "前进";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Image = global::CameraViewer.Properties.Resources.btn;
            this.cancelButton.Location = new System.Drawing.Point(362, 16);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "取消";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // line3
            // 
            this.line3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line3.Dock = System.Windows.Forms.DockStyle.Left;
            this.line3.Location = new System.Drawing.Point(0, 57);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(1, 211);
            this.line3.TabIndex = 5;
            this.line3.TabStop = false;
            // 
            // line2
            // 
            this.line2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line2.Location = new System.Drawing.Point(0, 268);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(444, 2);
            this.line2.TabIndex = 3;
            this.line2.TabStop = false;
            // 
            // line1
            // 
            this.line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 56);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(444, 1);
            this.line1.TabIndex = 2;
            this.line1.TabStop = false;
            // 
            // finishButton
            // 
            this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finishButton.Image = global::CameraViewer.Properties.Resources.btn;
            this.finishButton.Location = new System.Drawing.Point(282, 16);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 3;
            this.finishButton.Text = "完成";
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Image = global::CameraViewer.Properties.Resources.btn;
            this.backButton.Location = new System.Drawing.Point(98, 16);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "后退";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Wizard
            // 
            this.AcceptButton = this.nextButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(444, 318);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.line3);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.descPannel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Wizard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.descPannel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.line3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// Add page
		public void AddPage(IWizardPage page)
		{
			Control ctrl = (Control) page;

			workPanel.Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;
            //this.Height = this.Height + ctrl.Height - workPanel.Height;
            //this.Width = this.Width + ctrl.Width - workPanel.Width;

			page.StateChanged += new EventHandler(page_StateChanged);
			page.Reset += new EventHandler(page_Reset);
		}
		
		// On form load
		private void Wizard_Load(object sender, System.EventArgs e)
		{
			// save original title
			title = this.Text;

			// set current page to the first
			SetCurrentPage(0);
		}

		// Update control buttons state
		private void UpdateControlButtons()
		{
			// "Back" button
			backButton.Enabled = (currentPage != 0);
			// "Next" button
			nextButton.Enabled = ((currentPage < workPanel.Controls.Count - 1) && (currentControl != null) && (((IWizardPage) currentControl).Completed));
			// "Finish" button
			finishButton.Enabled = true;
			foreach (IWizardPage page in workPanel.Controls)
			{
				if (!page.Completed)
				{
					finishButton.Enabled = false;
					break;
				}
			}
		}

		// Set current page
		private void SetCurrentPage(int n)
		{
			OnPageChanging(n);

			// hide previous page
			if (currentControl != null)
			{
				currentControl.Hide();
			}

			//
			currentPage = n;

			// update dialog text
			this.Text = "设备配置精灵" + " - 页 " + ((int)(n + 1)).ToString() + " / " + workPanel.Controls.Count.ToString();

			// show new page
			currentControl = workPanel.Controls[currentPage];
			IWizardPage	page = (IWizardPage) currentControl;
           
           
			currentControl.Show();

			// description
			descriptionLabel.Text = page.PageDescription;

			// notify the page
			page.Display();
            if (n > 0)
            {
                if (page.ControlWidth > 0)
                {
                    workPanel.Width = page.ControlWidth;
                    workPanel.Height = page.ControlHeight;
                    this.Height = controlPanel.Height + workPanel.Height + descPannel.Height;
                    this.Width =  workPanel.Width;
                }

            }

			// update conrol buttons
			UpdateControlButtons();
		}

		// On "Next" button click
		private void nextButton_Click(object sender, System.EventArgs e)
		{
			if (((IWizardPage) currentControl).Apply() == true)
			{
				if (currentPage < workPanel.Controls.Count - 1)
				{
					SetCurrentPage(currentPage + 1);
				}
			}
		}

		// On "Back" button click
		private void backButton_Click(object sender, System.EventArgs e)
		{
			if (currentPage > 0)
			{
				SetCurrentPage(currentPage - 1);
			}
		}

		// On "Finish" button click
		private void finishButton_Click(object sender, System.EventArgs e)
		{
			if (((IWizardPage) currentControl).Apply() == true)
			{
				OnFinish();

				// close the dialog
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		// On page state changed
		private void page_StateChanged(object sender, System.EventArgs e)
		{
			// update conrol buttons
			UpdateControlButtons();
		}

		// Reset on page
		private void page_Reset(object sender, System.EventArgs e)
		{
			OnResetOnPage(workPanel.Controls.GetChildIndex((Control) sender));

			// update conrol buttons
			UpdateControlButtons();
		}

		// Before page changing
		protected virtual void OnPageChanging(int page)
		{
		}

		// Reset event ocuren on page
		protected virtual void OnResetOnPage(int page)
		{
		}

		// On dialog finish
		protected virtual void OnFinish()
		{
		}

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
	}
}
