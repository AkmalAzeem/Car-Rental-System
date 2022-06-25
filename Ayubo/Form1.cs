using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Username = "Ayubo";
            string Password = "Admin";

            if (Username == textBox1.Text && Password == textBox2.Text)
            {
                HomePage f2 = new HomePage();
                this.Hide();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect");
            }
        }
    }
}
