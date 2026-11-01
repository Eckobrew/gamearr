using System;
using System.Collections.Generic;
using Equ;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.Movies;

namespace NzbDrone.Core.Games
{
    public class GameMetadata : Entity<GameMetadata>
    {
        public GameMetadata()
        {
            Images = new List<MediaCover.MediaCover>();
            Genres = new List<string>();
            Platforms = new List<string>();
            Tags = new List<string>();
            Ratings = new Ratings();
        }

        public int IgdbId { get; set; }
        public int? SteamAppId { get; set; }
        public int? RawgId { get; set; }

        public string Title { get; set; }
        public string CleanTitle { get; set; }
        public string SortTitle { get; set; }
        public string Overview { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public GameStatusType Status { get; set; }

        public List<string> Platforms { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Tags { get; set; }
        public List<MediaCover.MediaCover> Images { get; set; }
        public Ratings Ratings { get; set; }

        public string Website { get; set; }
        public string YouTubeTrailerId { get; set; }
        public DateTime? LastInfoSync { get; set; }
    }
}
