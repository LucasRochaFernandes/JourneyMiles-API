using Microsoft.EntityFrameworkCore;

namespace JourneyMiles.API.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Domain.Entities.TravelOffer> TravelOffers { get; set; }

    public AppDbContext(IServiceProvider serviceProvider, DbContextOptions<AppDbContext> options)
       : base(options)
    {
        _configuration = serviceProvider.GetRequiredService<IConfiguration>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
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
