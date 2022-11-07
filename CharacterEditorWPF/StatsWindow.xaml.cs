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
    public partial class StatsWindow : Window
    {
        public Character tempChar;
        public StatsWindow(Character character)
        {
            tempChar = character;
            InitializeComponent();
            strengthPlus.Click += StatsController;
            strengthMinus.Click += StatsController;
            dexterityPlus.Click += StatsController;
            dexterityMinus.Click += StatsController;
            intelligencePlus.Click += StatsController;
            intelligenceMinus.Click += StatsController;
            constitutionPlus.Click += StatsController;
            constitutionMinus.Click += StatsController;
            UpdateStats();
        }

        private void StatsController(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var stat = button.Name.Split(new char[] { 'P', 'M' })[0];
            var operation = button.Name.Split(new char[] { 'P', 'M' })[1];
            switch (stat)
            {
                case "strength":
                    if (operation == "lus")
                    {
                        if (int.Parse(availablePoints.Content.ToString()) > 0) tempChar.Strength.Value++;
                    }
                    else
                    {
                        tempChar.Strength.Value--;
                    }
                    break;
                case "dexterity":
                    if (operation == "lus")
                    {
                        if (int.Parse(availablePoints.Content.ToString()) > 0) tempChar.Dexterity.Value++;
                    }
                    else
                    {
                        tempChar.Dexterity.Value--;
                    }
                    break;
                case "intelligence":
                    if (operation == "lus")
                    {
                        if (int.Parse(availablePoints.Content.ToString()) > 0) tempChar.Intelligence.Value++;
                    }
                    else
                    {
                        tempChar.Intelligence.Value--;
                    }
                    break;
                case "constitution":
                    if (operation == "lus")
                    {
                        if (int.Parse(availablePoints.Content.ToString()) > 0) tempChar.Constitution.Value++;
                    }
                    else
                    {
                        tempChar.Constitution.Value--;
                    }
                    break;
            }
            UpdateStats();
        }

        private void UpdateStats()
        {
            expBox.Text = tempChar.Level.Experience.ToString();
            strengthBox.Text = tempChar.Strength.Value.ToString();
            dexterityBox.Text = tempChar.Dexterity.Value.ToString();
            intelligenceBox.Text = tempChar.Intelligence.Value.ToString();
            constitutionBox.Text = tempChar.Constitution.Value.ToString();
            availablePoints.Content = (10 + (tempChar.Level.Value - 1) +
                tempChar.Strength.MinValue +
                tempChar.Dexterity.MinValue +
                tempChar.Intelligence.MinValue +
                tempChar.Intelligence.MinValue -
                tempChar.Strength.Value -
                tempChar.Dexterity.Value -
                tempChar.Intelligence.Value -
                tempChar.Constitution.Value).ToString();
        }

        private void addExp1000_Click(object sender, RoutedEventArgs e)
        {
            tempChar.Level.Experience += 1000;
            UpdateStats();
        }

        private void addExp3000_Click(object sender, RoutedEventArgs e)
        {
            tempChar.Level.Experience += 3000;
            UpdateStats();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            tempChar.Strength.Value = tempChar.Strength.MinValue;
            tempChar.Dexterity.Value = tempChar.Dexterity.MinValue;
            tempChar.Intelligence.Value = tempChar.Intelligence.MinValue;
            tempChar.Constitution.Value = tempChar.Constitution.MinValue;
            UpdateStats();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (availablePoints.Content.ToString().Contains('-'))
                    throw new Exception("Decrease points on characteristics!");
                tempChar.Level.Experience = int.Parse(expBox.Text);
                tempChar.Strength.Value = int.Parse(strengthBox.Text);
                tempChar.Dexterity.Value = int.Parse(dexterityBox.Text);
                tempChar.Intelligence.Value = int.Parse(intelligenceBox.Text);
                tempChar.Constitution.Value = int.Parse(constitutionBox.Text);
                DialogResult = true;
                this.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }

        private void expBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (expBox.Text != "0")
                {
                    expBox.Text = Math.Min(Math.Max(int.Parse(expBox.Text), 0), tempChar.Level.MaxExp).ToString();
                    tempChar.Level.Experience = int.Parse(expBox.Text);
                    UpdateStats();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }

        private void strengthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //TODO: then decrease level and strength and some another characteristics
                //cause a bug when strengthBox = 27 and Strength.Value = 27 but Strength.MinValue = 30 and its recurses
                if (strengthBox.Text != "0")
                {
                    strengthBox.Text = Math.Min(Math.Max(int.Parse(strengthBox.Text), tempChar.Strength.MinValue),
                        Math.Min(tempChar.Strength.MaxValue, tempChar.Strength.Value + int.Parse(availablePoints.Content.ToString()))).ToString();
                    tempChar.Strength.Value = int.Parse(strengthBox.Text);
                    UpdateStats();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }

        private void dexterityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (dexterityBox.Text != "0")
                {
                    dexterityBox.Text = Math.Min(Math.Max(int.Parse(dexterityBox.Text), tempChar.Dexterity.MinValue),
                        Math.Min(tempChar.Dexterity.MaxValue, tempChar.Dexterity.Value + int.Parse(availablePoints.Content.ToString()))).ToString();
                    tempChar.Dexterity.Value = int.Parse(dexterityBox.Text);
                    UpdateStats();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }

        private void constitutionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (constitutionBox.Text != "0")
                {
                    constitutionBox.Text = Math.Min(Math.Max(int.Parse(constitutionBox.Text), tempChar.Constitution.MinValue),
                        Math.Min(tempChar.Constitution.MaxValue, tempChar.Constitution.Value + int.Parse(availablePoints.Content.ToString()))).ToString();
                    tempChar.Constitution.Value = int.Parse(constitutionBox.Text);
                    UpdateStats();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }

        private void intelligenceBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (intelligenceBox.Text != "0")
                {
                    intelligenceBox.Text = Math.Min(Math.Max(int.Parse(intelligenceBox.Text), tempChar.Intelligence.MinValue),
                        Math.Min(tempChar.Intelligence.MaxValue, tempChar.Intelligence.Value + int.Parse(availablePoints.Content.ToString()))).ToString();
                    tempChar.Intelligence.Value = int.Parse(intelligenceBox.Text);
                    UpdateStats();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: " + excep.Message);
            }
        }
    }
}
