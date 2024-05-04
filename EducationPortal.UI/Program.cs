
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
//app.Services.AddHttpClient();

//app.Services.AddHttpClient("MyAPI", client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5000/");
//    // Diðer HttpClient ayarlarýný burada yapabilirsiniz.
//});

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=User}/{id?}");

app.Run();
