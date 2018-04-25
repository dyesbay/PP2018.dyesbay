using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem3
{
    public partial class Form1 : Form
    {
        bool wh = false;
        
        List<Button> buttons = new List<Button>();
        List<TextBox> texts = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }
        public void cl (object sender, EventArgs e)
        {
            texts[texts.Count - 1].Text = "Hello";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {


            if (wh)
            {
                Button b = new Button();
                b.Location = e.Location;

                b.Size = new Size(40, 15);
                buttons.Add(b);
                b.Click += new EventHandler(cl);

                Controls.Add(buttons[buttons.Count - 1]);
//                buttons[buttons.Count - 1].Text = (buttons.Count - 1).ToString;
                wh = false;
            }
            else
            {
                TextBox t = new TextBox();
                t.Location = e.Location;

                t.Size = new Size(50, 15);
                texts.Add(t);
                wh = true;
                Controls.Add(texts[texts.Count - 1]);

            }

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
