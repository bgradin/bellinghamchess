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

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
      return await _dbContext.Games.ToListAsync();
    }

    public async Task<Game> GetGameByIdAsync(int id)
    {
      return await _dbContext.Games.FindAsync(id);
    }

    public async Task<Game> AddGameAsync(Game game)
    {
      await _dbContext.Games.AddAsync(game);
      await _dbContext.SaveChangesAsync();
      return game;
    }

    public async Task<Game> UpdateGameAsync(Game game)
    {
      _dbContext.Entry(game).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
      return game;
    }

    public async Task<Game> DeleteGameAsync(int id)
    {
      var game = await GetGameByIdAsync(id);
      _dbContext.Games.Remove(game);
      await _dbContext.SaveChangesAsync();
      return game;
    }
  }
}
