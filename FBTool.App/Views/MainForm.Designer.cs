
namespace FBTool.App.Views
{
    partial class MainForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Path");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "User");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Status");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Process");
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.cbProfiles = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.lvProfiles = new Telerik.WinControls.UI.RadListView();
            this.btnRun = new Telerik.WinControls.UI.RadButton();
            this.radCheckBox2 = new Telerik.WinControls.UI.RadCheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tbContents = new Telerik.WinControls.UI.RadTextBoxControl();
            this.tbPages = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radOpenFileDialog1 = new Telerik.WinControls.UI.RadOpenFileDialog();
            this.radOpenFileDialog2 = new Telerik.WinControls.UI.RadOpenFileDialog();
            this.radOpenFolderDialog1 = new Telerik.WinControls.UI.RadOpenFolderDialog();
            this.profileBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.profileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Location = new System.Drawing.Point(637, 12);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(77, 31);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Choose";
            this.radButton1.ThemeName = "Fluent";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(17, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(43, 18);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Profiles";
            this.radLabel1.ThemeName = "Fluent";
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radCheckBox1.Location = new System.Drawing.Point(17, 508);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(93, 18);
            this.radCheckBox1.TabIndex = 8;
            this.radCheckBox1.Text = "Random Page";
            this.radCheckBox1.ThemeName = "Fluent";
            this.radCheckBox1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // cbProfiles
            // 
            this.cbProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // cbProfiles.NestedRadGridView
            // 
            this.cbProfiles.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cbProfiles.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProfiles.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbProfiles.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cbProfiles.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cbProfiles.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cbProfiles.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cbProfiles.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cbProfiles.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cbProfiles.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.cbProfiles.EditorControl.Name = "NestedRadGridView";
            this.cbProfiles.EditorControl.ReadOnly = true;
            this.cbProfiles.EditorControl.ShowGroupPanel = false;
            this.cbProfiles.EditorControl.Size = new System.Drawing.Size(360, 225);
            this.cbProfiles.EditorControl.TabIndex = 0;
            this.cbProfiles.Location = new System.Drawing.Point(78, 12);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(540, 24);
            this.cbProfiles.TabIndex = 1;
            this.cbProfiles.TabStop = false;
            this.cbProfiles.Text = "C:\\Users\\qhle\\AppData\\Local\\Google\\Chrome\\User Data\\";
            this.cbProfiles.ThemeName = "Fluent";
            // 
            // lvProfiles
            // 
            this.lvProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProfiles.AutoScroll = true;
            this.lvProfiles.AutoSizeColumnsMode = Telerik.WinControls.UI.ListViewAutoSizeColumnsMode.Fill;
            listViewDetailColumn1.HeaderText = "Name";
            listViewDetailColumn1.Width = 33.29471F;
            listViewDetailColumn2.HeaderText = "Path";
            listViewDetailColumn2.Width = 306.1013F;
            listViewDetailColumn3.HeaderText = "User";
            listViewDetailColumn3.Width = 104.0224F;
            listViewDetailColumn4.HeaderText = "Status";
            listViewDetailColumn4.Width = 53.50262F;
            listViewDetailColumn5.HeaderText = "Process";
            listViewDetailColumn5.Width = 202.0789F;
            this.lvProfiles.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3,
            listViewDetailColumn4,
            listViewDetailColumn5});
            this.lvProfiles.GroupItemSize = new System.Drawing.Size(200, 28);
            this.lvProfiles.ItemSize = new System.Drawing.Size(200, 28);
            this.lvProfiles.ItemSpacing = -1;
            this.lvProfiles.Location = new System.Drawing.Point(17, 220);
            this.lvProfiles.MultiSelect = true;
            this.lvProfiles.Name = "lvProfiles";
            this.lvProfiles.ShowCheckBoxes = true;
            this.lvProfiles.Size = new System.Drawing.Size(697, 268);
            this.lvProfiles.TabIndex = 7;
            this.lvProfiles.ThemeName = "Fluent";
            this.lvProfiles.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(590, 523);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(124, 36);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Start";
            this.btnRun.ThemeName = "Fluent";
            this.btnRun.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // radCheckBox2
            // 
            this.radCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radCheckBox2.Location = new System.Drawing.Point(17, 541);
            this.radCheckBox2.Name = "radCheckBox2";
            this.radCheckBox2.Size = new System.Drawing.Size(108, 18);
            this.radCheckBox2.TabIndex = 9;
            this.radCheckBox2.Text = "Random Content";
            this.radCheckBox2.ThemeName = "Fluent";
            this.radCheckBox2.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(57, 573);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown1.TabIndex = 10;
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel4.Location = new System.Drawing.Point(127, 577);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(47, 18);
            this.radLabel4.TabIndex = 10;
            this.radLabel4.Text = "seconds";
            this.radLabel4.ThemeName = "Fluent";
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel5.Location = new System.Drawing.Point(17, 577);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(34, 18);
            this.radLabel5.TabIndex = 11;
            this.radLabel5.Text = "Delay";
            this.radLabel5.ThemeName = "Fluent";
            // 
            // radLabel6
            // 
            this.radLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel6.Location = new System.Drawing.Point(452, 577);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radLabel6.Size = new System.Drawing.Size(264, 18);
            this.radLabel6.TabIndex = 11;
            this.radLabel6.Text = "Reviewing https://www.facebook.com/cavoi.danang";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel6.ThemeName = "Fluent";
            // 
            // radButton3
            // 
            this.radButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton3.Location = new System.Drawing.Point(637, 133);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(82, 30);
            this.radButton3.TabIndex = 6;
            this.radButton3.Text = "Choose";
            this.radButton3.ThemeName = "Fluent";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(17, 133);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(51, 18);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Contents";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel3.ThemeName = "Fluent";
            // 
            // radButton2
            // 
            this.radButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton2.Location = new System.Drawing.Point(637, 52);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(77, 30);
            this.radButton2.TabIndex = 4;
            this.radButton2.Text = "Choose";
            this.radButton2.ThemeName = "Fluent";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(17, 52);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(36, 18);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "Pages";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel2.ThemeName = "Fluent";
            // 
            // tbContents
            // 
            this.tbContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContents.AutoScroll = true;
            this.tbContents.Location = new System.Drawing.Point(78, 133);
            this.tbContents.Multiline = true;
            this.tbContents.Name = "tbContents";
            this.tbContents.Size = new System.Drawing.Size(540, 70);
            this.tbContents.TabIndex = 5;
            this.tbContents.Text = "This is a review test for my page";
            this.tbContents.ThemeName = "Fluent";
            this.tbContents.WordWrap = false;
            // 
            // tbPages
            // 
            this.tbPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPages.Location = new System.Drawing.Point(78, 52);
            this.tbPages.Multiline = true;
            this.tbPages.Name = "tbPages";
            this.tbPages.Size = new System.Drawing.Size(540, 70);
            this.tbPages.TabIndex = 3;
            this.tbPages.Text = "https://www.facebook.com/cavoi.danang";
            this.tbPages.ThemeName = "Fluent";
            // 
            // profileBindingSource1
            // 
            this.profileBindingSource1.DataSource = typeof(FBTool.App.Views.Profile);
            // 
            // profileBindingSource
            // 
            this.profileBindingSource.DataSource = typeof(FBTool.App.Views.Profile);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(731, 601);
            this.Controls.Add(this.tbPages);
            this.Controls.Add(this.tbContents);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radCheckBox2);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lvProfiles);
            this.Controls.Add(this.cbProfiles);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radButton1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Facebook Review";
            this.ThemeName = "Fluent";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cbProfiles;
        private Telerik.WinControls.UI.RadListView lvProfiles;
        private Telerik.WinControls.UI.RadButton btnRun;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBoxControl tbContents;
        private Telerik.WinControls.UI.RadTextBoxControl tbPages;
        private Telerik.WinControls.UI.RadOpenFileDialog radOpenFileDialog1;
        private Telerik.WinControls.UI.RadOpenFileDialog radOpenFileDialog2;
        private Telerik.WinControls.UI.RadOpenFolderDialog radOpenFolderDialog1;
        private System.Windows.Forms.BindingSource profileBindingSource1;
        private System.Windows.Forms.BindingSource profileBindingSource;
    }
}