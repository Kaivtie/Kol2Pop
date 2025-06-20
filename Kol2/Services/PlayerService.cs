using Kol2.Data;
using Kol2.DTOs;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class PlayerService : IPlayerService
{
    private readonly DatabaseContext _context;

    public PlayerService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PlayerDto?> AddPlayerAsync(CreatePlayerDto playerDto)
    {
        var player = new Player
        {
            FirstName = PlayerDto.FirstName,
            LastName = PlayerDto.LastName,
            BirthDate = PlayerDto.BirthDate,
            PlayerMatches = new List<PlayerMatch>()
        };

        foreach (var matchDto in playerDto.Matches)
        {
            var match = await _context.Matches.FindAsync(matchDto.MatchId);
            if (match == null) return new PlayerDto { PlayerId = -1 };

            var playerMatch = new PlayerMatch
            {
                MatchId = Matches.MatchId,
                Mvps = matchDto.MVPs,
                Rating = matchDto.Rating,
                Player = player
            };
            
            if (matchDto.Rating > match.BestRating)
            {
                match.BestRating = matchDto.Rating;
                _context.Matches.Update(match);
            }

            player.PlayerMatches.Add(playerMatch);
        }

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return new PlayerDto
        {
            PlayerId = player.PlayerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate
        };
    }

    public Task AddPlayerAsync(PlayerDto playerDto)
    {
        throw new NotImplementedException();
    }
}
