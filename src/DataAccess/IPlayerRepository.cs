using System.Collections.Generic;
using System.Threading.Tasks;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.DataAccess
{
  public interface IPlayerRepository
  {
    int PlayerCount { get; }
    Task<IEnumerable<Player>> GetAllPlayers();
    Task<Player> GetPlayerById(int playerId);
    Task<Player> AddPlayer(Player player);
    Task<Player> UpdatePlayer(Player player);
    Task<Player> DeletePlayer(int playerId);
  }
}
