# Database Seeder

This project seeds test data into the SQL Server instance used by the [ProductMicroservice](../ProductMicroservice/). The seeding process first deletes all records from the `Product`, `ProductAttribute`, and `ProductAtributeType` tables and then inserts the test data, using the Entity Framework.

## Requirements

- .NET SDK 7+
- SQL Server 2019
- Assumes that the Entity Framework migrations have been run and the necessary tables and indexes exist, as defined in the [ProductMicroservice](../ProductMicroservice/) project

## Running

Please ensure that the target SQL Server instance is running. If you're using a different SQL Server instance or credentials than what's provided in the [docker-compose.yml](../docker-compose.yml) file, you'll need to modify the `ProductDatabase` connection string in the [appsettings.json](appsettings.json) file to suit your preferences.

```shell
dotnet run
```
