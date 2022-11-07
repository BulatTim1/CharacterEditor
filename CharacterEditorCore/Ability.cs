using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorCore
{
    public class Ability
    {
        private string _name;
        [BsonIgnoreIfNull]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        
        private string _description;
        [BsonIgnoreIfNull]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public Requires _requires;
        [BsonIgnoreIfNull]
        public Requires Requires
        {
            get
            {
                return _requires;
            }
            set
            {
                _requires = value;
            }
        }

        private Bonus _bonus;
        [BsonIgnoreIfNull]
        public Bonus Bonus
        {
            get
            {
                return _bonus;
            }
            set
            {
                _bonus = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }

    }
}
