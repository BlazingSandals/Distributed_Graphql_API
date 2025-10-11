var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddGraphQLServer()
    .AddDataLoader<FinTech.Dataloaders.TradesDataLoader>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
