using Kol2.DTOs;

namespace Kol2.Services;

public interface IGetPlayer
{
    Task<GetPlayerMatchesInfoDto?> GetPlayerMatchesInfo(int idPlayer);
}