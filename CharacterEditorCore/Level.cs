using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorCore
{
    public class Level
    {
        private int _maxLevel;
        private int _maxLevelExp;
        private int _experience;
        public Level(int maxLevel, int experience)
        {
            MaxLevel = maxLevel;
            _experience = experience;
        }

        [BsonIgnore]
        public int Value
        {
            get
            {
                int level = 1;
                int tempExp = 0;
                while (tempExp < _experience)
                {
                    tempExp += level * 1000;
                    level++;
                }
                return level; 
            }
            set
            {
                value = Math.Min(Math.Max(value, 1), _maxLevel);
                _experience = 0;
                for (int i = 1; i < value; i++)
                {
                    _experience += i * 1000;
                }
            }
        }
        public int MaxLevel
        {
            get { return _maxLevel; }
            set
            {
                _maxLevel = value;
                _maxLevelExp = 0;
                for (int i = 1; i < value; i++)
                {
                    _maxLevelExp += i * 1000;
                }
                if (_maxLevelExp < _experience)
                {
                    _experience = _maxLevelExp;
                }
            }
        }

        public int Experience
        {
            get { return _experience; }
            set
            {
                _experience = Math.Min(Math.Max(value, 0), _maxLevelExp);
            }
        }

        
        [BsonIgnore]
        public int MaxExp
        {
            get { return _maxLevelExp; }
        }
    }
}
