namespace CharacterEditorCore
{
    public class Warrior : Character
    {
        public Warrior() : base(new Characteristics(30, 250, 30),
                               new Characteristics(15, 70, 15),
                               new Characteristics(20,100,20),
                               new Characteristics(10,50,10),
                               2,5,1,1,2,
                               10,1,1, new Level(50, 0), new List<Item> 
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
            this.ClassName = "Warrior";
        }
    }
}
