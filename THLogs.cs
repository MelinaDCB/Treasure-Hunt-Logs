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
        string cluePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clues_full.json");
        string SavePath = Properties.Settings.Default.SavedHuntsPath;
        List<string> Languages = ["Français", "English", "Español", "Deutsch", "Portugués"];
        CluesList cl = new CluesList();
        List<THStep> ListSteps = new List<THStep>();
        Hunt hunt;
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
            public Hunt(int huntLevel, List<THStep> steps)
            {
                HuntLevel = huntLevel;
                Steps = steps;
            }

            public int HuntLevel { get; set; }
            public List<THStep> Steps { get; set; }
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

        private async void button_NewHunt_Click(object sender, EventArgs e)
        {
            label_Result.Text = "New Hunt created !";
            hunt = new Hunt(HuntLevel, ListSteps);
            hunt.HuntLevel = HuntLevel;
            await Task.Delay(500);
            label_Result.Text = "";
        }

        private void button_DisplayCurrentHuntClick(object sender, EventArgs e)
        {
            CurrentHuntPreview chp = new CurrentHuntPreview();
            chp.CluesToShow = new List<string>();
            foreach (THStep ths in hunt.Steps)
            {
                string data = $"{ths.X_Coordinate.ToString()}, {ths.Y_Coordinate.ToString()}, \"{ths.StepClue}\"";
                chp.CluesToShow.Add(data);
            }
            chp.ShowDialog();
        }

        private void button_RedoHunt_Click(object sender, EventArgs e)
        {
            int stepcount = hunt.Steps.Count;
            if (stepcount > 0)
            {
                string laststep = $"{hunt.Steps[stepcount - 1].X_Coordinate.ToString()}, {hunt.Steps[stepcount - 1].Y_Coordinate.ToString()}, \"{hunt.Steps[stepcount - 1].StepClue}\"";
                string mbtext = $"Are you sure you want to delete the last step ? {laststep}";
                DialogResult dr = MessageBox.Show(mbtext, "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    hunt.Steps.RemoveAt(stepcount - 1);
                }
            }
            else
            {
                MessageBox.Show("You don't have any step to erase !");
            }
        }

            

        private void button_SaveHunt_Click(object sender, EventArgs e)
        {
            if (SavePath == "")
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    SavePath = folderBrowserDialog.SelectedPath;
                }

                //OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.Filter = "json files (*.json)";
                //openFileDialog.RestoreDirectory = true;
                //openFileDialog.Title = "Please Select the JSON File you want to save the data to :"
                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //{
                //    SavePath = openFileDialog.FileName;
                //}
            }
            else
            {
                CreateHunt(hunt);
            }
        }

        private void CreateHunt(Hunt hunt)
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

        private async void comboBox_Clues_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_HuntLevel.Text != null && comboBox_Language.Text != null &&
            textBox_XCoordinate.Text != "" && textBox_YCoordinate.Text != "" &&
            comboBox_Clues.Text != null)
            {
                try
                {
                    hunt.Steps.Add(AddStep(x, y, comboBox_Clues.Text));
                    label_Result.Text = "Clue added successfuly.";
                    CleanTextboxes();
                    await Task.Delay(1000);
                    label_Result.Text = "";

                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show("Do you want to start a new hunt ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        hunt = new Hunt(HuntLevel, ListSteps);
                        hunt.HuntLevel = HuntLevel;
                        hunt.Steps.Add(AddStep(x, y, comboBox_Clues.Text));
                        label_Result.Text = "Clue added successfuly.";
                        CleanTextboxes();
                        await Task.Delay(1000);
                        label_Result.Text = "";
                    }
                }
            }
        }

        private THStep AddStep(int x, int y, string clue)
        {
            THStep ths = new THStep(x, y, clue);
            return ths;
        }

        private void CleanTextboxes()
        {
            textBox_XCoordinate.Clear();
            textBox_YCoordinate.Clear();
            comboBox_Clues.SelectedIndex = -1;
        }
    }
}
