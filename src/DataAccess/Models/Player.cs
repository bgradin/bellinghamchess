using System.ComponentModel.DataAnnotations;

namespace BellinghamChessClub.Models
{
  public class Player
  {
    public int Id
    {
      get; set;
    }

    [Required]
    [StringLength(100)]
    public string FirstName
    {
      get; set;
    }

    [Required]
    [StringLength(100)]
    public string LastName
    {
      get; set;
    }

    [Required]
    [StringLength(360)]
    public string Email
    {
      get; set;
    }

    [Required]
    public int LadderRanking
    {
      get; set;
    }

    public bool IsAdmin
    {
      get; set;
    }
  }
}
