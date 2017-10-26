using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["npgeek"].ConnectionString;

        const string SQL_GetAllParks = "SELECT * FROM park";
        const string SQL_GetOnePark = "select * from park where parkCode = @input  ";       
        const string SQL_GetWeatherForPark = "select * from weather where parkCode = @input";
        const string SQL_SurveyResult = "insert into survey_result values( @parkCodeSurvey, @emailAddress, @stateSurvey, @activityLevel)";
        const string SQL_GetSurvey = "Select count(survey_result.parkCode) as total, park.parkName, park.parkCode from survey_result join park on park.parkCode = survey_result.parkCode group by park.parkName, park.parkCode order by total desc";
        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park p = new Park();

                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    

                        parks.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return parks;

        }

        public Park GetPark(string id)
        {
            Park p = new Park();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetOnePark, conn);
                    cmd.Parameters.AddWithValue("@input", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        p.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                   
                        p.ParkCode = id;
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }

            return p;
        }

        public List<Weather> GetWeather(string id)
        {
            List<Weather> weather = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWeatherForPark, conn);
                    cmd.Parameters.AddWithValue("@input", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather w = new Weather();
                        w.ParkCodeWeather = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);
                        weather.Add(w);
                    }

                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return weather;
        }

        public void SaveSurvey(Park p)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SurveyResult, conn);
                    cmd.Parameters.AddWithValue("@parkCodeSurvey", p.ParkCodeSurvey);
                    cmd.Parameters.AddWithValue("@emailAddress", p.EmailAddress);
                    cmd.Parameters.AddWithValue("@stateSurvey", p.StateSurvey);
                    cmd.Parameters.AddWithValue("@activityLevel", p.ActivityLevel);
                    
                    cmd.ExecuteNonQuery();
                    return;   
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }
        public List<Park> GetSurveyResults()
        {
            List<Park> output = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetSurvey, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park s = new Park();
                        s.ParkName = Convert.ToString(reader["parkName"]);
                        s.ParkCodeSurvey = Convert.ToString(reader["parkCode"]);
                        s.Total = Convert.ToInt32(reader["total"]);
                        output.Add(s);

                    }
                
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return output;
        }
  
    }
}