using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Characteristics = CharacterEditorCore.Characteristics;

namespace CharacterEditorCore
{
    public class Character
    {
        private string _id;
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {

            get => _id;
            set => _id = value;
        }
        
        private string _name;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        [BsonElement("_t")]
        public string ClassName;
        
        private Characteristics _strength;
        
        public Characteristics Strength
        {
            get {
                var fullStr = new Characteristics(_strength.MinValue, _strength.MaxValue, _strength.Value);
                if (HeadArmor != null)
                {
                    fullStr.Value += HeadArmor.Bonus.StrBonus;
                }
                if (ChestArmor != null)
                {
                    fullStr.Value += ChestArmor.Bonus.StrBonus;
                }
                if (Weapon != null)
                {
                    fullStr.Value += Weapon.Bonus.StrBonus;
                }
                foreach (var ability in Abilities)
                {
                    if (ability.Bonus != null)
                    {
                        fullStr.Value += ability.Bonus.StrBonus;
                    }
                }
                return fullStr; 
            }
            set
            {
                _strength = value;
            }
        }
        
        
        protected int _strengthAttackChange;
        
        protected int _strengthHpChange;

        private Characteristics _dexterity;
        
        public Characteristics Dexterity
        {
            get
            {
                var fullDex = new Characteristics(_dexterity.MinValue, _dexterity.MaxValue, _dexterity.Value);
                if (HeadArmor != null)
                {
                    fullDex.Value += HeadArmor.Bonus.DexBonus;
                }
                if (ChestArmor != null)
                {
                    fullDex.Value += ChestArmor.Bonus.DexBonus;
                }
                if (Weapon != null)
                {
                    fullDex.Value += Weapon.Bonus.DexBonus;
                }
                foreach (var ability in Abilities)
                {
                    if (ability.Bonus != null)
                    {
                        fullDex.Value += ability.Bonus.DexBonus;
                    }
                }
                return fullDex; 
            }
            set
            {
                _dexterity = value;
            }
        }
        
        
        protected int _dexterityAttackChange;
        
        protected double _dexterityPhysicalDefChange;

        private Characteristics _constitution;
        
        public Characteristics Constitution
        {
            get
            {
                var fullCon = new Characteristics(_constitution.MinValue, _constitution.MaxValue, _constitution.Value);
                if (HeadArmor != null)
                {
                    fullCon.Value += HeadArmor.Bonus.ConBonus;
                }
                if (ChestArmor != null)
                {
                    fullCon.Value += ChestArmor.Bonus.ConBonus;
                }
                if (Weapon != null)
                {
                    fullCon.Value += Weapon.Bonus.ConBonus;
                }
                foreach (var ability in Abilities)
                {
                    if (ability.Bonus != null)
                    {
                        fullCon.Value += ability.Bonus.ConBonus;
                    }
                }
                return fullCon;
            }
            set
            {
                _constitution = value;
            }
        }

        
        protected int _constitutionHpChange;
        
        protected double _constitutionPhysicalDefChange;

        private Characteristics _intelligence;
        
        public Characteristics Intelligence
        {
            get
            {
                var fullInt = new Characteristics(_intelligence.MinValue, _intelligence.MaxValue, _intelligence.Value);
                if (HeadArmor != null)
                {
                    fullInt.Value += HeadArmor.Bonus.IntBonus;
                }
                if (ChestArmor != null)
                {
                    fullInt.Value += ChestArmor.Bonus.IntBonus;
                }
                if (Weapon != null)
                {
                    fullInt.Value += Weapon.Bonus.IntBonus;
                }
                foreach (var ability in Abilities)
                {
                    if (ability.Bonus != null)
                    {
                        fullInt.Value += ability.Bonus.IntBonus;
                    }
                }
                return fullInt; }
            set
            {
                _intelligence = value;
            }
        }
        private Level _level;
        
        public Level Level
        {
            get { return _level; }
            set
            {
                _level = value;
            }
        }
        
        private List<Item> _inventory;

        [BsonIgnoreIfNull]
        public List<Item> Inventory
        {
            get { return _inventory; }
            set
            {
                _inventory = value;
            }
        }

        private Item _headArmor;

        [BsonIgnoreIfNull]
        public Item HeadArmor
        {
            get { return _headArmor; }
            set
            {
                _headArmor = value;
            }
        }

        private Item _chestArmor;

        [BsonIgnoreIfNull]
        public Item ChestArmor
        {
            get { return _chestArmor; }
            set
            {
                _chestArmor = value;
            }
        }

        private Item _weapon;

        [BsonIgnoreIfNull]
        public Item Weapon
        {
            get { return _weapon; }
            set
            {
                _weapon = value;
            }
        }

        
        protected double _intelligenceMpChange;
        
        protected int _intelligenceMagicAttackChange;

        
        private int _attackDamage;

        [BsonIgnore]
        public int AttackDamage
        {
            get { return _attackDamage; }
            set
            {
                if (value >= 0)
                {
                    _attackDamage = value;
                }
                else _attackDamage = 0;
            }
        }

        
        private double _physicalDef;

        [BsonIgnore]
        public double PhysicalDef
        {
            get { return _physicalDef; }
            set
            {
                if (value >= 0)
                {
                    _physicalDef = value;
                }
                else _physicalDef = 0;
            }
        }

        
        private int _magicAttack;

        [BsonIgnore]
        public int MagicAttack
        {
            get { return _magicAttack; }
            set
            {
                if (value >= 0)
                {
                    _magicAttack = value;
                }
                else _magicAttack = 0;
            }
        }

        
        private double _mp;

        [BsonIgnore]
        public double ManaPoint
        {
            get { return _mp; }
            set
            {
                if (value >= 0)
                {
                    _mp = value;
                }
                else _mp = 0;
            }
        }
        
        
        private int _hp;

        [BsonIgnore]
        public int HealthPoint
        {
            get { return _hp; }
            set
            {
                if (value >= 0)
                {
                    _hp = value;
                }
                else _hp = 0;
            }
        }
        
        private List<Ability> _abilities;

        [BsonIgnoreIfNull]
        public List<Ability> Abilities
        {
            get { return _abilities; }
            set
            {
                _abilities = value;
            }
        }

        public void HealthPointCalc()
        {
            HealthPoint = _strength.Value * _strengthHpChange + _constitution.Value * _constitutionHpChange;
        }

        public void AttackDamageCalc()
        {
            AttackDamage = _strength.Value * _strengthAttackChange + _dexterity.Value * _dexterityAttackChange;
        }
        public void ManaPointCalc()
        {
            ManaPoint = _intelligence.Value * _intelligenceMpChange;
        }
        public void MagicAttackCalc()
        {
            MagicAttack = _intelligence.Value * _intelligenceMagicAttackChange;
        }
        public void PhysicalDefCalc()
        {
            PhysicalDef = _dexterity.Value * _dexterityPhysicalDefChange + _constitution.Value * _constitutionPhysicalDefChange;
        }

        public void CalcStats()
        {
            AttackDamageCalc();
            HealthPointCalc();
            ManaPointCalc();
            MagicAttackCalc();
            PhysicalDefCalc();
        }

        public Character(Characteristics strength,
                                Characteristics dexterity,
                                Characteristics constitution,
                                Characteristics intelligense,
                                int strengthHpChange,
                                int strengthAttackChange,
                                double dexterityPhysicalDefChange,
                                int dexterityAttackChange,
                                double constitutionPhysicalDefChange,
                                int constitutionHpChange,
                                int intelligenceMagicAttackChange,
                                double intelligenceMpChange,
                                Level level, List<Item> inventory,
                                List<Ability> abillities)
        {
            _strength = strength;
            _dexterity = dexterity;
            _constitution = constitution;
            _intelligence = intelligense;
            _strengthHpChange = strengthHpChange;
            _strengthAttackChange = strengthAttackChange;
            _dexterityAttackChange = dexterityAttackChange;
            _dexterityPhysicalDefChange = dexterityPhysicalDefChange;
            _constitutionHpChange = constitutionHpChange;
            _constitutionPhysicalDefChange = constitutionPhysicalDefChange;
            _intelligenceMagicAttackChange = intelligenceMagicAttackChange;
            _intelligenceMpChange = intelligenceMpChange;
            _level = level;
            _inventory = inventory;
            _abilities = abillities;
            CalcStats();
        }

        public Character DeepCopy()
        {
            Character othercopy = (Character)this.MemberwiseClone();
            othercopy.Level = new Level(_level.MaxLevel, _level.Experience);
            othercopy.Abilities = new List<Ability>(_abilities);
            othercopy.Inventory = new List<Item>(_inventory);
            othercopy.Intelligence = new Characteristics(Intelligence.MinValue, Intelligence.MaxValue, Intelligence.Value);
            othercopy.Constitution = new Characteristics(Constitution.MinValue, Constitution.MaxValue, Constitution.Value);
            othercopy.Dexterity = new Characteristics(Dexterity.MinValue, Dexterity.MaxValue, Dexterity.Value);
            othercopy.Strength = new Characteristics(Strength.MinValue, Strength.MaxValue, Strength.Value);

            return othercopy;
        }
    }
}
