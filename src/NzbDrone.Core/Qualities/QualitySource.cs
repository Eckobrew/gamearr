namespace NzbDrone.Core.Qualities
{
    public enum QualitySource
    {
        UNKNOWN = 0,
        SCENE = 1,
        GOG = 2,
        REPACK = 3,
        RETAIL_DISC = 4,
        PORTABLE = 5,
        EARLY_ACCESS = 6,
        UPDATE_PATCH = 7,
        DLC = 8,
        
        // Legacy / fallback types
        DVD = 10,
        TV = 11,
        WEBDL = 12,
        WEBRIP = 13,
        BLURAY = 14
    }
}
