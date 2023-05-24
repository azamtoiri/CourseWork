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

namespace WindowsFormsApp4
{
    public partial class Login : Form
    {
        Classcon1 connect = new Classcon1();  //объект класса (выделили под него память)

        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select nameST, passST from Logins where nameST = '{login}' and passST = '{password}'";

            SqlCommand command = new SqlCommand(querystring, connect.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1) {
                if (login == "Admin")
                {
                   AdminForm af = new AdminForm();
                    this.Hide();
                    af.ShowDialog();
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    this.Hide();
                    mw.ShowDialog();
                }
            }
          
            else
            {
                MessageBox.Show("Пользователь не найден!", "ИНФО", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
