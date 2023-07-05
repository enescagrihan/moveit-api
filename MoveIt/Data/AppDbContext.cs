using System;
using Microsoft.EntityFrameworkCore;
using MoveIt.Models;
using MoveIt.Models.Carrier;
using MoveIt.Models.Customer;

namespace MoveIt.Data
{
	public class AppDbContext: DbContext
	{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Ad> Ads { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
    }
}

