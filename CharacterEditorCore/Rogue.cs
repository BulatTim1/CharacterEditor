
namespace CharacterEditorCore
{
    public class Rogue : Character
    {
        public Rogue() : base(new Characteristics(15, 55, 15),
                               new Characteristics(30, 250, 30),
                               new Characteristics(20, 80, 20),
                               new Characteristics(15, 70, 15),
                               1, 2, 1.5, 4, 0,
                               6, 2, 1.5, new Level(50, 0), new List<Item> 
                               { 
                                   new Item 
                                   {
                                       Name = "Dagger", 
                                       Amount = 1, 
                                       Type = "Weapon",
                                       Bonus = new Bonus
                                       {
                                           PDamBonus = 5,
                                           DexBonus = 3
                                       }
                                   } 
                               }, new List<Ability>())
        {
            this.ClassName = "Rogue";
        }
    }
}
