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
    public partial class Package_Details : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3UU4EVA7\\SQLEXPRESS;Initial Catalog=Ayubo;Integrated Security=True");
        SqlCommand com;
        public Package_Details()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Insert into Package ( Pk_ID, Pk_Name, vh_Type, Pk_Rate, Max_Hours, Max_Km, Ex_Kmrate, Ex_Hourrate, vh_NightRate, Dri_NightRate) Values ('" + comboBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox1.Text + "')";
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Data added Successfully");
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox1.Clear();
           
   

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            HomePage f7 = new HomePage();
            this.Hide();
            f7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string query = "Delete from Package  Where Pk_ID = '" + comboBox1.Text + "'";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Data Deleted");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            con.Close();
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
                    textBox9.Text = dr["vh_NightRate"].ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Update Package Set Pk_Name = '" + textBox2.Text + "', vh_type ='" + textBox3.Text + "', Pk_Rate ='" + textBox4.Text + "', Max_Hours= '" + textBox5.Text + "', Max_Km= '" + textBox6.Text + "', Ex_Kmrate= '" + textBox7.Text + "', Ex_Hourrate= '" + textBox8.Text + "', vh_Nightrate= '" + textBox9.Text + "', Dri_NightRate= '" + textBox1.Text + "' where Pk_ID = '" + comboBox1.Text + "'";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Clear();
        }

        private void Package_Details_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Pk_ID from Package", con);
            DataTable Dt = new DataTable();
            sqlDataAdapter.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "Pk_ID";
            comboBox1.ValueMember = "Pk_ID";
        }
    }
}
