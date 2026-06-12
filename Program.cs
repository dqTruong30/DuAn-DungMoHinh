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
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

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

    await TaoMauNhanVatMacDinhAsync(dbContext);
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

static async Task TaoMauNhanVatMacDinhAsync(ApplicationDbContext dbContext)
{
    var mauMacDinhs = new[]
    {
        new MauNhanVat
        {
            Name = "Nữ pháp sư huyền thuật",
            MoTa = "Mẫu fantasy với áo choàng xanh, hiệu ứng phép thuật và phong cách nhân vật nổi bật.",
            Kind = LoaiNhanVat.Nu,
            Style = PhongCachNhanVat.GiaTuong,
            ModelUrl = "/models/templates/fantasy-mage.glb",
            IsActive = true
        },
        new MauNhanVat
        {
            Name = "Nam chiến binh cơ bản",
            MoTa = "Mẫu thân hình cân đối, phù hợp để phát triển nhân vật phiêu lưu hoặc chiến đấu.",
            Kind = LoaiNhanVat.Nam,
            Style = PhongCachNhanVat.BinhThuong,
            ModelUrl = "/models/templates/male-warrior.glb",
            IsActive = true
        },
        new MauNhanVat
        {
            Name = "Chibi đáng yêu",
            MoTa = "Mẫu đầu to, dáng nhỏ gọn, phù hợp nhân vật vui nhộn hoặc phong cách anime.",
            Kind = LoaiNhanVat.ChibiNu,
            Style = PhongCachNhanVat.Chibi,
            ModelUrl = "/models/templates/chibi-cute.glb",
            IsActive = true
        }
    };

    foreach (var mau in mauMacDinhs)
    {
        var daTonTai = await dbContext.MauNhanVats.AnyAsync(item => item.ModelUrl == mau.ModelUrl);
        if (!daTonTai)
        {
            dbContext.MauNhanVats.Add(mau);
        }
    }

    await dbContext.SaveChangesAsync();
}

