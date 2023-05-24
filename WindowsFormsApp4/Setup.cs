using System;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    class Setup
    {
        string createTableLogins = "CREATE TABLE Logins (nameST VARCHAR(50), surnameST VARCHAR(50), groupST INT, passST VARCHAR (250)";
        string createTableSubjects = "CREATE TABLE Subjects (int NOT NULL AUTO_INCREMENT, name_of_sub VARCHAR(250), number_of_students INT)";
        Classcon1 connect = new Classcon1();

        public void createTables()
        {
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
            finally
            {
                connect.closeConnection();
            }
        }

    }
}