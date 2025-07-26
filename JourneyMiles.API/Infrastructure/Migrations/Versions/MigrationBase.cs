﻿using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace JourneyMiles.API.Infrastructure.Migrations.Versions;

public abstract class MigrationBase : ForwardOnlyMigration
{
    protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string tableName)
    {
        return Create.Table(tableName)
           .WithColumn("Id").AsGuid().PrimaryKey();
    }
}
