using System;

namespace BellinghamChessClub.Models
{
  public class Game
  {
    public int Id
    {
      get; set;
    }

    public Player WhitePlayer
    {
      get; set;
    }

    public Player BlackPlayer
    {
      get; set;
    }

    public DateTime DatePlayed
    {
      get; set;
    }

    public string Result
    {
      get; set;
    }

    public int WhitePlayerRatingBeforeGame
    {
      get; set;
    }

    public int BlackPlayerRatingBeforeGame
    {
      get; set;
    }

    public int WhitePlayerRatingAfterGame
    {
      get; set;
    }

    public int BlackPlayerRatingAfterGame
    {
      get; set;
    }
  }
}
