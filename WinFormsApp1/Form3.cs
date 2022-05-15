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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }
        string con = connection.con();
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            string search = "Select ID from Users";
            SqlConnection sqlConnection1 = new SqlConnection(con);
            SqlCommand cmd2 = new SqlCommand(search, sqlConnection1);
            sqlConnection1.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd2);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            m1:
            int value = random.Next(0, 10);
            for (int i = 0; dt1.Rows.Count > i; i++)
            {
                if (dt1.Rows[i][0].ToString() == value.ToString())
                {
                    goto m1;
                }
            }
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || dateTimePicker1.Text != "" || textBox6.Text != "")
            {
                string save = $"insert into Users ( ID,Email, FirstName, LastName, OfficeID, Birthdate,Password, RoleID ) values ( '{value}', '{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{dateTimePicker1.Value}','{textBox6.Text}','2')";
                SqlConnection conn = new SqlConnection(con);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(save, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Form2 form2 = new Form2();
                form2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }
    }
}
