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
using System.CodeDom.Compiler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        string userid;
        string userName;
        string lastName;

        Classcon1 connect = new Classcon1();  //объект класса (выделили под него память)
        public int GetUserId()
        {
            int useridF = int.Parse(userid);
            return useridF;
        }

        public string GetUserName() { return userName; }
        public string GetUserLastName() { return lastName; }
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

            string querystring = $"select id, name, surname, pass, isAdmin from Students WHERE name = '{login}' AND pass = '{password}'";

            SqlCommand command = new SqlCommand(querystring, connect.getConnection());

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(table);
            }
            catch (Exception)
            {
                MessageBox.Show("Нет нужных таблиц. Нажмите на кномпку чтобы создать таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string createstudents = $"CREATE TABLE Students (id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, name NVARCHAR(50) NOT NULL, surname NVARCHAR(50) NOT NULL, groupST NVARCHAR(50) NOT NULL, pass NVARCHAR(50) NOT NULL, isAdmin BIT DEFAULT 0);";
                string craetecourses = $"CREATE TABLE Courses (id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, name NVARCHAR(50) NOT NULL);";
                string craetegrades = $"CREATE TABLE Grades (id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, studentId INT NOT NULL, courseId INT NOT NULL, score INT NOT NULL DEFAULT 0, CONSTRAINT Fk_Grades_Courses FOREIGN KEY (courseId) REFERENCES Courses (id) ON DELETE CASCADE, CONSTRAINT Fk_Grades_Students FOREIGN KEY (studentId) REFERENCES Students (id) ON DELETE CASCADE,);";

                connect.openConnection();
                
                SqlCommand command1 = new SqlCommand(createstudents, connect.getConnection());
                command1.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand(craetecourses, connect.getConnection());
                command2.ExecuteNonQuery();                
                
                SqlCommand command3 = new SqlCommand(craetegrades, connect.getConnection());
                command3.ExecuteNonQuery();

                MessageBox.Show("Таблицы Созданы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.None);
            }


            if (table.Rows.Count == 1) {
                userName = table.Rows[0][1].ToString();
                string isAdmin = table.Rows[0][4].ToString();
                userid = table.Rows[0][0].ToString();
                lastName = table.Rows[0][2].ToString();
                if (isAdmin == "True")
                {
                    AdminForm af = new AdminForm();
                    af.Owner = this;
                    this.Hide();
                    af.ShowDialog();
                }
                else
                {
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Owner = this;
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
        Point lastpoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }
}
