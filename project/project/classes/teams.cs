using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace project.classes
{
    class teams
    {
        public static string sss;
        static string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int id { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public int? stadium_id { get; set; }
        public string city { get; set; }
        public byte[] logo { get; set; }

        public static DataTable Select()
        {

            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "select * from teams";

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
        public static bool Insert(teams t)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "insert into teams(name,points,stadium_id,city,logo) values (@name,@points,@stadium_id,@city,@logo) ";
                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@name", t.name);
                cm.Parameters.AddWithValue("@points", t.points);
                cm.Parameters.AddWithValue("@stadium_id", t.stadium_id);
                cm.Parameters.AddWithValue("@city", t.city);
                cm.Parameters.AddWithValue("@logo", t.logo);
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

        public static bool Update(teams t)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "update teams set name =@name,points =@points,stadium_id=@stadium_id ,city=@city,logo=@logo where id=@id";
                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", t.id);
                cm.Parameters.AddWithValue("@name", t.name);
                cm.Parameters.AddWithValue("@points", t.points);
                cm.Parameters.AddWithValue("@stadium_id", t.stadium_id);
                cm.Parameters.AddWithValue("@city", t.city);
                cm.Parameters.AddWithValue("@logo", t.logo);
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

        public static bool Delete(teams t)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "delete from teams where id=@id ";


                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", t.id);


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
