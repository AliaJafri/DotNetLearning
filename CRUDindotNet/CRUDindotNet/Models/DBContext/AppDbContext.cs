
using CRUDindotNet.Models;
using Microsoft.EntityFrameworkCore; //installed nuget pkgs to connect with sql 
using CRUDindotNet.Models.Entities; //add this so <Employee> can work 
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Define a DbSet for each table in your database
    //in below line <model name> is connected with <table name>
    public DbSet<Employee> Employee { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuring the primary key for the Employee entity
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.ID);

        base.OnModelCreating(modelBuilder);
    }
}
//db context class use for connection between db and code it write query in db... code is mention in settings as well as program