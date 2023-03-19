using System.Collections.Generic;
using System.Threading.Tasks;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.DataAccess
{
  public interface IPlayerRepository
  {
    Task<IEnumerable<Player>> GetAllPlayersAsync();
    Task<Player> GetPlayerByIdAsync(int playerId);
    Task<Player> AddPlayerAsync(Player player);
    Task<Player> UpdatePlayerAsync(Player player);
    Task<Player> DeletePlayerAsync(int playerId);
  }
}
