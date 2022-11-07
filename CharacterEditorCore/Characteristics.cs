namespace CharacterEditorCore
{
    public class Characteristics
    {
        private int _value;
        private int _minValue;
        private int _maxValue;
        public Characteristics(int minValue, int maxValue, int value)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _value = value;
        }
        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                if (_value > _maxValue)
                {
                    _value = _maxValue;
                }
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= _minValue && value <= _maxValue)
                {
                    _value = value;
                }
            }
        }

        public int MinValue
        {
            get { return _minValue; }
            set
            {
                if(value >= 0)
                {
                    _minValue = value;
                }
                if (_value < _minValue)
                {
                    _value = _minValue;
                }
            }
        }
    }
}
