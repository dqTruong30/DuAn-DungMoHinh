#nullable enable

using DungMoHinh.Models;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class TaiKhoanController : Controller
{
    private readonly SignInManager<NguoiDungUngDung> _signInManager;
    private readonly UserManager<NguoiDungUngDung> _userManager;

    public TaiKhoanController(
        SignInManager<NguoiDungUngDung> signInManager,
        UserManager<NguoiDungUngDung> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult DangNhap(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToLocal(returnUrl);
        }

        return View(new YeuCauDangNhap { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DangNhap(YeuCauDangNhap request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
            return View(request);
        }

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.MatKhau, lockoutOnFailure: false);
        if (!checkPassword.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
            return View(request);
        }

        if (await _userManager.IsInRoleAsync(user, VaiTroHeThong.Admin))
        {
            ModelState.AddModelError(string.Empty, "Tài khoản Admin vui lòng đăng nhập tại /modelAdmin.");
            return View(request);
        }

        await _signInManager.SignInAsync(user, request.GhiNhoDangNhap);

        return RedirectToLocal(request.ReturnUrl);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult DangKy()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "TrangChu");
        }

        return View(new YeuCauDangKy());
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DangKy(YeuCauDangKy request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var user = new NguoiDungUngDung
        {
            UserName = request.Email,
            Email = request.Email,
            TenHienThi = request.TenHienThi,
            EmailConfirmed = true
        };

        var createResult = await _userManager.CreateAsync(user, request.MatKhau);
        if (!createResult.Succeeded)
        {
            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(request);
        }

        await _userManager.AddToRoleAsync(user, VaiTroHeThong.User);
        await _signInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction("Index", "TrangChu");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DangXuat()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "TrangChu");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult KhongCoQuyen()
    {
        return View();
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToAction("Index", "TrangChu");
    }
}
