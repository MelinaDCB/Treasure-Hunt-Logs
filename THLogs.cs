using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Treasure_Hunt_Logs
{
    public partial class THLogs : Form
    {
        public THLogs()
        {
            InitializeComponent();
        }

        //[100, [2, 4, "Deer Skull"], [2, 13, "Bloody Handprint"], [4, 13, "Skull in a Hole"], [5, 13, "Sneaky Drheller"], [5, 22, "Striped Mushroom"],
        //[6, 22, "Smiley Flowers"], [7, 22, "Planted Pickaxe"], [8, 22, "Folded Paper Star"], [9, 22, "Folded Paper Star"], [10, 22, "Black and White Wheat"],
        //[11, 22, "Studded Belt"], [14, 22, ""]]
        int HuntLevel = 0;
        string cluePath = "C:\\Users\\melin\\OneDrive\\Documents\\Projets\\Treasure Hunt Logs\\clues_full.json";
        string SavePath = "";
        List<string> Languages = ["Français", "English", "Español", "Deutsch", "Portugués"];
        CluesList cl = new CluesList();
        Hunt hunt = new Hunt();
        int x;
        int y;

        public class THStep
        {
            public THStep(int x_Coordinate, int y_Coordinate, string stepClue)
            {
                X_Coordinate = x_Coordinate;
                Y_Coordinate = y_Coordinate;
                StepClue = stepClue;
            }

            public int X_Coordinate { get; set; }
            public int Y_Coordinate { get; set; }
            public string StepClue { get; set; }

        }

        public class Hunt
        {
            public int HuntLevel { get; set; }
            List<THStep> Steps { get; set; }
        }

        public class Clue
        {
            [JsonPropertyName("clue-id")]
            public int ClueID { get; set; }
            [JsonPropertyName("name-fr")]
            public string FrenchText { get; set; }
            [JsonPropertyName("name-en")]
            public string EnglishText { get; set; }
            [JsonPropertyName("name-es")]
            public string SpanishText { get; set; }
            [JsonPropertyName("name-de")]
            public string GermanText { get; set; }
            [JsonPropertyName("name-pt")]
            public string PortugueseText { get; set; }

        }

        public class CluesList
        {
            [JsonPropertyName("clues")]
            public List<Clue> Clues { get; set; }
        }


        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedLanguage = comboBox_Language.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedLanguage) && cl.Clues != null)
            {
                var filteredClues = cl.Clues.Select(clue =>
                {
                    return selectedLanguage switch
                    {
                        "Français" => clue.FrenchText,
                        "English" => clue.EnglishText,
                        "Español" => clue.SpanishText,
                        "Deutsch" => clue.GermanText,
                        "Portugués" => clue.PortugueseText,
                        _ => null
                    };
                }).Where(text => !string.IsNullOrEmpty(text)).ToList();

                comboBox_Clues.Items.Clear();
                comboBox_Clues.Items.AddRange(filteredClues.ToArray());

                comboBox_Clues.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox_Clues.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                comboBox_Clues.Items.Clear();
            }
        }

        private void comboBox_HuntLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            HuntLevel = Int32.Parse(comboBox_HuntLevel.Text);
        }

        private void THLogs_Load(object sender, EventArgs e)
        {
            ClueComboBoxLoad();
            comboBox_Language.DataSource = Languages;
            comboBox_HuntLevel.SelectedIndex = 5;
            comboBox_Language.Text = "";
            comboBox_Clues.Text = "";
        }

        private void ClueComboBoxLoad()
        {
            using (var sr = new StreamReader(cluePath))
            {
                var json = sr.ReadToEnd();
                cl = JsonSerializer.Deserialize<CluesList>(json);
            }

        }

        private void button_NewHunt_Click(object sender, EventArgs e)
        {
            hunt.HuntLevel = HuntLevel;
        }

        private void button_DisplayCurrentHuntClick(object sender, EventArgs e)
        {
            CurrentHuntPreview chp = new CurrentHuntPreview();
            chp.Show();
        }

        private void button_RedoHunt_Click(object sender, EventArgs e)
        {
            //Messagebox to show the last step and make sure they want it erased
        }

        private void button_SaveHunt_Click(object sender, EventArgs e)
        {

        }

        private void textBox_XCoordinate_Leave(object sender, EventArgs e)
        {
            if (textBox_XCoordinate.Text != "")
            {
                try
                {
                    x = Int16.Parse(textBox_XCoordinate.Text);
                }
                catch (Exception ex)
                {
                    textBox_XCoordinate.Text = "";
                    MessageBox.Show("Please enter a valid coordinate");
                }
            }

        }

        private void textBox_YCoordinate_Leave(object sender, EventArgs e)
        {
            if (textBox_YCoordinate.Text != "")
            {
                try
                {
                    y = Int16.Parse(textBox_XCoordinate.Text);
                }
                catch (Exception ex)
                {
                    textBox_YCoordinate.Text = "";
                    MessageBox.Show("Please enter a valid coordinate");
                }
            }

        }
    }
}
