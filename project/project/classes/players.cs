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
    class players
    {
        
        static string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public int? teamId { get; set; }
        public string position { get; set; }
        public int goals { get; set; }
        public static DataTable Select()
        {
            
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "select * from players";
                
                SqlCommand cm = new SqlCommand(cmd,con);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                con.Open();
                da.Fill(dt);

            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
            
        }
        public static bool  Insert(players p)
        {
            bool done=false;
            

            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "insert into players(first_name,last_name,age,position,goals,team_id) values (@first_name,@last_name,@age,@position,@goals,@team_id) ";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@first_name", p.firstName);
                cm.Parameters.AddWithValue("@last_name", p.lastName);
                cm.Parameters.AddWithValue("@age", p.age);
                cm.Parameters.AddWithValue("@position", p.position);
                cm.Parameters.AddWithValue("@goals", p.goals);
                cm.Parameters.AddWithValue("@team_id", p.teamId);

              
                con.Open();
  
               int check= cm.ExecuteNonQuery();
                if(check>0)
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

        public static bool Update(players p)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "update players set first_name =@first_name,last_name =@last_name,age=@age ,position=@position,goals=@goals,team_id=@team_id where id=@id";

                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", p.id);
                cm.Parameters.AddWithValue("@first_name", p.firstName);
                cm.Parameters.AddWithValue("@last_name", p.lastName);
                cm.Parameters.AddWithValue("@age", p.age);
                cm.Parameters.AddWithValue("@position", p.position);
                cm.Parameters.AddWithValue("@goals", p.goals);
                cm.Parameters.AddWithValue("@team_id", p.teamId);

                
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

        public static bool Delete(players p)
        {
            bool done = false;


            SqlConnection con = new SqlConnection(connection);
            try
            {
                string cmd = "delete from players where id=@id ";


                SqlCommand cm = new SqlCommand(cmd,con);
                cm.Parameters.AddWithValue("@id", p.id);
                

                
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
