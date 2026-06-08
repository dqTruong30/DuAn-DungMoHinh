using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DungMoHinh.Models;

namespace DungMoHinh.Controllers;

public class TrangChuController : Controller
{
    private readonly ILogger<TrangChuController> _logger;

    public TrangChuController(ILogger<TrangChuController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new LoiViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

