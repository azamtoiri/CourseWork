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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Linq.Expressions;

namespace WindowsFormsApp4

{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class AdminForm : Form
    {
        Classcon1 connect = new Classcon1();
        int selectedRow;

        public AdminForm()
        {
            InitializeComponent();
        }

        private string GetUserid(string name, string surname)
        {
            string userid;
            string queryString = $"SELECT Students.id"
                                + " FROM Grades"
                                + " INNER JOIN Students ON Grades.StudentId = Students.Id"
                                + " INNER JOIN Courses ON Grades.CourseId = Courses.Id"
                                + $" WHERE Students.name = '{name}' AND Students.surname = '{surname}';";


            connect.openConnection();

            SqlCommand command = new SqlCommand(queryString, connect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            
            adapter.Fill(table);

            if (table.Rows.Count > 0 )
            {
                userid = table.Rows[0][0].ToString();
                return userid;
            }
            else
            {
                MessageBox.Show("Нету такого юзера");
                return null;
            }
        }

        private string GetCourseId(string name, string surname, string courseName)
        {
            string courseId;
            string queryString = "SELECT Courses.id"
                                + " FROM Grades"
                                + " INNER JOIN Students ON Grades.StudentId = Students.Id"
                                + " INNER JOIN Courses ON Grades.CourseId = Courses.Id"
                                + $" WHERE Students.name = '{name}' AND Students.surname = '{surname}' AND Courses.name = '{courseName}';";
            connect.openConnection();

            SqlCommand command = new SqlCommand(queryString, connect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                courseId = table.Rows[0][0].ToString();
                return courseId;
            }
            else
            {
                MessageBox.Show("Нету такого юзера");
                return null;
            }
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("name", "Имя");
            dataGridView1.Columns.Add("surname", "Фамилия");
            dataGridView1.Columns.Add("groupST", "Группа");
            dataGridView1.Columns.Add("Coursename", "Имя курса");
            dataGridView1.Columns.Add("score", "Оценка");
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2),
                record.GetString(3), record.GetInt32(4));
        }

        public void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"SELECT Students.name, Students.surname, Students.groupST, Courses.name AS Coursename, Grades.score"
                +" FROM Grades"
                + " INNER JOIN Students ON Grades.StudentId = Students.Id"
                + " INNER JOIN Courses ON Grades.CourseId = Courses.Id;";

            SqlCommand command = new SqlCommand(queryString, connect.getConnection());

            connect.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
            connect.closeConnection();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public DataTable SearchInDatabase(string searchValue)
        {
            string query = $"SELECT Students.name, Students.surname, Students.groupST, Courses.name AS Coursename, Grades.score"
                + " FROM Grades"
                + " INNER JOIN Students ON Grades.StudentId = Students.Id"
                + " INNER JOIN Courses ON Grades.CourseId = Courses.Id"
                + $" WHERE Students.name LIKE '%{searchValue.ToLower()}%';";

            DataTable dt = new DataTable();

            connect.openConnection();
            SqlCommand command = new SqlCommand(query, connect.getConnection());
            dataGridView1.DataSource = dt;
            connect.closeConnection();

            return dt;
        }

        public DataTable GetALL()
        {
            string queryString = $"SELECT Students.name, Students.surname, Students.groupST, Courses.name AS Coursename, Grades.score"
                + " FROM Grades"
                + " INNER JOIN Students ON Grades.StudentId = Students.Id"
                + " INNER JOIN Courses ON Grades.CourseId = Courses.Id;";

            DataTable dt = new DataTable();

            connect.openConnection();
            SqlCommand command = new SqlCommand(queryString, connect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            connect.closeConnection();

            return dt;
        }

        private void serarchButton_Click(object sender, EventArgs e)
        {
            SearchForm addForm = new SearchForm();
            addForm.Owner = this;
            addForm.ShowDialog();
        }

        public string GetSearchValue()
        {
            string searchValue = searchTextBox.Text.Trim().ToLower();

            return searchValue;   

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            string queryString = $"SELECT Students.name, Students.surname, Students.groupST, Courses.name AS Coursename, Grades.score"
                                + " FROM Grades"
                                + " INNER JOIN Students ON Grades.StudentId = Students.Id"
                                + " INNER JOIN Courses ON Grades.CourseId = Courses.Id;";

            string scoreQuery = "UPDATE Grades SET score = @score WHERE StudentId = @studentId AND CourseId = @courseId";

            string studentId = GetUserid(textBox1.Text, textBox2.Text);
            string courseId = GetCourseId(textBox1.Text, textBox2.Text, textBox4.Text);
            
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-V8T8EK3;Initial Catalog=University;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(scoreQuery, connection);
                cmd.Parameters.AddWithValue("@score", textBox5.Text);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@courseId", courseId);

                cmd.ExecuteNonQuery();
                connect.closeConnection();

            }
            RefreshDataGrid(dataGridView1);

        }

        private void new_subject_button_Click(object sender, EventArgs e)
        {
            AddNewCourse addNewStudent = new AddNewCourse();
            addNewStudent.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
        }
    }
}
