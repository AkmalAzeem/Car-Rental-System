using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ayubo
{
    public partial class Rent_Details : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3UU4EVA7\\SQLEXPRESS;Initial Catalog=Ayubo;Integrated Security=True");
        SqlCommand com;
        int months;
        int Noofmonths;
        DateTime startdate;
        DateTime enddate;
        TimeSpan days;
        int Noofdays;
        int weeks;
        int noofweeks;
        int remainder;
        int day;
        public Rent_Details()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage f7 = new HomePage();
            this.Hide();
            f7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // DateTime startdate;
            // DateTime enddate;
            // TimeSpan days;
            // int Noofdays;

            startdate = DateTime.Parse(dateTimePicker1.Text);
            enddate = DateTime.Parse(dateTimePicker2.Text);
            days = enddate - startdate;
            Noofdays = days.Days;
            textBox6.Text = Convert.ToString(Noofdays);


            // int months;
            //int Noofmonths;

            months = Noofdays / 30;

            textBox3.Text = Convert.ToString(months);


            //int weeks;
            //int noofweeks;
            //int remainder;


            remainder = Noofdays - (months *30);
            weeks = remainder / 7;
            textBox4.Text = weeks.ToString();


            day = remainder % 7;
            textBox5.Text = day.ToString();
            textBox6.Text = Noofdays.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query1;
                query1 = "Select * from Vehicle where Reg_No =  '" + comboBox1.Text + "'";
                SqlCommand com = new SqlCommand(query1, con);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {

                    textBox12.Text = dr["vh_model"].ToString();
                    textBox11.Text = dr["vh_type"].ToString();
                    textBox10.Text = dr["dayrate"].ToString();
                    textBox9.Text = dr["weekrate"].ToString();
                    textBox8.Text = dr["monthrate"].ToString();
                    textBox7.Text = dr["driverrate"].ToString();



                }

                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Double MnRa, WkRa, DyRa, DrRa, Amt ;
                Double totcost;
                MnRa = double.Parse(textBox8.Text);
                WkRa = double.Parse(textBox9.Text);
                DyRa = double.Parse(textBox10.Text);
                DrRa = double.Parse(textBox7.Text);


                Amt = (MnRa * months) + (WkRa * weeks) + (DyRa * day);
                if (checkBox1.Checked == true)
                {
                    totcost = Amt + (DrRa * Noofdays);
                }
                else
                {
                    totcost = Amt;
                }
                textBox13.Text = totcost.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rent_Details_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Reg_No from Vehicle", con);
            DataTable Dt = new DataTable();
            sqlDataAdapter.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "Reg_No";
            comboBox1.ValueMember = "Reg_No";
        }
    }
}
