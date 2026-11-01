using System;
using System.Collections.Generic;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.Profiles.Qualities;

namespace NzbDrone.Core.Games
{
    public class Game : ModelBase
    {
        public Game()
        {
            Tags = new HashSet<int>();
            GameMetadata = new GameMetadata();
            GameFiles = new List<GameFile>();
            Platform = "PC";
        }

        public int GameMetadataId { get; set; }
        public bool Monitored { get; set; }
        public GameStatusType MinimumAvailability { get; set; }
        public int QualityProfileId { get; set; }

        public string Platform { get; set; }
        public string Path { get; set; }
        public string RootFolderPath { get; set; }
        public DateTime Added { get; set; }
        public QualityProfile QualityProfile { get; set; }
        public HashSet<int> Tags { get; set; }
        public DateTime? LastSearchTime { get; set; }

        public LazyLoaded<GameMetadata> GameMetadata { get; set; }
        public List<GameFile> GameFiles { get; set; }

        public bool HasFile => GameFiles != null && GameFiles.Count > 0;

        // Convenient metadata proxy properties
        public string Title
        {
            get => GameMetadata?.Value?.Title ?? "";
            set
            {
                if (GameMetadata?.Value != null)
                {
                    GameMetadata.Value.Title = value;
                }
            }
        }

        public int IgdbId
        {
            get => GameMetadata?.Value?.IgdbId ?? 0;
            set
            {
                if (GameMetadata?.Value != null)
                {
                    GameMetadata.Value.IgdbId = value;
                }
            }
        }

        public int? SteamAppId
        {
            get => GameMetadata?.Value?.SteamAppId;
            set
            {
                if (GameMetadata?.Value != null)
                {
                    GameMetadata.Value.SteamAppId = value;
                }
            }
        }

        public int Year
        {
            get => GameMetadata?.Value?.Year ?? 0;
            set
            {
                if (GameMetadata?.Value != null)
                {
                    GameMetadata.Value.Year = value;
                }
            }
        }

        public string FolderName()
        {
            return Path.IsNullOrWhiteSpace() ? "" : Path;
        }

        public bool IsAvailable()
        {
            if (GameMetadata?.Value == null)
            {
                return true;
            }

            return GameMetadata.Value.Status >= MinimumAvailability;
        }
    }
}
