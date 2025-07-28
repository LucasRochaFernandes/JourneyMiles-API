using JourneyMiles.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JourneyMiles.API.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Domain.Entities.TravelOffer> TravelOffers { get; set; }
    public DbSet<Domain.Entities.Route> Routes { get; set; }

    public AppDbContext(IServiceProvider serviceProvider, DbContextOptions<AppDbContext> options)
       : base(options)
    {
        _configuration = serviceProvider.GetRequiredService<IConfiguration>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<TravelOffer>(builder =>
        {
            builder.OwnsOne(to => to.Period, periodBuilder =>
            {
                periodBuilder.Property(p => p.InitialDate)
                    .HasColumnName("InitialDate");
                periodBuilder.Property(p => p.EndDate)
                    .HasColumnName("EndDate");
            });
        });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
