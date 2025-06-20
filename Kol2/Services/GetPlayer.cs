using Kol2.Data;
using Kol2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class GetPlayer : IGetPlayer
{
    private readonly DatabaseContext _context;

    public GetPlayer(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetPlayerMatchesInfoDto?> GetPlayerMatchesInfo(int idPlayer)
    {
        var player = await _context.Players
            .Where(p => p.PlayerId == idPlayer)
            .Select(p => new GetPlayerMatchesInfoDto
            {
                PlayerId = p.PlayerId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Matches = p.PlayerMatches.Select(pm => new Matches
                {
                    TournamentName = pm.Tournaments.Select(t => t.Name).FirstOrDefault(),
                    MapName = pm.Maps.Select(m => m.Name).FirstOrDefault(),
                    Date = pm.DateTime,
                    Mvps = pm.Players.Select(m => m.Mvps),
                    Rating = pm.Players.Select(p => p.Rating),
                    Team1Score = pm.Team1Score,
                    Team2Score = pm.Team2Score
                }).ToList()
            })
            .FirstOrDefaultAsync<object>();

        if (player == null)
        {
            throw new Exception("Player not found");
        }

        return (GetPlayerMatchesInfoDto?)player;
    }
}