﻿using BengalBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BengalBooksWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}