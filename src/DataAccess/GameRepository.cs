using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BellinghamChessClub.Models;

namespace BellinghamChessClub.DataAccess
{
  public class GameRepository : IGameRepository
  {
    private readonly ClubDbContext _dbContext;

    public GameRepository(ClubDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllGames()
    {
      return await _dbContext.Games.ToListAsync();
    }

    public async Task<Game> GetGameById(int id)
    {
      return await _dbContext.Games.FindAsync(id);
    }

    public async Task<Game> AddGame(Game game)
    {
      await _dbContext.Games.AddAsync(game);
      await _dbContext.SaveChangesAsync();
      return game;
    }

    public async Task<Game> UpdateGame(Game game)
    {
      _dbContext.Entry(game).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
      return game;
    }

    public async Task<Game> DeleteGame(int id)
    {
      var game = await GetGameById(id);
      _dbContext.Games.Remove(game);
      await _dbContext.SaveChangesAsync();
      return game;
    }
  }
}
