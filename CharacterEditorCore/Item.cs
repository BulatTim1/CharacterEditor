using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorCore
{
    public class Item
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _description;
        [BsonIgnoreIfNull]
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        private int _amount;
        [BsonIgnoreIfNull]
        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        private string _type;
        public string Type
        {
            get => _type;
            set => _type = value;
        }

        private Bonus _bonus;
        [BsonIgnoreIfNull]
        public Bonus Bonus
        {
            get => _bonus;
            set => _bonus = value;
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
    }
}
