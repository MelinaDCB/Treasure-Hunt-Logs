namespace Treasure_Hunt_Logs
{
    partial class THLogs
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_THLogger = new Label();
            label_HuntLevel = new Label();
            comboBox_HuntLevel = new ComboBox();
            label_Language = new Label();
            comboBox_Language = new ComboBox();
            groupBox_Coordinates = new GroupBox();
            textBox_YCoordinate = new TextBox();
            textBox_XCoordinate = new TextBox();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox_Coordinates.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label_THLogger
            // 
            label_THLogger.AutoSize = true;
            label_THLogger.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_THLogger.Location = new Point(163, 8);
            label_THLogger.Name = "label_THLogger";
            label_THLogger.Size = new Size(195, 25);
            label_THLogger.TabIndex = 0;
            label_THLogger.Text = "Treasure Hunt Logger";
            // 
            // label_HuntLevel
            // 
            label_HuntLevel.AutoSize = true;
            label_HuntLevel.Location = new Point(12, 46);
            label_HuntLevel.Name = "label_HuntLevel";
            label_HuntLevel.Size = new Size(73, 15);
            label_HuntLevel.TabIndex = 1;
            label_HuntLevel.Text = "Hunt Level  :";
            // 
            // comboBox_HuntLevel
            // 
            comboBox_HuntLevel.FormattingEnabled = true;
            comboBox_HuntLevel.Items.AddRange(new object[] { "20", "40", "60", "80", "100", "120", "140", "160", "180", "200" });
            comboBox_HuntLevel.Location = new Point(92, 43);
            comboBox_HuntLevel.Name = "comboBox_HuntLevel";
            comboBox_HuntLevel.Size = new Size(65, 23);
            comboBox_HuntLevel.TabIndex = 3;
            comboBox_HuntLevel.SelectedIndexChanged += comboBox_HuntLevel_SelectedIndexChanged;
            // 
            // label_Language
            // 
            label_Language.AutoSize = true;
            label_Language.Location = new Point(338, 46);
            label_Language.Name = "label_Language";
            label_Language.Size = new Size(65, 15);
            label_Language.TabIndex = 5;
            label_Language.Text = "Language :";
            // 
            // comboBox_Language
            // 
            comboBox_Language.FormattingEnabled = true;
            comboBox_Language.Location = new Point(409, 43);
            comboBox_Language.Name = "comboBox_Language";
            comboBox_Language.Size = new Size(89, 23);
            comboBox_Language.TabIndex = 6;
            comboBox_Language.SelectedIndexChanged += comboBox_Language_SelectedIndexChanged;
            // 
            // groupBox_Coordinates
            // 
            groupBox_Coordinates.Controls.Add(textBox_YCoordinate);
            groupBox_Coordinates.Controls.Add(textBox_XCoordinate);
            groupBox_Coordinates.Location = new Point(12, 79);
            groupBox_Coordinates.Name = "groupBox_Coordinates";
            groupBox_Coordinates.Size = new Size(118, 134);
            groupBox_Coordinates.TabIndex = 7;
            groupBox_Coordinates.TabStop = false;
            groupBox_Coordinates.Text = "Coordinates";
            // 
            // textBox_YCoordinate
            // 
            textBox_YCoordinate.Location = new Point(27, 92);
            textBox_YCoordinate.Name = "textBox_YCoordinate";
            textBox_YCoordinate.PlaceholderText = "Y";
            textBox_YCoordinate.Size = new Size(66, 23);
            textBox_YCoordinate.TabIndex = 1;
            textBox_YCoordinate.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_XCoordinate
            // 
            textBox_XCoordinate.Location = new Point(26, 49);
            textBox_XCoordinate.Name = "textBox_XCoordinate";
            textBox_XCoordinate.PlaceholderText = "X";
            textBox_XCoordinate.Size = new Size(67, 23);
            textBox_XCoordinate.TabIndex = 0;
            textBox_XCoordinate.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(21, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(224, 23);
            comboBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(158, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(340, 134);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // THLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 491);
            Controls.Add(groupBox1);
            Controls.Add(groupBox_Coordinates);
            Controls.Add(comboBox_Language);
            Controls.Add(label_Language);
            Controls.Add(comboBox_HuntLevel);
            Controls.Add(label_HuntLevel);
            Controls.Add(label_THLogger);
            Name = "THLogs";
            Text = "Treasure Hunt funsies";
            Load += THLogs_Load;
            groupBox_Coordinates.ResumeLayout(false);
            groupBox_Coordinates.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_THLogger;
        private Label label_HuntLevel;
        private ComboBox comboBox_HuntLevel;
        private Label label_Language;
        private ComboBox comboBox_Language;
        private GroupBox groupBox_Coordinates;
        private TextBox textBox_YCoordinate;
        private TextBox textBox_XCoordinate;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
    }
}
