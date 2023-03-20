using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BellinghamChessClub.DataAccess;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.Controllers
{
  [Route("Admin")]
  public class AdminController : Controller
  {
    private readonly IPlayerRepository _playerRepository;

    public AdminController(IPlayerRepository playerRepository)
    {
      _playerRepository = playerRepository;
    }

    [Route("")]
    public async Task<IActionResult> Index()
    {
      var players = (await _playerRepository.GetAllPlayers()).OrderBy(p => p.FirstName).ToList();
      return View(players);
    }

    [Route("AddPlayer")]
    public IActionResult AddPlayer()
    {
      return View();
    }

    [HttpPost]
    [Route("AddPlayer")]
    public async Task<IActionResult> AddPlayer(Player player)
    {
      // New players are automatically placed at the end of the ladder
      player.LadderRanking = _playerRepository.PlayerCount + 1;

      await _playerRepository.AddPlayer(player);
      return RedirectToAction("Index");
    }

    [Route("EditPlayer")]
    public async Task<IActionResult> EditPlayer(int id)
    {
      var player = await _playerRepository.GetPlayerById(id);
      return View(player);
    }

    [HttpPost]
    [Route("EditPlayer")]
    public async Task<IActionResult> EditPlayer(Player player)
    {
      await _playerRepository.UpdatePlayer(player);
      return RedirectToAction("Index");
    }

    [Route("ConfirmDeletePlayer")]
    public async Task<IActionResult> ConfirmDeletePlayer(int id)
    {
      var player = await _playerRepository.GetPlayerById(id);
      return View(player);
    }

    [Route("DeletePlayer")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
      await _playerRepository.DeletePlayer(id);
      return RedirectToAction("Index");
    }
  }
}
