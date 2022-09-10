using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using FluentValidation.AspNetCore;
using Graphql_CURD.Data;
using Graphql_CURD.Shema.Mutation;
using Graphql_CURD.Shema.Query;
using Graphql_CURD.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyWorkDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CTMSSQL"));
});
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.AddSingleton<BooksService>();
builder.Services.AddFluentValidation();
builder.Services.AddTransient<CakeInputTypeValidator>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddAuthorization();
builder.Services.AddSingleton(FirebaseApp.Create());
builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization(o=>o.AddPolicy(
    "IsAdmin",p=>p.RequireClaim(FirebaseUserClaimType.EMAIL, "xoree2e@o2.com")));

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.MapGraphQL();
app.Run();
