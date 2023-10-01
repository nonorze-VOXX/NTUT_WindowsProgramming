namespace Unity
{
    public class Number2
    {
        private float _first;
        private float _second;
        private const string ROUND_BRACKET_LEFT = "(";
        private const string ROUND_BRACKET_RIGHT = ")";
        private const string COMMA = ",";

        public float X
        {
            get
            {
                return _first;
            }
            set
            { 
                _first = value; 
            }
        }

        public float Y
        {
            get
            {
                return _second;
            }
            set
            {
                _second = value; 
            }
        }

        public Number2(float x, float y)
        {
            _first = x;
            _second = y;
        }

        /// <summary>
        /// Normal To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return ROUND_BRACKET_LEFT + _first + COMMA+ _second + ROUND_BRACKET_RIGHT;
        }
    }
}