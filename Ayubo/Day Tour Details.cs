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
    public partial class Day_Tour_Details : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3UU4EVA7\\SQLEXPRESS;Initial Catalog=Ayubo;Integrated Security=True");
        SqlCommand com;
        DateTime startdate, enddate;
        TimeSpan ts;
        int hours, excost, extra, Cost;
        Double Noofhours, MaxHours, ExHours, ExHourRate, ExHourCharge, StartKm, endKm, TotalKm, MaxKM, ExKM, ExKmCharge, totalCost, Packagerate, ExKMrate, Exhourrate;
       
        public Day_Tour_Details()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            HomePage f7 = new HomePage();
            this.Hide();
            f7.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Day_Tour_Details_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Pk_ID from Package", con);
            DataTable Dt = new DataTable();
            sqlDataAdapter.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "Pk_ID";
            comboBox1.ValueMember = "Pk_ID";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartKm = double.Parse(textBox9.Text);
            endKm = double.Parse(textBox10.Text);
            TotalKm = endKm - StartKm;
            textBox11.Text = TotalKm.ToString();
            MaxKM = double.Parse(textBox6.Text);
            if ( TotalKm > MaxKM)
            {
                ExKM = (TotalKm - MaxKM);
            }
            else
            {
                ExKM = 0;

            }
            textBox12.Text = ExKM.ToString();
            ExKMrate = double.Parse(textBox8.Text);
            ExKmCharge = (ExKMrate * ExKM);
            textBox19.Text = ExKmCharge.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query1;
                query1 = "Select * from Package where Pk_ID =  '" + comboBox1.Text + "'";
                SqlCommand com = new SqlCommand(query1, con);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {

                    textBox2.Text = dr["Pk_Name"].ToString();
                    textBox3.Text = dr["vh_type"].ToString();
                    textBox4.Text = dr["Pk_Rate"].ToString();
                    textBox5.Text = dr["Max_Hours"].ToString();
                    textBox6.Text = dr["Max_Km"].ToString();
                    textBox7.Text = dr["Ex_Kmrate"].ToString();
                    textBox8.Text = dr["Ex_Hourrate"].ToString();
                    textBox1.Text = dr["vh_NightRate"].ToString();
                    textBox18.Text = dr["Dri_NightRate"].ToString();

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
            startdate = DateTime.Parse(dateTimePicker1.Text);
            enddate = DateTime.Parse(dateTimePicker2.Text);
            
            ts = enddate - startdate;
            Noofhours = ts.Hours;
            textBox13.Text = Noofhours.ToString();
            
            MaxHours = double.Parse(textBox5.Text);
            
           
            if (Noofhours > MaxHours)
            {
                ExHours = (Noofhours - MaxHours);

            }
            else
            {
                ExHours = 0;
            }
            textBox14.Text = ExHours.ToString();

            ExHourRate = double.Parse(textBox7.Text);
            ExHourCharge = (ExHourRate * ExHours);
            textBox20.Text = ExHourCharge.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Packagerate = double.Parse(textBox4.Text);
            ExKmCharge = double.Parse(textBox19.Text);
            ExKMrate = double.Parse(textBox8.Text);

            totalCost = (Packagerate + Exhourrate + ExKMrate);
            textBox17.Text = totalCost.ToString();


        }
    }
}
