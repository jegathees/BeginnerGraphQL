using Microsoft.EntityFrameworkCore;
using MyFirstGraphQL.DataAccess;
using MyFirstGraphQL.GraphQL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBlogRepository, BlogPostRepository>();

//builder.Services.AddGraphQLServer();

builder.Services
.AddGraphQLServer()
.AddType<AuthorType>()
.AddType<BlogPostType>()
.AddQueryType<AuthorQuery>()
.AddMutationType<Mutation>()
.AddSubscriptionType<Subscription>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseInMemoryDatabase("BlogsManagement"));
builder.Services.AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebSockets();
app.UseRouting().UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.UseAuthorization();

app.MapControllers();
//app.MapGraphQL("/graphql", "");

app.Run();
