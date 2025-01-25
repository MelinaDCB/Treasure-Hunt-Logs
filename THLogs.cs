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
        List<string> Languages = ["Français", "English", "Español", "Deutsch", "Portugués"];


        public class THStep
        {
            public THStep(int x_Coordinate, int y_Coordinate, string stepClue)
            {
                X_Coordinate = x_Coordinate;
                Y_Coordinate = y_Coordinate;
                StepClue = stepClue;
            }

            public int HuntLevel { get; set; }
            public int X_Coordinate { get; set; }
            public int Y_Coordinate { get; set; }
            public string StepClue { get; set; }

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

            //Pick the right clues from the json file
        }

        private void comboBox_HuntLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            HuntLevel = Int32.Parse(comboBox_HuntLevel.Text);
        }

        private void THLogs_Load(object sender, EventArgs e)
        {
            comboBox_Language.Items.AddRange(Languages.ToArray());
            comboBox_Language.SelectedIndex = 1;
            comboBox_HuntLevel.SelectedIndex = 5;
            ClueComboBoxLoad();
        }

        private void ClueComboBoxLoad()
        {
            using (var sr = new StreamReader(cluePath))
            {
                var json = sr.ReadToEnd();
                var cl = JsonSerializer.Deserialize<CluesList>(json);

            }
        }

    }
}
