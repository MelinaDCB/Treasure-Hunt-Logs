using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Treasure_Hunt_Logs
{
    public partial class THLogs : Form
    {
        public THLogs()
        {
            InitializeComponent();
        }

        public CurrentHuntPreview chp;
        int HuntLevel = Properties.Settings.Default.Level;
        string cluePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clues_full.json");
        string SavePath = string.Empty;
        string language = Properties.Settings.Default.Language;
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
            Properties.Settings.Default.Language = selectedLanguage;
            Properties.Settings.Default.Save();
        }

        private void comboBox_HuntLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            HuntLevel = Int32.Parse(comboBox_HuntLevel.Text);
            Properties.Settings.Default.Level = HuntLevel;
            Properties.Settings.Default.Save();
        }

        private void THLogs_Load(object sender, EventArgs e)
        {
            ClueComboBoxLoad();
            comboBox_Language.DataSource = Languages;
            comboBox_Language.Text = language;
            comboBox_HuntLevel.Text = HuntLevel.ToString();
            comboBox_Clues.Text = "";
            hunt = new Hunt(HuntLevel, ListSteps);
            hunt.HuntLevel = HuntLevel;
        }

        private void ClueComboBoxLoad()
        {
            using (var sr = new StreamReader(cluePath))
            {
                var json = sr.ReadToEnd();
                cl = JsonSerializer.Deserialize<CluesList>(json);
            }
        }

        private async void button_AddLastHint_Click(object sender, EventArgs e)
        {
            if (comboBox_HuntLevel.Text != null && comboBox_Language.Text != null &&
            textBox_XCoordinate.Text != "" && textBox_YCoordinate.Text != "" &&
            comboBox_Clues.Text == "")
            {
                hunt.Steps.Add(AddStep(x, y, ""));
                UpdateSecondForm();
                label_Result.Text = "First Clue added successfuly, happy hunting !";
                CleanTextboxes();
                await Task.Delay(1000);
                label_Result.Text = "";
            }
        }

        private void button_DisplayCurrentHuntClick(object sender, EventArgs e)
        {
            if (chp == null || chp.IsDisposed)
            {
                chp = new CurrentHuntPreview();
                chp.StartPosition = FormStartPosition.Manual;
                Screen currentScreen = Screen.FromControl(this);

                // Calculate the position for the second form
                int newX = this.Location.X + this.Width + 10;
                int newY = this.Location.Y;
                Rectangle workingArea = currentScreen.WorkingArea;
                if (newX + chp.Width > workingArea.Right)
                {
                    newX = workingArea.Right - chp.Width;
                }
                if (newY + chp.Height > workingArea.Bottom)
                {
                    newY = workingArea.Bottom - chp.Height;
                }

                chp.Location = new Point(newX, newY);
                chp.CluesToShow = new List<string>();
                foreach (THStep ths in hunt.Steps)
                {
                    string data = $"{ths.X_Coordinate.ToString()}, {ths.Y_Coordinate.ToString()}, \"{ths.StepClue}\"";
                    chp.CluesToShow.Add(data);
                }
                chp.Show();
            }

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
                    UpdateSecondForm();
                }
            }
            else
            {
                MessageBox.Show("You don't have any step to erase !");
            }
        }

        private async void button_SaveHunt_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path.Combine(Properties.Settings.Default.FolderPath, $"HuntLogs.json")))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.FolderPath = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                    SavePath = Path.Combine(folderBrowserDialog.SelectedPath, $"HuntLogs.json");
                    using (FileStream fs = File.Create(SavePath))
                    {
                    }
                }
                CreateHunt(hunt);
                label_Result.Text = "Hunt added successfuly.";
                await Task.Delay(1000);
            }
            else
            {
                SavePath = Path.Combine(Properties.Settings.Default.FolderPath, $"HuntLogs.json");
                CreateHunt(hunt);
                label_Result.Text = "Hunt added successfuly.";
                await Task.Delay(1000);
            }
        }

        private void CreateHunt(Hunt hunt)
        {
            List<string> thslist = new List<string>();
            //[100, [2, 4, "Deer Skull"], [2, 13, "Bloody Handprint"], [4, 13, "Skull in a Hole"], [5, 13, "Sneaky Drheller"], [5, 22, "Striped Mushroom"],
            //[6, 22, "Smiley Flowers"], [7, 22, "Planted Pickaxe"], [8, 22, "Folded Paper Star"], [9, 22, "Folded Paper Star"], [10, 22, "Black and White Wheat"],
            //[11, 22, "Studded Belt"], [14, 22, ""]]

            foreach (THStep ths in hunt.Steps)
            {
                string data = $"[{ths.X_Coordinate.ToString()}, {ths.Y_Coordinate.ToString()}, \"{ths.StepClue}\"]";
                thslist.Add(data);
            }
            string HuntToSave = $"[{hunt.HuntLevel}, {string.Join(", ", thslist)}],\n";
            File.AppendAllText(SavePath, HuntToSave);
            hunt.Steps.Clear();
            ClearSecondForm();
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
                    y = Int16.Parse(textBox_YCoordinate.Text);
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
                    UpdateSecondForm();
                    label_Result.Text = "Clue added successfuly.";
                    await Task.Delay(1000);
                    CleanTextboxes();
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
                        UpdateSecondForm();
                        label_Result.Text = "Clue added successfuly.";
                        await Task.Delay(1000);
                        CleanTextboxes();
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

        private void UpdateSecondForm()
        {
            if (chp != null && !chp.IsDisposed)
            {
                chp.CluesToShow.Clear();
                foreach (THStep ths in hunt.Steps)
                {
                    string data = $"{ths.X_Coordinate.ToString()}, {ths.Y_Coordinate.ToString()}, \"{ths.StepClue}\"";
                    chp.CluesToShow.Add(data);
                }
                chp.UpdateDisplay();
            }
        }

        private void ClearSecondForm()
        {
            if (chp != null && !chp.IsDisposed)
            {
                chp.NewHunt();
            }
        }

        private void textBox_XCoordinate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText();

                if (!string.IsNullOrEmpty(clipboardText))
                {
                    string x_c = clipboardText.Split(' ')[1];
                    string y_c = clipboardText.Split(' ')[2];

                    textBox_XCoordinate.Text = x_c;
                    textBox_YCoordinate.Text = y_c;
                    x = Int16.Parse(x_c);
                    y = Int16.Parse(y_c);
                    comboBox_Clues.Focus();
                }
            }
        }

        private void textBox_YCoordinate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText();

                if (!string.IsNullOrEmpty(clipboardText))
                {
                    string x_c = clipboardText.Split(' ')[1];
                    string y_c = clipboardText.Split(' ')[2];

                    textBox_XCoordinate.Text = x_c;
                    textBox_YCoordinate.Text = y_c;
                    x = Int16.Parse(x_c);
                    y = Int16.Parse(y_c);
                    comboBox_Clues.Focus();
                }
            }
        }
    }
}