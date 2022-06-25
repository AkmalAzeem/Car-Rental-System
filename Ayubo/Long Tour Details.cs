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
    public partial class Long_Tour_Details : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3UU4EVA7\\SQLEXPRESS;Initial Catalog=Ayubo;Integrated Security=True");
        SqlCommand com;
        Double  StartKm, endKm, MaxKM, ExKm, exkmxharge, totKM, ExKMrate, Noofdays, Packagerate, hirecharge, DriNightrate, VehNightrate, OvrNightchrge, totamnt;
        DateTime rentdate, returndate;
        TimeSpan Ts;
        
        public Long_Tour_Details()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DriNightrate = double.Parse(textBox1.Text);
            VehNightrate = double.Parse(textBox18.Text);
            OvrNightchrge = (DriNightrate + VehNightrate) * (Noofdays - 1);
            totamnt = (exkmxharge + hirecharge + OvrNightchrge);
            textBox16.Text = totamnt.ToString();
            MessageBox.Show("Total is " + totamnt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartKm = double.Parse(textBox13.Text);
            endKm = double.Parse(textBox12.Text);
            totKM = endKm - StartKm;
            textBox8.Text = totKM.ToString();

            MaxKM = double.Parse(textBox6.Text);
            if (totKM > MaxKM)
            {
                ExKm = (totKM - MaxKM);

            }
            else
            {
                ExKm = 0;
            }
            textBox10.Text = ExKm.ToString();
            ExKMrate = double.Parse(textBox15.Text);
            exkmxharge = (ExKMrate * ExKm);
            textBox11.Text = exkmxharge.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                    textBox9.Text = dr["Ex_Kmrate"].ToString();
                    textBox15.Text = dr["Ex_Hourrate"].ToString();
                    textBox18.Text = dr["vh_NightRate"].ToString();
                    textBox1.Text = dr["Dri_NightRate"].ToString();

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

        private void button5_Click(object sender, EventArgs e)
        {   
            rentdate = DateTime.Parse(dateTimePicker1.Text);
            returndate = DateTime.Parse(dateTimePicker2.Text);
            Ts = returndate - rentdate;
            //int totdays;//
            Noofdays = Ts.Days;
            textBox14.Text = Noofdays.ToString();
            Packagerate = double.Parse(textBox4.Text);
            hirecharge = (Noofdays * Packagerate);

            textBox7.Text = hirecharge.ToString();
            
            DriNightrate = double.Parse(textBox1.Text);
            VehNightrate = double.Parse(textBox18.Text);
            OvrNightchrge = (DriNightrate + VehNightrate) * (Noofdays - 1);
            textBox17.Text = OvrNightchrge.ToString();
            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage f7 = new HomePage();
            this.Hide();
            f7.Show();
        }

        private void Long_Tour_Details_Load(object sender, EventArgs e)
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Pk_ID from Package", con);
            DataTable Dt = new DataTable();
            sqlDataAdapter.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "Pk_ID";
            comboBox1.ValueMember = "Pk_ID";
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
