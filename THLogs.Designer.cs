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
            comboBox_Clues = new ComboBox();
            groupBox_Clue = new GroupBox();
            label_Result = new Label();
            button_NewHunt = new Button();
            button_DisplayCurrentHunt = new Button();
            button_EraseLastStep = new Button();
            button_SaveHunt = new Button();
            groupBox_Coordinates.SuspendLayout();
            groupBox_Clue.SuspendLayout();
            SuspendLayout();
            // 
            // label_THLogger
            // 
            label_THLogger.AutoSize = true;
            label_THLogger.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_THLogger.Location = new Point(125, 9);
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
            label_Language.Location = new Point(227, 46);
            label_Language.Name = "label_Language";
            label_Language.Size = new Size(65, 15);
            label_Language.TabIndex = 5;
            label_Language.Text = "Language :";
            // 
            // comboBox_Language
            // 
            comboBox_Language.FormattingEnabled = true;
            comboBox_Language.Location = new Point(335, 43);
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
            textBox_YCoordinate.Leave += textBox_YCoordinate_Leave;
            // 
            // textBox_XCoordinate
            // 
            textBox_XCoordinate.Location = new Point(26, 49);
            textBox_XCoordinate.Name = "textBox_XCoordinate";
            textBox_XCoordinate.PlaceholderText = "X";
            textBox_XCoordinate.Size = new Size(67, 23);
            textBox_XCoordinate.TabIndex = 0;
            textBox_XCoordinate.TextAlign = HorizontalAlignment.Center;
            textBox_XCoordinate.Leave += textBox_XCoordinate_Leave;
            // 
            // comboBox_Clues
            // 
            comboBox_Clues.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Clues.FormattingEnabled = true;
            comboBox_Clues.Location = new Point(21, 59);
            comboBox_Clues.Name = "comboBox_Clues";
            comboBox_Clues.Size = new Size(224, 23);
            comboBox_Clues.TabIndex = 8;
            comboBox_Clues.SelectedIndexChanged += comboBox_Clues_SelectedIndexChanged;
            // 
            // groupBox_Clue
            // 
            groupBox_Clue.Controls.Add(label_Result);
            groupBox_Clue.Controls.Add(comboBox_Clues);
            groupBox_Clue.Location = new Point(158, 79);
            groupBox_Clue.Name = "groupBox_Clue";
            groupBox_Clue.Size = new Size(266, 134);
            groupBox_Clue.TabIndex = 2;
            groupBox_Clue.TabStop = false;
            groupBox_Clue.Text = "Clue";
            // 
            // label_Result
            // 
            label_Result.AutoSize = true;
            label_Result.ForeColor = Color.Green;
            label_Result.Location = new Point(21, 95);
            label_Result.Name = "label_Result";
            label_Result.Size = new Size(0, 15);
            label_Result.TabIndex = 12;
            // 
            // button_NewHunt
            // 
            button_NewHunt.Location = new Point(15, 242);
            button_NewHunt.Name = "button_NewHunt";
            button_NewHunt.Size = new Size(90, 40);
            button_NewHunt.TabIndex = 8;
            button_NewHunt.Text = "New Hunt";
            button_NewHunt.UseVisualStyleBackColor = true;
            button_NewHunt.Click += button_NewHunt_Click;
            // 
            // button_DisplayCurrentHunt
            // 
            button_DisplayCurrentHunt.Location = new Point(121, 242);
            button_DisplayCurrentHunt.Name = "button_DisplayCurrentHunt";
            button_DisplayCurrentHunt.Size = new Size(90, 40);
            button_DisplayCurrentHunt.TabIndex = 9;
            button_DisplayCurrentHunt.Text = "See current Hunt";
            button_DisplayCurrentHunt.UseVisualStyleBackColor = true;
            button_DisplayCurrentHunt.Click += button_DisplayCurrentHuntClick;
            // 
            // button_EraseLastStep
            // 
            button_EraseLastStep.Location = new Point(227, 242);
            button_EraseLastStep.Name = "button_EraseLastStep";
            button_EraseLastStep.Size = new Size(90, 40);
            button_EraseLastStep.TabIndex = 10;
            button_EraseLastStep.Text = "Erase last Step";
            button_EraseLastStep.UseVisualStyleBackColor = true;
            button_EraseLastStep.Click += button_RedoHunt_Click;
            // 
            // button_SaveHunt
            // 
            button_SaveHunt.Location = new Point(334, 242);
            button_SaveHunt.Name = "button_SaveHunt";
            button_SaveHunt.Size = new Size(90, 40);
            button_SaveHunt.TabIndex = 11;
            button_SaveHunt.Text = "Save Hunt";
            button_SaveHunt.UseVisualStyleBackColor = true;
            button_SaveHunt.Click += button_SaveHunt_Click;
            // 
            // THLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 297);
            Controls.Add(button_SaveHunt);
            Controls.Add(button_EraseLastStep);
            Controls.Add(button_DisplayCurrentHunt);
            Controls.Add(button_NewHunt);
            Controls.Add(groupBox_Clue);
            Controls.Add(groupBox_Coordinates);
            Controls.Add(comboBox_Language);
            Controls.Add(label_Language);
            Controls.Add(comboBox_HuntLevel);
            Controls.Add(label_HuntLevel);
            Controls.Add(label_THLogger);
            KeyPreview = true;
            MaximumSize = new Size(452, 336);
            MinimumSize = new Size(452, 336);
            Name = "THLogs";
            Text = "Treasure Hunt funsies";
            Load += THLogs_Load;
            groupBox_Coordinates.ResumeLayout(false);
            groupBox_Coordinates.PerformLayout();
            groupBox_Clue.ResumeLayout(false);
            groupBox_Clue.PerformLayout();
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
        private ComboBox comboBox_Clues;
        private GroupBox groupBox_Clue;
        private Button button_NewHunt;
        private Button button_DisplayCurrentHunt;
        private Button button_EraseLastStep;
        private Button button_SaveHunt;
        private Label label_Result;
    }
}
