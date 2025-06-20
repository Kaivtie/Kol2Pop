using Microsoft.EntityFrameworkCore;

namespace Kol2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
public class PlayerMatch
{
    public int Mvps { get; set; }
    [Column(TypeName = "decimal")]
    [Precision(4, 2)]
    public double Rating { get; set; }
    
    [ForeignKey(nameof(MatchId))]
    public int MatchId { get; set; }
    [ForeignKey(nameof(PlayerId))]
    public int PlayerId { get; set; }
    
    
}