namespace Treasure_Hunt_Logs
{
    partial class CurrentHuntPreview
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
            richTextBox_clues = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox_clues
            // 
            richTextBox_clues.Location = new Point(0, 0);
            richTextBox_clues.Name = "richTextBox_clues";
            richTextBox_clues.ReadOnly = true;
            richTextBox_clues.Size = new Size(261, 247);
            richTextBox_clues.TabIndex = 0;
            richTextBox_clues.Text = "";
            // 
            // CurrentHuntPreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 248);
            Controls.Add(richTextBox_clues);
            Name = "CurrentHuntPreview";
            Text = "Current Hunt";
            Load += CurrentHuntPreview_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox_clues;
    }
}