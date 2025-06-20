namespace Kol2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Map
{
    [Key] 
    public int MapId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Type { get; set; }
}