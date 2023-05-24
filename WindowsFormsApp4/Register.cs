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
using System.Diagnostics.Eventing.Reader;

namespace WindowsFormsApp4
{
    public partial class Register : Form
    {
        Classcon1 connect = new Classcon1();  //объект класса (выделили под него память)

        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var name = nameBox.Text;
            var surname = surnameBox.Text;
            var group = groupBox.Text;
            var password = passBox.Text;

            string querystring = $"insert into Students (name, surname, groupST, pass)  values ('{name}','{surname}','{group}','{password}')";

            SqlCommand command = new SqlCommand(querystring, connect.getConnection());

            connect.openConnection(); // тут мы уже открываем подключение

            try
            {
                if (command.ExecuteNonQuery() == 1) // метод ExecuteNonQuery() просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE
                {
                    MessageBox.Show("Вы успешно зарегестрировались в системе!", "ИНФО", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
                else 
                {     
                    MessageBox.Show("Аккаунт не создан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show( "Нет нужных таблиц. Нажмите на кномпку чтобы создать таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            connect.closeConnection();  // не забываем его закрыть

            Form1 log = new Form1();
            this.Hide();
            log.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            this.Hide();
            back.ShowDialog();
        }
    }
}
