using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        string operation = "";
        double result = 0;
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        textBox1.Text = (result + double.Parse(textBox1.Text)).ToString();
                        break;
                    case "-":
                        textBox1.Text = (result - double.Parse(textBox1.Text)).ToString();
                        break;
                    case "*":
                        textBox1.Text = (result * double.Parse(textBox1.Text)).ToString();
                        break;
                    case "/":
                        if (double.Parse(textBox1.Text) != 0)
                        {
                            textBox1.Text = (result / double.Parse(textBox1.Text)).ToString();
                        }
                        else
                        {
                            textBox1.Text = "Error"; 
                        }
                        break;
                    default:
                        textBox1.Text = "0"; 
                        break;
                }
                result = double.Parse(textBox1.Text); 
                operation = ""; 
            }
            catch (FormatException)
            {
                textBox1.Text = "Error"; 
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (textBox1.Text == "0" || isOperationPerformed || string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Clear();
            }

            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                {
                    textBox1.Text += button.Text;
                }
            }
            else
            {
                textBox1.Text += button.Text;
            }
            isOperationPerformed = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            try
            {
                result = double.Parse(textBox1.Text);
                operation = button.Text;
                isOperationPerformed = true;
            }
            catch (FormatException)
            {
                textBox1.Text = "Error"; 
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            result = 0;
            operation = "";
        }
    }
}