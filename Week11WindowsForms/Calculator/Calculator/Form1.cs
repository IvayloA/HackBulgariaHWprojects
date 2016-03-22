using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApplicaiton
{
    public partial class Form1 : Form
    {
        string input = null;
        string num1 = null;
        string num2 = null;
        char operation;
        decimal result = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Button senderBtn = sender as Button;
            input += senderBtn.Text;
            textBox1.Text += input;

        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            input = null;
            num1 = null;
            num2 = null;
        }

        private void add_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '+';
            input = null;
        }

        private void subtrak_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '-';
            input = null;
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '*';
            input = null;
        }

        private void devide_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '/';
            input = null;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            num2 = input;
            decimal operator1, operator2;
            decimal.TryParse(num1,  out operator1);
            decimal.TryParse(num2, out operator2);

            if (operation == '+')
            {
                result = operator1 + operator2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = operator1 - operator2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '*')
            {
                result = operator1 * operator2;
                textBox1.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (operator2 != 0)
                {
                    result = operator1 / operator2;
                    textBox1.Text = result.ToString();
                }
                else
                {
                    textBox1.Text = "OnlyPotatosDevByZERO!";
                }

            }
        }

        private void zero_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";   
            input += '0';
            textBox1.Text += input;
        }

        private void sqrt_Click(object sender, EventArgs e)
        {

            double operator1; 
            double.TryParse(input, out operator1);
            result = (decimal)Math.Sqrt(operator1);
            textBox1.Text = result.ToString();
        }

        private void log2_Click(object sender, EventArgs e)
        {
            double operator1;
            double.TryParse(input, out operator1);
            result = (decimal)Math.Log(operator1, 2);
            textBox1.Text = result.ToString();
            
        }

        private void ln_Click(object sender, EventArgs e)
        {
            double operator1;
            double.TryParse(input, out operator1);
            result = (decimal)Math.Log(operator1, 2.71);
            textBox1.Text = result.ToString();
        }

        private void point_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (!input.Contains("."))
            {
                input += ".";
            }
            textBox1.Text += input;
        }
    }
}
