using StrongsideStats.Data.DTOs;
using StrongsideStats.Data.Models;

namespace StrongsideStats.Services.Interfaces
{
    public interface IMappingService
    {
        Summoner MapSummoner(AccountDTO account);
        League MapLeague(LeagueDTO leagueDto);
    }
}
