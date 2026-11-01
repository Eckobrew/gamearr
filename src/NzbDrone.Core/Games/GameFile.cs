using System;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.Qualities;

namespace NzbDrone.Core.Games
{
    public class GameFile : ModelBase
    {
        public int GameId { get; set; }
        public string RelativePath { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime DateAdded { get; set; }
        
        public GameFileComponentType ComponentType { get; set; }
        public string Version { get; set; }
        public string BuildId { get; set; }
        public string DlcName { get; set; }
        
        public QualityModel Quality { get; set; }
        public string ReleaseGroup { get; set; }
        public string SceneName { get; set; }
    }
}
