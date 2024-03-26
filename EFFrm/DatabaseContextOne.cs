using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm
{
    public class DatabaseContextOne : DbContext
    {
       protected override  void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=DESKTOP-HEQ5CMC\\SQLEXPRESS2014;Database=EFTRai;User Id=sa; Password=P@ssw0rd;");
            }   
        }
    }
}
