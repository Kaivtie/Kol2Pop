namespace Kol2.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    [Key]
    public int PlayerId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; }
}