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
    /// Interaction logic for MatchesHistoryWindow.xaml
    /// </summary>
    public partial class MatchesHistoryWindow : Window
    {
        static MatchesContext matchContext = new MatchesContext();
        public MatchesHistoryWindow()
        {
            InitializeComponent();
            UpdateMatches();
        }

        private void UpdateMatches()
        {
            matchesList.Items.Clear();
            var matches = matchContext.GetAllMatches();
            foreach (var match in matches)
            {
                matchesList.Items.Add(match);
            }
            matchesList.Items.Refresh();
        }

        private void matchesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var match = (Match)((ListView)sender).SelectedItem;
            matchTeam1.Items.Clear();
            matchTeam2.Items.Clear();
            foreach (var character in match.Team1)
            {
                matchTeam1.Items.Add(character);
            }
            foreach (var character in match.Team2)
            {
                matchTeam2.Items.Add(character);
            }
            matchTeam1.Items.Refresh();
            matchTeam2.Items.Refresh();
            switch (match.Result)
            {
                case 0:
                    resultLabel.Content = "Draw";
                    break;
                case 1:
                    resultLabel.Content = "Team 1 won";
                    break;
                case 2:
                    resultLabel.Content = "Team 2 won";
                    break;
                default:
                    resultLabel.Content = "Error";
                    break;
            }
        }

        private void matchTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var character = (Character)((ListView)sender).SelectedItem;
            string abilites = "";
            if (character.Abilities.Count() != 0)
            {
                abilites += "Abilities: ";
                foreach (var ability in character.Abilities)
                {
                    abilites += ability.Name + ", ";
                }
            }
            MessageBox.Show($"Character: {character.Name}\n" +
                $"Class: {character.ClassName}\n" +
                $"Strength: {character.FullStrength}\n" +
                $"Dexterity: {character.FullDexterity}\n" +
                $"Intelligence: {character.FullIntelligence}\n" +
                $"Constitution: {character.FullConstitution}\n" +
                $"Head Armor: {(character.HeadArmor != null ? character.HeadArmor.Name : "None")}\n" +
                $"Chest Armor: {(character.ChestArmor != null ? character.ChestArmor.Name : "None")}\n" +
                $"Weapon: {(character.Weapon != null ? character.Weapon.Name : "None")}\n" + abilites, 
                $"Character: {character.Name}");
        }
    }
}
