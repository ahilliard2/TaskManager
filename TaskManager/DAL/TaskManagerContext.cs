using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace TaskManager.DAL
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("TaskManagerContext")
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Task> Task { get; set; }
  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}