
namespace FBTool.App.Views
{
    partial class FBReviewForm
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnOpenContentsFile = new System.Windows.Forms.Button();
            this.cbContentsPath = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFanpagesFile = new System.Windows.Forms.Button();
            this.cbFanpagesPath = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenProfilesFolder = new System.Windows.Forms.Button();
            this.cbProfilesPath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numInHours = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.scheduleStatus = new System.Windows.Forms.Label();
            this.lvSchedule = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.numOfReviews = new System.Windows.Forms.NumericUpDown();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.btnOpenContentsFile);
            this.gbSettings.Controls.Add(this.cbContentsPath);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.btnOpenFanpagesFile);
            this.gbSettings.Controls.Add(this.cbFanpagesPath);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.btnOpenProfilesFolder);
            this.gbSettings.Controls.Add(this.cbProfilesPath);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Location = new System.Drawing.Point(18, 18);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSettings.Size = new System.Drawing.Size(1142, 254);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // btnOpenContentsFile
            // 
            this.btnOpenContentsFile.Location = new System.Drawing.Point(980, 177);
            this.btnOpenContentsFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenContentsFile.Name = "btnOpenContentsFile";
            this.btnOpenContentsFile.Size = new System.Drawing.Size(108, 35);
            this.btnOpenContentsFile.TabIndex = 8;
            this.btnOpenContentsFile.Text = "Open";
            this.btnOpenContentsFile.UseVisualStyleBackColor = true;
            this.btnOpenContentsFile.Click += new System.EventHandler(this.btnOpenContentsFile_Click);
            // 
            // cbContentsPath
            // 
            this.cbContentsPath.FormattingEnabled = true;
            this.cbContentsPath.Items.AddRange(new object[] {
            "C:\\data\\content.txt"});
            this.cbContentsPath.Location = new System.Drawing.Point(159, 180);
            this.cbContentsPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbContentsPath.Name = "cbContentsPath";
            this.cbContentsPath.Size = new System.Drawing.Size(800, 28);
            this.cbContentsPath.TabIndex = 7;
            this.cbContentsPath.SelectedIndexChanged += new System.EventHandler(this.cbContentsPath_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contents";
            // 
            // btnOpenFanpagesFile
            // 
            this.btnOpenFanpagesFile.Location = new System.Drawing.Point(980, 111);
            this.btnOpenFanpagesFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenFanpagesFile.Name = "btnOpenFanpagesFile";
            this.btnOpenFanpagesFile.Size = new System.Drawing.Size(108, 35);
            this.btnOpenFanpagesFile.TabIndex = 5;
            this.btnOpenFanpagesFile.Text = "Open";
            this.btnOpenFanpagesFile.UseVisualStyleBackColor = true;
            this.btnOpenFanpagesFile.Click += new System.EventHandler(this.btnOpenFanpagesFile_Click);
            // 
            // cbFanpagesPath
            // 
            this.cbFanpagesPath.FormattingEnabled = true;
            this.cbFanpagesPath.Items.AddRange(new object[] {
            "C:\\data\\page.txt"});
            this.cbFanpagesPath.Location = new System.Drawing.Point(159, 114);
            this.cbFanpagesPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFanpagesPath.Name = "cbFanpagesPath";
            this.cbFanpagesPath.Size = new System.Drawing.Size(800, 28);
            this.cbFanpagesPath.TabIndex = 4;
            this.cbFanpagesPath.SelectedIndexChanged += new System.EventHandler(this.cbFanpagesPath_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fanpages";
            // 
            // btnOpenProfilesFolder
            // 
            this.btnOpenProfilesFolder.Location = new System.Drawing.Point(980, 43);
            this.btnOpenProfilesFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenProfilesFolder.Name = "btnOpenProfilesFolder";
            this.btnOpenProfilesFolder.Size = new System.Drawing.Size(108, 35);
            this.btnOpenProfilesFolder.TabIndex = 2;
            this.btnOpenProfilesFolder.Text = "Open";
            this.btnOpenProfilesFolder.UseVisualStyleBackColor = true;
            this.btnOpenProfilesFolder.Click += new System.EventHandler(this.btnOpenProfilesFolder_Click);
            // 
            // cbProfilesPath
            // 
            this.cbProfilesPath.FormattingEnabled = true;
            this.cbProfilesPath.Items.AddRange(new object[] {
            "X:\\Freelancer\\FBTool-master\\FBExecution\\Python\\profile\\windows"});
            this.cbProfilesPath.Location = new System.Drawing.Point(159, 47);
            this.cbProfilesPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbProfilesPath.Name = "cbProfilesPath";
            this.cbProfilesPath.Size = new System.Drawing.Size(800, 28);
            this.cbProfilesPath.TabIndex = 1;
            this.cbProfilesPath.SelectedIndexChanged += new System.EventHandler(this.cbProfilesPath_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profiles";
            // 
            // numInHours
            // 
            this.numInHours.Location = new System.Drawing.Point(289, 301);
            this.numInHours.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numInHours.Name = "numInHours";
            this.numInHours.Size = new System.Drawing.Size(79, 26);
            this.numInHours.TabIndex = 2;
            this.numInHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numInHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Location = new System.Drawing.Point(998, 302);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(160, 57);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // scheduleStatus
            // 
            this.scheduleStatus.AutoSize = true;
            this.scheduleStatus.Location = new System.Drawing.Point(14, 854);
            this.scheduleStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scheduleStatus.Name = "scheduleStatus";
            this.scheduleStatus.Size = new System.Drawing.Size(152, 20);
            this.scheduleStatus.TabIndex = 8;
            this.scheduleStatus.Text = "Schedule process ...";
            // 
            // lvSchedule
            // 
            this.lvSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvSchedule.HideSelection = false;
            this.lvSchedule.Location = new System.Drawing.Point(18, 382);
            this.lvSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvSchedule.Name = "lvSchedule";
            this.lvSchedule.Size = new System.Drawing.Size(1140, 462);
            this.lvSchedule.TabIndex = 9;
            this.lvSchedule.UseCompatibleStateImageBehavior = false;
            this.lvSchedule.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Profile";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Username";
            this.columnHeader3.Width = 126;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fanpage";
            this.columnHeader4.Width = 308;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Reviews schedule";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Content";
            this.columnHeader6.Width = 129;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(816, 303);
            this.btnAddSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(161, 57);
            this.btnAddSchedule.TabIndex = 10;
            this.btnAddSchedule.Text = "Add Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "hours";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.Location = new System.Drawing.Point(18, 302);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(157, 24);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Number of reviews";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "/";
            // 
            // numOfReviews
            // 
            this.numOfReviews.Location = new System.Drawing.Point(183, 301);
            this.numOfReviews.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numOfReviews.Name = "numOfReviews";
            this.numOfReviews.Size = new System.Drawing.Size(79, 26);
            this.numOfReviews.TabIndex = 13;
            this.numOfReviews.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FBReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 882);
            this.Controls.Add(this.numOfReviews);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.lvSchedule);
            this.Controls.Add(this.scheduleStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.numInHours);
            this.Controls.Add(this.gbSettings);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FBReviewForm";
            this.Text = "FBReview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBReviewForm_FormClosing);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfReviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Button btnOpenFanpagesFile;
        private System.Windows.Forms.ComboBox cbFanpagesPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenProfilesFolder;
        private System.Windows.Forms.ComboBox cbProfilesPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenContentsFile;
        private System.Windows.Forms.ComboBox cbContentsPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numInHours;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label scheduleStatus;
        private System.Windows.Forms.ListView lvSchedule;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numOfReviews;
    }
}