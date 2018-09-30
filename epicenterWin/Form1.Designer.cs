namespace epicenterWin
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Tabs = new System.Windows.Forms.TabControl();
            this._searchPage = new System.Windows.Forms.TabPage();
            this._searchSelectedFilesToUploadListview = new System.Windows.Forms.CheckedListBox();
            this._searchSelectionText = new System.Windows.Forms.Label();
            this._reportPage = new System.Windows.Forms.TabPage();
            this._historyPage = new System.Windows.Forms.TabPage();
            this._searchBrowseUrlToListButton = new System.Windows.Forms.Button();
            this._searchUploadButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._reportCarTab = new System.Windows.Forms.TabPage();
            this._reportPersonTab = new System.Windows.Forms.TabPage();
            this._reportPersonNameTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonNameLabel = new System.Windows.Forms.Label();
            this._enteredUrlBox = new System.Windows.Forms.TextBox();
            this._reportPersonLastSeenLabel = new System.Windows.Forms.Label();
            this._reportPersonLastSeenTextBox = new System.Windows.Forms.TextBox();
            this._reportPersonLastDatePicker = new System.Windows.Forms.DateTimePicker();
            this._reportPersonInfoLabel = new System.Windows.Forms.Label();
            this._reportPersonInfoBox = new System.Windows.Forms.TextBox();
            this._reportPersonUsedLetterLabel = new System.Windows.Forms.Label();
            this._reportPersonReportButton = new System.Windows.Forms.Button();
            this._reportCarReportButton = new System.Windows.Forms.Button();
            this._reportCarInfoBoxUsedLetters = new System.Windows.Forms.Label();
            this._reportCarInfoTextBox = new System.Windows.Forms.TextBox();
            this._reportCarAdditionalInfoLabel = new System.Windows.Forms.Label();
            this._reportCarLastSeenDatePicker = new System.Windows.Forms.DateTimePicker();
            this._reportCarLastSeenTextBox = new System.Windows.Forms.TextBox();
            this._reportCarLastSeenLabel = new System.Windows.Forms.Label();
            this._reportCarPlateLabel = new System.Windows.Forms.Label();
            this._reportCarPlateTextBox = new System.Windows.Forms.TextBox();
            this.Tabs.SuspendLayout();
            this._searchPage.SuspendLayout();
            this._reportPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this._reportCarTab.SuspendLayout();
            this._reportPersonTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this._searchPage);
            this.Tabs.Controls.Add(this._reportPage);
            this.Tabs.Controls.Add(this._historyPage);
            this.Tabs.Location = new System.Drawing.Point(12, 24);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(630, 602);
            this.Tabs.TabIndex = 0;
            // 
            // _searchPage
            // 
            this._searchPage.Controls.Add(this.progressBar1);
            this._searchPage.Controls.Add(this._searchUploadButton);
            this._searchPage.Controls.Add(this._searchBrowseUrlToListButton);
            this._searchPage.Controls.Add(this._enteredUrlBox);
            this._searchPage.Controls.Add(this._searchSelectedFilesToUploadListview);
            this._searchPage.Controls.Add(this._searchSelectionText);
            this._searchPage.Location = new System.Drawing.Point(4, 33);
            this._searchPage.Name = "_searchPage";
            this._searchPage.Padding = new System.Windows.Forms.Padding(3);
            this._searchPage.Size = new System.Drawing.Size(622, 565);
            this._searchPage.TabIndex = 0;
            this._searchPage.Text = "Search";
            this._searchPage.UseVisualStyleBackColor = true;
            // 
            // _searchSelectedFilesToUploadListview
            // 
            this._searchSelectedFilesToUploadListview.FormattingEnabled = true;
            this._searchSelectedFilesToUploadListview.Location = new System.Drawing.Point(11, 87);
            this._searchSelectedFilesToUploadListview.Name = "_searchSelectedFilesToUploadListview";
            this._searchSelectedFilesToUploadListview.Size = new System.Drawing.Size(497, 412);
            this._searchSelectedFilesToUploadListview.TabIndex = 1;
            // 
            // _searchSelectionText
            // 
            this._searchSelectionText.AutoSize = true;
            this._searchSelectionText.Location = new System.Drawing.Point(6, 13);
            this._searchSelectionText.Name = "_searchSelectionText";
            this._searchSelectionText.Size = new System.Drawing.Size(414, 25);
            this._searchSelectionText.TabIndex = 0;
            this._searchSelectionText.Text = "Please select a video(s) or photo(s) to analyze";
            // 
            // _reportPage
            // 
            this._reportPage.Controls.Add(this.tabControl1);
            this._reportPage.Location = new System.Drawing.Point(4, 33);
            this._reportPage.Name = "_reportPage";
            this._reportPage.Padding = new System.Windows.Forms.Padding(3);
            this._reportPage.Size = new System.Drawing.Size(622, 565);
            this._reportPage.TabIndex = 1;
            this._reportPage.Text = "Report";
            this._reportPage.UseVisualStyleBackColor = true;
            // 
            // _historyPage
            // 
            this._historyPage.Location = new System.Drawing.Point(4, 33);
            this._historyPage.Name = "_historyPage";
            this._historyPage.Padding = new System.Windows.Forms.Padding(3);
            this._historyPage.Size = new System.Drawing.Size(622, 565);
            this._historyPage.TabIndex = 2;
            this._historyPage.Text = "History";
            this._historyPage.UseVisualStyleBackColor = true;
            // 
            // _searchBrowseUrlToListButton
            // 
            this._searchBrowseUrlToListButton.Location = new System.Drawing.Point(516, 41);
            this._searchBrowseUrlToListButton.Name = "_searchBrowseUrlToListButton";
            this._searchBrowseUrlToListButton.Size = new System.Drawing.Size(100, 40);
            this._searchBrowseUrlToListButton.TabIndex = 3;
            this._searchBrowseUrlToListButton.Text = "Browse";
            this._searchBrowseUrlToListButton.UseVisualStyleBackColor = true;
            // 
            // _searchUploadButton
            // 
            this._searchUploadButton.Location = new System.Drawing.Point(514, 511);
            this._searchUploadButton.Name = "_searchUploadButton";
            this._searchUploadButton.Size = new System.Drawing.Size(96, 40);
            this._searchUploadButton.TabIndex = 4;
            this._searchUploadButton.Text = "Upload";
            this._searchUploadButton.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 511);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(497, 40);
            this.progressBar1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._reportCarTab);
            this.tabControl1.Controls.Add(this._reportPersonTab);
            this.tabControl1.Location = new System.Drawing.Point(7, 4);
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
            this._reportCarTab.Name = "_reportCarTab";
            this._reportCarTab.Padding = new System.Windows.Forms.Padding(3);
            this._reportCarTab.Size = new System.Drawing.Size(585, 521);
            this._reportCarTab.TabIndex = 0;
            this._reportCarTab.Text = "Car";
            this._reportCarTab.UseVisualStyleBackColor = true;
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
            this._reportPersonTab.Name = "_reportPersonTab";
            this._reportPersonTab.Padding = new System.Windows.Forms.Padding(3);
            this._reportPersonTab.Size = new System.Drawing.Size(585, 521);
            this._reportPersonTab.TabIndex = 1;
            this._reportPersonTab.Text = "Person";
            this._reportPersonTab.UseVisualStyleBackColor = true;
            // 
            // _reportPersonNameTextBox
            // 
            this._reportPersonNameTextBox.Location = new System.Drawing.Point(141, 52);
            this._reportPersonNameTextBox.Name = "_reportPersonNameTextBox";
            this._reportPersonNameTextBox.Size = new System.Drawing.Size(346, 29);
            this._reportPersonNameTextBox.TabIndex = 0;
            // 
            // _reportPersonNameLabel
            // 
            this._reportPersonNameLabel.AutoSize = true;
            this._reportPersonNameLabel.Location = new System.Drawing.Point(29, 52);
            this._reportPersonNameLabel.Name = "_reportPersonNameLabel";
            this._reportPersonNameLabel.Size = new System.Drawing.Size(106, 25);
            this._reportPersonNameLabel.TabIndex = 1;
            this._reportPersonNameLabel.Text = "Full Name:";
            // 
            // _enteredUrlBox
            // 
            this._enteredUrlBox.Location = new System.Drawing.Point(11, 41);
            this._enteredUrlBox.Name = "_enteredUrlBox";
            this._enteredUrlBox.Size = new System.Drawing.Size(497, 29);
            this._enteredUrlBox.TabIndex = 2;
            // 
            // _reportPersonLastSeenLabel
            // 
            this._reportPersonLastSeenLabel.AutoSize = true;
            this._reportPersonLastSeenLabel.Location = new System.Drawing.Point(28, 102);
            this._reportPersonLastSeenLabel.Name = "_reportPersonLastSeenLabel";
            this._reportPersonLastSeenLabel.Size = new System.Drawing.Size(107, 25);
            this._reportPersonLastSeenLabel.TabIndex = 2;
            this._reportPersonLastSeenLabel.Text = "Last Seen:";
            // 
            // _reportPersonLastSeenTextBox
            // 
            this._reportPersonLastSeenTextBox.Location = new System.Drawing.Point(141, 102);
            this._reportPersonLastSeenTextBox.Name = "_reportPersonLastSeenTextBox";
            this._reportPersonLastSeenTextBox.Size = new System.Drawing.Size(346, 29);
            this._reportPersonLastSeenTextBox.TabIndex = 3;
            // 
            // _reportPersonLastDatePicker
            // 
            this._reportPersonLastDatePicker.Location = new System.Drawing.Point(141, 146);
            this._reportPersonLastDatePicker.Name = "_reportPersonLastDatePicker";
            this._reportPersonLastDatePicker.Size = new System.Drawing.Size(346, 29);
            this._reportPersonLastDatePicker.TabIndex = 4;
            // 
            // _reportPersonInfoLabel
            // 
            this._reportPersonInfoLabel.AutoSize = true;
            this._reportPersonInfoLabel.Location = new System.Drawing.Point(28, 195);
            this._reportPersonInfoLabel.Name = "_reportPersonInfoLabel";
            this._reportPersonInfoLabel.Size = new System.Drawing.Size(141, 25);
            this._reportPersonInfoLabel.TabIndex = 6;
            this._reportPersonInfoLabel.Text = "Additional Info:";
            this._reportPersonInfoLabel.Click += new System.EventHandler(this._reportPersonInfoLabel_Click);
            // 
            // _reportPersonInfoBox
            // 
            this._reportPersonInfoBox.Location = new System.Drawing.Point(141, 234);
            this._reportPersonInfoBox.MaxLength = 80;
            this._reportPersonInfoBox.Name = "_reportPersonInfoBox";
            this._reportPersonInfoBox.Size = new System.Drawing.Size(346, 29);
            this._reportPersonInfoBox.TabIndex = 7;
            // 
            // _reportPersonUsedLetterLabel
            // 
            this._reportPersonUsedLetterLabel.AutoSize = true;
            this._reportPersonUsedLetterLabel.Location = new System.Drawing.Point(374, 283);
            this._reportPersonUsedLetterLabel.Name = "_reportPersonUsedLetterLabel";
            this._reportPersonUsedLetterLabel.Size = new System.Drawing.Size(113, 25);
            this._reportPersonUsedLetterLabel.TabIndex = 8;
            this._reportPersonUsedLetterLabel.Text = "(0/80) used";
            // 
            // _reportPersonReportButton
            // 
            this._reportPersonReportButton.Location = new System.Drawing.Point(441, 336);
            this._reportPersonReportButton.Name = "_reportPersonReportButton";
            this._reportPersonReportButton.Size = new System.Drawing.Size(99, 46);
            this._reportPersonReportButton.TabIndex = 9;
            this._reportPersonReportButton.Text = "Report";
            this._reportPersonReportButton.UseVisualStyleBackColor = true;
            // 
            // _reportCarReportButton
            // 
            this._reportCarReportButton.Location = new System.Drawing.Point(457, 331);
            this._reportCarReportButton.Name = "_reportCarReportButton";
            this._reportCarReportButton.Size = new System.Drawing.Size(99, 46);
            this._reportCarReportButton.TabIndex = 18;
            this._reportCarReportButton.Text = "Report";
            this._reportCarReportButton.UseVisualStyleBackColor = true;
            // 
            // _reportCarInfoBoxUsedLetters
            // 
            this._reportCarInfoBoxUsedLetters.AutoSize = true;
            this._reportCarInfoBoxUsedLetters.Location = new System.Drawing.Point(386, 274);
            this._reportCarInfoBoxUsedLetters.Name = "_reportCarInfoBoxUsedLetters";
            this._reportCarInfoBoxUsedLetters.Size = new System.Drawing.Size(113, 25);
            this._reportCarInfoBoxUsedLetters.TabIndex = 17;
            this._reportCarInfoBoxUsedLetters.Text = "(0/80) used";
            // 
            // _reportCarInfoTextBox
            // 
            this._reportCarInfoTextBox.Location = new System.Drawing.Point(157, 229);
            this._reportCarInfoTextBox.MaxLength = 80;
            this._reportCarInfoTextBox.Name = "_reportCarInfoTextBox";
            this._reportCarInfoTextBox.Size = new System.Drawing.Size(342, 29);
            this._reportCarInfoTextBox.TabIndex = 16;
            // 
            // _reportCarAdditionalInfoLabel
            // 
            this._reportCarAdditionalInfoLabel.AutoSize = true;
            this._reportCarAdditionalInfoLabel.Location = new System.Drawing.Point(15, 188);
            this._reportCarAdditionalInfoLabel.Name = "_reportCarAdditionalInfoLabel";
            this._reportCarAdditionalInfoLabel.Size = new System.Drawing.Size(141, 25);
            this._reportCarAdditionalInfoLabel.TabIndex = 15;
            this._reportCarAdditionalInfoLabel.Text = "Additional Info:";
            // 
            // _reportCarLastSeenDatePicker
            // 
            this._reportCarLastSeenDatePicker.Location = new System.Drawing.Point(157, 141);
            this._reportCarLastSeenDatePicker.Name = "_reportCarLastSeenDatePicker";
            this._reportCarLastSeenDatePicker.Size = new System.Drawing.Size(342, 29);
            this._reportCarLastSeenDatePicker.TabIndex = 14;
            // 
            // _reportCarLastSeenTextBox
            // 
            this._reportCarLastSeenTextBox.Location = new System.Drawing.Point(157, 97);
            this._reportCarLastSeenTextBox.Name = "_reportCarLastSeenTextBox";
            this._reportCarLastSeenTextBox.Size = new System.Drawing.Size(342, 29);
            this._reportCarLastSeenTextBox.TabIndex = 13;
            // 
            // _reportCarLastSeenLabel
            // 
            this._reportCarLastSeenLabel.AutoSize = true;
            this._reportCarLastSeenLabel.Location = new System.Drawing.Point(44, 97);
            this._reportCarLastSeenLabel.Name = "_reportCarLastSeenLabel";
            this._reportCarLastSeenLabel.Size = new System.Drawing.Size(107, 25);
            this._reportCarLastSeenLabel.TabIndex = 12;
            this._reportCarLastSeenLabel.Text = "Last Seen:";
            // 
            // _reportCarPlateLabel
            // 
            this._reportCarPlateLabel.AutoSize = true;
            this._reportCarPlateLabel.Location = new System.Drawing.Point(15, 47);
            this._reportCarPlateLabel.Name = "_reportCarPlateLabel";
            this._reportCarPlateLabel.Size = new System.Drawing.Size(136, 25);
            this._reportCarPlateLabel.TabIndex = 11;
            this._reportCarPlateLabel.Text = "Plate Number:";
            // 
            // _reportCarPlateTextBox
            // 
            this._reportCarPlateTextBox.Location = new System.Drawing.Point(157, 47);
            this._reportCarPlateTextBox.Name = "_reportCarPlateTextBox";
            this._reportCarPlateTextBox.Size = new System.Drawing.Size(120, 29);
            this._reportCarPlateTextBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(659, 647);
            this.Controls.Add(this.Tabs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tabs.ResumeLayout(false);
            this._searchPage.ResumeLayout(false);
            this._searchPage.PerformLayout();
            this._reportPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this._reportCarTab.ResumeLayout(false);
            this._reportCarTab.PerformLayout();
            this._reportPersonTab.ResumeLayout(false);
            this._reportPersonTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage _searchPage;
        private System.Windows.Forms.TabPage _reportPage;
        private System.Windows.Forms.TabPage _historyPage;
        private System.Windows.Forms.Label _searchSelectionText;
        private System.Windows.Forms.CheckedListBox _searchSelectedFilesToUploadListview;
        private System.Windows.Forms.Button _searchUploadButton;
        private System.Windows.Forms.Button _searchBrowseUrlToListButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage _reportCarTab;
        private System.Windows.Forms.TabPage _reportPersonTab;
        private System.Windows.Forms.Label _reportPersonNameLabel;
        private System.Windows.Forms.TextBox _reportPersonNameTextBox;
        private System.Windows.Forms.TextBox _enteredUrlBox;
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
    }
}

