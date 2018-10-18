namespace epicenterWin
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this._searchPage = new System.Windows.Forms.TabPage();
            this._clearButtonSearch = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.BrowseListBox = new System.Windows.Forms.CheckedListBox();
            this.removeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._searchSelectionText = new System.Windows.Forms.Label();
            this._webCam = new System.Windows.Forms.TabPage();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.consoleLabel = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this.trainingButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.webcamLabel = new System.Windows.Forms.Label();
            this.webcamPictureBox = new System.Windows.Forms.PictureBox();
            this._reportPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._reportCarTab = new System.Windows.Forms.TabPage();
            this._reportCarReasonBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._reportCarLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._reportCarFirstNameTextBox = new System.Windows.Forms.TextBox();
            this._reportCarReportButton = new System.Windows.Forms.Button();
            this._reportCarPlateLabel = new System.Windows.Forms.Label();
            this._reportCarPlateTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonTab = new System.Windows.Forms.TabPage();
            this._reportPersonReasonBox = new System.Windows.Forms.ComboBox();
            this._clearReportPersonButton = new System.Windows.Forms.Button();
            this._reportImagesListbox = new System.Windows.Forms.CheckedListBox();
            this._browseReportImageButton = new System.Windows.Forms.Button();
            this._reportImageTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._reportPersonMissingLabel = new System.Windows.Forms.Label();
            this._reportPersonLastNameTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonReportButton = new System.Windows.Forms.Button();
            this._reportLastNameLabel = new System.Windows.Forms.Label();
            this._reportFirstNameLabel = new System.Windows.Forms.Label();
            this._reportPersonFirstNameTextBox = new System.Windows.Forms.TextBox();
            this._train = new System.Windows.Forms.TabPage();
            this._clearButtonTrain = new System.Windows.Forms.Button();
            this._trainLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._trainFirstNameTextBox = new System.Windows.Forms.TextBox();
            this._trainBrowserButton = new System.Windows.Forms.Button();
            this._trainBrowseButton = new System.Windows.Forms.Button();
            this._trainBrowseTextBox = new System.Windows.Forms.TextBox();
            this._trainCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Tabs.SuspendLayout();
            this._searchPage.SuspendLayout();
            this.removeContextMenu.SuspendLayout();
            this._webCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).BeginInit();
            this._reportPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this._reportCarTab.SuspendLayout();
            this._reportPersonTab.SuspendLayout();
            this._train.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this._searchPage);
            this.Tabs.Controls.Add(this._webCam);
            this.Tabs.Controls.Add(this._reportPage);
            this.Tabs.Controls.Add(this._train);
            this.Tabs.Location = new System.Drawing.Point(7, 0);
            this.Tabs.Margin = new System.Windows.Forms.Padding(2);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(622, 411);
            this.Tabs.TabIndex = 0;
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // _searchPage
            // 
            this._searchPage.Controls.Add(this._clearButtonSearch);
            this._searchPage.Controls.Add(this.CheckButton);
            this._searchPage.Controls.Add(this.BrowseButton);
            this._searchPage.Controls.Add(this.FilePathBox);
            this._searchPage.Controls.Add(this.BrowseListBox);
            this._searchPage.Controls.Add(this._searchSelectionText);
            this._searchPage.Location = new System.Drawing.Point(4, 22);
            this._searchPage.Margin = new System.Windows.Forms.Padding(2);
            this._searchPage.Name = "_searchPage";
            this._searchPage.Padding = new System.Windows.Forms.Padding(2);
            this._searchPage.Size = new System.Drawing.Size(614, 385);
            this._searchPage.TabIndex = 0;
            this._searchPage.Text = "Search";
            this._searchPage.UseVisualStyleBackColor = true;
            // 
            // _clearButtonSearch
            // 
            this._clearButtonSearch.Location = new System.Drawing.Point(6, 310);
            this._clearButtonSearch.Name = "_clearButtonSearch";
            this._clearButtonSearch.Size = new System.Drawing.Size(53, 21);
            this._clearButtonSearch.TabIndex = 28;
            this._clearButtonSearch.Text = "Clear";
            this._clearButtonSearch.UseVisualStyleBackColor = true;
            this._clearButtonSearch.Click += new System.EventHandler(this._clearButtonSearch_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(246, 325);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(2);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(84, 44);
            this.CheckButton.TabIndex = 4;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(544, 22);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(55, 22);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(6, 22);
            this.FilePathBox.Margin = new System.Windows.Forms.Padding(2);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(526, 20);
            this.FilePathBox.TabIndex = 2;
            this.FilePathBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilePathBox_KeyDown);
            // 
            // BrowseListBox
            // 
            this.BrowseListBox.CheckOnClick = true;
            this.BrowseListBox.ContextMenuStrip = this.removeContextMenu;
            this.BrowseListBox.FormattingEnabled = true;
            this.BrowseListBox.Location = new System.Drawing.Point(6, 47);
            this.BrowseListBox.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseListBox.Name = "BrowseListBox";
            this.BrowseListBox.Size = new System.Drawing.Size(606, 259);
            this.BrowseListBox.TabIndex = 1;
            this.BrowseListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseListBox_MouseDown);
            // 
            // removeContextMenu
            // 
            this.removeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.removeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.removeContextMenu.Name = "removeContextMenu";
            this.removeContextMenu.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // _searchSelectionText
            // 
            this._searchSelectionText.AutoSize = true;
            this._searchSelectionText.Location = new System.Drawing.Point(3, 8);
            this._searchSelectionText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._searchSelectionText.Name = "_searchSelectionText";
            this._searchSelectionText.Size = new System.Drawing.Size(223, 13);
            this._searchSelectionText.TabIndex = 0;
            this._searchSelectionText.Text = "Please select a video(s) or photo(s) to analyze";
            // 
            // _webCam
            // 
            this._webCam.Controls.Add(this._lastNameTextBox);
            this._webCam.Controls.Add(this.label6);
            this._webCam.Controls.Add(this.recognizeButton);
            this._webCam.Controls.Add(this.consoleLabel);
            this._webCam.Controls.Add(this.OutputBox);
            this._webCam.Controls.Add(this._firstNameTextBox);
            this._webCam.Controls.Add(this.trainingButton);
            this._webCam.Controls.Add(this.idLabel);
            this._webCam.Controls.Add(this.webcamLabel);
            this._webCam.Controls.Add(this.webcamPictureBox);
            this._webCam.Location = new System.Drawing.Point(4, 22);
            this._webCam.Name = "_webCam";
            this._webCam.Padding = new System.Windows.Forms.Padding(3);
            this._webCam.Size = new System.Drawing.Size(614, 385);
            this._webCam.TabIndex = 3;
            this._webCam.Text = "Webcam";
            this._webCam.UseVisualStyleBackColor = true;
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(476, 75);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._lastNameTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "LastName";
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(485, 342);
            this.recognizeButton.Margin = new System.Windows.Forms.Padding(2);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(99, 26);
            this.recognizeButton.TabIndex = 7;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.RecognizeButton_Click);
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.Location = new System.Drawing.Point(476, 189);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(45, 13);
            this.consoleLabel.TabIndex = 6;
            this.consoleLabel.Text = "Console";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(478, 218);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(100, 96);
            this.OutputBox.TabIndex = 5;
            this.OutputBox.Text = "";
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(476, 26);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._firstNameTextBox.TabIndex = 4;
            // 
            // trainingButton
            // 
            this.trainingButton.Location = new System.Drawing.Point(476, 119);
            this.trainingButton.Name = "trainingButton";
            this.trainingButton.Size = new System.Drawing.Size(95, 30);
            this.trainingButton.TabIndex = 3;
            this.trainingButton.Text = "Start Training";
            this.trainingButton.UseVisualStyleBackColor = true;
            this.trainingButton.Click += new System.EventHandler(this.TrainingButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(476, 8);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(54, 13);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "FirstName";
            // 
            // webcamLabel
            // 
            this.webcamLabel.AutoSize = true;
            this.webcamLabel.Location = new System.Drawing.Point(7, 8);
            this.webcamLabel.Name = "webcamLabel";
            this.webcamLabel.Size = new System.Drawing.Size(50, 13);
            this.webcamLabel.TabIndex = 1;
            this.webcamLabel.Text = "Webcam";
            // 
            // webcamPictureBox
            // 
            this.webcamPictureBox.Location = new System.Drawing.Point(6, 26);
            this.webcamPictureBox.Name = "webcamPictureBox";
            this.webcamPictureBox.Size = new System.Drawing.Size(464, 342);
            this.webcamPictureBox.TabIndex = 0;
            this.webcamPictureBox.TabStop = false;
            // 
            // _reportPage
            // 
            this._reportPage.Controls.Add(this.tabControl1);
            this._reportPage.Location = new System.Drawing.Point(4, 22);
            this._reportPage.Margin = new System.Windows.Forms.Padding(2);
            this._reportPage.Name = "_reportPage";
            this._reportPage.Padding = new System.Windows.Forms.Padding(2);
            this._reportPage.Size = new System.Drawing.Size(614, 385);
            this._reportPage.TabIndex = 1;
            this._reportPage.Text = "Report";
            this._reportPage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._reportCarTab);
            this.tabControl1.Controls.Add(this._reportPersonTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 381);
            this.tabControl1.TabIndex = 0;
            // 
            // _reportCarTab
            // 
            this._reportCarTab.Controls.Add(this._reportCarReasonBox);
            this._reportCarTab.Controls.Add(this.label3);
            this._reportCarTab.Controls.Add(this._reportCarLastNameTextBox);
            this._reportCarTab.Controls.Add(this.label4);
            this._reportCarTab.Controls.Add(this.label5);
            this._reportCarTab.Controls.Add(this._reportCarFirstNameTextBox);
            this._reportCarTab.Controls.Add(this._reportCarReportButton);
            this._reportCarTab.Controls.Add(this._reportCarPlateLabel);
            this._reportCarTab.Controls.Add(this._reportCarPlateTextBox);
            this._reportCarTab.Location = new System.Drawing.Point(4, 22);
            this._reportCarTab.Margin = new System.Windows.Forms.Padding(2);
            this._reportCarTab.Name = "_reportCarTab";
            this._reportCarTab.Padding = new System.Windows.Forms.Padding(2);
            this._reportCarTab.Size = new System.Drawing.Size(602, 355);
            this._reportCarTab.TabIndex = 0;
            this._reportCarTab.Text = "Car";
            this._reportCarTab.UseVisualStyleBackColor = true;
            // 
            // _reportCarReasonBox
            // 
            this._reportCarReasonBox.FormattingEnabled = true;
            this._reportCarReasonBox.Location = new System.Drawing.Point(82, 115);
            this._reportCarReasonBox.Name = "_reportCarReasonBox";
            this._reportCarReasonBox.Size = new System.Drawing.Size(121, 21);
            this._reportCarReasonBox.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Reason";
            // 
            // _reportCarLastNameTextBox
            // 
            this._reportCarLastNameTextBox.Location = new System.Drawing.Point(82, 87);
            this._reportCarLastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._reportCarLastNameTextBox.Name = "_reportCarLastNameTextBox";
            this._reportCarLastNameTextBox.Size = new System.Drawing.Size(191, 20);
            this._reportCarLastNameTextBox.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "First Name";
            // 
            // _reportCarFirstNameTextBox
            // 
            this._reportCarFirstNameTextBox.Location = new System.Drawing.Point(82, 59);
            this._reportCarFirstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._reportCarFirstNameTextBox.Name = "_reportCarFirstNameTextBox";
            this._reportCarFirstNameTextBox.Size = new System.Drawing.Size(191, 20);
            this._reportCarFirstNameTextBox.TabIndex = 19;
            // 
            // _reportCarReportButton
            // 
            this._reportCarReportButton.Location = new System.Drawing.Point(47, 174);
            this._reportCarReportButton.Margin = new System.Windows.Forms.Padding(2);
            this._reportCarReportButton.Name = "_reportCarReportButton";
            this._reportCarReportButton.Size = new System.Drawing.Size(511, 159);
            this._reportCarReportButton.TabIndex = 18;
            this._reportCarReportButton.Text = "Report";
            this._reportCarReportButton.UseVisualStyleBackColor = true;
            this._reportCarReportButton.Click += new System.EventHandler(this._reportCarReportButton_Click);
            // 
            // _reportCarPlateLabel
            // 
            this._reportCarPlateLabel.AutoSize = true;
            this._reportCarPlateLabel.Location = new System.Drawing.Point(4, 25);
            this._reportCarPlateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._reportCarPlateLabel.Name = "_reportCarPlateLabel";
            this._reportCarPlateLabel.Size = new System.Drawing.Size(71, 13);
            this._reportCarPlateLabel.TabIndex = 11;
            this._reportCarPlateLabel.Text = "Plate Number";
            // 
            // _reportCarPlateTextBox
            // 
            this._reportCarPlateTextBox.Location = new System.Drawing.Point(82, 25);
            this._reportCarPlateTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._reportCarPlateTextBox.Name = "_reportCarPlateTextBox";
            this._reportCarPlateTextBox.Size = new System.Drawing.Size(191, 20);
            this._reportCarPlateTextBox.TabIndex = 10;
            // 
            // _reportPersonTab
            // 
            this._reportPersonTab.Controls.Add(this._reportPersonReasonBox);
            this._reportPersonTab.Controls.Add(this._clearReportPersonButton);
            this._reportPersonTab.Controls.Add(this._reportImagesListbox);
            this._reportPersonTab.Controls.Add(this._browseReportImageButton);
            this._reportPersonTab.Controls.Add(this._reportImageTextBox);
            this._reportPersonTab.Controls.Add(this.label10);
            this._reportPersonTab.Controls.Add(this._reportPersonMissingLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonLastNameTextBox);
            this._reportPersonTab.Controls.Add(this._reportPersonReportButton);
            this._reportPersonTab.Controls.Add(this._reportLastNameLabel);
            this._reportPersonTab.Controls.Add(this._reportFirstNameLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonFirstNameTextBox);
            this._reportPersonTab.Location = new System.Drawing.Point(4, 22);
            this._reportPersonTab.Margin = new System.Windows.Forms.Padding(2);
            this._reportPersonTab.Name = "_reportPersonTab";
            this._reportPersonTab.Padding = new System.Windows.Forms.Padding(2);
            this._reportPersonTab.Size = new System.Drawing.Size(602, 355);
            this._reportPersonTab.TabIndex = 1;
            this._reportPersonTab.Text = "Person";
            this._reportPersonTab.UseVisualStyleBackColor = true;
            // 
            // _reportPersonReasonBox
            // 
            this._reportPersonReasonBox.AllowDrop = true;
            this._reportPersonReasonBox.FormattingEnabled = true;
            this._reportPersonReasonBox.Location = new System.Drawing.Point(77, 83);
            this._reportPersonReasonBox.Name = "_reportPersonReasonBox";
            this._reportPersonReasonBox.Size = new System.Drawing.Size(121, 21);
            this._reportPersonReasonBox.TabIndex = 30;
            // 
            // _clearReportPersonButton
            // 
            this._clearReportPersonButton.Location = new System.Drawing.Point(5, 308);
            this._clearReportPersonButton.Name = "_clearReportPersonButton";
            this._clearReportPersonButton.Size = new System.Drawing.Size(53, 21);
            this._clearReportPersonButton.TabIndex = 29;
            this._clearReportPersonButton.Text = "Clear";
            this._clearReportPersonButton.UseVisualStyleBackColor = true;
            this._clearReportPersonButton.Click += new System.EventHandler(this._clearReportPersonButton_Click);
            // 
            // _reportImagesListbox
            // 
            this._reportImagesListbox.CheckOnClick = true;
            this._reportImagesListbox.ContextMenuStrip = this.removeContextMenu;
            this._reportImagesListbox.FormattingEnabled = true;
            this._reportImagesListbox.Location = new System.Drawing.Point(4, 160);
            this._reportImagesListbox.Margin = new System.Windows.Forms.Padding(2);
            this._reportImagesListbox.Name = "_reportImagesListbox";
            this._reportImagesListbox.Size = new System.Drawing.Size(586, 139);
            this._reportImagesListbox.TabIndex = 16;
            this._reportImagesListbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._reportImagesListbox_MouseDown);
            // 
            // _browseReportImageButton
            // 
            this._browseReportImageButton.Location = new System.Drawing.Point(535, 130);
            this._browseReportImageButton.Margin = new System.Windows.Forms.Padding(2);
            this._browseReportImageButton.Name = "_browseReportImageButton";
            this._browseReportImageButton.Size = new System.Drawing.Size(55, 22);
            this._browseReportImageButton.TabIndex = 15;
            this._browseReportImageButton.Text = "Browse";
            this._browseReportImageButton.UseVisualStyleBackColor = true;
            this._browseReportImageButton.Click += new System.EventHandler(this._browseReportImageButton_Click);
            // 
            // _reportImageTextBox
            // 
            this._reportImageTextBox.Location = new System.Drawing.Point(5, 132);
            this._reportImageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._reportImageTextBox.Name = "_reportImageTextBox";
            this._reportImageTextBox.Size = new System.Drawing.Size(526, 20);
            this._reportImageTextBox.TabIndex = 14;
            this._reportImageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._reportImageTextBox_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 117);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Please select person\'s vidoe(s) or photo(s)";
            // 
            // _reportPersonMissingLabel
            // 
            this._reportPersonMissingLabel.AutoSize = true;
            this._reportPersonMissingLabel.Location = new System.Drawing.Point(4, 83);
            this._reportPersonMissingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._reportPersonMissingLabel.Name = "_reportPersonMissingLabel";
            this._reportPersonMissingLabel.Size = new System.Drawing.Size(44, 13);
            this._reportPersonMissingLabel.TabIndex = 11;
            this._reportPersonMissingLabel.Text = "Reason";
            // 
            // _reportPersonLastNameTextBox
            // 
            this._reportPersonLastNameTextBox.Location = new System.Drawing.Point(77, 52);
            this._reportPersonLastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._reportPersonLastNameTextBox.Name = "_reportPersonLastNameTextBox";
            this._reportPersonLastNameTextBox.Size = new System.Drawing.Size(191, 20);
            this._reportPersonLastNameTextBox.TabIndex = 10;
            // 
            // _reportPersonReportButton
            // 
            this._reportPersonReportButton.Location = new System.Drawing.Point(257, 303);
            this._reportPersonReportButton.Margin = new System.Windows.Forms.Padding(2);
            this._reportPersonReportButton.Name = "_reportPersonReportButton";
            this._reportPersonReportButton.Size = new System.Drawing.Size(55, 30);
            this._reportPersonReportButton.TabIndex = 9;
            this._reportPersonReportButton.Text = "Report";
            this._reportPersonReportButton.UseVisualStyleBackColor = true;
            this._reportPersonReportButton.Click += new System.EventHandler(this._reportPersonReportButton_Click);
            // 
            // _reportLastNameLabel
            // 
            this._reportLastNameLabel.AutoSize = true;
            this._reportLastNameLabel.Location = new System.Drawing.Point(4, 55);
            this._reportLastNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._reportLastNameLabel.Name = "_reportLastNameLabel";
            this._reportLastNameLabel.Size = new System.Drawing.Size(58, 13);
            this._reportLastNameLabel.TabIndex = 2;
            this._reportLastNameLabel.Text = "Last Name";
            // 
            // _reportFirstNameLabel
            // 
            this._reportFirstNameLabel.AutoSize = true;
            this._reportFirstNameLabel.Location = new System.Drawing.Point(4, 28);
            this._reportFirstNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._reportFirstNameLabel.Name = "_reportFirstNameLabel";
            this._reportFirstNameLabel.Size = new System.Drawing.Size(57, 13);
            this._reportFirstNameLabel.TabIndex = 1;
            this._reportFirstNameLabel.Text = "First Name";
            // 
            // _reportPersonFirstNameTextBox
            // 
            this._reportPersonFirstNameTextBox.Location = new System.Drawing.Point(77, 25);
            this._reportPersonFirstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._reportPersonFirstNameTextBox.Name = "_reportPersonFirstNameTextBox";
            this._reportPersonFirstNameTextBox.Size = new System.Drawing.Size(191, 20);
            this._reportPersonFirstNameTextBox.TabIndex = 0;
            // 
            // _train
            // 
            this._train.Controls.Add(this._clearButtonTrain);
            this._train.Controls.Add(this._trainLastNameTextBox);
            this._train.Controls.Add(this.label8);
            this._train.Controls.Add(this.label9);
            this._train.Controls.Add(this._trainFirstNameTextBox);
            this._train.Controls.Add(this._trainBrowserButton);
            this._train.Controls.Add(this._trainBrowseButton);
            this._train.Controls.Add(this._trainBrowseTextBox);
            this._train.Controls.Add(this._trainCheckedListBox);
            this._train.Controls.Add(this.label7);
            this._train.Location = new System.Drawing.Point(4, 22);
            this._train.Margin = new System.Windows.Forms.Padding(2);
            this._train.Name = "_train";
            this._train.Padding = new System.Windows.Forms.Padding(2);
            this._train.Size = new System.Drawing.Size(614, 385);
            this._train.TabIndex = 4;
            this._train.Text = "Train";
            this._train.UseVisualStyleBackColor = true;
            // 
            // _clearButtonTrain
            // 
            this._clearButtonTrain.Location = new System.Drawing.Point(7, 300);
            this._clearButtonTrain.Name = "_clearButtonTrain";
            this._clearButtonTrain.Size = new System.Drawing.Size(53, 21);
            this._clearButtonTrain.TabIndex = 27;
            this._clearButtonTrain.Text = "Clear";
            this._clearButtonTrain.UseVisualStyleBackColor = true;
            this._clearButtonTrain.Click += new System.EventHandler(this._clearButtonTrain_Click);
            // 
            // _trainLastNameTextBox
            // 
            this._trainLastNameTextBox.Location = new System.Drawing.Point(80, 32);
            this._trainLastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._trainLastNameTextBox.Name = "_trainLastNameTextBox";
            this._trainLastNameTextBox.Size = new System.Drawing.Size(191, 20);
            this._trainLastNameTextBox.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Last Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "First Name";
            // 
            // _trainFirstNameTextBox
            // 
            this._trainFirstNameTextBox.Location = new System.Drawing.Point(80, 4);
            this._trainFirstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._trainFirstNameTextBox.Name = "_trainFirstNameTextBox";
            this._trainFirstNameTextBox.Size = new System.Drawing.Size(191, 20);
            this._trainFirstNameTextBox.TabIndex = 23;
            // 
            // _trainBrowserButton
            // 
            this._trainBrowserButton.Location = new System.Drawing.Point(281, 337);
            this._trainBrowserButton.Margin = new System.Windows.Forms.Padding(2);
            this._trainBrowserButton.Name = "_trainBrowserButton";
            this._trainBrowserButton.Size = new System.Drawing.Size(57, 33);
            this._trainBrowserButton.TabIndex = 9;
            this._trainBrowserButton.Text = "Train";
            this._trainBrowserButton.UseVisualStyleBackColor = true;
            this._trainBrowserButton.Click += new System.EventHandler(this._trainBrowserButton_Click);
            // 
            // _trainBrowseButton
            // 
            this._trainBrowseButton.Location = new System.Drawing.Point(550, 73);
            this._trainBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this._trainBrowseButton.Name = "_trainBrowseButton";
            this._trainBrowseButton.Size = new System.Drawing.Size(55, 22);
            this._trainBrowseButton.TabIndex = 8;
            this._trainBrowseButton.Text = "Browse";
            this._trainBrowseButton.UseVisualStyleBackColor = true;
            this._trainBrowseButton.Click += new System.EventHandler(this._trainBrowseButton_Click);
            // 
            // _trainBrowseTextBox
            // 
            this._trainBrowseTextBox.Location = new System.Drawing.Point(7, 75);
            this._trainBrowseTextBox.Margin = new System.Windows.Forms.Padding(2);
            this._trainBrowseTextBox.Name = "_trainBrowseTextBox";
            this._trainBrowseTextBox.Size = new System.Drawing.Size(526, 20);
            this._trainBrowseTextBox.TabIndex = 7;
            this._trainBrowseTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._trainBrowseTextBox_KeyDown);
            // 
            // _trainCheckedListBox
            // 
            this._trainCheckedListBox.CheckOnClick = true;
            this._trainCheckedListBox.ContextMenuStrip = this.removeContextMenu;
            this._trainCheckedListBox.FormattingEnabled = true;
            this._trainCheckedListBox.Location = new System.Drawing.Point(6, 110);
            this._trainCheckedListBox.Margin = new System.Windows.Forms.Padding(2);
            this._trainCheckedListBox.Name = "_trainCheckedListBox";
            this._trainCheckedListBox.Size = new System.Drawing.Size(606, 184);
            this._trainCheckedListBox.TabIndex = 6;
            this._trainCheckedListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._trainCheckedListBox_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Please select a video(s) or photo(s) to train";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 418);
            this.Controls.Add(this.Tabs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Tabs.ResumeLayout(false);
            this._searchPage.ResumeLayout(false);
            this._searchPage.PerformLayout();
            this.removeContextMenu.ResumeLayout(false);
            this._webCam.ResumeLayout(false);
            this._webCam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).EndInit();
            this._reportPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this._reportCarTab.ResumeLayout(false);
            this._reportCarTab.PerformLayout();
            this._reportPersonTab.ResumeLayout(false);
            this._reportPersonTab.PerformLayout();
            this._train.ResumeLayout(false);
            this._train.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage _searchPage;
        private System.Windows.Forms.TabPage _reportPage;
        private System.Windows.Forms.Label _searchSelectionText;
        private System.Windows.Forms.CheckedListBox BrowseListBox;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage _reportCarTab;
        private System.Windows.Forms.TabPage _reportPersonTab;
        private System.Windows.Forms.Label _reportFirstNameLabel;
        private System.Windows.Forms.TextBox _reportPersonFirstNameTextBox;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Label _reportLastNameLabel;
        private System.Windows.Forms.Button _reportCarReportButton;
        private System.Windows.Forms.Label _reportCarPlateLabel;
        private System.Windows.Forms.TextBox _reportCarPlateTextBox;
        private System.Windows.Forms.Button _reportPersonReportButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip removeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.TabPage _webCam;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.Button trainingButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label webcamLabel;
        private System.Windows.Forms.PictureBox webcamPictureBox;
        private System.Windows.Forms.Label consoleLabel;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.TextBox _reportPersonLastNameTextBox;
        private System.Windows.Forms.Label _reportPersonMissingLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _reportCarLastNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _reportCarFirstNameTextBox;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage _train;
        private System.Windows.Forms.Button _trainBrowserButton;
        private System.Windows.Forms.Button _trainBrowseButton;
        private System.Windows.Forms.TextBox _trainBrowseTextBox;
        private System.Windows.Forms.CheckedListBox _trainCheckedListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _trainLastNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _trainFirstNameTextBox;
        private System.Windows.Forms.Button _clearButtonTrain;
        private System.Windows.Forms.Button _clearButtonSearch;
        private System.Windows.Forms.Button _browseReportImageButton;
        private System.Windows.Forms.TextBox _reportImageTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox _reportImagesListbox;
        private System.Windows.Forms.Button _clearReportPersonButton;
        private System.Windows.Forms.ComboBox _reportPersonReasonBox;
        private System.Windows.Forms.ComboBox _reportCarReasonBox;
    }
}