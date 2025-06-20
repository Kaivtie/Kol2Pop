using Kol2.DTOs;

namespace Kol2.Services;

public interface IPlayerService
{
    Task AddPlayerAsync(PlayerDto playerDto);
}