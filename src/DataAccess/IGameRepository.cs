using System.Collections.Generic;
using System.Threading.Tasks;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.DataAccess
{
  public interface IGameRepository
  {
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<Game> GetGameByIdAsync(int gameId);
    Task<Game> AddGameAsync(Game game);
    Task<Game> UpdateGameAsync(Game game);
    Task<Game> DeleteGameAsync(int gameId);
  }
}
