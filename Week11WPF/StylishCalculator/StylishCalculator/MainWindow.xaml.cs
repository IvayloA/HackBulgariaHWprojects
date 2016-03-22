using System;
using System.Windows;
using System.Windows.Controls;


namespace StylishCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input = null;
        string num1 = null;
        string num2 = null;
        char operation;
        decimal result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void allbuttonsClick(object sender, RoutedEventArgs e)
        {
            screenResult.Text = "";
            Button senderbtn = sender as Button;
            input += senderbtn.Content;
            screenResult.Text += input;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            screenResult.Text = "";
            input = null;
            num1 = null;
            num2 = null;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            num1 = input;
            operation = '+';
            input = null;
        }

        private void subt_Click(object sender, RoutedEventArgs e)
        {
            num1 = input;
            operation = '-';
            input = null;
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            num1 = input;
            operation = '*';
            input = null;
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            num1 = input;
            operation = '/';
            input = null;
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            screenResult.Text = "";
            if (!input.Contains("."))
            {
                input += '.';
            }
            screenResult.Text += input;
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            num2 = input;
            decimal operator1, operator2;
            decimal.TryParse(num1, out operator1);
            decimal.TryParse(num2, out operator2);

            if (operation == '+')
            {
                result = operator1 + operator2;
                screenResult.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = operator1 - operator2;
                screenResult.Text = result.ToString();
            }
            else if (operation == '*')
            {
                result = operator1 * operator2;
                screenResult.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (operator2 != 0)
                {
                    result = operator1 / operator2;
                    screenResult.Text = result.ToString();
                }
                else
                {
                    screenResult.Text = "OnlyPotatosDevByZERO!";
                }

            }
        }

        private void log2_Click(object sender, RoutedEventArgs e)
        {
            double operator1;
            double.TryParse(input, out operator1);
            result = (decimal)Math.Log(operator1, 2);
            screenResult.Text = result.ToString();
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            double operator1;
            double.TryParse(input, out operator1);
            result = (decimal)Math.Sqrt(operator1);
            screenResult.Text = result.ToString();
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            this.Close();          
        }
    }
}
