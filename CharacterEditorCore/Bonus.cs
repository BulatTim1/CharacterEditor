namespace CharacterEditorCore
{
    public class Bonus
    {
        private int _strBonus = 0;
        private int _dexBonus = 0;
        private int _intBonus = 0;
        private int _conBonus = 0;
        private int _hpBonus = 0;
        private int _manaBonus = 0;
        private int _pDefBonus = 0;
        private int _mDefBonus = 0;
        private int _pDamBonus = 0;
        private int _mDamBonus = 0;

        public int StrBonus
        {
            get
            {
                return _strBonus;
            }
            set
            {
                _strBonus = value;
            }
        }

        public int DexBonus
        {
            get
            {
                return _dexBonus;
            }
            set
            {
                _dexBonus = value;
            }
        }

        public int IntBonus
        {
            get
            {
                return _intBonus;
            }
            set
            {
                _intBonus = value;
            }
        }

        public int ConBonus
        {
            get
            {
                return _conBonus;
            }
            set
            {
                _conBonus = value;
            }
        }

        public int HpBonus
        {
            get
            {
                return _hpBonus;
            }
            set
            {
                _hpBonus = value;
            }
        }

        public int ManaBonus
        {
            get
            {
                return _manaBonus;
            }
            set
            {
                _manaBonus = value;
            }
        }

        public int PDefBonus
        {
            get
            {
                return _pDefBonus;
            }
            set
            {
                _pDefBonus = value;
            }
        }

        public int MDefBonus
        {
            get
            {
                return _mDefBonus;
            }
            set
            {
                _mDefBonus = value;
            }
        }

        public int PDamBonus
        {
            get
            {
                return _pDamBonus;
            }
            set
            {
                _pDamBonus = value;
            }
        }

        public int MDamBonus
        {
            get
            {
                return _mDamBonus;
            }
            set
            {
                _mDamBonus = value;
            }
        }

        public Bonus()
        {
            _strBonus = 0;
            _dexBonus = 0;
            _intBonus = 0;
            _conBonus = 0;
            _hpBonus = 0;
            _manaBonus = 0;
            _pDefBonus = 0;
            _mDefBonus = 0;
            _pDamBonus = 0;
            _mDamBonus = 0;
        }
    }
}
