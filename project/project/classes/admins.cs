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
    class admins
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        static string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    

        public static DataTable Select()
        {

            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "select * from admins";
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
        public static bool check (string username,string password)
        {
            
            DataTable dt=admins.Select();
            
            foreach (DataRow r in dt.Rows)
            {

                if (Convert.ToString(r["user_name"]) == username && Convert.ToString(r["password"]) == password)
                {
                    return true;
                }
            }

            return false;

        }
        public static bool Insert(admins a)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "insrert into admins(user_name,password) values (@user_name,@password) ";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@user_name", a.user_name);
                cm.Parameters.AddWithValue("@password", a.password);

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

        public static bool Update(admins a)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "update admins set user_name =@user_name,password =@password";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@user_name", a.user_name);
                cm.Parameters.AddWithValue("@last_name", a.password);
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

        public static bool Delete(admins a)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "delete from admins where id=@id ";


                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", a.id);


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

