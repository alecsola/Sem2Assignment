using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Class;

namespace DataLayer.DataConvertingToObject
{
    public class DataConvertingSeasonTickets
    {

        public static SeasonTickets ConvertRowToSeasonTickets(DataRow row)
        {
            SeasonTickets seasonTickets = new SeasonTickets("", "", "","");

            seasonTickets.SeasonTicketName = (string)row["SeasonTicketName"];
            seasonTickets.Price = (string)row["Price"];
            seasonTickets.Description = (string)row["SeasonTicketDescription"];
            seasonTickets.Image = (string)row["ImageURL"];

            return seasonTickets;
            //User user = new User("", "", "", "", "", "", "", "", "");
            ////Roles roles = new Roles();

            //user.FirstName = (string)row["FirstName"];
            //user.LastName = (string)row["LastName"];
            //user.Username = (string)row["Username"];
            ////user.Password = (string)row["Password"];
            //user.Salt = (string)row["Salt"];
            //user.HashedPassword = (string)row["HashedPassword"];
            //user.Email = (string)row["Email"];

            //user.PhoneNumber = (string)row["PhoneNumber"];
            //user.BirthDate = ((DateTime)row["DateOfBirth"]).ToString("yyyy-MM-dd");


            //user.Adress = (string)row["Adress"];
            //// roles.JobId = (int)row["JobId"];


            //return user;
        }
    }
}
