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
    // TODO: then item equiped dont change item
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public Character tempChar;
        public InventoryWindow(Character character)
        {
            tempChar = character;
            InitializeComponent();
            UpdateItems();
        }

        private void UpdateItems()
        {
            if (tempChar.HeadArmor != null)
            {
                headBtn.Content = "Delete " + tempChar.HeadArmor.Name;
                headBtn.IsEnabled = true;
            }
            if (tempChar.ChestArmor != null)
            {
                chestBtn.Content = "Delete " + tempChar.ChestArmor.Name;
                chestBtn.IsEnabled = true;
            }
            if (tempChar.Weapon != null)
            {
                weaponBtn.Content = "Delete " + tempChar.Weapon.Name;
                weaponBtn.IsEnabled = true;
            }

            InvetnoryList.UnselectAll();
            addBtn.IsEnabled = false;
            InvetnoryList.Items.Clear();
            foreach (var item in tempChar.Inventory)
            {
                InvetnoryList.Items.Add(item);
            }
            InvetnoryList.Items.Refresh();
        }
        Item tempItem;
        private void InvetnoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InvetnoryList.SelectedIndex != -1)
            {
                tempItem = tempChar.Inventory[InvetnoryList.SelectedIndex];
                addBtn.IsEnabled = true;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (tempItem != null && (tempItem.Requires == null || tempItem.Requires.CheckRequirements(tempChar)))
            {
                if (tempItem.Type == "HeadArmor" && tempChar.HeadArmor == null)
                {
                    tempChar.HeadArmor = tempItem;
                    tempChar.Inventory.Remove(tempItem);
                    tempItem = null;
                }
                else if (tempItem.Type == "ChestArmor" && tempChar.ChestArmor == null)
                {
                    tempChar.ChestArmor = tempItem;
                    tempChar.Inventory.Remove(tempItem);
                    tempItem = null;
                }
                else if (tempItem.Type == "Weapon" && tempChar.Weapon == null)
                {
                    tempChar.Weapon = tempItem;
                    tempChar.Inventory.Remove(tempItem);
                    tempItem = null;
                }
                else
                {
                    MessageBox.Show("This item can't be equipped");
                }
            }
            else
            {
                MessageBox.Show("This item can't be equipped");
            }
            UpdateItems();
        }
        
        private void DelHeadArmor_Click(object sender, RoutedEventArgs e)
        {
            if (tempChar.HeadArmor != null)
            {
                tempChar.Inventory.Add(tempChar.HeadArmor);
                tempChar.HeadArmor = null;
                UpdateItems();
            }
            headBtn.IsEnabled = false;
        }

        private void DelChestArmor_Click(object sender, RoutedEventArgs e)
        {
            if (tempChar.ChestArmor != null)
            {
                tempChar.Inventory.Add(tempChar.ChestArmor);
                tempChar.ChestArmor = null;
                UpdateItems();
            }
            chestBtn.IsEnabled = false;
        }

        private void DelWeapon_Click(object sender, RoutedEventArgs e)
        {
            if (tempChar.Weapon != null)
            {
                tempChar.Inventory.Add(tempChar.Weapon);
                tempChar.Weapon = null;
                UpdateItems();
            }
            weaponBtn.IsEnabled = false;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            DelChestArmor_Click(sender, e);
            DelHeadArmor_Click(sender, e);
            DelWeapon_Click(sender, e);
            UpdateItems();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Leather Helmet",
                    Type = "HeadArmor",
                    Description = "A simple leather helmet",
                    Bonus = new Bonus() { HpBonus = 10, StrBonus = 5 },
                    Requires = new Requires(new Dictionary<string, int>() { { "strength", 10 }, { "level", 2} })
                });
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Iron Helmet",
                    Type = "HeadArmor",
                    Description = "A simple iron helmet",
                    Bonus = new Bonus() { HpBonus = 20, StrBonus = 10 },
                    Requires = new Requires(new Dictionary<string, int>() { { "strength", 20 }, { "level", 4 } })
                });
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Leather Plate",
                    Type = "ChestArmor",
                    Description = "A simple leather plate",
                    Bonus = new Bonus() { HpBonus = 10, StrBonus = 5 },
                    Requires = new Requires(new Dictionary<string, int>() { { "strength", 10 }, { "level", 2 } })
                });
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Iron Plate",
                    Type = "ChestArmor",
                    Description = "A simple iron plate",
                    Bonus = new Bonus() { HpBonus = 20, StrBonus = 10 },
                    Requires = new Requires(new Dictionary<string, int>() { { "strength", 20 }, { "level", 4 } })
                });
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Dagger",
                    Type = "Weapon",
                    Description = "A simple dagger",
                    Bonus = new Bonus() { HpBonus = 10, StrBonus = 5 },
                    Requires = new Requires(new Dictionary<string, int>() { { "strength", 10 }, { "level", 2 } })
                });
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Sword",
                    Type = "Weapon",
                    Description = "A simple sword",
                    Bonus = new Bonus() { HpBonus = 20, StrBonus = 10 },
                    Requires = new Requires(new Dictionary<string, int>() { { "strength", 20 }, { "level", 4 } })
                });
            tempChar.Inventory.Add(
                new Item()
                {
                    Name = "Bow",
                    Type = "Weapon",
                    Description = "A simple bow",
                    Bonus = new Bonus() { DexBonus = 20, ConBonus = 10 },
                    Requires = new Requires(new Dictionary<string, int>() { { "dexterity", 20 }, { "level", 5 } })
                });
            UpdateItems();
        }
    }
}
