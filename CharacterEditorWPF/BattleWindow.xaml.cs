using CharacterEditorCore;
using CharacterEditorMongoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CharacterEditorWPF
{
    /// <summary>
    /// Interaction logic for Battle.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        static MatchesContext matchContext = new MatchesContext();
        static CharacterEditorContext context = new CharacterEditorContext();
        List<Character> characters;
        List<Character> charactersListCB;
        ComboBox[] comboBoxes;
        public BattleWindow()
        {
            InitializeComponent();
            characters = context.GetAllCharacters();
            charactersListCB = new List<Character>(characters);
            comboBoxes = new ComboBox[] { team1char1CB, team1char2CB,
                team1char3CB, team1char4CB, team1char5CB, team1char6CB,
                team2char1CB, team2char2CB, team2char3CB, team2char4CB,
                team2char5CB, team2char6CB};
            Update_ComboBoxes();
        }

        private bool updateFlag = true;
        private void Update_ComboBoxes()
        {
            updateFlag = true;
            foreach (var cb in comboBoxes)
            {
                int i = cb.SelectedIndex;
                cb.Items.Clear();
                foreach (var item in charactersListCB)
                {
                    cb.Items.Add(item);
                }
                cb.Items.Refresh();
                cb.SelectedIndex = i;
            }
            updateFlag = false;
        }

        private Character tempChar;
        private string tempCBName;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!updateFlag)
            {
                //var cb = (ComboBox)sender;
                //if (tempChar != null && cb.Name == tempCBName)
                //{
                //    charactersListCB.Add(tempChar);
                //    tempChar = null;
                //    tempCBName = "";
                //}
                //charactersListCB.Remove((Character)cb.SelectedItem);
                Update_ComboBoxes();
                BalanceCheck();
            }
        }

        private void BalanceCheck()
        {
            int lvlTeam1 = 0;
            int lvlTeam2 = 0;
            int countWarriorsTeam1 = 0;
            int countWarriorsTeam2 = 0;
            int countRoguesTeam1 = 0;
            int countRoguesTeam2 = 0;
            int countWizardsTeam1 = 0;
            int countWizardsTeam2 = 0;

            foreach (var cb in comboBoxes)
            {
                if (cb.SelectedIndex != -1)
                {
                    if (cb.Name.Contains("team1"))
                    {
                        lvlTeam1 += ((Character)cb.SelectedItem).Level.Value;
                        if (cb.SelectedItem is Warrior)
                        {
                            countWarriorsTeam1++;
                        }
                        else if (cb.SelectedItem is Rogue)
                        {
                            countRoguesTeam1++;
                        }
                        else if (cb.SelectedItem is Wizard)
                        {
                            countWizardsTeam1++;
                        }
                    }
                    else
                    {
                        lvlTeam2 += ((Character)cb.SelectedItem).Level.Value;
                        if (cb.SelectedItem is Warrior)
                        {
                            countWarriorsTeam2++;
                        }
                        else if (cb.SelectedItem is Rogue)
                        {
                            countRoguesTeam2++;
                        }
                        else if (cb.SelectedItem is Wizard)
                        {
                            countWizardsTeam2++;
                        }
                    }
                }
            }

            if (Math.Abs(lvlTeam1 - lvlTeam2) <= 1)
            {
                if (Math.Abs(countWarriorsTeam1 - countWarriorsTeam2) == 0)
                {
                    if (Math.Abs(countRoguesTeam1 - countRoguesTeam2) == 0)
                    {
                        if (Math.Abs(countWizardsTeam1 - countWizardsTeam2) == 0)
                        {
                            balanceLabel.Content = "Teams are balanced";
                            startBtn.IsEnabled = true;
                        }
                        else
                        {
                            balanceLabel.Content = "Wizards need to be balanced";
                            startBtn.IsEnabled = false;
                        }
                    }
                    else
                    {
                        balanceLabel.Content = "Rogues need to be balanced";
                        startBtn.IsEnabled = false;
                    }
                }
                else
                {
                    balanceLabel.Content = "Warriors need to be balanced";
                    startBtn.IsEnabled = false;
                }
            }
            else
            {
                balanceLabel.Content = "Level not balanced";
                startBtn.IsEnabled = false;
            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            charactersListCB = new List<Character>(characters);
            Update_ComboBoxes();
            foreach (var cb in comboBoxes)
            {
                cb.SelectedIndex = -1;
            }
            startBtn.IsEnabled = false;
        }
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Character> team1 = new List<Character>();
            List<Character> team2 = new List<Character>();
            foreach (var cb in comboBoxes)
            {
                if (cb.SelectedIndex != -1)
                {
                    if (cb.Name.Contains("team1"))
                    {
                        team1.Add((Character)cb.SelectedItem);
                    }
                    else
                    {
                        team2.Add((Character)cb.SelectedItem);
                    }
                }
            }
                
            matchContext.CreateMatch(
            new Match()
            {
                Team1 = team1,
                Team2 = team2,
                Date = DateTime.Now,
                Result = new Random().Next(0, 3)
            });
            clear_Click(sender, e);
        }
        private void history_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            new MatchesHistoryWindow().ShowDialog();
            this.IsEnabled = true;
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
        //    var cb = (ComboBox)sender;
        //    if (cb.SelectedIndex != -1)
        //    {
        //        tempChar = (Character)cb.SelectedItem;
        //        tempCBName = cb.Name;
        //    }
        }
    }
}
