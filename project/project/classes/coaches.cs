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
    class coaches
    {
      
        static string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public int? teamId { get; set; }
     
        public static DataTable Select()
        {

            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "select * from coaches";

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
        public static bool Insert(coaches c)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "insert into coaches(first_name,last_name,age,team_id) values (@first_name,@last_name,@age,@team_id) ";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@first_name", c.firstName);
                cm.Parameters.AddWithValue("@last_name", c.lastName);
                cm.Parameters.AddWithValue("@age", c.age);
                cm.Parameters.AddWithValue("@team_id", c.teamId);

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

        public static bool Update(coaches c)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "update coaches set first_name =@first_name,last_name =@last_name,age=@age ,team_id=@team_id where id=@id ";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", c.id);
                cm.Parameters.AddWithValue("@first_name", c.firstName);
                cm.Parameters.AddWithValue("@last_name", c.lastName);
                cm.Parameters.AddWithValue("@age", c.age);
                cm.Parameters.AddWithValue("@team_id", c.teamId);
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

        public static bool Delete(coaches c)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "delete from coaches where id=@id ";


                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", c.id);


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
    }
}
