﻿using System;
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
            int Id = (int)row["UserId"];
            string FirstName = (string)row["FirstName"];
            string LastName = (string)row["LastName"];
            string Username = (string)row["Username"];
            //user.Password = (string)row["Password"];
            string Salt = (string)row["Salt"];
            string HashedPassword = (string)row["HashedPassword"];
            string Email = (string)row["Email"];

            string PhoneNumber = (string)row["PhoneNumber"];
            string BirthDate = ((DateTime)row["DateOfBirth"]).ToString("yyyy-MM-dd");
            string roleId = ((int)row["RoleId"]).ToString();
            
            string Adress = (string)row["Adress"];
            // roles.JobId = (int)row["JobId"];
            User user = new User(Id, FirstName,LastName,Username,Salt,HashedPassword,Email,PhoneNumber,BirthDate,Adress,roleId);

            return user;
        }

       
    }
}
