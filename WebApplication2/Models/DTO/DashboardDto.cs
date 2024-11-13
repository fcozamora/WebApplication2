using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebApplication2.Models.DTO
{
    public class DashboardDto
    {
        public User UserModel { get; set; }
        public Product ProductModel { get; set; }
    }
}