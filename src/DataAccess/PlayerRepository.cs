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

    public async Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
      return await _dbContext.Players.ToListAsync();
    }

    public async Task<Player> GetPlayerByIdAsync(int playerId)
    {
      return await _dbContext.Players.FindAsync(playerId);
    }

    public async Task<Player> AddPlayerAsync(Player player)
    {
      await _dbContext.Players.AddAsync(player);
      await _dbContext.SaveChangesAsync();
      return player;
    }

    public async Task<Player> UpdatePlayerAsync(Player player)
    {
      _dbContext.Players.Update(player);
      await _dbContext.SaveChangesAsync();
      return player;
    }

    public async Task<Player> DeletePlayerAsync(int playerId)
    {
      var player = await GetPlayerByIdAsync(playerId);
      if (player != null)
      {
        _dbContext.Players.Remove(player);
        await _dbContext.SaveChangesAsync();
      }
      return player;
    }
  }
}
