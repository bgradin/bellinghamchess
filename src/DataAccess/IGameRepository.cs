using System.Collections.Generic;
using System.Threading.Tasks;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.DataAccess
{
  public interface IGameRepository
  {
    Task<IEnumerable<Game>> GetAllGames();
    Task<Game> GetGameById(int gameId);
    Task<Game> AddGame(Game game);
    Task<Game> UpdateGame(Game game);
    Task<Game> DeleteGame(int gameId);
  }
}
