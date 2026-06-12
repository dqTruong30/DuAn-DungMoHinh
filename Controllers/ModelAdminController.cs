#nullable enable

using DungMoHinh.Models;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

[Route("modelAdmin")]
public class ModelAdminController : Controller
{
    private readonly SignInManager<NguoiDungUngDung> _signInManager;
    private readonly UserManager<NguoiDungUngDung> _userManager;

    public ModelAdminController(
        SignInManager<NguoiDungUngDung> signInManager,
        UserManager<NguoiDungUngDung> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet("")]
    [AllowAnonymous]
    public IActionResult Index(string? returnUrl = null)
    {
        if (User.IsInRole(VaiTroHeThong.Admin))
        {
            return RedirectToAdmin(returnUrl);
        }

        return View(new YeuCauDangNhap { ReturnUrl = returnUrl });
    }

    [HttpPost("")]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(YeuCauDangNhap request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu Admin không đúng.");
            return View(request);
        }

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.MatKhau, lockoutOnFailure: false);
        if (!checkPassword.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu Admin không đúng.");
            return View(request);
        }

        if (!await _userManager.IsInRoleAsync(user, VaiTroHeThong.Admin))
        {
            ModelState.AddModelError(string.Empty, "Tài khoản này không có quyền Admin.");
            return View(request);
        }

        await _signInManager.SignInAsync(user, request.GhiNhoDangNhap);

        return RedirectToAdmin(request.ReturnUrl);
    }

    private IActionResult RedirectToAdmin(string? returnUrl)
    {
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToAction("Dashboard", "QuanTri");
    }
}
