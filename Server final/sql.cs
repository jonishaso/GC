using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SmartPTT_API
{
    public sealed class userDetial
    {
        public int ID { get; private set; }// this cannot be edited, each user have a unique ID;
        public string name { get; set; }
        public string phone { get; set; }
        public string radio { get; set; }
        public bool HIB { get; set; }

        public userDetial(string username, string userphone, string userradio, bool hib)// for create a new user
        {
            this.ID = -1;
            this.name = username;
            this.phone = userphone;
            this.radio = userradio;
            this.HIB = hib;
        }
        public userDetial(int ID, string username, string userphone, string userradio, bool hib)// for editing existing user inform
        {
            this.ID = ID;
            this.name = username;
            this.phone = userphone;
            this.radio = userradio;
            this.HIB = hib;

        }

    }

    public sealed class sql
    {

        public static SqlConnection conn { get; private set; }

        public sql(string connString)
        {
            conn = new SqlConnection(connString);
        }

        public bool insertRow(userDetial ud)
        {
            string query = "INSERT INTO users VALUES(@id,@name,@phone,@radio,@hib)";
            try
            {
                DataSet ds = selectRow();

                DataRow row = ds.Tables["users"].AsEnumerable().OrderByDescending(r => r[0]).First();
                int ID = Int32.Parse(row[0].ToString()) + 1;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@radio", ud.radio);
                cmd.Parameters.AddWithValue("@name", ud.name);
                cmd.Parameters.AddWithValue("@phone", ud.phone);
                cmd.Parameters.AddWithValue("@hib", ud.HIB);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException) { return false; }
            return true;
        }

        public DataSet selectRow()
        {
            //string query = "SELECT * FROM users WHERE id=@idvalue";
            string query = "SELECT * FROM users";
            try
            {
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                conn.Open();
                adapter.SelectCommand = new SqlCommand(query, conn);
                adapter.Fill(dataset, "users");
                conn.Close();
                return dataset;
            }
            catch (SqlException)
            {
                return null;
            }

        }

        public bool deleteRow(int ID)
        {
            try
            {
                string query = "DELETE FROM  users WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            { return false; }
            return true;
        }

        public bool updateRow(userDetial ud, int ID)
        {
            string query = "UPDATE users SET name=@name,phone=@phone,radio=@radio,hib=@hib WHERE id=@id ";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@radio", ud.radio);
                cmd.Parameters.AddWithValue("@name", ud.name);
                cmd.Parameters.AddWithValue("@phone", ud.phone);
                cmd.Parameters.AddWithValue("@hib", ud.HIB);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException) { return false; }
            return true;
        }

        public DataSet selectHIB()
        {
            //string query = "SELECT * FROM users WHERE id=@idvalue";
            string query = "SELECT * FROM users WHERE hib=@hib";
            try
            {
                DataSet dataset = new DataSet();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@hib", true);
                SqlDataAdapter adapter = new SqlDataAdapter();

                conn.Open();
                adapter.SelectCommand = comm;
                adapter.Fill(dataset, "users");
                conn.Close();
                return dataset;
            }
            catch (SqlException)
            {
                return null;
            }

        }
    }
}
