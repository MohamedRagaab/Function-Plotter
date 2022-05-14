using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Can_Convert_Function_To_Arrays **********************************************************************/
            /* Test1 ***********************************************************************************************/
            List<char> arrayNumbersTest = new List<char>{'2', 'x', '3', '3', 'x', '2', Convert.ToChar(25 + 48) };
            List<char> arrayOperandsTest = new List<char> { '*', '^', '+', '*', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("2*x^3+3*x^2+25", arrayNumbersTest, arrayOperandsTest);
            /* Test2 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { '5', 'x', '2', '3', 'x', '2', Convert.ToChar(25 + 48) };
            arrayOperandsTest = new List<char> { '*', '^', '+', '*', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("5*x^2+3*x^2+25", arrayNumbersTest, arrayOperandsTest);
            /* Test3 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { '2', 'x', '3', '3', 'x', '2'};
            arrayOperandsTest = new List<char> { '*', '^', '+', '*', '^' };
            Testing.Can_Convert_Function_To_Arrays("2*x^3+3*x^2", arrayNumbersTest, arrayOperandsTest);
            /* Test4 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { 'x', '3', '3', 'x', '2', Convert.ToChar(25 + 48) };
            arrayOperandsTest = new List<char> { '^', '+', '*', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("x^3+3*x^2+25", arrayNumbersTest, arrayOperandsTest);
            /* Test5 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { '2', 'x', '3','x', '2', Convert.ToChar(25 + 48) };
            arrayOperandsTest = new List<char> { '*', '^', '+', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("2*x^3+x^2+25", arrayNumbersTest, arrayOperandsTest);
            /* Test6 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { 'x','4', 'x','3', 'x','2', 'x' };
            arrayOperandsTest = new List<char> { '^', '+', '^', '+', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("x^4+x^3+x^2+x", arrayNumbersTest, arrayOperandsTest);
            /* Test7 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { '2', 'x', '3', '3', 'x', '2', '4' };
            arrayOperandsTest = new List<char> { '*', '^', '+', '*', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("2*x^3+3*x^2+4", arrayNumbersTest, arrayOperandsTest);
            /* Test8 ***********************************************************************************************/
            arrayNumbersTest = new List<char> { '2', 'x', '9', '3', 'x', '2', Convert.ToChar(25 + 48) };
            arrayOperandsTest = new List<char> { '*', '^', '+', '*', '^', '+' };
            Testing.Can_Convert_Function_To_Arrays("2*x^9+3*x^2+25", arrayNumbersTest, arrayOperandsTest);

            /* Can_Convert_Function_To_Arrays **********************************************************************/
            Testing.FunctionArrayNumbers.Clear();
            Testing.FunctionArrayOperands.Clear();
            Testing.FunctionArrayNumbers.Add('x');
            Testing.FunctionArrayNumbers.Add('2');
            Testing.FunctionArrayOperands.Add('^');
            /* Test1 ***********************************************************************************************/
            Testing.can_Calculate_Point(0,0);
            Testing.FunctionArrayOperands.Add('^');
            /* Test2 ***********************************************************************************************/
            Testing.can_Calculate_Point(1, 1);
            Testing.FunctionArrayOperands.Add('^');
            /* Test3 ***********************************************************************************************/
            Testing.can_Calculate_Point(2, 4);
            Testing.FunctionArrayOperands.Add('^');
            /* Test4 ***********************************************************************************************/
            Testing.can_Calculate_Point(3, 9);
            Testing.FunctionArrayOperands.Add('^');
            /* Test5 ***********************************************************************************************/
            Testing.can_Calculate_Point(4, 16);
            Testing.FunctionArrayOperands.Add('^');
            /* Test6 ***********************************************************************************************/
            Testing.can_Calculate_Point(5, 25);
            Testing.FunctionArrayOperands.Add('^');
            /* Test7 ***********************************************************************************************/
            Testing.can_Calculate_Point(6, 36);
            Testing.FunctionArrayOperands.Add('^');
            /* Test8 ***********************************************************************************************/
            Testing.can_Calculate_Point(7, 49);
            Testing.FunctionArrayOperands.Add('^');

        }
    }
}
