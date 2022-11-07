using CharacterEditorCore;
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
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class AbilityWindow : Window
    {
        public Character tempChar;
        private Ability[] abilitiesTemplate = new Ability[]
            {
                new Ability() {Name = "Strength", Bonus = new Bonus() {StrBonus = 10}, Requires = new Requires(new Dictionary<string, int>() {{"level", 2}})},
                new Ability() {Name = "Dexterity", Bonus = new Bonus() {DexBonus = 10}, Requires = new Requires(new Dictionary<string, int>() {{"level", 2}})},
                new Ability() {Name = "Constitution", Bonus = new Bonus() {ConBonus = 10}, Requires = new Requires(new Dictionary<string, int>() {{"level", 2}})},
                new Ability() {Name = "Intelligence", Bonus = new Bonus() {IntBonus = 10}, Requires = new Requires(new Dictionary<string, int>() {{"level", 2}})},
                //new Ability() { Name = "Strength", Description = "Test Ability for strength", MinLevel = 1, Bonus = new Bonus(){ StrBonus = 5}, Requires = new Dictionary<string, Characteristics>().Add("strength", 10) },
                //new Ability() { Name = "Dexterity", Description = "Test Ability for dexterity", MinLevel = 1, Bonus = new Bonus(){ DexBonus = 5} },
                //new Ability() { Name = "Constitution", Description = "Test Ability for constitution", MinLevel = 1, Bonus = new Bonus(){ ConBonus = 5} },
                //new Ability() { Name = "Intelligence", Description = "Test Ability for intelligence", MinLevel = 1, Bonus = new Bonus(){ IntBonus = 5} },
                //new Ability() { Name = "Health", Description = "Test Ability for health", MinLevel = 1, Bonus = new Bonus(){ HpBonus = 5} },
                //new Ability() { Name = "Mana", Description = "Test Ability for mana", MinLevel = 1, Bonus = new Bonus(){ ManaBonus = 5} },
                //new Ability() { Name = "Physical Damage", Description = "Test Ability for physical damage", MinLevel = 1, Bonus = new Bonus(){ PDamBonus = 5} },
                //new Ability() { Name = "Magical Damage", Description = "Test Ability for magical damage", MinLevel = 1, Bonus = new Bonus(){ MDamBonus = 5} },
                //new Ability() { Name = "Physical Defense", Description = "Test Ability for physical defense", MinLevel = 1, Bonus = new Bonus(){ PDefBonus = 5} },
                //new Ability() { Name = "Magical Defense", Description = "Test Ability for magical defense", MinLevel = 1, Bonus = new Bonus(){ MDefBonus = 5} }
            };
        
        public AbilityWindow(in Character character)
        {
            InitializeComponent();
            tempChar = character;
            UpdateStats();
        }
        
        private void UpdateAbilitites()
        {
            abilitiesList.Items.Clear();
            if (int.Parse(availablePoints.Content.ToString()) > 0)
            {
                foreach (var ability in abilitiesTemplate.ToArray())
                {
                    if (ability.Requires.CheckRequirements(tempChar)) abilitiesList.Items.Add(ability);
                }
            }
            abilitiesList.Items.Refresh();
            addBtn.IsEnabled = false;
        }

        private void UpdateStats()
        {
            try
            {
                availablePoints.Content = ((tempChar.Level.Value / 3) - tempChar.Abilities.Count).ToString();
            } 
            catch
            {
                tempChar.Abilities = new List<Ability>();
                availablePoints.Content = ((tempChar.Level.Value / 3) - tempChar.Abilities.Count).ToString();
            }
            UpdateAbilitites();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            UpdateStats();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogResult = true;
                this.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            tempChar.Abilities.Add((Ability)abilitiesList.SelectedItem);
            UpdateStats();
        }

        private void abilitiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addBtn.IsEnabled = true;
        }
    }
}
