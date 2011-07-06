namespace CameraViewer.Forms
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.gridControlSearch = new DevExpress.XtraGrid.GridControl();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIilegalReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditUser = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.teStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.teEndTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlSearch
            // 
            this.gridControlSearch.Location = new System.Drawing.Point(5, 6);
            this.gridControlSearch.MainView = this.gridView7;
            this.gridControlSearch.Name = "gridControlSearch";
            this.gridControlSearch.Size = new System.Drawing.Size(886, 235);
            this.gridControlSearch.TabIndex = 0;
            this.gridControlSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView7});
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnName,
            this.gridColumnIilegalReason,
            this.gridColumnTime,
            this.gridColumnPosition});
            this.gridView7.GridControl = this.gridControlSearch;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsBehavior.Editable = false;
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "编号";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "用户名";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            // 
            // gridColumnIilegalReason
            // 
            this.gridColumnIilegalReason.Caption = "抓拍违法行为";
            this.gridColumnIilegalReason.Name = "gridColumnIilegalReason";
            this.gridColumnIilegalReason.Visible = true;
            this.gridColumnIilegalReason.VisibleIndex = 2;
            // 
            // gridColumnTime
            // 
            this.gridColumnTime.Caption = "时间";
            this.gridColumnTime.Name = "gridColumnTime";
            this.gridColumnTime.Visible = true;
            this.gridColumnTime.VisibleIndex = 3;
            // 
            // gridColumnPosition
            // 
            this.gridColumnPosition.Caption = "地点";
            this.gridColumnPosition.Name = "gridColumnPosition";
            this.gridColumnPosition.Visible = true;
            this.gridColumnPosition.VisibleIndex = 4;
            // 
            // simpleButtonSearch
            // 
            this.simpleButtonSearch.Location = new System.Drawing.Point(690, 255);
            this.simpleButtonSearch.Name = "simpleButtonSearch";
            this.simpleButtonSearch.Size = new System.Drawing.Size(90, 27);
            this.simpleButtonSearch.TabIndex = 52;
            this.simpleButtonSearch.Text = "查询";
            this.simpleButtonSearch.Click += new System.EventHandler(this.simpleButtonSearch_Click);
            // 
            // comboBoxEditUser
            // 
            this.comboBoxEditUser.Location = new System.Drawing.Point(561, 259);
            this.comboBoxEditUser.Name = "comboBoxEditUser";
            this.comboBoxEditUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditUser.Size = new System.Drawing.Size(95, 21);
            this.comboBoxEditUser.TabIndex = 51;
            // 
            // labelControl8
            // 
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl8.Location = new System.Drawing.Point(74, 261);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 46;
            this.labelControl8.Text = "开始时间：";
            // 
            // labelControl9
            // 
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl9.Location = new System.Drawing.Point(519, 261);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(36, 14);
            this.labelControl9.TabIndex = 48;
            this.labelControl9.Text = "用户：";
            // 
            // labelControl12
            // 
            this.labelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl12.Location = new System.Drawing.Point(309, 261);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(60, 14);
            this.labelControl12.TabIndex = 47;
            this.labelControl12.Text = "结束时间：";
            // 
            // teStartTime
            // 
            this.teStartTime.EditValue = new System.DateTime(2010, 10, 30, 11, 0, 0, 0);
            this.teStartTime.Location = new System.Drawing.Point(140, 258);
            this.teStartTime.Name = "teStartTime";
            this.teStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartTime.Properties.Mask.EditMask = "G";
            this.teStartTime.Size = new System.Drawing.Size(145, 21);
            this.teStartTime.TabIndex = 49;
            // 
            // teEndTime
            // 
            this.teEndTime.EditValue = new System.DateTime(2010, 1, 11, 10, 0, 0, 0);
            this.teEndTime.Location = new System.Drawing.Point(375, 258);
            this.teEndTime.Name = "teEndTime";
            this.teEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndTime.Properties.Mask.EditMask = "G";
            this.teEndTime.Size = new System.Drawing.Size(138, 21);
            this.teEndTime.TabIndex = 50;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 298);
            this.Controls.Add(this.simpleButtonSearch);
            this.Controls.Add(this.comboBoxEditUser);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.teStartTime);
            this.Controls.Add(this.teEndTime);
            this.Controls.Add(this.gridControlSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询窗口";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIilegalReason;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPosition;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSearch;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditUser;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TimeEdit teStartTime;
        private DevExpress.XtraEditors.TimeEdit teEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
    }
}