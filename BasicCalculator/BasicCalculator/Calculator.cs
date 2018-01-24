
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace BasicCalculator
{
    public class Calculator : INotifyPropertyChanged
    {
        const string ERROR = "Err";
        const char PLUS = '+';
        const char MINUS = '-';
        const char DIVIDE = '/';
        const char MULTIPLY = '*';

        string _calcString = string.Empty;
        public string CalcString
        {
            get { return _calcString; }
            set
            {
                _calcString = value.Substring(0, Math.Min(value.Length, 20));
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Performs addition, subtraction, multiplication, and division operations.
        /// Obeys order of operations (Multiply and divide first, then add and subtract).
        /// </summary>
        public void PerformCalculations()
        {
            if (HasInvalidDecimal())
            {
                CalcString = ERROR;
                return;
            }
            CheckForSubtraction();
            string calcStringCopy;
            if (CalcString.Contains(MULTIPLY) || CalcString.Contains(DIVIDE))
            {
                calcStringCopy = CalcString;
                foreach (var c in calcStringCopy)
                {
                    if (CalcString.Equals(ERROR)) break;
                    if (c.Equals(MULTIPLY) || c.Equals(DIVIDE))
                    {
                        PerformOperation(c);
                    }
                }
            }
            if (CalcString.Contains(PLUS))
            {
                calcStringCopy = CalcString;
                foreach (var c in calcStringCopy)
                {
                    if (CalcString.Equals(ERROR)) break;
                    if (c.Equals(PLUS))
                    {
                        PerformOperation(c);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to see if CalcString contains an invalid decimal point.
        /// </summary>
        /// <returns>True if Calcstring has an invalid decimal point, false otherwise</returns>
        bool HasInvalidDecimal()
        {
            Regex invalidDecimal = new Regex(@"(\.)(\d*)(\.)");
            return invalidDecimal.IsMatch(CalcString);
        }

        /// <summary>
        /// Converts CalcString subtraction operations to appropriate addition operations.
        /// </summary>
        void CheckForSubtraction()
        {
            if (CalcString.Contains(MINUS))
            {
                Regex doubleNegative = new Regex($@"(?<=(\d|\.)){MINUS}{MINUS}(?=(\d|\.))");
                Regex subtraction = new Regex($@"(?<=(\d|\.)){MINUS}(?=(\d|\.))");
                CalcString = doubleNegative.Replace(CalcString, $"{PLUS}");
                CalcString = subtraction.Replace(CalcString, $"{PLUS}-");
            }
        }

        /// <summary>
        /// Performs the specified operation (multiply, divide, or add) on CalcString.
        /// </summary>
        /// <param name="op">Operator</param>
        void PerformOperation(char op)
        {
            Regex operandReL = new Regex(@"-?\d*(\.?(\d+)?)$");
            Regex operandReR = new Regex(@"^-?\d*(\.?(\d+)?)(?=\D|$)");
            string tempL = operandReL.Match(CalcString.Substring(0,
                CalcString.IndexOf(op))).ToString();
            string tempR = operandReR.Match(CalcString.Substring(
                CalcString.IndexOf(op) + 1)).ToString();
            if (double.TryParse(tempL, out double numL) && double.TryParse(tempR, out double numR))
            {
                var ans = op.Equals(MULTIPLY) ? numL * numR :
                    op.Equals(DIVIDE) ? numL / numR : numL + numR;
                Regex regex = new Regex($@"{tempL}\{op}{tempR}");
                CalcString = regex.Replace(CalcString, ans.ToString(), 1);
            }
            else
            {
                CalcString = ERROR;
            }
        }

        /// <summary>
        /// Removes the last character from the CalcString property.
        /// </summary>
        public void RemoveLast()
        {
            CalcString = !CalcString.Equals(string.Empty) ? CalcString.Substring(0, CalcString.Length - 1) : CalcString;
        }

        /// <summary>
        /// Clears and sets the CalcString property to string.Empty.
        /// </summary>
        public void ClearAll()
        {
            CalcString = string.Empty;
        }

        /// <summary>
        /// Adds the specified op to CalcString.
        /// If the CalcString is 'Err,' set CalcString to the specified op.
        /// </summary>
        /// <param name="op">Operator/Operand.</param>
        public void AddOp(string op)
        {
            if (CalcString.Equals(ERROR))
            {
                CalcString = op.ToString();
            }
            else
            {
                CalcString += op;
            }
        }

        /// <summary>
        /// Notifies listeners of property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
