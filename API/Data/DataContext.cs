using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
        //DBSet, para realizar queries a la tabla Users
        public DbSet<AppUser> Users { get; set; } //Name of our table in the database
}
