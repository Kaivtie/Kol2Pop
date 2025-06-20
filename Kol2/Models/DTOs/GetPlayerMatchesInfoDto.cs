using System.Collections.ObjectModel;

namespace Kol2.DTOs;

public class GetPlayerMatchesInfoDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Matches> Matches { get; set; }
}

public class Matches
{
    public string TournamentName { get; set; }
    public string MapName { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<int> Mvps { get; set; }
    public IEnumerable<double> Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}