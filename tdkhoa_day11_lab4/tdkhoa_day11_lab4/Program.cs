using Microsoft.EntityFrameworkCore;
using tdkhoa_day11_lab4.Data;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký MVC
builder.Services.AddControllersWithViews();

// Đăng ký SchoolContext
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolContext")));

var app = builder.Build();

// Khởi tạo database và dữ liệu mẫu
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DbInitializer.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();