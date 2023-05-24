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
using System.Xml.Linq;

namespace WindowsFormsApp4
{
    public partial class AddNewCourse : Form
    {
        Classcon1 connect = new Classcon1 ();
        public AddNewCourse()
        {
            InitializeComponent();
        }

        private bool GetCourse(string courseName)
        {
            courseName = courseName.ToLower();
            
            string query = $"SELECT name FROM Courses WHERE name = '{courseName}';";
            SqlCommand command = new SqlCommand (query, connect.getConnection());
            connect.openConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                courseName = table.Rows[0][0].ToString();
                return true;
            }
            else
            {
                return false;
            }

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            connect.openConnection();

            string querystring = $"insert into Courses (name)  values ('{courseName}');";
            SqlCommand command = new SqlCommand(querystring, connect.getConnection());

            if (!GetCourse(courseName))
            {
                if (command.ExecuteNonQuery() == 1) // метод ExecuteNonQuery() просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE
                {
                    MessageBox.Show("Курс успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Курс уже существет!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            connect.openConnection();

            string querystring = $"DELETE FROM Courses WHERE name = '{courseName}';";
            SqlCommand command = new SqlCommand(querystring, connect.getConnection());

            if (GetCourse(courseName))
            {
                if (command.ExecuteNonQuery() == 1) // метод ExecuteNonQuery() просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE
                {
                    MessageBox.Show("Курс успешно удален!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Такого курса нет", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    
}
