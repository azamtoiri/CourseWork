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

namespace WindowsFormsApp4
{
    public partial class CreateTableForm : Form
    {
        Classcon1 connect = new Classcon1();

        public CreateTableForm()
        {
            InitializeComponent();
        }

        private void CreateTableForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string createTableLogins = "CREATE TABLE Logins (nameST VARCHAR(50), surnameST VARCHAR(50), groupST INT, passST VARCHAR (250)";
            string createTableSubjects = "CREATE TABLE Subjects (int NOT NULL AUTO_INCREMENT, name_of_sub VARCHAR(250), number_of_students INT)";

            try
            {
                connect.openConnection();

                SqlCommand command = new SqlCommand(createTableLogins, connect.getConnection());
                command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand(createTableSubjects, connect.getConnection());
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                connect.closeConnection();
            }

            MessageBox.Show("Таблицы созданы!", "Ура", MessageBoxButtons.OK, MessageBoxIcon.None);
            Register reg = new Register();
            this.Close();
            reg.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.Show();
        }
    }
}
