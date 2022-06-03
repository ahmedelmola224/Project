using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace project.classes
{
    class stadiums
    {
        public static string sss;
        static string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public string city { get; set; }
        

        public static DataTable Select()
        {

            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "select * from stadiums";

                SqlCommand cm = new SqlCommand(cmd,con);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                con.Open();
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;

        }
        public static bool Insert(stadiums s)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "insert into stadiums(name,city,capacity) values (@name,@city,@capacity) ";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@name", s.name);
                cm.Parameters.AddWithValue("@city", s.city);
                cm.Parameters.AddWithValue("@capacity", s.capacity);

                SqlDataAdapter da = new SqlDataAdapter(cm);
                con.Open();

                int check = cm.ExecuteNonQuery();
                if (check > 0)
                {
                    done = true;
                }
                else
                {
                    done = false;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                con.Close();

            }
            return done;
        }

        public static bool Update(stadiums s)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "update stadiums set name =@name,city =@city,capacity=@capacity where id=@id ";
                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", s.id);
                cm.Parameters.AddWithValue("@name", s.name);
                cm.Parameters.AddWithValue("@city", s.city);
                cm.Parameters.AddWithValue("@capacity", s.capacity);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                con.Open();
                int check = cm.ExecuteNonQuery();
                if (check > 0)
                {
                    done = true;
                }
                else
                {
                    done = false;
                }

            }
            catch (Exception ex)
            {
                

            }
            finally
            {
                con.Close();

            }
            return done;
        }

        public static bool Delete(stadiums s)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "delete from stadiums where id=@id ";


                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", s.id);


                SqlDataAdapter da = new SqlDataAdapter(cm);
                con.Open();

                int check = cm.ExecuteNonQuery();
                if (check > 0)
                {
                    done = true;
                }
                else
                {
                    done = false;
                }

            }
            catch (Exception ex)
            {
                sss = ex.Message;

            }
            finally
            {
                con.Close();

            }
            return done;
        }
    }
}
