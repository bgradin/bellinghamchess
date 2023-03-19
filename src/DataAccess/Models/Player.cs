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
    public string Name
    {
      get; set;
    }

    [Required]
    [StringLength(100)]
    public string Email
    {
      get; set;
    }

    [Required]
    public int Rating
    {
      get; set;
    }

    public bool IsAdmin
    {
      get; set;
    }

    public void UpdateRating(int newRating)
    {
      this.Rating = newRating;
    }
  }
}
