using FluentMigrator;

namespace JourneyMiles.API.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_TRAVEL_OFFERS, "Create table to persist ")]
public class Version0002 : MigrationBase
{
    public override void Up()
    {
        CreateTable("TravelOffers")
            .WithColumn("InitialDate").AsDateTime().NotNullable()
            .WithColumn("EndDate").AsDateTime().NotNullable()
            .WithColumn("Price").AsDouble().NotNullable()
            .WithColumn("RouteId").AsGuid().NotNullable().ForeignKey("FK_TravelOffers_Route_Id", "Routes", "Id");
    }
}
