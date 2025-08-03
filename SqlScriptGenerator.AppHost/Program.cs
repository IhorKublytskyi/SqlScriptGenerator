var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres", port:54321)
    .WithDataVolume()
    .WithPgAdmin();

var postgresDb = postgres.AddDatabase("postgres-db");

var dataProvider = builder.AddProject<Projects.DataProvider>("dataprovider")
    .WithExternalHttpEndpoints()
    .WithReference(postgresDb)
    .WaitFor(postgresDb);

var service = builder.AddProject<Projects.Service>("apiservice")
    .WithExternalHttpEndpoints()
    .WithReference(dataProvider);

var storefront = builder.AddProject<Projects.Storefront>("frontend")
    .WithExternalHttpEndpoints()
    .WithReference(service);

await builder.Build().RunAsync();
