namespace Kol2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tournament
{
    [Key] 
    public int TournamentId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}