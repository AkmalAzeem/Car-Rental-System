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
    public partial class Vehicle_Details : Form
    {
        
        static string connectionstring =  "Data Source=LAPTOP-3UU4EVA7\\SQLEXPRESS;Initial Catalog=Ayubo;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand com;
        
        public Vehicle_Details()
        {
            InitializeComponent();
        }

        private void Vehicle_Details_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Reg_No from Vehicle", con);
            DataTable Dt = new DataTable();
            sqlDataAdapter.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "Reg_No";
            comboBox1.ValueMember = "Reg_No";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePage f7 = new HomePage();
            this.Hide();
            f7.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Insert into Vehicle (Reg_No, vh_model, vh_type, dayrate, weekrate, monthrate, driverrate) Values ('" + comboBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "')";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data added Successfully");
               
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

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
                query1 = "Select * from Vehicle where Reg_No =  '" + comboBox1.Text + "'";
                SqlCommand com = new SqlCommand(query1,con);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                   
                    textBox2.Text = dr["vh_model"].ToString();
                    textBox3.Text = dr["vh_type"].ToString();
                    textBox4.Text = dr["dayrate"].ToString();
                    textBox5.Text = dr["weekrate"].ToString();
                    textBox6.Text = dr["monthrate"].ToString();
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
                con.Open();
                string query = "Update Vehicle Set vh_model = '" + textBox2.Text + "', vh_type='" + textBox3.Text + "', dayrate='" + textBox4.Text + "',weekrate= '" + textBox5.Text + "',monthrate= '" + textBox6.Text + "',driverrate= '" + textBox7.Text + "' where Reg_No= '" +comboBox1.Text + "'";
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            string query = "Delete from Vehicle where Reg_No = '" + comboBox1.Text + "'";
            com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
          
            }
     

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}

      