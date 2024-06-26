﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Class;

namespace DataLayer.DataConvertingToObject
{
    public class DataConvertingStations
    {
        public static Station ConvertRowToStation(DataRow row)
        {
            

            int Id = (int)row["StationId"];
            string Name =(string)row["StationName"];
            double Latitude = Convert.ToDouble(row["Latitude"]);
            double Longitude = Convert.ToDouble(row["Longitude"]);
           Station station = new Station(Id, Name, Latitude,Longitude);

            return station;
        }
        //public static SeasonTickets ConvertRowToSeasonTickets(DataRow row)
        //{
        //    SeasonTickets seasonTickets = new SeasonTickets("", "", "", "");

        //    seasonTickets.SeasonTicketName = (string)row["SeasonTicketName"];
        //    seasonTickets.Price = (string)row["Price"];
        //    seasonTickets.Description = (string)row["SeasonTicketDescription"];
        //    seasonTickets.Image = (string)row["ImageURL"];

        //    return seasonTickets;

        //}
    }
}
