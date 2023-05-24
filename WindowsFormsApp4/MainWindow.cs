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
using System.Web.UI.WebControls;
using static WindowsFormsApp4.MainWindow;
using System.Data.Common;

namespace WindowsFormsApp4
{
    public partial class MainWindow : Form

    {
        Classcon1 connect = new Classcon1();  //объект класса (выделили под него память)

        public int GetId()
        {
            Form1 authF = (Form1)this.Owner;
            int UserId = authF.GetUserId();
            return UserId;
        }

        public string GetUsername()
        {
            Form1 form1 = (Form1)this.Owner;
            string username = form1.GetUserName();
            return username;
        }

        public string GetLastName()
        {
            Form1 form1= (Form1)this.Owner;
            string lastname = form1.GetUserLastName();
            return lastname;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public class Course
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Course(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Result
        {
            public string Name { get; set; }
            
            public string CourseName { get; set; }

            public int Score { get; set; }

            public int? Score2 { get; set; }


            public Result (string name, string coursename, int score)
            {
                Name = name;
                CourseName = coursename;
                Score = score;
            }
            public Result (string name, string coursename, int? score)
            {
                Name = name;
                CourseName = coursename;
                Score2 = score;
            }
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string GroupSt { get; set; }
            public string Pass { get; set; }
            public bool IsAdmin { get; set; }

            public Student(int id, string name, string surname)
            {
                Id = id;
                Name = name;
                Surname = surname;
            }
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            coursesGrid.Columns.Add("StudentName", "Имя");
            coursesGrid.Columns.Add("CourseName", "Имя курса");
            coursesGrid.Columns.Add("Score", "Баллы");
            coursesGrid.Columns["StudentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            coursesGrid.Columns["CourseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            coursesGrid.Columns["Score"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            LoadRegistredCourse();
            LoadCourses();
            userLabel.Text = $"Страница {GetUsername()} {GetLastName()}";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        // Отписаться кнопка
        private void button1_Click(object sender, EventArgs e)
        {
            Course selectedItem = (Course)courseComboBox.SelectedItem;
            int studentId = GetId();
            int courseId = selectedItem.Id;

            if (!IsEnrolled(courseId, studentId))
            {
                MessageBox.Show("Вы не записаны на этот курс.");
            }
            else
            {
                DeleteEnrollment(courseId, studentId);
                MessageBox.Show("Вы успешно отписались от курса");
            }
        }

        // Записаться кнопка
        private void button2_Click(object sender, EventArgs e)
        {
            Course selectedItem = (Course)courseComboBox.SelectedItem;
            int studentId = GetId();
            int courseId = selectedItem.Id;
            if (IsEnrolled(courseId, studentId))
            {
                MessageBox.Show("Вы уже записаны на этот курс");
            }
            else
            {
                AddEnrollment(courseId, studentId);
            }
            connect.closeConnection();
        }

        private void LoadCourses()
        {
            string query = "SELECT id, name FROM courses";
            connect.openConnection();
            SqlCommand cmd = new SqlCommand(query, connect.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int courseId = reader.GetInt32(0);
                string courseName = reader.GetString(1);
                courseComboBox.Items.Add(new Course(courseId, courseName));
            }
            reader.Close();
            connect.closeConnection();
        }

        private void AddStudentToDataGridView(Result res)
        {
            coursesGrid.Rows.Add(res.Name, res.CourseName, res.Score);
        }

        private void LoadRegistredCourse()
        {
            int UserId = GetId();
            string query = "SELECT s.name, s.surname, c.name as CourseName, sg.score " +
                "FROM Students s INNER JOIN Grades sg " +
                "ON sg.studentId = s.id INNER JOIN Courses c ON sg.courseId = c.id " +
                $"WHERE s.id = {UserId}";
            connect.openConnection();
            SqlCommand command = new SqlCommand(query, connect.getConnection());
            SqlDataReader reader = command.ExecuteReader();

            coursesGrid.Rows.Clear();
            while (reader.Read())
            {
                string studentName = reader.GetString(0)+ " " + reader.GetString(1);
                string courseName = reader.GetString(2);
                int Score = reader.GetInt32(3);
                Result res = new Result (studentName, courseName, Score);
                AddStudentToDataGridView(res);
            }
            reader.Close();
            connect.closeConnection();

        }

        private bool IsEnrolled(int courseId, int studentId)
        {
            connect.openConnection();
            string query = $"SELECT COUNT(*) FROM grades WHERE courseid={courseId} AND studentid={studentId}";
            SqlCommand command = new SqlCommand(query, connect.getConnection());
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private void DeleteEnrollment(int courseid, int studentid)
        {
            connect.openConnection();
            string query = $"DELETE FROM Grades WHERE studentId={studentid} AND courseId={courseid};";
            SqlCommand command = new SqlCommand(query, connect.getConnection());
            command.ExecuteNonQuery();
            connect.closeConnection();


            LoadRegistredCourse();
        }

        private void AddEnrollment(int courseId, int studentId)
        {
            connect.openConnection();
            string query = $"INSERT INTO grades (courseid, studentid) VALUES ({courseId}, {studentId})";
            SqlCommand command = new SqlCommand(query, connect.getConnection());
            command.ExecuteNonQuery();
            LoadRegistredCourse();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Спасибо что вы выбрали нас\nНавм важно знать ваше мнение", "Благодарсность", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
