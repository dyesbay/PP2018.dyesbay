using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class user
        {
            public string login;
            public string pass;
        
            public user (string a, string b)
            {
                login = a;
                pass = b;
            }
        }

         List<user> users = new List<user>();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool s = false, t =false;
            for (int i =0; i < textBox2.Text.Length; i++)
            {
                if (textBox2.Text[i] == '@')
                    s = true;
            }
            if (textBox1.Text != "")
                t = true;
            if (s && t)
            {
                users.Add(new user(textBox2.Text, textBox1.Text));
                label4.Text = "OK";
            }
            else
                label4.Text = "Wrong!!!";
            s = false;
            t = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool b = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (textBox3.Text == users[i].login && textBox4.Text == users[i].pass)
                {
                    label3.Text = "Logged in";
                    b = true;
                }
                if (!b)
                {
                    label3.Text = "Invalid login or password";
                }

            }
        
        }
    }
}
