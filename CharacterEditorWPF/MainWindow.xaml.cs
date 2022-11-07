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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CharacterEditorCore;
using CharacterEditorMongoHelper;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace CharacterEditorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static CharacterEditorContext context = new CharacterEditorContext();
        static Character? tempChar;
        static string charId;
        public MainWindow()
        {
            InitializeComponent();
            InitializeBsonMap();
            UpdateCharacters();
        }

        private void InitializeBsonMap()
        {
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Warrior>();
            
            BsonClassMap.RegisterClassMap<Match>();

            BsonClassMap.RegisterClassMap<Requires>();
            BsonClassMap.RegisterClassMap<Level>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(l => new Level(l.MaxLevel, l.Experience));
                });
            BsonClassMap.RegisterClassMap<Item>();
            BsonClassMap.RegisterClassMap<Bonus>();
            BsonClassMap.RegisterClassMap<Characteristics>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(c => new Characteristics(c.MinValue, c.MaxValue, c.Value));
                });
        }
        
        private void UpdateCharacters()
        {
            tempChar = null;
            CharactersList.UnselectAll();
            CharactersList.Items.Clear();
            CharactersList.Items.Add(new KeyValuePair<string, string>("", "Add new character"));
            CharacterClass.SelectedIndex = -1;
            foreach (var character in context.GetAllCharactersIDWithName())
            {
                CharactersList.Items.Add(character);
            }
            CharactersList.Items.Refresh();

            CharacterName.Text = "";
            CharacterId.Content = "ID: ";
            CharacterClass.SelectedIndex = -1;
        }  

        private void GetCharactersBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCharacters();
        }

        private void CreateTestCharactersBtn_Click(object sender, RoutedEventArgs e)
        {
            //var char1 = new Warrior();
            //var char2 = new Wizard();
            //var char3 = new Rogue();
            //char1.Name = "WarriorTest";
            //char2.Name = "WizardTest";
            //char3.Name = "RogueTest";
            //context.AddCharacterToDb(char1);
            //context.AddCharacterToDb(char2);
            //context.AddCharacterToDb(char3);
            //UpdateCharacters();

            this.Hide();
            var battleWindow = new BattleWindow();
            if (battleWindow.ShowDialog() != null)
            {
                this.Show();
            }
        }

        private void listCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharactersList.SelectedValue != null && CharactersList.SelectedIndex != 0)
            {
                charId = ((KeyValuePair<string, string>)CharactersList.SelectedValue).Key;
                tempChar = context.GetCharacter(charId);
                CharacterName.Text = tempChar.Name;
                CharacterId.Content = $"ID: {charId}";

                //CharacterClass indexes: 0 - Rogue, 1 - Wizard, 2 - Warrior
                switch(tempChar.ClassName)
                {
                    case "Rogue":
                        CharacterClass.SelectedIndex = 0;
                        break;
                    case "Wizard":
                        CharacterClass.SelectedIndex = 1;
                        break;
                    case "Warrior":
                        CharacterClass.SelectedIndex = 2;
                        break;
                    default:
                        CharacterClass.SelectedIndex = -1;
                        break;
                }
                CharacterClass.IsEnabled = false;
            }
            else
            {
                charId = "";
                CharacterId.Content = "ID:";
                CharacterClass.IsEnabled = true;
            }
        }

        private void CharacterSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            tempChar.Name = CharacterName.Text;
            if (charId == "")
            {
                context.AddCharacterToDb(tempChar);
            } else
            {
                context.UpdateCharacter(charId, tempChar);
            }
            UpdateCharacters();
        }
        
        private void CharacterDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (charId != "")
            {
                context.DeleteCharacter(charId);
                UpdateCharacters();
            }
        }

        private void CharacterStatsBtn_Click(object sender, RoutedEventArgs e)
        {
            Character newChar;

            if (tempChar == null)
            {
                MessageBox.Show("Choose class!");
                return;
            }
            this.Hide();
            var stats = new StatsWindow(tempChar.DeepCopy());
            var res = stats.ShowDialog();
            if (res == true)
            {
                tempChar = stats.tempChar;
                context.UpdateCharacter(charId, tempChar);
                
            }
            this.Show();
        }

        private void CharacterAbilitiesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tempChar == null)
            {
                MessageBox.Show("Choose class!");
                return;
            }
            this.Hide();
            var abilityWindow = new AbilityWindow(tempChar.DeepCopy());
            if (abilityWindow.ShowDialog() == true)
            {
                tempChar = abilityWindow.tempChar;
                context.UpdateCharacter(charId, tempChar);
            }
            this.Show();
        }

        private void CharacterClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CharacterClass.SelectedIndex)
            {
                case 0:
                    CharacterStatsBtn.IsEnabled = true;
                    CharacterAbilitiesBtn.IsEnabled = true;
                    CharacterInventoryBtn.IsEnabled = true;
                    CharacterSaveBtn.IsEnabled = true;
                    CharacterDeleteBtn.IsEnabled = true;
                    if (tempChar == null) tempChar = new Rogue();
                    break;
                case 1:
                    CharacterStatsBtn.IsEnabled = true;
                    CharacterAbilitiesBtn.IsEnabled = true;
                    CharacterInventoryBtn.IsEnabled = true;
                    CharacterSaveBtn.IsEnabled = true;
                    CharacterDeleteBtn.IsEnabled = true;
                    if (tempChar == null) tempChar = new Wizard();
                    break;
                case 2:
                    CharacterStatsBtn.IsEnabled = true;
                    CharacterAbilitiesBtn.IsEnabled = true;
                    CharacterInventoryBtn.IsEnabled = true;
                    CharacterSaveBtn.IsEnabled = true;
                    CharacterDeleteBtn.IsEnabled = true;
                    if (tempChar == null) tempChar = new Warrior();
                    break;
                default:
                    CharacterStatsBtn.IsEnabled = false;
                    CharacterAbilitiesBtn.IsEnabled = false;
                    CharacterInventoryBtn.IsEnabled = false;
                    CharacterSaveBtn.IsEnabled = false;
                    CharacterDeleteBtn.IsEnabled = false;
                    break;
            }
        }

        private void CharacterInventoryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tempChar == null)
            {
                MessageBox.Show("Choose class!");
                return;
            }
            this.Hide();
            var inventoryWindow = new InventoryWindow(tempChar.DeepCopy());
            if (inventoryWindow.ShowDialog() == true)
            {
                tempChar = inventoryWindow.tempChar;
                context.UpdateCharacter(charId, tempChar);
            }
            this.Show();
        }
    }
}
