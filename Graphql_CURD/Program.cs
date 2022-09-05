using Graphql_CURD.Data;
using Graphql_CURD.Shema.Mutation;
using Graphql_CURD.Shema.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyWorkDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CTMSSQL"));
});
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering();

var app = builder.Build();

app.MapGraphQL();
app.Run();
