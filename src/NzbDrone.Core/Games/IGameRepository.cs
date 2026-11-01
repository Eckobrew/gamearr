using System.Collections.Generic;
using NzbDrone.Core.Datastore;

namespace NzbDrone.Core.Games
{
    public interface IGameRepository : IBasicRepository<Game>
    {
        bool Exists(string title, int year, string platform);
        Game FindByTitle(string cleanTitle);
        Game FindByIgdbId(int igdbId);
        Game FindBySteamAppId(int steamAppId);
        List<Game> FindByPlatform(string platform);
    }
}
