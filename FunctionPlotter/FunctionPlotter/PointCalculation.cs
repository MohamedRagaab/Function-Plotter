using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPlotter
{
    class PointCalculation
    {
        static public List<char> FunctionArrayNumbers = new List<char>();
        static public List<char> FunctionArrayOperands = new List<char>();
        static public List<double> FunctionArrayNumbersType = new List<double>();

        /* Helper Functions ************************************************************************/
        internal static void convert_Function_To_Array(String FunctionString)
        {
            for (int i = 0; i < FunctionString.Length; i++)
            {
                int num;
                if (FunctionString[i] == '+') FunctionArrayOperands.Add('+');
                else if (FunctionString[i] == '-') FunctionArrayOperands.Add('-');
                else if (FunctionString[i] == '*') FunctionArrayOperands.Add('*');
                else if (FunctionString[i] == '/') FunctionArrayOperands.Add('/');
                else if (FunctionString[i] == '^') FunctionArrayOperands.Add('^');
                else if (FunctionString[i] == 'x') FunctionArrayNumbers.Add('x');
                else if (FunctionString[i] >= 48 && FunctionString[i] <= 57)
                {
                    if (i == FunctionString.Length - 1)
                    {
                        FunctionArrayNumbers.Add(FunctionString[i]);
                    }
                    else
                    {
                        int j = i + 1;
                        while (true)
                        {
                            if (FunctionString[j] >= 48 && FunctionString[j] <= 57)
                            {
                                if (j == FunctionString.Length - 1)
                                {
                                    num = int.Parse(FunctionString.Substring(i, j - i + 1));
                                    FunctionArrayNumbers.Add(Convert.ToChar(num + 48));
                                    i = j;
                                    break;
                                }
                                else
                                {
                                    j++;
                                }
                            }
                            else
                            {
                                num = int.Parse(FunctionString.Substring(i, j - i));
                                FunctionArrayNumbers.Add(Convert.ToChar(num + 48));
                                i = j - 1;
                                break;
                            }
                        }
                    }
                }
            }
        }
        /* CalCulate FuctionOf X *******************************************************************/
        internal static double CalCulateFuctionOfX(double x)
        {
            FunctionArrayNumbersType.Clear();
            // X Substitution
            for (int k = 0; k < FunctionArrayNumbers.Count; k++)
            {
                if (FunctionArrayNumbers[k] == 'x')
                    FunctionArrayNumbersType.Add(x);
                else
                    FunctionArrayNumbersType.Add(FunctionArrayNumbers[k] - 48);
            }

            if (FunctionArrayNumbersType.Count == 1) return (double)FunctionArrayNumbersType[0];

            // ^
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '^')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    operand1 = FunctionArrayNumbersType[i];
                    operand2 = FunctionArrayNumbersType[i + 1];
                    FunctionArrayNumbersType[i] = Math.Pow(operand1, operand2);
                    FunctionArrayNumbersType.RemoveAt(i + 1);
                    i--;
                }
            }
            if (FunctionArrayNumbersType.Count == 1) return (double)FunctionArrayNumbersType[0];
            // *
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '*')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    operand1 = FunctionArrayNumbersType[i];
                    operand2 = FunctionArrayNumbersType[i + 1];
                    FunctionArrayNumbersType[i] = (operand1 * operand2);
                    FunctionArrayNumbersType.RemoveAt(i + 1);
                    i--;
                }

            }
            if (FunctionArrayNumbersType.Count == 1) return (double)FunctionArrayNumbersType[0];
            // /
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '/')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    operand1 = FunctionArrayNumbersType[i];
                    operand2 = FunctionArrayNumbersType[i + 1];
                    FunctionArrayNumbersType[i] = (operand1 / operand2);
                    FunctionArrayNumbersType.RemoveAt(i + 1);
                    i--;
                }

            }
            if (FunctionArrayNumbersType.Count == 1) return (double)FunctionArrayNumbersType[0];
            // +
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '+')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    operand1 = FunctionArrayNumbersType[i];
                    operand2 = FunctionArrayNumbersType[i + 1];
                    FunctionArrayNumbersType[i] = (operand1 + operand2);
                    FunctionArrayNumbersType.RemoveAt(i + 1);
                    i--;
                }

            }
            if (FunctionArrayNumbersType.Count == 1) return (double)FunctionArrayNumbersType[0];
            // -
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '-')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    operand1 = FunctionArrayNumbersType[i];
                    operand2 = FunctionArrayNumbersType[i + 1];
                    FunctionArrayNumbersType[i] = (operand1 - operand2);
                    FunctionArrayNumbersType.RemoveAt(i + 1);
                    i--;
                }

            }
            if (FunctionArrayNumbersType.Count == 1) return (double)FunctionArrayNumbersType[0];

            return 1.0;
        }
    }
}
