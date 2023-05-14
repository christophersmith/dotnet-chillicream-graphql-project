# Product Microservice

This application shows a basic example of an ASP.NET GraphQL implementation using ASP.NET Core 6, ChilliCream Hot Chocolate, and entity Framework with SQL Server.

## Requirements

- .NET SDK 7+
- Docker for your environment
  - [Docker Desktop](https://www.docker.com/products/docker-desktop) for Mac or Windows
  - [Docker for Linux](https://hub.docker.com/search?offering=community&operating_system=linux&q=&type=edition)

## Start the SQL Server instance

From the solution root directory, run the following command:

```shell
docker-compose up
```

## Running database migrations

The database migrations process will create the necessary tables and indexes used by this application. You'll need the [Entity Framework Core tools installed](https://learn.microsoft.com/en-us/ef/core/cli/dotnet).

```shell
dotnet tool install --global dotnet-ef
```

Or installed locally, when in the `ProductMicroservice` directory.

```shell
dotnet new tool-manifest
dotnet tool install --local dotnet-ef
```

Ensure the SQL Server instance is running, then run the following command in the `ProductMicroservice` directory:

```shell
dotnet ef database update
```

## Installing test data

Test data is provided as a separate seeder project, and is recommended so you can see some data. Follow the instructions in the [DatabaseSeeder/README.md](../DatabaseSeeder/README.md) file to load the test data.

## Running the ProductMicroservice application

Once the SQL Server instance is running, the migrations have been applied, and the test data is seeded, you're ready to start the application and play around.

```shell
dotnet run
```

Once started, you can access [http://localhost:5009/graphql](http://localhost:5009/graphql) to explore the GraphQL schema and requests.

## Sample request

The following JSON will return the first 50 records from the database where `isActive` and `isSellable` is `true`, and the records will be sorted by `sku` ascending.

```graphql
query {
  products(
    first: 50
    where: { isActive: { eq: true }, isSellable: { eq: true } }
    order: [{ sku: ASC }]
  ) {
    totalCount
    pageInfo {
      hasNextPage
      hasPreviousPage
      startCursor
      endCursor
      __typename
    }
    edges {
      node {
        id
        sku
        name
        description
        unitMsrp
        productAttributes {
          productAttributeType {
            code
            name
            isActive
            __typename
          }
          value
          __typename
        }
        __typename
      }
      cursor
      __typename
    }
    __typename
  }
}
```

Additional information can be found in the Schema Reference section of the [http://localhost:5009/graphql](http://localhost:5009/graphql) site.
