using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
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
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddAuthorization();
builder.Services.AddSingleton(FirebaseApp.Create());
builder.Services.AddFirebaseAuthentication();

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.MapGraphQL();
app.Run();
