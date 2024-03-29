﻿using EnterpriseODataApis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnterpriseODataApis.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventClass> EventClasses { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

    }
}
