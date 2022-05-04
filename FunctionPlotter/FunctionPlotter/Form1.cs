using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;


namespace FunctionPlotter
{
    public partial class Form1 : Form
    {
        // Create PlotView Object
        OxyPlot.WindowsForms.PlotView pv = new PlotView();
        // Function Plotter Variables
        int MIN;
        int MAX;
        List<char> FunctionArrayNumbers = new List<char>();
        List<char> FunctionArrayOperands = new List<char>();
        List<char> orderedOperations = new List<char>();
        List<char> FunctionArrayNumbersBackup = new List<char>();
        List<char> FunctionArrayOperandsBackup = new List<char>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Order of Operations
            orderedOperations.Add('^');
            orderedOperations.Add('*');
            orderedOperations.Add('/');
            orderedOperations.Add('+');
            orderedOperations.Add('-');

            this.ActiveControl = label1;
            FunctionPlotterInitialization();
            textBox1.GotFocus += new EventHandler(RemoveText);
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (textBox1.Text == "e.g., 5*x^3 + 2*x")
            {
                textBox1.Text = "";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            check_Equation(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check Range
            check_Range(textBox2.Text,textBox3.Text);
            // Check validation Warning
            if (label5.Text=="") 
            {
                // Check is not empty
                if (textBox1.Text =="" || textBox2.Text == "" || textBox3.Text == "") 
                {
                    label5.Text = "Please enter a valid values";

                }else
                {
                    convert_Function_To_Array(textBox1.Text);
                    FunctionPlotter();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            FunctionPlotterInitialization();
            textBox1.Text = "e.g., 5*x^3 + 2*x";
            textBox1.GotFocus += new EventHandler(RemoveText);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            check_Numbers(textBox2.Text);

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check_Numbers(textBox3.Text);
        }

        /* Helper Functions ************************************************************************/
        private void convert_Function_To_Array(String FunctionString) 
        {
            for (int i =0; i < FunctionString.Length; i++) 
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
                    int j = i;
                    while (true) 
                    {
                        if (i != FunctionString.Length-1) 
                        {
                            j++;
                            if (!(FunctionString[j] >= 48 && FunctionString[j] <= 57))
                            {
                                num = int.Parse(FunctionString.Substring(i, j-i));
                                FunctionArrayNumbers.Add((char)num);
                                i = j - 1;
                                break;
                            }
                        }
                        else
                        {
                            FunctionArrayNumbers.Add(FunctionString[i]);
                            break;
                        }
                        
                    }

                }
            }
            FunctionArrayNumbersBackup = FunctionArrayNumbers.ToList();
            FunctionArrayOperandsBackup = FunctionArrayOperands.ToList();
        }
        /* Function Plotter Initialization *********************************************************/
        private void FunctionPlotterInitialization()
        {
            pv.Location = new Point(400, 10);
            pv.Size = new Size(500, 500);
            this.Controls.Add(pv);
            pv.Model = new PlotModel { Title = "Function(x)" };
            FunctionSeries fs = new FunctionSeries();
            fs.Points.Add(new DataPoint(0, 0));
            pv.Model.Series.Add(fs);
            
        }
        /* Function Plotter ************************************************************************/
        private void FunctionPlotter()
        {
            pv.Model.Series.Clear();
            FunctionSeries fs = new FunctionSeries();
            FunctionPlotterInitialization();
            for (int i =MIN;i<=MAX;i++) 
            {
                fs.Points.Add(new DataPoint(i, CalCulateFuctionOfX(i)));
                FunctionArrayNumbers = FunctionArrayNumbersBackup;
                FunctionArrayOperands = FunctionArrayOperandsBackup;
            }
            pv.Model.Series.Add(fs);
        }
        /* CalCulate FuctionOf X *******************************************************************/
        private double CalCulateFuctionOfX(int x) 
        {
            if (FunctionArrayNumbers.Count == 1) return (double)FunctionArrayNumbers[0];
            // ^
            for (int i =0; i<FunctionArrayOperands.Count;i++) 
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i]=='^') 
                {
                    FunctionArrayOperands.RemoveAt(i);
                    // x substitution
                    if (FunctionArrayNumbers[i] == 'x') 
                    {
                         operand1 = x;
                    }
                    else
                    {
                         operand1 = FunctionArrayNumbers[i];
                    }

                    if (FunctionArrayNumbers[i+1] == 'x')
                    {
                         operand2 = x;
                    }
                    else
                    {
                         operand2 = FunctionArrayNumbers[i+1];
                    }
                    FunctionArrayNumbers[i] = (char) Math.Pow((double)operand1, (double)operand2);
                    FunctionArrayNumbers.RemoveAt(i + 1);
                }
            }
            if (FunctionArrayNumbers.Count == 1) return (double)FunctionArrayNumbers[0];
            // *
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '*')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    // x substitution
                    if (FunctionArrayNumbers[i] == 'x')
                    {
                        operand1 = x;
                    }
                    else
                    {
                        operand1 = FunctionArrayNumbers[i];
                    }

                    if (FunctionArrayNumbers[i + 1] == 'x')
                    {
                        operand2 = x;
                    }
                    else
                    {
                        operand2 = FunctionArrayNumbers[i + 1];
                    }
                    FunctionArrayNumbers[i] = (char)(operand1 * operand2);
                    FunctionArrayNumbers.RemoveAt(i + 1);
                }
            }
            if (FunctionArrayNumbers.Count == 1) return (double)FunctionArrayNumbers[0];
            // /
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '/')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    // x substitution
                    if (FunctionArrayNumbers[i] == 'x')
                    {
                        operand1 = x;
                    }
                    else
                    {
                        operand1 = FunctionArrayNumbers[i];
                    }

                    if (FunctionArrayNumbers[i + 1] == 'x')
                    {
                        operand2 = x;
                    }
                    else
                    {
                        operand2 = FunctionArrayNumbers[i + 1];
                    }
                    FunctionArrayNumbers[i] = (char)(operand1 / operand2);
                    FunctionArrayNumbers.RemoveAt(i + 1);
                }
            }
            if (FunctionArrayNumbers.Count == 1) return (double)FunctionArrayNumbers[0];
            // +
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '+')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    // x substitution
                    if (FunctionArrayNumbers[i] == 'x')
                    {
                        operand1 = x;
                    }
                    else
                    {
                        operand1 = FunctionArrayNumbers[i];
                    }

                    if (FunctionArrayNumbers[i + 1] == 'x')
                    {
                        operand2 = x;
                    }
                    else
                    {
                        operand2 = FunctionArrayNumbers[i + 1];
                    }
                    FunctionArrayNumbers[i] = (char)(operand1 + operand2);
                    FunctionArrayNumbers.RemoveAt(i + 1);
                }
            }
            if (FunctionArrayNumbers.Count == 1) return (double)FunctionArrayNumbers[0];
            // -
            for (int i = 0; i < FunctionArrayOperands.Count; i++)
            {
                double operand1, operand2;
                if (FunctionArrayOperands[i] == '-')
                {
                    FunctionArrayOperands.RemoveAt(i);
                    // x substitution
                    if (FunctionArrayNumbers[i] == 'x')
                    {
                        operand1 = x;
                    }
                    else
                    {
                        operand1 = FunctionArrayNumbers[i];
                    }

                    if (FunctionArrayNumbers[i + 1] == 'x')
                    {
                        operand2 = x;
                    }
                    else
                    {
                        operand2 = FunctionArrayNumbers[i + 1];
                    }
                    FunctionArrayNumbers[i] = (char)(operand1 - operand2);
                    FunctionArrayNumbers.RemoveAt(i + 1);
                }
            }
            if (FunctionArrayNumbers.Count == 1) return (double)FunctionArrayNumbers[0];

            return 1.0;
        }
        /* User Input Validation *******************************************************************/
        // Check Enter A Valid Equation
        private void check_Equation(String textBoxText) 
        {
            for (int i =0; i< textBoxText.Length;i++) 
            {
                if (textBoxText[i] == 'X')
                {
                    label5.Text = "Please enter a valid form equation. (Use small x)";
                }
                else if (!(textBoxText[i]>=48 && textBoxText[i]<=57) && textBoxText[i] != 'x' && textBoxText[i] != '+' && textBoxText[i] != '-' && textBoxText[i] != '/' && textBoxText[i] != '*' && textBoxText[i] != '^')
                {
                    label5.Text = "Please enter a valid form equation. e.g., 5*x^3 + 2*x";
                }
                else
                {
                    label5.Text = "";
                }
            }
        }

        // Check Enter Only Numbers
        private void check_Numbers(String textBoxText)
        {
            for (int i = 0; i < textBoxText.Length; i++) 
            {
                if (!(textBoxText[i] >= 48 && textBoxText[i] <= 57) && textBoxText[i] != '-')
                {
                    label5.Text = "Please enter only numbers.";
                }
                else
                {
                    label5.Text = "";
                }
            }
        }
        // Check Range
        private void check_Range(String min, String Max)
        {
            MIN = Int32.Parse(min);
            MAX = Int32.Parse(Max);
            if (MAX<MIN) 
            {
                label5.Text = "Please enter a valid range.";
            }
        }

    }
}
