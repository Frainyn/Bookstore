using Json.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Json.Data;

public class ConsoleAppDatabase : DbContext
{
    



    public DbSet<Book> books { get; set; } = null!;
    public DbSet<Author> authors { get; set; } = null!;
    public DbSet<Library> libraries { get; set; } = null!;
    public DbSet<HistoryFiles> historyFiles { get; set; } = null!;



    //public ConsoleAppDatabase() => Database.EnsureCreated();

    //string connection = string.Format("server=localhost;user=root;password=123;database=json;");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    //{
    //    optionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 10, 28)));
    //}
    public ConsoleAppDatabase(DbContextOptions<ConsoleAppDatabase> options) : base(options)
    {
        Database.Migrate();
    }
    //public void migration()
    //{
    //    using (ConsoleAppDatabase db = new ConsoleAppDatabase())
    //    {
    //        db.Database.Migrate();
    //    }
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Library>()
            .HasOne(u => u.Book)
            .WithMany(c => c.Libraries)
            .HasForeignKey(u => u.BookID)
            .HasPrincipalKey(c => c.Id1C);


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        Console.WriteLine(Assembly.GetExecutingAssembly());
    }

    public void migration()
    {
        throw new NotImplementedException();
    }
}

