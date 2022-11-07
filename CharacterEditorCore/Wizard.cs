
using MongoDB.Bson.Serialization;

namespace CharacterEditorCore
{
    public class Wizard : Character
    {
        public Wizard() : base(new Characteristics(10, 45, 10),
                               new Characteristics(20, 70, 20),
                               new Characteristics(15, 60, 15),
                               new Characteristics(35, 250, 35),
                               1, 3, 0.5, 0, 1,
                               3, 5, 2, new Level(50, 0), new List<Item> 
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
            this.ClassName = "Wizard";
        }
    }
}
