using Analytics.Portal.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Analytics.Portal.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=177.93.108.166,9091;Initial Catalog=bg_AZfrete_Homolog;Persist Security Info=True;User ID=gbsdbmaster;Password=DB#@gbs@@2022;TrustServerCertificate=true");
    }

    public DbSet<LogModel> Log { get; set; }



}