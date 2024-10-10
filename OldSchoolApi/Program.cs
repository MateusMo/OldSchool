using Microsoft.EntityFrameworkCore;
using OldSchoolAplication.Jwt;
using OldSchoolAplication.Services;
using OldSchoolInfrastructure.Data;
using OldSchoolInfrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OldSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OldSchool")));
builder.Services.AddScoped<IGetToken>(x => new GetToken(x.GetRequiredService<IUserRepository>(), builder.Configuration["Jwt:SecretKey"]));
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommandService, CommandService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
