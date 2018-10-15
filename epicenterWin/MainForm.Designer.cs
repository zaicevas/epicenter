﻿namespace epicenterWin
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
            this.CheckButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.BrowseListBox = new System.Windows.Forms.CheckedListBox();
            this.removeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._searchSelectionText = new System.Windows.Forms.Label();
            this._webCam = new System.Windows.Forms.TabPage();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.consoleLabel = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.trainingButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.webcamLabel = new System.Windows.Forms.Label();
            this.webcamPictureBox = new System.Windows.Forms.PictureBox();
            this._reportPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._reportCarTab = new System.Windows.Forms.TabPage();
            this._reportCarReportButton = new System.Windows.Forms.Button();
            this._reportCarPlateLabel = new System.Windows.Forms.Label();
            this._reportCarPlateTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonTab = new System.Windows.Forms.TabPage();
            this._reportPersonReportButton = new System.Windows.Forms.Button();
            this._reportLastNameLabel = new System.Windows.Forms.Label();
            this._reportFirstNameLabel = new System.Windows.Forms.Label();
            this._reportPersonFirstNameTextBox = new System.Windows.Forms.TextBox();
            this._historyPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._reportPersonLastNameTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonMissingLabel = new System.Windows.Forms.Label();
            this._reportPersonMissingCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._train = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.Tabs.SuspendLayout();
            this._searchPage.SuspendLayout();
            this.removeContextMenu.SuspendLayout();
            this._webCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).BeginInit();
            this._reportPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this._reportCarTab.SuspendLayout();
            this._reportPersonTab.SuspendLayout();
            this._historyPage.SuspendLayout();
            this._train.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this._searchPage);
            this.Tabs.Controls.Add(this._webCam);
            this.Tabs.Controls.Add(this._reportPage);
            this.Tabs.Controls.Add(this._train);
            this.Tabs.Controls.Add(this._historyPage);
            this.Tabs.Location = new System.Drawing.Point(9, 0);
            this.Tabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(829, 506);
            this.Tabs.TabIndex = 0;
            // 
            // _searchPage
            // 
            this._searchPage.Controls.Add(this.CheckButton);
            this._searchPage.Controls.Add(this.BrowseButton);
            this._searchPage.Controls.Add(this.FilePathBox);
            this._searchPage.Controls.Add(this.BrowseListBox);
            this._searchPage.Controls.Add(this._searchSelectionText);
            this._searchPage.Location = new System.Drawing.Point(4, 25);
            this._searchPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._searchPage.Name = "_searchPage";
            this._searchPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._searchPage.Size = new System.Drawing.Size(821, 477);
            this._searchPage.TabIndex = 0;
            this._searchPage.Text = "Search";
            this._searchPage.UseVisualStyleBackColor = true;
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(331, 372);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(152, 83);
            this.CheckButton.TabIndex = 4;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(725, 27);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(73, 27);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(8, 27);
            this.FilePathBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(700, 22);
            this.FilePathBox.TabIndex = 2;
            this.FilePathBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilePathBox_KeyDown);
            // 
            // BrowseListBox
            // 
            this.BrowseListBox.CheckOnClick = true;
            this.BrowseListBox.ContextMenuStrip = this.removeContextMenu;
            this.BrowseListBox.FormattingEnabled = true;
            this.BrowseListBox.Location = new System.Drawing.Point(8, 58);
            this.BrowseListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowseListBox.Name = "BrowseListBox";
            this.BrowseListBox.Size = new System.Drawing.Size(807, 293);
            this.BrowseListBox.TabIndex = 1;
            this.BrowseListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseListBox_MouseDown);
            // 
            // removeContextMenu
            // 
            this.removeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.removeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.removeContextMenu.Name = "removeContextMenu";
            this.removeContextMenu.Size = new System.Drawing.Size(133, 28);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // _searchSelectionText
            // 
            this._searchSelectionText.AutoSize = true;
            this._searchSelectionText.Location = new System.Drawing.Point(4, 10);
            this._searchSelectionText.Name = "_searchSelectionText";
            this._searchSelectionText.Size = new System.Drawing.Size(302, 17);
            this._searchSelectionText.TabIndex = 0;
            this._searchSelectionText.Text = "Please select a video(s) or photo(s) to analyze";
            // 
            // _webCam
            // 
            this._webCam.Controls.Add(this.textBox3);
            this._webCam.Controls.Add(this.label6);
            this._webCam.Controls.Add(this.recognizeButton);
            this._webCam.Controls.Add(this.consoleLabel);
            this._webCam.Controls.Add(this.OutputBox);
            this._webCam.Controls.Add(this.idTextBox);
            this._webCam.Controls.Add(this.trainingButton);
            this._webCam.Controls.Add(this.idLabel);
            this._webCam.Controls.Add(this.webcamLabel);
            this._webCam.Controls.Add(this.webcamPictureBox);
            this._webCam.Location = new System.Drawing.Point(4, 25);
            this._webCam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._webCam.Name = "_webCam";
            this._webCam.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._webCam.Size = new System.Drawing.Size(821, 477);
            this._webCam.TabIndex = 3;
            this._webCam.Text = "Webcam";
            this._webCam.UseVisualStyleBackColor = true;
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(647, 421);
            this.recognizeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(132, 32);
            this.recognizeButton.TabIndex = 7;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.RecognizeButton_Click);
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.Location = new System.Drawing.Point(635, 233);
            this.consoleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(59, 17);
            this.consoleLabel.TabIndex = 6;
            this.consoleLabel.Text = "Console";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(638, 268);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(132, 117);
            this.OutputBox.TabIndex = 5;
            this.OutputBox.Text = "";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(634, 32);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(132, 22);
            this.idTextBox.TabIndex = 4;
            // 
            // trainingButton
            // 
            this.trainingButton.Location = new System.Drawing.Point(634, 146);
            this.trainingButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trainingButton.Name = "trainingButton";
            this.trainingButton.Size = new System.Drawing.Size(127, 37);
            this.trainingButton.TabIndex = 3;
            this.trainingButton.Text = "Start Training";
            this.trainingButton.UseVisualStyleBackColor = true;
            this.trainingButton.Click += new System.EventHandler(this.TrainingButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(635, 10);
            this.idLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(72, 17);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "FirstName";
            // 
            // webcamLabel
            // 
            this.webcamLabel.AutoSize = true;
            this.webcamLabel.Location = new System.Drawing.Point(9, 10);
            this.webcamLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.webcamLabel.Name = "webcamLabel";
            this.webcamLabel.Size = new System.Drawing.Size(63, 17);
            this.webcamLabel.TabIndex = 1;
            this.webcamLabel.Text = "Webcam";
            // 
            // webcamPictureBox
            // 
            this.webcamPictureBox.Location = new System.Drawing.Point(8, 32);
            this.webcamPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webcamPictureBox.Name = "webcamPictureBox";
            this.webcamPictureBox.Size = new System.Drawing.Size(619, 421);
            this.webcamPictureBox.TabIndex = 0;
            this.webcamPictureBox.TabStop = false;
            // 
            // _reportPage
            // 
            this._reportPage.Controls.Add(this.tabControl1);
            this._reportPage.Location = new System.Drawing.Point(4, 25);
            this._reportPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportPage.Name = "_reportPage";
            this._reportPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportPage.Size = new System.Drawing.Size(821, 477);
            this._reportPage.TabIndex = 1;
            this._reportPage.Text = "Report";
            this._reportPage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._reportCarTab);
            this.tabControl1.Controls.Add(this._reportPersonTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // _reportCarTab
            // 
            this._reportCarTab.Controls.Add(this.checkBox1);
            this._reportCarTab.Controls.Add(this.label3);
            this._reportCarTab.Controls.Add(this.textBox1);
            this._reportCarTab.Controls.Add(this.label4);
            this._reportCarTab.Controls.Add(this.label5);
            this._reportCarTab.Controls.Add(this.textBox2);
            this._reportCarTab.Controls.Add(this._reportCarReportButton);
            this._reportCarTab.Controls.Add(this._reportCarPlateLabel);
            this._reportCarTab.Controls.Add(this._reportCarPlateTextBox);
            this._reportCarTab.Location = new System.Drawing.Point(4, 25);
            this._reportCarTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportCarTab.Name = "_reportCarTab";
            this._reportCarTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportCarTab.Size = new System.Drawing.Size(807, 444);
            this._reportCarTab.TabIndex = 0;
            this._reportCarTab.Text = "Car";
            this._reportCarTab.UseVisualStyleBackColor = true;
            this._reportCarTab.Click += new System.EventHandler(this._reportCarTab_Click);
            // 
            // _reportCarReportButton
            // 
            this._reportCarReportButton.Location = new System.Drawing.Point(45, 190);
            this._reportCarReportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportCarReportButton.Name = "_reportCarReportButton";
            this._reportCarReportButton.Size = new System.Drawing.Size(698, 220);
            this._reportCarReportButton.TabIndex = 18;
            this._reportCarReportButton.Text = "Report";
            this._reportCarReportButton.UseVisualStyleBackColor = true;
            // 
            // _reportCarPlateLabel
            // 
            this._reportCarPlateLabel.AutoSize = true;
            this._reportCarPlateLabel.Location = new System.Drawing.Point(6, 31);
            this._reportCarPlateLabel.Name = "_reportCarPlateLabel";
            this._reportCarPlateLabel.Size = new System.Drawing.Size(94, 17);
            this._reportCarPlateLabel.TabIndex = 11;
            this._reportCarPlateLabel.Text = "Plate Number";
            // 
            // _reportCarPlateTextBox
            // 
            this._reportCarPlateTextBox.Location = new System.Drawing.Point(109, 31);
            this._reportCarPlateTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportCarPlateTextBox.Name = "_reportCarPlateTextBox";
            this._reportCarPlateTextBox.Size = new System.Drawing.Size(253, 22);
            this._reportCarPlateTextBox.TabIndex = 10;
            this._reportCarPlateTextBox.TextChanged += new System.EventHandler(this._reportCarPlateTextBox_TextChanged);
            // 
            // _reportPersonTab
            // 
            this._reportPersonTab.Controls.Add(this._reportPersonMissingCheckBox);
            this._reportPersonTab.Controls.Add(this._reportPersonMissingLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonLastNameTextBox);
            this._reportPersonTab.Controls.Add(this._reportPersonReportButton);
            this._reportPersonTab.Controls.Add(this._reportLastNameLabel);
            this._reportPersonTab.Controls.Add(this._reportFirstNameLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonFirstNameTextBox);
            this._reportPersonTab.Location = new System.Drawing.Point(4, 25);
            this._reportPersonTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportPersonTab.Name = "_reportPersonTab";
            this._reportPersonTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportPersonTab.Size = new System.Drawing.Size(807, 444);
            this._reportPersonTab.TabIndex = 1;
            this._reportPersonTab.Text = "Person";
            this._reportPersonTab.UseVisualStyleBackColor = true;
            // 
            // _reportPersonReportButton
            // 
            this._reportPersonReportButton.Location = new System.Drawing.Point(159, 168);
            this._reportPersonReportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportPersonReportButton.Name = "_reportPersonReportButton";
            this._reportPersonReportButton.Size = new System.Drawing.Size(72, 31);
            this._reportPersonReportButton.TabIndex = 9;
            this._reportPersonReportButton.Text = "Report";
            this._reportPersonReportButton.UseVisualStyleBackColor = true;
            // 
            // _reportLastNameLabel
            // 
            this._reportLastNameLabel.AutoSize = true;
            this._reportLastNameLabel.Location = new System.Drawing.Point(20, 68);
            this._reportLastNameLabel.Name = "_reportLastNameLabel";
            this._reportLastNameLabel.Size = new System.Drawing.Size(76, 17);
            this._reportLastNameLabel.TabIndex = 2;
            this._reportLastNameLabel.Text = "Last Name";
            // 
            // _reportFirstNameLabel
            // 
            this._reportFirstNameLabel.AutoSize = true;
            this._reportFirstNameLabel.Location = new System.Drawing.Point(21, 34);
            this._reportFirstNameLabel.Name = "_reportFirstNameLabel";
            this._reportFirstNameLabel.Size = new System.Drawing.Size(76, 17);
            this._reportFirstNameLabel.TabIndex = 1;
            this._reportFirstNameLabel.Text = "First Name";
            // 
            // _reportPersonFirstNameTextBox
            // 
            this._reportPersonFirstNameTextBox.Location = new System.Drawing.Point(103, 34);
            this._reportPersonFirstNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reportPersonFirstNameTextBox.Name = "_reportPersonFirstNameTextBox";
            this._reportPersonFirstNameTextBox.Size = new System.Drawing.Size(253, 22);
            this._reportPersonFirstNameTextBox.TabIndex = 0;
            // 
            // _historyPage
            // 
            this._historyPage.Controls.Add(this.label2);
            this._historyPage.Controls.Add(this.label1);
            this._historyPage.Controls.Add(this.dateTimePicker2);
            this._historyPage.Controls.Add(this.dateTimePicker1);
            this._historyPage.Controls.Add(this.button2);
            this._historyPage.Controls.Add(this.button1);
            this._historyPage.Controls.Add(this.listView1);
            this._historyPage.Location = new System.Drawing.Point(4, 25);
            this._historyPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._historyPage.Name = "_historyPage";
            this._historyPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._historyPage.Size = new System.Drawing.Size(821, 477);
            this._historyPage.TabIndex = 2;
            this._historyPage.Text = "History";
            this._historyPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "From:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(55, 36);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(304, 22);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.Value = new System.DateTime(2018, 10, 2, 10, 4, 42, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(55, 6);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(304, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 36);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 26);
            this.button2.TabIndex = 0;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 336);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear history";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 68);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(441, 260);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _reportPersonLastNameTextBox
            // 
            this._reportPersonLastNameTextBox.Location = new System.Drawing.Point(103, 68);
            this._reportPersonLastNameTextBox.Name = "_reportPersonLastNameTextBox";
            this._reportPersonLastNameTextBox.Size = new System.Drawing.Size(253, 22);
            this._reportPersonLastNameTextBox.TabIndex = 10;
            // 
            // _reportPersonMissingLabel
            // 
            this._reportPersonMissingLabel.AutoSize = true;
            this._reportPersonMissingLabel.Location = new System.Drawing.Point(21, 102);
            this._reportPersonMissingLabel.Name = "_reportPersonMissingLabel";
            this._reportPersonMissingLabel.Size = new System.Drawing.Size(55, 17);
            this._reportPersonMissingLabel.TabIndex = 11;
            this._reportPersonMissingLabel.Text = "Missing";
            // 
            // _reportPersonMissingCheckBox
            // 
            this._reportPersonMissingCheckBox.AutoSize = true;
            this._reportPersonMissingCheckBox.Location = new System.Drawing.Point(103, 105);
            this._reportPersonMissingCheckBox.Name = "_reportPersonMissingCheckBox";
            this._reportPersonMissingCheckBox.Size = new System.Drawing.Size(15, 14);
            this._reportPersonMissingCheckBox.TabIndex = 12;
            this._reportPersonMissingCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(109, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Missing";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 22);
            this.textBox1.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "First Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 73);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 22);
            this.textBox2.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(634, 92);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(635, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "LastName";
            // 
            // _train
            // 
            this._train.Controls.Add(this.textBox5);
            this._train.Controls.Add(this.label8);
            this._train.Controls.Add(this.label9);
            this._train.Controls.Add(this.textBox6);
            this._train.Controls.Add(this.button3);
            this._train.Controls.Add(this.button4);
            this._train.Controls.Add(this.textBox4);
            this._train.Controls.Add(this.checkedListBox1);
            this._train.Controls.Add(this.label7);
            this._train.Location = new System.Drawing.Point(4, 25);
            this._train.Name = "_train";
            this._train.Padding = new System.Windows.Forms.Padding(3);
            this._train.Size = new System.Drawing.Size(821, 477);
            this._train.TabIndex = 4;
            this._train.Text = "Train";
            this._train.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(375, 415);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 41);
            this.button3.TabIndex = 9;
            this.button3.Text = "Train";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(733, 90);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 27);
            this.button4.TabIndex = 8;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(9, 92);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(700, 22);
            this.textBox4.TabIndex = 7;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ContextMenuStrip = this.removeContextMenu;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(8, 136);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(807, 259);
            this.checkedListBox1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(281, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Please select a video(s) or photo(s) to train";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(107, 39);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(253, 22);
            this.textBox5.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Last Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "First Name";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(107, 5);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(253, 22);
            this.textBox6.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 514);
            this.Controls.Add(this.Tabs);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            this._historyPage.ResumeLayout(false);
            this._historyPage.PerformLayout();
            this._train.ResumeLayout(false);
            this._train.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage _searchPage;
        private System.Windows.Forms.TabPage _reportPage;
        private System.Windows.Forms.TabPage _historyPage;
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ContextMenuStrip removeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.TabPage _webCam;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button trainingButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label webcamLabel;
        private System.Windows.Forms.PictureBox webcamPictureBox;
        private System.Windows.Forms.Label consoleLabel;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.TextBox _reportPersonLastNameTextBox;
        private System.Windows.Forms.CheckBox _reportPersonMissingCheckBox;
        private System.Windows.Forms.Label _reportPersonMissingLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage _train;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
    }
}