import { QualityModel } from './QualityProfile';

export interface GameFile {
  id: number;
  gameId: number;
  relativePath: string;
  path: string;
  size: number;
  dateAdded: string;
  componentType: 'BaseGame' | 'Update' | 'DLC' | 'Bonus';
  version?: string;
  buildId?: string;
  dlcName?: string;
  quality: QualityModel;
  releaseGroup?: string;
  sceneName?: string;
}

export interface Game {
  id: number;
  title: string;
  sortTitle: string;
  cleanTitle: string;
  overview: string;
  developer?: string;
  publisher?: string;
  year: number;
  platform: string;
  platforms: string[];
  genres: string[];
  status: 'TBA' | 'Announced' | 'EarlyAccess' | 'Released' | 'Delisted';
  minimumAvailability: 'TBA' | 'Announced' | 'EarlyAccess' | 'Released';
  igdbId: number;
  steamAppId?: number;
  rawgId?: number;
  path: string;
  rootFolderPath: string;
  qualityProfileId: number;
  monitored: boolean;
  hasFile: boolean;
  sizeOnDisk?: number;
  images: Array<{
    coverType: 'poster' | 'banner' | 'fanart' | 'screenshot' | 'clearlogo';
    url: string;
    remoteUrl?: string;
  }>;
  ratings?: {
    votes: number;
    value: number;
  };
  tags: number[];
  added: string;
  releaseDate?: string;
  gameFiles?: GameFile[];
}
