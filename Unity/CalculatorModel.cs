using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Unity
{
    internal enum Confucius
    {
        Number1,
        OPERATOR,
        Number2
    }

    /// <summary>
    /// 
    /// </summary>
    public class CalculatorModel
    {
        public string _result 
        {
            get;
            set; 
        }
        public string _processingNumber 
        {
            get;
            set;
        }
        public string _operator 
        {
            get;
            set;
        }
        private Confucius _confucius;
        private bool _boolean;
        private const string ZERO = "0";
        private const string CARBON = "C";
        private const string COMPILE_ERROR = "CE";
        private const string EQ = "=";
        private const string DOT = ".";
        private const string ADD = "+";
        private const string SUBWAY = "-";
        private const string MANY = "*";
        private const string LINE = "/";

        public CalculatorModel()
        {
            _result = ZERO;
            _processingNumber = ZERO;
            _operator = ZERO;
            _confucius = Confucius.Number1;
            _boolean = false;
        }

        /// <summary>
        /// too long
        /// </summary>
        /// <param name="input"></param>
        private void PushOperator(string input)
        {

            _confucius = Confucius.Number2;
            if (_boolean)
            {
                _boolean = false;
                Input(CARBON);
                _confucius = Confucius.Number1;
                _result += input;
            }
            else
                _processingNumber += input;
        }

        /// <summary>
        /// push
        /// </summary>
        /// <param name="input"></param>
        private void Push(string input)
        {
            if (_confucius == Confucius.Number2) 
                _confucius = Confucius.OPERATOR;
            switch (_confucius)
            {
                case Confucius.Number1:
                    _result += input;
                    break;
                case Confucius.OPERATOR:
                    PushOperator(input);
                    break;
                case Confucius.Number2:
                    _processingNumber += input;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// input
        /// </summary>
        /// <param name="input"></param>
        public void Input(string input)
        {
            if (int.TryParse(input, out _))
                Push(input);
            else
            {
                if (input.Equals(CARBON))
                {
                    _result = ZERO;
                    _processingNumber = ZERO;
                }
                else if (input.Equals(COMPILE_ERROR.ToString()))
                    _processingNumber = ZERO;
                else if (input.Equals(DOT))
                    Push(input);
                else
                    InputOperator(input);
            }
            _boolean = input.Equals(EQ.ToString());
        }

        /// <summary>
        /// operator
        /// </summary>
        /// <param name="input"></param>
        private void InputOperator(string input)
        {
            if (!input.Equals(EQ.ToString()))
                _operator = input;
            if (_confucius == Confucius.Number2 || input.Equals(EQ.ToString()))
                if (_operator == ADD)
                    _result = (double.Parse(_result) + double.Parse(_processingNumber)).ToString();
                else if (_operator == SUBWAY)
                    _result = (double.Parse(_result) - double.Parse(_processingNumber)).ToString();
                else if (_operator == MANY)
                    _result = (double.Parse(_result) * double.Parse(_processingNumber)).ToString();
                else if (_operator == LINE)
                    if (double.Parse(_processingNumber) != 0d)
                        _result = (double.Parse(_result) / double.Parse(_processingNumber)).ToString();

            _confucius = Confucius.OPERATOR;
            if (!input.Equals(EQ.ToString()))
                _processingNumber = ZERO;
        }

        /// <summary>
        /// 
        /// out
        /// </summary>
        /// <returns></returns>
        public string GetOutput()
        {
            switch (_confucius)
            {
                case Confucius.Number1:
                    return double.Parse(_result).ToString();
                case Confucius.OPERATOR:
                    return double.Parse(_result).ToString();
                case Confucius.Number2:
                    return double.Parse(_processingNumber).ToString();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}