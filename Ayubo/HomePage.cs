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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Vehicle_Details f3 = new Vehicle_Details();
            this.Hide();
            f3.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Package_Details f4 = new Package_Details();
            this.Hide();
            f4.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Day_Tour_Details f5 = new Day_Tour_Details();
            this.Hide();
            f5.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Long_Tour_Details f8 = new Long_Tour_Details();
            this.Hide();
            f8.Show();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            Rent_Details f6 = new Rent_Details();
            this.Hide();
            f6.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
