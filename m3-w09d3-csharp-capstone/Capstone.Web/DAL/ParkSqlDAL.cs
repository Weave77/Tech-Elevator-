using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;


namespace Capstone.Web.DAL
{
    public class ParkSqlDAL
    {
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";

        private const string SQL_AllParks = @"SELECT parkCode, parkName, parkDescription, state, acreage, elevationInFeet, milesOfTrail, numberofCampsites, 
                                                     climate, yearFounded, numberOfAnimalSpecies FROM park";

        private const string SQL_SpecificPark = @"SELECT * FROM park WHERE park.parkCode = @parkCode";

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> NationalParksList()
        {
            List<ParkModel> thisList = new List<ParkModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AllParks, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel thisPark = new ParkModel();

                        thisPark.ParkName = Convert.ToString(reader["parkName"]);
                        thisPark.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        thisPark.State = Convert.ToString(reader["state"]);
                        thisPark.Acreage = Convert.ToInt32(reader["acreage"]);
                        thisPark.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        thisPark.MilesOfTrail = Convert.ToDecimal(reader["milesOfTrail"]);
                        thisPark.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        thisPark.Climate = Convert.ToString(reader["climate"]);
                        thisPark.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        thisPark.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        thisPark.ParkCode = Convert.ToString(reader["parkCode"]);

                        thisList.Add(thisPark);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return thisList;
        }

        public ParkModel SelectedParkDecriptiveDetails(string parkCode)
        {
            
            ParkModel p = new ParkModel();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SpecificPark, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())  
                    {
                        
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                       
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.MilesOfTrail = Convert.ToDecimal(reader["milesOfTrail"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberofCampsites"]);
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return p;
        }

    }
}