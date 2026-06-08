#nullable enable

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public abstract class ControllerCoSo : Controller
{
    protected string CurrentUserId =>
        User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? User.Identity?.Name
        ?? "demo-user";
}

