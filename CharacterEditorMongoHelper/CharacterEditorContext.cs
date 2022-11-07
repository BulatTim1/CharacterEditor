using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using System.Xml.Linq;

namespace CharacterEditorMongoHelper
{
    public class CharacterEditorContext
    {
        public bool AddCharacterToDb(Character character)
        {
            try
            {
                MongoDBHelper.collection.InsertOne((Character)character);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<KeyValuePair<string, string>> GetAllCharactersIDWithName()
        {
            //TODO: when db is off catch exception
            try
            {
                List<Character> chars = MongoDBHelper.collection.Find(new BsonDocument()).ToList();
                var characters = new List<KeyValuePair<string, string>>();
                foreach (var i in chars)
                {
                    characters.Add(new KeyValuePair<string, string>(i.Id, i.Name));
                }
                return characters;
            }
            catch { }
            return new List<KeyValuePair<string, string>>();
        }

        public List<Character> GetAllCharacters()
        {
            var characters = MongoDBHelper.collection.Find(new BsonDocument()).ToList();
            return characters;
            try
            {
            }
            catch { }
            return new List<Character>();
        }

        public bool DeleteCharacter(string id)
        {
            try
            {
                MongoDBHelper.collection.DeleteOne(new BsonDocument("_id", new ObjectId(id)));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Character GetCharacter(string characterId)
        {
            try
            {
                var characterDb = MongoDBHelper.collection.Find(x => x.Id == characterId).FirstOrDefault();
                Character tempChar;
                switch (characterDb.ClassName)
                {
                    case "Warrior":
                        tempChar = new Warrior() 
                        {
                            Id = characterDb.Id,
                            Name = characterDb.Name,
                            ClassName = characterDb.ClassName,
                            Strength = characterDb.Strength,
                            Dexterity = characterDb.Dexterity,
                            Intelligence = characterDb.Intelligence,
                            Constitution = characterDb.Constitution,
                            Abilities = characterDb.Abilities,
                            Inventory = characterDb.Inventory,
                            HeadArmor = characterDb.HeadArmor,
                            ChestArmor = characterDb.ChestArmor,
                            Weapon = characterDb.Weapon,
                            Level = characterDb.Level,
                        };
                        break;
                    case "Rogue":
                        tempChar = new Rogue()
                        {
                            Id = characterDb.Id,
                            Name = characterDb.Name,
                            ClassName = characterDb.ClassName,
                            Strength = characterDb.Strength,
                            Dexterity = characterDb.Dexterity,
                            Intelligence = characterDb.Intelligence,
                            Constitution = characterDb.Constitution,
                            Abilities = characterDb.Abilities,
                            Inventory = characterDb.Inventory,
                            HeadArmor = characterDb.HeadArmor,
                            ChestArmor = characterDb.ChestArmor,
                            Weapon = characterDb.Weapon,
                            Level = characterDb.Level,
                        };
                        break;
                    case "Wizard":
                        tempChar = new Wizard()
                        {
                            Id = characterDb.Id,
                            Name = characterDb.Name,
                            ClassName = characterDb.ClassName,
                            Strength = characterDb.Strength,
                            Dexterity = characterDb.Dexterity,
                            Intelligence = characterDb.Intelligence,
                            Constitution = characterDb.Constitution,
                            Abilities = characterDb.Abilities,
                            Inventory = characterDb.Inventory,
                            HeadArmor = characterDb.HeadArmor,
                            ChestArmor = characterDb.ChestArmor,
                            Weapon = characterDb.Weapon,
                            Level = characterDb.Level,
                        };
                        break;
                    default:
                        tempChar = characterDb;
                        break;
                }
                return tempChar;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateCharacter(string id, Character newCharacter)
        {
            var filter = Builders<Character>.Filter.Eq(x => x.Id, id);
            newCharacter.Id = id;
            MongoDBHelper.collection.ReplaceOne(new BsonDocument("_id", new ObjectId(id)),
                newCharacter);
            return true;
        }
    }
}