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
            User user = new User("","","","","","","","","");
            //Roles roles = new Roles();

            user.FirstName = (string)row["FirstName"];
            user.LastName = (string)row["LastName"];
            user.Username = (string)row["Username"];
            //user.Password = (string)row["Password"];
            user.Salt = (string)row["Salt"];
            user.HashedPassword = (string)row["HashedPassword"];
            user.Email = (string)row["Email"];

            user.PhoneNumber = (string)row["PhoneNumber"];
            user.BirthDate = ((DateTime)row["DateOfBirth"]).ToString("yyyy-MM-dd");
            
            
            user.Adress = (string)row["Adress"];
           // roles.JobId = (int)row["JobId"];
            

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
