using System;
using System.Collections.Generic;
using NzbDrone.Core.Games;
using NzbDrone.Core.MediaCover;
using NzbDrone.Core.Movies;
using Gamearr.Http.REST;

namespace Gamearr.Api.V3.Games
{
    public class GameResource : RestResource
    {
        public GameResource()
        {
            Monitored = true;
            MinimumAvailability = GameStatusType.Released;
            Platforms = new List<string>();
            Genres = new List<string>();
            Tags = new HashSet<int>();
            Images = new List<MediaCover>();
        }

        public string Title { get; set; }
        public string SortTitle { get; set; }
        public string CleanTitle { get; set; }
        public string Overview { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string Platform { get; set; }
        public List<string> Platforms { get; set; }
        public List<string> Genres { get; set; }
        public GameStatusType Status { get; set; }
        public GameStatusType MinimumAvailability { get; set; }
        
        public int IgdbId { get; set; }
        public int? SteamAppId { get; set; }
        public int? RawgId { get; set; }
        
        public string Path { get; set; }
        public string RootFolderPath { get; set; }
        public int QualityProfileId { get; set; }
        public bool Monitored { get; set; }
        public bool HasFile { get; set; }
        public long? SizeOnDisk { get; set; }
        
        public List<MediaCover> Images { get; set; }
        public Ratings Ratings { get; set; }
        public HashSet<int> Tags { get; set; }
        public DateTime Added { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
