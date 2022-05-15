using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string con = connection.con();
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            string get = "select ID, FirstName, LastName, Birthdate, RoleID as [Role], Email, OfficeID as [Office] from Users";
            SqlConnection sqlConnection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(get, sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "1")
            {
                string update = $"update Users set RoleID ='{2}' where ID = '{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
                SqlConnection conn = new SqlConnection(con);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(update, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                load();
            }
            else if(dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "2")
            {
                string update = $"update Users set RoleID ='{1}' where ID = '{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
                SqlConnection conn = new SqlConnection(con);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(update, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                load();
            }
            
            load();
        }
    }
}
