using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL
    {
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";

        private const string SQL_NewSurvey = @"INSERT INTO [dbo].[survey_result] ([parkCode],[emailAddress],[state],[activityLevel])
     VALUES (@parkCode, @emailAddress, @state, @activityLevel)";

        //private const string SQL_AllParkCodes = @"SELECT parkCode FROM park";

        private const string SQL_BestParks = @"SELECT COUNT(survey_result.parkCode) as Votes, parkName, park.ParkCode 
                                                FROM survey_result 
                                                JOIN park ON park.ParkCode = Survey_Result.ParkCode
                                                GROUP by Park.parkname, Park.ParkCode 
                                                ORDER BY Count(Park.parkCode) DESC, Park.ParkName ASC";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //public List<SurveyModel> ParkCodes()
        //{
        //    List<SurveyModel> thisList = new List<SurveyModel>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(SQL_AllParkCodes, conn);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                SurveyModel codes = new SurveyModel();
        //                codes.ParkCode = Convert.ToString(reader["parkCode"]);

        //                thisList.Add(codes);

        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return thisList;
        //}

        public bool SurveyPost(SurveyModel newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_NewSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<SurveyModel> BestParks()
        {
            List<SurveyModel> thisList = new List<SurveyModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_BestParks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyModel parks = new SurveyModel();
                        parks.ParkName = Convert.ToString(reader["ParkName"]);
                        parks.ParkCode = Convert.ToString(reader["ParkCode"]);
                        parks.Votes = Convert.ToInt32(reader["Votes"]);

                        thisList.Add(parks);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return thisList;
        }

    }
}