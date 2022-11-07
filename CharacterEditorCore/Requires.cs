using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Requires
    {
        private Dictionary<string, int> _requiresDict;
        [BsonIgnoreIfNull]
        public Dictionary<string, int> RequiresDict
        {
            get
            {
                return _requiresDict;
            }
            set
            {
                _requiresDict = value;
            }
        }

        public Requires(Dictionary<string, int> requiresDict)
        {
            _requiresDict = requiresDict;
        }

        public bool CheckRequirements(Character character)
        {
            foreach (var requirement in _requiresDict)
            {
                switch (requirement.Key)
                {
                    case "strength":
                        if (character.Strength.Value < requirement.Value)
                        {
                            return false;
                        }
                        break;
                    case "dexterity":
                        if (character.Dexterity.Value < requirement.Value)
                        {
                            return false;
                        }
                        break;
                    case "constitution":
                        if (character.Constitution.Value < requirement.Value)
                        {
                            return false;
                        }
                        break;
                    case "intelligence":
                        if (character.Intelligence.Value < requirement.Value)
                        {
                            return false;
                        }
                        break;
                    case "level":
                        if (character.Level.Value < requirement.Value)
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
    }
}
