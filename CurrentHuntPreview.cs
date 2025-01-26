using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Treasure_Hunt_Logs
{
    public partial class CurrentHuntPreview : Form
    {
        public CurrentHuntPreview()
        {
            InitializeComponent();
        }

        public List<string> CluesToShow {  get; set; }

        private void CurrentHuntPreview_Load(object sender, EventArgs e)
        {
            foreach (var clue in CluesToShow)
            {
                richTextBox_clues.Lines = CluesToShow.ToArray();
            }
        }

        public void UpdateDisplay()
        {
            richTextBox_clues.Clear();
            foreach (var clue in CluesToShow)
            {
                richTextBox_clues.Lines = CluesToShow.ToArray();
            }
            //richTextBox_clues.Refresh();
        }

        public void RemoveLastStep()
        {
            richTextBox_clues.Lines = richTextBox_clues.Lines.Take(richTextBox_clues.Lines.Count() - 1).ToArray();
            richTextBox_clues.Update();
        }

        public void NewHunt()
        {
            richTextBox_clues.Clear();
        }

    }
}
