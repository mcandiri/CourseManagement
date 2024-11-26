using CourseManagement.Data;
using CourseManagement.Models;
using CourseManagement.Repositories.Abstract;
using CourseManagement.Repositories.Concrete;
using CourseManagement.Services.Abstract;
using CourseManagement.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CourseManagementDatabase"));
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Mock objects
    context.Students.Add(new Student
    {
        Id = 1,
        Name = "John",
        Surname = "Doe",
        Email = "john.doe@example.com",
        EnrollmentDate = DateTime.Now,
        IsPriority = true //  priority student
    });

    context.Students.Add(new Student
    {
        Id = 2,
        Name = "Jane",
        Surname = "Smith",
        Email = "jane.smith@example.com",
        EnrollmentDate = DateTime.Now,
        IsPriority = false // normal student
    });


    // Courses
    context.Courses.Add(new Course
    {
        Id = 1,
        CourseName = "Mathematics 101",
        Capacity = 30,
        AvailableSlots = 30,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(3)
    });

    context.Courses.Add(new Course
    {
        Id = 2,
        CourseName = "Physics 101",
        Capacity = 25,
        AvailableSlots = 25,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(3)
    });


    context.Courses.Add(new Course
    {
        Id = 3,
        CourseName = "Chemistry 101",
        Capacity = 20,
        AvailableSlots = 20,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(3)
    });

    context.Courses.Add(new Course
    {
        Id = 4,
        CourseName = "Biology 101",
        Capacity = 15,
        AvailableSlots = 15,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(3)
    });

    context.Courses.Add(new Course
    {
        Id = 5,
        CourseName = "History 101",
        Capacity = 10,
        AvailableSlots = 10,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now.AddMonths(3)
    });

    context.SaveChanges();
}

app.Run();
