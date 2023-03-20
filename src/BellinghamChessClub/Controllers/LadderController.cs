using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BellinghamChessClub.DataAccess;

namespace BellinghamChessClub.Controllers
{
    [Route("Ladder")]
    public class LadderController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public LadderController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [Route("/Ladder")]
        public async Task<IActionResult> Index()
        {
            var players = (await _playerRepository.GetAllPlayers()).OrderBy(p => p.LadderRanking).ToList();
            return View(players);
        }
    }
}
