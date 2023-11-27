using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace SpikeHangfire.DB
{
    public class HangFireDBContext : DbContext
    {
        //public DbSet<YourEntity> YourEntities { get; set; } // Replace YourEntity with your actual entity//

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set up your connection string to the database file here
            string connectionString = @"Data Source=(LocalDB)\TestDB;AttachDbFilename=|DataDirectory|\TestDB.mdf;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
