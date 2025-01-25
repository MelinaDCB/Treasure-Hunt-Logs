using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
