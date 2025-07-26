using FluentMigrator;

namespace JourneyMiles.API.Infrastructure.Migrations.Versions;


[Migration(DatabaseVersions.TABLE_ROUTES, "Create table to persist routes")]
public class Version0001 : MigrationBase
{
    public override void Up()
    {
        CreateTable("Routes")
          .WithColumn("Origin").AsString().NotNullable()
          .WithColumn("Destination").AsString().NotNullable();
    }
}
