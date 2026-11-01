using System.Collections.Generic;

namespace NzbDrone.Core.Games
{
    public interface IGameService
    {
        Game AddGame(Game newGame);
        Game GetGame(int gameId);
        List<Game> GetAllGames();
        Game UpdateGame(Game game);
        void DeleteGame(int gameId, bool deleteFiles);
        Game FindByIgdbId(int igdbId);
        Game FindBySteamAppId(int steamAppId);
        List<Game> FindByPlatform(string platform);
        bool GameExists(string title, int year, string platform);
    }
}
