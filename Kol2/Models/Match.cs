using Microsoft.EntityFrameworkCore;

namespace Kol2.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Match
{
    [Key] public int MatchId { get; set; }

    [ForeignKey(nameof(TournamentId))]
    public int TournamentId { get; set; }

    [ForeignKey(nameof(MapId))]
    public int MapId { get; set; }
    
    public DateTime DateTime { get; set; }

    public int Team1Score { get; set; }
    public int Team2Score { get; set; }

    [Column(TypeName = "decimal")]
    [Precision(4, 2)]
    public double BestRating { get; set; }
    
    public ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
    public ICollection<Map> Maps { get; set; } = new List<Map>();
    public ICollection<PlayerMatch> Players { get; set; } = new List<PlayerMatch>();

}