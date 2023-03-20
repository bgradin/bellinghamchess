using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellinghamChessClub.Models;
using Microsoft.EntityFrameworkCore;

namespace BellinghamChessClub.DataAccess
{
  public class PlayerRepository : IPlayerRepository
  {
    private readonly ClubDbContext _dbContext;

    public PlayerRepository(ClubDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public int PlayerCount
    {
      get { return _dbContext.Players.Count(); }
    }

    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
      return await _dbContext.Players.ToListAsync();
    }

    public async Task<Player> GetPlayerById(int playerId)
    {
      return await _dbContext.Players.FindAsync(playerId);
    }

    public async Task<Player> AddPlayer(Player player)
    {
      await _dbContext.Players.AddAsync(player);
      await _dbContext.SaveChangesAsync();
      return player;
    }

    public async Task<Player> UpdatePlayer(Player player)
    {
      _dbContext.Players.Update(player);
      await _dbContext.SaveChangesAsync();
      return player;
    }

    public async Task<Player> DeletePlayer(int playerId)
    {
      var player = await GetPlayerById(playerId);
      if (player != null)
      {
        _dbContext.Players.Remove(player);
        await _dbContext.SaveChangesAsync();
      }
      return player;
    }
  }
}
