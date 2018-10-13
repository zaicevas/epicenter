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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Tabs = new System.Windows.Forms.TabControl();
            this._searchPage = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CheckButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.BrowseListBox = new System.Windows.Forms.CheckedListBox();
            this.removeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._searchSelectionText = new System.Windows.Forms.Label();
            this._facePage = new System.Windows.Forms.TabPage();
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
            this._reportCarInfoBoxUsedLetters = new System.Windows.Forms.Label();
            this._reportCarInfoTextBox = new System.Windows.Forms.TextBox();
            this._reportCarAdditionalInfoLabel = new System.Windows.Forms.Label();
            this._reportCarLastSeenDatePicker = new System.Windows.Forms.DateTimePicker();
            this._reportCarLastSeenTextBox = new System.Windows.Forms.TextBox();
            this._reportCarLastSeenLabel = new System.Windows.Forms.Label();
            this._reportCarPlateLabel = new System.Windows.Forms.Label();
            this._reportCarPlateTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonTab = new System.Windows.Forms.TabPage();
            this._reportPersonReportButton = new System.Windows.Forms.Button();
            this._reportPersonUsedLetterLabel = new System.Windows.Forms.Label();
            this._reportPersonInfoBox = new System.Windows.Forms.TextBox();
            this._reportPersonInfoLabel = new System.Windows.Forms.Label();
            this._reportPersonLastDatePicker = new System.Windows.Forms.DateTimePicker();
            this._reportPersonLastSeenTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonLastSeenLabel = new System.Windows.Forms.Label();
            this._reportPersonNameLabel = new System.Windows.Forms.Label();
            this._reportPersonNameTextBox = new System.Windows.Forms.TextBox();
            this._historyPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Tabs.SuspendLayout();
            this._searchPage.SuspendLayout();
            this.removeContextMenu.SuspendLayout();
            this._facePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).BeginInit();
            this._reportPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this._reportCarTab.SuspendLayout();
            this._reportPersonTab.SuspendLayout();
            this._historyPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this._searchPage);
            this.Tabs.Controls.Add(this._facePage);
            this.Tabs.Controls.Add(this._reportPage);
            this.Tabs.Controls.Add(this._historyPage);
            this.Tabs.Location = new System.Drawing.Point(12, 0);
            this.Tabs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1141, 758);
            this.Tabs.TabIndex = 0;
            // 
            // _searchPage
            // 
            this._searchPage.Controls.Add(this.progressBar1);
            this._searchPage.Controls.Add(this.CheckButton);
            this._searchPage.Controls.Add(this.BrowseButton);
            this._searchPage.Controls.Add(this.FilePathBox);
            this._searchPage.Controls.Add(this.BrowseListBox);
            this._searchPage.Controls.Add(this._searchSelectionText);
            this._searchPage.Location = new System.Drawing.Point(4, 33);
            this._searchPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._searchPage.Name = "_searchPage";
            this._searchPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._searchPage.Size = new System.Drawing.Size(1133, 721);
            this._searchPage.TabIndex = 0;
            this._searchPage.Text = "Search";
            this._searchPage.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 512);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(496, 40);
            this.progressBar1.TabIndex = 5;
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(513, 512);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(95, 40);
            this.CheckButton.TabIndex = 4;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(516, 40);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(100, 40);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(11, 40);
            this.FilePathBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(498, 29);
            this.FilePathBox.TabIndex = 2;
            this.FilePathBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilePathBox_KeyDown);
            // 
            // BrowseListBox
            // 
            this.BrowseListBox.CheckOnClick = true;
            this.BrowseListBox.ContextMenuStrip = this.removeContextMenu;
            this.BrowseListBox.FormattingEnabled = true;
            this.BrowseListBox.Location = new System.Drawing.Point(11, 87);
            this.BrowseListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseListBox.Name = "BrowseListBox";
            this.BrowseListBox.Size = new System.Drawing.Size(498, 364);
            this.BrowseListBox.TabIndex = 1;
            this.BrowseListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseListBox_MouseDown);
            // 
            // removeContextMenu
            // 
            this.removeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.removeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.removeContextMenu.Name = "removeContextMenu";
            this.removeContextMenu.Size = new System.Drawing.Size(161, 38);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // _searchSelectionText
            // 
            this._searchSelectionText.AutoSize = true;
            this._searchSelectionText.Location = new System.Drawing.Point(6, 14);
            this._searchSelectionText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._searchSelectionText.Name = "_searchSelectionText";
            this._searchSelectionText.Size = new System.Drawing.Size(414, 25);
            this._searchSelectionText.TabIndex = 0;
            this._searchSelectionText.Text = "Please select a video(s) or photo(s) to analyze";
            // 
            // _facePage
            // 
            this._facePage.Controls.Add(this.recognizeButton);
            this._facePage.Controls.Add(this.consoleLabel);
            this._facePage.Controls.Add(this.OutputBox);
            this._facePage.Controls.Add(this.idTextBox);
            this._facePage.Controls.Add(this.trainingButton);
            this._facePage.Controls.Add(this.idLabel);
            this._facePage.Controls.Add(this.webcamLabel);
            this._facePage.Controls.Add(this.webcamPictureBox);
            this._facePage.Location = new System.Drawing.Point(4, 33);
            this._facePage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._facePage.Name = "_facePage";
            this._facePage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._facePage.Size = new System.Drawing.Size(1133, 721);
            this._facePage.TabIndex = 3;
            this._facePage.Text = "Face";
            this._facePage.UseVisualStyleBackColor = true;
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(872, 510);
            this.recognizeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(175, 34);
            this.recognizeButton.TabIndex = 7;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.Location = new System.Drawing.Point(868, 207);
            this.consoleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(85, 25);
            this.consoleLabel.TabIndex = 6;
            this.consoleLabel.Text = "Console";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(872, 262);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(180, 174);
            this.OutputBox.TabIndex = 5;
            this.OutputBox.Text = "";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(872, 68);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(180, 29);
            this.idTextBox.TabIndex = 4;
            // 
            // trainingButton
            // 
            this.trainingButton.Location = new System.Drawing.Point(872, 132);
            this.trainingButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trainingButton.Name = "trainingButton";
            this.trainingButton.Size = new System.Drawing.Size(175, 56);
            this.trainingButton.TabIndex = 3;
            this.trainingButton.Text = "Start Training";
            this.trainingButton.UseVisualStyleBackColor = true;
            this.trainingButton.Click += new System.EventHandler(this.trainingButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(868, 14);
            this.idLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(125, 25);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "Enter your ID";
            // 
            // webcamLabel
            // 
            this.webcamLabel.AutoSize = true;
            this.webcamLabel.Location = new System.Drawing.Point(12, 14);
            this.webcamLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.webcamLabel.Name = "webcamLabel";
            this.webcamLabel.Size = new System.Drawing.Size(91, 25);
            this.webcamLabel.TabIndex = 1;
            this.webcamLabel.Text = "Webcam";
            // 
            // webcamPictureBox
            // 
            this.webcamPictureBox.Location = new System.Drawing.Point(11, 48);
            this.webcamPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.webcamPictureBox.Name = "webcamPictureBox";
            this.webcamPictureBox.Size = new System.Drawing.Size(851, 631);
            this.webcamPictureBox.TabIndex = 0;
            this.webcamPictureBox.TabStop = false;
            // 
            // _reportPage
            // 
            this._reportPage.Controls.Add(this.tabControl1);
            this._reportPage.Location = new System.Drawing.Point(4, 33);
            this._reportPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPage.Name = "_reportPage";
            this._reportPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPage.Size = new System.Drawing.Size(1133, 721);
            this._reportPage.TabIndex = 1;
            this._reportPage.Text = "Report";
            this._reportPage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._reportCarTab);
            this.tabControl1.Controls.Add(this._reportPersonTab);
            this.tabControl1.Location = new System.Drawing.Point(7, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // _reportCarTab
            // 
            this._reportCarTab.Controls.Add(this._reportCarReportButton);
            this._reportCarTab.Controls.Add(this._reportCarInfoBoxUsedLetters);
            this._reportCarTab.Controls.Add(this._reportCarInfoTextBox);
            this._reportCarTab.Controls.Add(this._reportCarAdditionalInfoLabel);
            this._reportCarTab.Controls.Add(this._reportCarLastSeenDatePicker);
            this._reportCarTab.Controls.Add(this._reportCarLastSeenTextBox);
            this._reportCarTab.Controls.Add(this._reportCarLastSeenLabel);
            this._reportCarTab.Controls.Add(this._reportCarPlateLabel);
            this._reportCarTab.Controls.Add(this._reportCarPlateTextBox);
            this._reportCarTab.Location = new System.Drawing.Point(4, 33);
            this._reportCarTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarTab.Name = "_reportCarTab";
            this._reportCarTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarTab.Size = new System.Drawing.Size(585, 521);
            this._reportCarTab.TabIndex = 0;
            this._reportCarTab.Text = "Car";
            this._reportCarTab.UseVisualStyleBackColor = true;
            // 
            // _reportCarReportButton
            // 
            this._reportCarReportButton.Location = new System.Drawing.Point(456, 330);
            this._reportCarReportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarReportButton.Name = "_reportCarReportButton";
            this._reportCarReportButton.Size = new System.Drawing.Size(99, 46);
            this._reportCarReportButton.TabIndex = 18;
            this._reportCarReportButton.Text = "Report";
            this._reportCarReportButton.UseVisualStyleBackColor = true;
            // 
            // _reportCarInfoBoxUsedLetters
            // 
            this._reportCarInfoBoxUsedLetters.AutoSize = true;
            this._reportCarInfoBoxUsedLetters.Location = new System.Drawing.Point(386, 273);
            this._reportCarInfoBoxUsedLetters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportCarInfoBoxUsedLetters.Name = "_reportCarInfoBoxUsedLetters";
            this._reportCarInfoBoxUsedLetters.Size = new System.Drawing.Size(113, 25);
            this._reportCarInfoBoxUsedLetters.TabIndex = 17;
            this._reportCarInfoBoxUsedLetters.Text = "(0/80) used";
            // 
            // _reportCarInfoTextBox
            // 
            this._reportCarInfoTextBox.Location = new System.Drawing.Point(158, 230);
            this._reportCarInfoTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarInfoTextBox.MaxLength = 80;
            this._reportCarInfoTextBox.Name = "_reportCarInfoTextBox";
            this._reportCarInfoTextBox.Size = new System.Drawing.Size(341, 29);
            this._reportCarInfoTextBox.TabIndex = 16;
            // 
            // _reportCarAdditionalInfoLabel
            // 
            this._reportCarAdditionalInfoLabel.AutoSize = true;
            this._reportCarAdditionalInfoLabel.Location = new System.Drawing.Point(15, 189);
            this._reportCarAdditionalInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportCarAdditionalInfoLabel.Name = "_reportCarAdditionalInfoLabel";
            this._reportCarAdditionalInfoLabel.Size = new System.Drawing.Size(141, 25);
            this._reportCarAdditionalInfoLabel.TabIndex = 15;
            this._reportCarAdditionalInfoLabel.Text = "Additional Info:";
            // 
            // _reportCarLastSeenDatePicker
            // 
            this._reportCarLastSeenDatePicker.Location = new System.Drawing.Point(158, 141);
            this._reportCarLastSeenDatePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarLastSeenDatePicker.Name = "_reportCarLastSeenDatePicker";
            this._reportCarLastSeenDatePicker.Size = new System.Drawing.Size(341, 29);
            this._reportCarLastSeenDatePicker.TabIndex = 14;
            // 
            // _reportCarLastSeenTextBox
            // 
            this._reportCarLastSeenTextBox.Location = new System.Drawing.Point(158, 98);
            this._reportCarLastSeenTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarLastSeenTextBox.Name = "_reportCarLastSeenTextBox";
            this._reportCarLastSeenTextBox.Size = new System.Drawing.Size(341, 29);
            this._reportCarLastSeenTextBox.TabIndex = 13;
            // 
            // _reportCarLastSeenLabel
            // 
            this._reportCarLastSeenLabel.AutoSize = true;
            this._reportCarLastSeenLabel.Location = new System.Drawing.Point(44, 98);
            this._reportCarLastSeenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportCarLastSeenLabel.Name = "_reportCarLastSeenLabel";
            this._reportCarLastSeenLabel.Size = new System.Drawing.Size(107, 25);
            this._reportCarLastSeenLabel.TabIndex = 12;
            this._reportCarLastSeenLabel.Text = "Last Seen:";
            // 
            // _reportCarPlateLabel
            // 
            this._reportCarPlateLabel.AutoSize = true;
            this._reportCarPlateLabel.Location = new System.Drawing.Point(15, 46);
            this._reportCarPlateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportCarPlateLabel.Name = "_reportCarPlateLabel";
            this._reportCarPlateLabel.Size = new System.Drawing.Size(136, 25);
            this._reportCarPlateLabel.TabIndex = 11;
            this._reportCarPlateLabel.Text = "Plate Number:";
            // 
            // _reportCarPlateTextBox
            // 
            this._reportCarPlateTextBox.Location = new System.Drawing.Point(158, 46);
            this._reportCarPlateTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportCarPlateTextBox.Name = "_reportCarPlateTextBox";
            this._reportCarPlateTextBox.Size = new System.Drawing.Size(120, 29);
            this._reportCarPlateTextBox.TabIndex = 10;
            // 
            // _reportPersonTab
            // 
            this._reportPersonTab.Controls.Add(this._reportPersonReportButton);
            this._reportPersonTab.Controls.Add(this._reportPersonUsedLetterLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonInfoBox);
            this._reportPersonTab.Controls.Add(this._reportPersonInfoLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonLastDatePicker);
            this._reportPersonTab.Controls.Add(this._reportPersonLastSeenTextBox);
            this._reportPersonTab.Controls.Add(this._reportPersonLastSeenLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonNameLabel);
            this._reportPersonTab.Controls.Add(this._reportPersonNameTextBox);
            this._reportPersonTab.Location = new System.Drawing.Point(4, 33);
            this._reportPersonTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonTab.Name = "_reportPersonTab";
            this._reportPersonTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonTab.Size = new System.Drawing.Size(585, 521);
            this._reportPersonTab.TabIndex = 1;
            this._reportPersonTab.Text = "Person";
            this._reportPersonTab.UseVisualStyleBackColor = true;
            // 
            // _reportPersonReportButton
            // 
            this._reportPersonReportButton.Location = new System.Drawing.Point(441, 336);
            this._reportPersonReportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonReportButton.Name = "_reportPersonReportButton";
            this._reportPersonReportButton.Size = new System.Drawing.Size(99, 46);
            this._reportPersonReportButton.TabIndex = 9;
            this._reportPersonReportButton.Text = "Report";
            this._reportPersonReportButton.UseVisualStyleBackColor = true;
            // 
            // _reportPersonUsedLetterLabel
            // 
            this._reportPersonUsedLetterLabel.AutoSize = true;
            this._reportPersonUsedLetterLabel.Location = new System.Drawing.Point(374, 282);
            this._reportPersonUsedLetterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportPersonUsedLetterLabel.Name = "_reportPersonUsedLetterLabel";
            this._reportPersonUsedLetterLabel.Size = new System.Drawing.Size(113, 25);
            this._reportPersonUsedLetterLabel.TabIndex = 8;
            this._reportPersonUsedLetterLabel.Text = "(0/80) used";
            // 
            // _reportPersonInfoBox
            // 
            this._reportPersonInfoBox.Location = new System.Drawing.Point(142, 234);
            this._reportPersonInfoBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonInfoBox.MaxLength = 80;
            this._reportPersonInfoBox.Name = "_reportPersonInfoBox";
            this._reportPersonInfoBox.Size = new System.Drawing.Size(346, 29);
            this._reportPersonInfoBox.TabIndex = 7;
            // 
            // _reportPersonInfoLabel
            // 
            this._reportPersonInfoLabel.AutoSize = true;
            this._reportPersonInfoLabel.Location = new System.Drawing.Point(28, 195);
            this._reportPersonInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportPersonInfoLabel.Name = "_reportPersonInfoLabel";
            this._reportPersonInfoLabel.Size = new System.Drawing.Size(141, 25);
            this._reportPersonInfoLabel.TabIndex = 6;
            this._reportPersonInfoLabel.Text = "Additional Info:";
            // 
            // _reportPersonLastDatePicker
            // 
            this._reportPersonLastDatePicker.Location = new System.Drawing.Point(142, 146);
            this._reportPersonLastDatePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonLastDatePicker.Name = "_reportPersonLastDatePicker";
            this._reportPersonLastDatePicker.Size = new System.Drawing.Size(346, 29);
            this._reportPersonLastDatePicker.TabIndex = 4;
            // 
            // _reportPersonLastSeenTextBox
            // 
            this._reportPersonLastSeenTextBox.Location = new System.Drawing.Point(142, 102);
            this._reportPersonLastSeenTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonLastSeenTextBox.Name = "_reportPersonLastSeenTextBox";
            this._reportPersonLastSeenTextBox.Size = new System.Drawing.Size(346, 29);
            this._reportPersonLastSeenTextBox.TabIndex = 3;
            // 
            // _reportPersonLastSeenLabel
            // 
            this._reportPersonLastSeenLabel.AutoSize = true;
            this._reportPersonLastSeenLabel.Location = new System.Drawing.Point(28, 102);
            this._reportPersonLastSeenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportPersonLastSeenLabel.Name = "_reportPersonLastSeenLabel";
            this._reportPersonLastSeenLabel.Size = new System.Drawing.Size(107, 25);
            this._reportPersonLastSeenLabel.TabIndex = 2;
            this._reportPersonLastSeenLabel.Text = "Last Seen:";
            // 
            // _reportPersonNameLabel
            // 
            this._reportPersonNameLabel.AutoSize = true;
            this._reportPersonNameLabel.Location = new System.Drawing.Point(29, 51);
            this._reportPersonNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._reportPersonNameLabel.Name = "_reportPersonNameLabel";
            this._reportPersonNameLabel.Size = new System.Drawing.Size(106, 25);
            this._reportPersonNameLabel.TabIndex = 1;
            this._reportPersonNameLabel.Text = "Full Name:";
            // 
            // _reportPersonNameTextBox
            // 
            this._reportPersonNameTextBox.Location = new System.Drawing.Point(142, 51);
            this._reportPersonNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._reportPersonNameTextBox.Name = "_reportPersonNameTextBox";
            this._reportPersonNameTextBox.Size = new System.Drawing.Size(346, 29);
            this._reportPersonNameTextBox.TabIndex = 0;
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
            this._historyPage.Location = new System.Drawing.Point(4, 33);
            this._historyPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._historyPage.Name = "_historyPage";
            this._historyPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._historyPage.Size = new System.Drawing.Size(1133, 721);
            this._historyPage.TabIndex = 2;
            this._historyPage.Text = "History";
            this._historyPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "From:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(76, 54);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(416, 29);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.Value = new System.DateTime(2018, 10, 2, 10, 4, 42, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(76, 10);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(416, 29);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 54);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 504);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear history";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(4, 102);
            this.listView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(605, 388);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1168, 771);
            this.Controls.Add(this.Tabs);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tabs.ResumeLayout(false);
            this._searchPage.ResumeLayout(false);
            this._searchPage.PerformLayout();
            this.removeContextMenu.ResumeLayout(false);
            this._facePage.ResumeLayout(false);
            this._facePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).EndInit();
            this._reportPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this._reportCarTab.ResumeLayout(false);
            this._reportCarTab.PerformLayout();
            this._reportPersonTab.ResumeLayout(false);
            this._reportPersonTab.PerformLayout();
            this._historyPage.ResumeLayout(false);
            this._historyPage.PerformLayout();
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage _reportCarTab;
        private System.Windows.Forms.TabPage _reportPersonTab;
        private System.Windows.Forms.Label _reportPersonNameLabel;
        private System.Windows.Forms.TextBox _reportPersonNameTextBox;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Label _reportPersonInfoLabel;
        private System.Windows.Forms.DateTimePicker _reportPersonLastDatePicker;
        private System.Windows.Forms.TextBox _reportPersonLastSeenTextBox;
        private System.Windows.Forms.Label _reportPersonLastSeenLabel;
        private System.Windows.Forms.Button _reportCarReportButton;
        private System.Windows.Forms.Label _reportCarInfoBoxUsedLetters;
        private System.Windows.Forms.TextBox _reportCarInfoTextBox;
        private System.Windows.Forms.Label _reportCarAdditionalInfoLabel;
        private System.Windows.Forms.DateTimePicker _reportCarLastSeenDatePicker;
        private System.Windows.Forms.TextBox _reportCarLastSeenTextBox;
        private System.Windows.Forms.Label _reportCarLastSeenLabel;
        private System.Windows.Forms.Label _reportCarPlateLabel;
        private System.Windows.Forms.TextBox _reportCarPlateTextBox;
        private System.Windows.Forms.Button _reportPersonReportButton;
        private System.Windows.Forms.Label _reportPersonUsedLetterLabel;
        private System.Windows.Forms.TextBox _reportPersonInfoBox;
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
        private System.Windows.Forms.TabPage _facePage;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button trainingButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label webcamLabel;
        private System.Windows.Forms.PictureBox webcamPictureBox;
        private System.Windows.Forms.Label consoleLabel;
        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Button recognizeButton;
    }
}