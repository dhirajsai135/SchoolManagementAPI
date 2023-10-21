﻿using SchoolManagementAPI.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolCS")));
builder.Services.TryAddScoped<IStudentService, StudentService>();
builder.Services.TryAddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.TryAddScoped<ICourseService, CourseService>();
builder.Services.TryAddScoped<IClassService, ClassService>();
builder.Services.TryAddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
