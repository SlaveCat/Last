using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string con = connection.con();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string get = $"Select * from Users where Email = '{textBox1.Text}' AND Password = '{textBox2.Text}'";
            SqlConnection sqlConnection = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(get, sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();
            if (textBox1.Text == "" || textBox2.Text=="")
            {
                MessageBox.Show("Введите пароль и логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(dt.Rows.Count <= 0)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (dt.Rows[0][2].ToString() == textBox1.Text && dt.Rows[0][3].ToString() == textBox2.Text && dt.Rows[0][1].ToString() == "1" && dt.Rows[0][8].ToString() == "True")
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else if(dt.Rows[0][2].ToString() == textBox1.Text && dt.Rows[0][3].ToString() == textBox2.Text && dt.Rows[0][1].ToString() == "2" && dt.Rows[0][8].ToString() == "True")
                    {
                        MessageBox.Show("Пользователь");
                    }
                    else if(dt.Rows[0][8].ToString() == "False")
                    {
                        MessageBox.Show("Пользователь заблокирован!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
