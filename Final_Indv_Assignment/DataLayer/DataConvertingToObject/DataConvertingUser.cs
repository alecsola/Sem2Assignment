using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Class;

namespace DataLayer.DataConvertingToObject
{
    public class DataConvertingUser 
    {
        
        public static User ConvertRowToUser(DataRow row)
        {
            
            //Roles roles = new Roles();

            string FirstName = (string)row["FirstName"];
            string LastName = (string)row["LastName"];
            string Username = (string)row["Username"];
            //user.Password = (string)row["Password"];
            string Salt = (string)row["Salt"];
            string HashedPassword = (string)row["HashedPassword"];
            string Email = (string)row["Email"];

            string PhoneNumber = (string)row["PhoneNumber"];
            string BirthDate = ((DateTime)row["DateOfBirth"]).ToString("yyyy-MM-dd");
            
            
            string Adress = (string)row["Adress"];
            // roles.JobId = (int)row["JobId"];
            User user = new User(FirstName,LastName,Username,Salt,HashedPassword,Email,PhoneNumber,BirthDate,Adress);

            return user;
        }

        public static List<User> ConvertTableToList(DataTable table)
        {
            List<User> userList = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                User user = ConvertRowToUser(row);
                userList.Add(user);
            }
            return userList;
        }
    }
}
