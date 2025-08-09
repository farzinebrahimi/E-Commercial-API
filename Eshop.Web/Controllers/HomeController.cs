using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Controllers;

public class HomeController : SideBaseController
{
  public async Task<IActionResult> Index()
  {
    return View();
  }   
}