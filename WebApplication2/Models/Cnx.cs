using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public static class Cnx
    {
        private static string cnx = "Server=localhost; port=3307; Database=cars_test; UserID=root";
        public static MySqlConnection getCnx()
        {
            return new MySqlConnection(cnx);
        }
    }
}