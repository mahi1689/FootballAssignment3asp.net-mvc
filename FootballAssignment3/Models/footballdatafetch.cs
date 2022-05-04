using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FootballAssignment3.Models
{
    public class footballdatafetch
    {
        public void AddFootballData(Football fb)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("football", con);
                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@matchid", fb.matchid);
                cmd.Parameters.AddWithValue("@teamname1", fb.teamname1);
                cmd.Parameters.AddWithValue("@teamname2", fb.teamname2);
                cmd.Parameters.AddWithValue("@status", fb.status);
                cmd.Parameters.AddWithValue("@winningteam", fb.winningteam);
                cmd.Parameters.AddWithValue("@points", fb.points);

                con.Open();
                
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Football> fbl
        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                List<Football> list = new List<Football>();
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand("spGetData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Football football = new Football();
                        football.matchid = Convert.ToInt32(rd["matchid"]);
                        football.teamname1 = rd["teamname1"].ToString();
                        football.teamname2 = rd["teamname2"].ToString();
                        football.status = rd["status"].ToString();
                        football.winningteam = rd["winningteam"].ToString();
                        football.points = Convert.ToInt32(rd["points"]);

                        list.Add(football);
                    }

                }  
                return list;
            }
           
        }
    }
}