using DungMoHinh.Data;
using DungMoHinh.Extensions;
using DungMoHinh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddIdentity<NguoiDungUngDung, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/TaiKhoan/DangNhap";
    options.LogoutPath = "/TaiKhoan/DangXuat";
    options.AccessDeniedPath = "/TaiKhoan/KhongCoQuyen";
    options.Events.OnRedirectToLogin = context =>
    {
        var returnUrl = $"{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}";
        if (context.Request.Path.StartsWithSegments("/QuanTri"))
        {
            context.Response.Redirect($"/modelAdmin?returnUrl={Uri.EscapeDataString(returnUrl)}");
            return Task.CompletedTask;
        }

        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
});

builder.Services.AddRepositoryLayer();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/TrangChu/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TrangChu}/{action=Index}/{id?}");

await TaoDuLieuDangNhapMauAsync(app);

app.Run();

static async Task TaoDuLieuDangNhapMauAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<NguoiDungUngDung>>();

    foreach (var roleName in new[] { VaiTroHeThong.Admin, VaiTroHeThong.User })
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    await TaoTaiKhoanNeuChuaCoAsync(
        userManager,
        email: "admin@dungmohinh.local",
        password: "Admin123",
        tenHienThi: "Quản trị viên",
        roleName: VaiTroHeThong.Admin);

    await TaoTaiKhoanNeuChuaCoAsync(
        userManager,
        email: "user@dungmohinh.local",
        password: "User123",
        tenHienThi: "Người dùng mẫu",
        roleName: VaiTroHeThong.User);
}

static async Task TaoTaiKhoanNeuChuaCoAsync(
    UserManager<NguoiDungUngDung> userManager,
    string email,
    string password,
    string tenHienThi,
    string roleName)
{
    var user = await userManager.FindByEmailAsync(email);
    if (user is null)
    {
        user = new NguoiDungUngDung
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            TenHienThi = tenHienThi
        };

        var createResult = await userManager.CreateAsync(user, password);
        if (!createResult.Succeeded)
        {
            throw new InvalidOperationException(
                $"Không thể tạo tài khoản mẫu {email}: {string.Join(", ", createResult.Errors.Select(error => error.Description))}");
        }
    }

    if (!await userManager.IsInRoleAsync(user, roleName))
    {
        await userManager.AddToRoleAsync(user, roleName);
    }
}

