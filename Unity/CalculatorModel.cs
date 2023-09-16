namespace Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculatorModel
    {
        public string _context 
        {
            get; set; 
        }

        /// <summary>
        /// put number in context
        /// </summary>
        /// <param name="input"></param>
        public void InputNumber(string input)
        {
            if (input.Length == 1)
            {
                _context += input;
            }
        }
    }
}