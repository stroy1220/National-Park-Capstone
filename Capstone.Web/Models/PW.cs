using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class PW
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public List<Weather> Weather { get; set; } = new List<Weather>();

        public PW(Park p, List<Weather> weather)
        {
            this.ParkCode = p.ParkCode;
            this.ParkName = p.ParkName;
            this.State = p.State;
            this.Acreage = p.Acreage;
            this.ElevationInFeet = p.ElevationInFeet;
            this.MilesOfTrail = p.MilesOfTrail;
            this.NumberOfCampsites = p.NumberOfCampsites;
            this.Climate = p.Climate;
            this.YearFounded = p.YearFounded;
            this.AnnualVisitorCount = p.AnnualVisitorCount;
            this.InspirationalQuote = p.InspirationalQuote;
            this.InspirationalQuoteSource = p.InspirationalQuoteSource;
            this.ParkDescription = p.ParkDescription;
            this.EntryFee = p.EntryFee;
            this.NumberOfAnimalSpecies = p.NumberOfAnimalSpecies;
            this.Weather = weather;
        }
    }
}