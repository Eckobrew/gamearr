using System.Collections.Generic;
using System.Threading.Tasks;

namespace NzbDrone.Core.Games
{
    public interface IGameMetadataProvider
    {
        string ProviderName { get; }
        Task<List<GameMetadata>> SearchGame(string title);
        Task<GameMetadata> GetGameByIgdbId(int igdbId);
        Task<GameMetadata> GetGameBySteamId(int steamAppId);
    }
}
