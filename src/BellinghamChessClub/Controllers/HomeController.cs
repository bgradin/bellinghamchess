using Microsoft.AspNetCore.Mvc;

namespace BellinghamChessClub.Controllers
{
  [Route("Home")]
  public class HomeController : Controller
  {
    [Route("")]
    [Route("/")]
    public IActionResult Index()
    {
      return View();
    }

    [Route("Error")]
    [Route("/Error")]
    public IActionResult Error()
    {
      return View();
    }

    [Route("Privacy")]
    [Route("/Privacy")]
    public IActionResult Privacy()
    {
      return View();
    }
  }
}
