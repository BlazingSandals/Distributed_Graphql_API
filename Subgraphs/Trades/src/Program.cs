using FinTech.Trades.Dataloaders;
using FinTech.Trades.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddDataLoader<TradesDataLoader>().AddQueryType<Query>();
builder.Services.AddDbContext<FinTechDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FintechDatabase"))
);

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
