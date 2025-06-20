using Kol2.Models;

namespace Kol2.Data;

using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }

    protected DatabaseContext()
    {
        
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Map>().HasData(new List<Map>()
        {
            new Map() {MapId = 1, Name = "costam", Type = "classic"},
            new Map() {MapId = 2, Name = "cosinnego", Type = "war"},
        });
        
        modelBuilder.Entity<Match>().HasData(new List<Match>()
        {
            new Match() {MatchId = 1, TournamentId = 1, MapId = 1, DateTime = DateTime.Now, Team1Score = 1, Team2Score = 3, BestRating = 4},
            new Match() {MatchId = 2, TournamentId = 2, MapId = 2, DateTime = DateTime.Now, Team1Score = 5, Team2Score = 2, BestRating = 2},
            
        });
        
        modelBuilder.Entity<Player>().HasData(new List<Player>()
        {
            new Player() {PlayerId = 1, FirstName = "John", LastName = "Smith", BirthDate = DateTime.Now},
            new Player() {PlayerId = 2, FirstName = "Simon", LastName = "High", BirthDate = DateTime.Now}
        });
        
        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>()
        {
            new PlayerMatch() {Mvps = 1, Rating = 2, MatchId = 1, PlayerId = 1},
            new PlayerMatch() {Mvps = 2, Rating = 2, MatchId = 2, PlayerId = 2}
        });
        
        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>()
        {
            new Tournament() {TournamentId = 1, Name = "BigOne", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7)},
            new Tournament() {TournamentId = 2, Name = "Small", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7)},
        });
    }
}