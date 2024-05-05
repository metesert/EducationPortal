using EducationPortal.Business.Abstract;
using EducationPortal.Business.Concrete;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Concrete;
using EducationPortal.UI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EducationPortalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();

builder.Services.AddScoped<IEducationDal, EducationDal>();
builder.Services.AddScoped<IEducationService, EducationService>();

builder.Services.AddScoped<IFilesDal, FilesDal>();
builder.Services.AddScoped<IFilesService, FilesService>();

builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProcessDal, ProcessDal>();
builder.Services.AddScoped<IProcessService, ProcessService>();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:7217") // MVC uygulamanýzýn adresi
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

//app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
