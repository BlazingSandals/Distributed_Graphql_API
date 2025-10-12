using FinTech.Accounts.Dataloaders;
using FinTech.Accounts.Repository;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddDataLoader<AccountsDataLoader>().AddQueryType<Query>();
builder.Services.AddDbContext<FinTechDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FintechDatabase"))
);

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
