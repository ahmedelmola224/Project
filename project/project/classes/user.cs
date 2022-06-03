using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace project
{
    class user
    {
        static string connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public static DataTable standings()
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "SELECT teams.name, teams.city, teams.points, coaches.last_name AS coach, stadiums.name AS stadium, teams.logo FROM(teams LEft JOIN stadiums ON teams.stadium_id = stadiums.id left JOIN coaches ON teams.id = coaches.team_id) order by teams.points desc";

                SqlCommand cm = new SqlCommand(cmd, con);
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
       
   
        public static DataTable teamplayers(string teamname)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "SELECT players.last_name AS player, players.position, players.goals FROM (players INNER JOIN teams ON players.team_id = teams.id) WHERE teams.name =@name ";

                
                SqlCommand cm = new SqlCommand(cmd, con);
                cm.Parameters.AddWithValue("@name", teamname);
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

        public static DataTable topscorer()
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "SELECT last_name,position,goals FROM players ORDER BY goals DESC";

                SqlCommand cm = new SqlCommand(cmd, con);
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
        public static DataTable search(string keyword)
        {
            SqlConnection con = new SqlConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmd = "SELECT  *  FROM players WHERE first_name LIKE '%" + keyword + "%' OR last_name LIKE '%" + keyword + "%'";

                SqlCommand cm = new SqlCommand(cmd, con);
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

    }


    }

