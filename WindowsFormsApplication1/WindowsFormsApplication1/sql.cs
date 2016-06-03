using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    public sealed class sql
    {

        public static SqlConnection conn { get; private set; }

        public sql()
        {
            string connString = @"Data Source=.\GG;Database=KK;User ID=sa;password=wwsi123";
            conn = new SqlConnection(connString);
        }

        public bool insertRow(int ID, string name, string phone)
        {
            string query = "INSERT INTO users VALUES(@id,@name,@phone)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException) { return false; }
            return true;
        }

        public DataSet selectRow(int ID)
        {
            //string query = "SELECT * FROM users WHERE id=@idvalue";
            string query = "SELECT * FROM users";
            try
            {
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                conn.Open();
                adapter.SelectCommand = new SqlCommand(query, conn);

                //adapter.SelectCommand.Parameters.AddWithValue("@idvalue", ID);
                adapter.Fill(dataset,"users");

                //foreach (DataRow rows in dataset.Tables["users"].Rows)
                //{
                //    Console.WriteLine("{0} + {1} + {2}", rows["name"], rows["phone"], rows["name"].ToString().Length);
                //}
                conn.Close();
                return dataset;
            }
            catch (SqlException)
            {
                return null;
            }
            
        }

        public bool deleteRow(string name)
        {
            try
            {
                string query = "DELETE FROM  users WHERE name=@name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            { return false; }
            return true;
        }

        public bool updateRow(int ID, string name, string phone)
        {
            string query = "UPDATE users SET name=@name,phone=@phone WHERE id=@id ";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException) { return false; }
            return true;
        }
    }
}
