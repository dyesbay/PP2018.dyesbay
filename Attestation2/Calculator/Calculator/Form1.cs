using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
   
    public partial class Form1 : Form
    {
        Calc calc = new Calc();
        public double memory = 0;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            Call_Memory.Enabled = false;
            Clear_Memory.Enabled = false;
            textBox1.Enabled = false;
        }

        private void input (object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (textBox1.Text == "0" || textBox1.Text == "Error" || calc.complete == true)
            {
                textBox1.Text = b.Text;
                calc.complete = false;
            }
            else textBox1.Text += b.Text;
            if (calc.operationbi != "") calc.sec = true;
            if (calc.entermod == 1)
            {
                calc.first = double.Parse(textBox1.Text);
            }
            else calc.second = double.Parse(textBox1.Text);
        }

        private void change_sign_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) * (-1)).ToString();
            if (calc.operationbi != "") calc.sec = true;
            if (calc.entermod == 1) calc.first = double.Parse(textBox1.Text);
            else calc.second = double.Parse(textBox1.Text);
        }

        private void point_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(",") != true && textBox1.Text != "Error")
                textBox1.Text += ",";
        }

        private void delete_last_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 1)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            else textBox1.Text = "0";
            if (calc.entermod == 1) calc.first = double.Parse(textBox1.Text);
            else calc.second = double.Parse(textBox1.Text);
        }

        private void Mono_operations(object sender, EventArgs e)
        {
            Button b = sender as Button;
            calc.operationmono = b.Text;
            calc.Mono(calc.operationmono);
            if (calc.error != "")
            {
                textBox1.Text = calc.error;
                calc.error = "";
            }
            else
            {
                textBox1.Text = calc.result.ToString();
            }
            calc.complete = true;
        }

        private void Bi_operations(object sender, EventArgs e)
        {
            if (calc.entermod == 1 && textBox1.Text.Contains(",") == true)
            {
                while (textBox1.Text[textBox1.Text.Length - 1] == '0')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
            }
            calc.entermod = 2;
            calc.second = double.Parse(textBox1.Text);
            if (calc.operationbi != "" && calc.sec == true)
            {
                calc.Bi(calc.operationbi);
                if (calc.error != "")
                {
                    textBox1.Text = calc.error;
                    calc.error = "";
                }
                else textBox1.Text = calc.result.ToString();
                calc.first = calc.result;
                calc.second = calc.result;
            }
            Button b = sender as Button;
            calc.operationbi = b.Text;
            calc.complete = true;
            calc.sec = false;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            if (calc.entermod == 1 && textBox1.Text.Contains(",") == true)
            {
                while (textBox1.Text[textBox1.Text.Length - 1] == '0')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
            }
            if (calc.operationbi != "")
            {
                calc.Bi(calc.operationbi);
                if (calc.error != "")
                {
                    textBox1.Text = calc.error;
                    calc.error = "";
                }
                else textBox1.Text = calc.result.ToString();
                calc.first = calc.result;
                calc.entermod = 1;
                calc.complete = true;
                calc.sec = false;
            }
            else calc.complete = true;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            if (calc.entermod == 1) calc.first = 0;
            else calc.second = 0;
        }

        private void C_Click(object sender, EventArgs e)
        {
            calc = new Calc();
            textBox1.Text = "0";
        }

        private void Subtract_From_Memory_Click(object sender, EventArgs e)
        {
            memory -= double.Parse(textBox1.Text);
            Call_Memory.Enabled = true;
            Clear_Memory.Enabled = true;
        }

        private void Clear_Memory_Click(object sender, EventArgs e)
        {
            memory = 0;
            Call_Memory.Enabled = false;
            Clear_Memory.Enabled = false;
        }

        private void Call_Memory_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
            if (calc.entermod == 1) calc.first = memory;
            else calc.second = memory;
            calc.complete = true;
        }

        private void Add_To_Memory_Click(object sender, EventArgs e)
        {
            memory += double.Parse(textBox1.Text);
            Call_Memory.Enabled = true;
            Clear_Memory.Enabled = true;
        }

        private void MS_Click(object sender, EventArgs e)
        {
            memory = double.Parse(textBox1.Text);
            Call_Memory.Enabled = true;
            Clear_Memory.Enabled = true;
            calc.complete = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
    public class Calc
    {
        public double first;
        public double second;
        public bool sec;
        public bool complete;
        public int entermod;
        public double result;
        public string operationmono;
        public string operationbi;
        public string error;

        public Calc()
        {
            first = 0;
            second = 0;
            sec = false;
            complete = false;
            result = 0;
            operationmono = "";
            operationbi = "";
            error = "";
            entermod = 1;
        }

        int fact(int x)
        {
            if (x != 0) return x * fact(x - 1);
            else return 1;
        }

        public void Mono(string operation)
        {
            double k;
            if (entermod == 1) k = first;
            else k = second;
            switch (operation)
            {
                case "sqrt":
                    if (k >= 0) result = Math.Sqrt(k);
                    else error = "Error";
                    break;
                case "1/x":
                    if (k != 0) result = 1 / k;
                    else error = "Error";
                    break;
            }
            if (entermod == 1) first = result;
            else second = result;
        }

        public void Bi(string operation)
        {
            switch (operation)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "х":
                    result = first * second;
                    break;
                case "÷":
                    if (second != 0) result = first / second;
                    else error = "Error";
                    break;
                case "%":
                    result = first * second / 100;
                    break;
            }
        }
    }
}
