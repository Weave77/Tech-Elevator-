using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL
    {
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";
        private const string SQL_SpecificDetailSelectedParkWeather = @"SELECT * FROM weather where parkcode = @parkcode";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> SpecificParkWeather(string parkCode)
        {
            
           List<Weather> wL = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SpecificDetailSelectedParkWeather, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather w = new Weather();
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Forecast = Convert.ToString(reader["Forecast"]);
                        w.TemperatureHigh = Convert.ToInt32(reader["high"]);
                        w.TemperatureLow = Convert.ToInt32(reader["low"]);

                        wL.Add(w);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return wL;
        }
    }
}