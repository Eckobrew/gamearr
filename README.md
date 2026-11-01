# Gamearr — Video Game PVR & Collection Manager

[![License](https://img.shields.io/badge/license-GPLv3-blue.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/platform-Linux%20%7C%20macOS%20%7C%20Windows-lightgrey.svg)](https://github.com/eckobrew/gamearr)
[![Docker](https://img.shields.io/badge/docker-ready-blue.svg)](docker-compose.yml)

**Gamearr** is an `*arr`-style automated PVR and game library manager for Usenet and BitTorrent users, forked and adapted from Radarr. It monitors RSS feeds and indexers for wanted PC and console games, interfaces with download clients (like qBittorrent), and organizes, renames, and manages your game collection.

---

## 🎮 Why Gamearr?

While Radarr manages movies and Sonarr manages TV episodes, **video games require an entirely different domain model**:

* **Game-Native Quality Profiles**: Instead of video resolutions (1080p, 4K, Remux), Gamearr understands game releases:
  * **Scene** (standard scene ISO/installers by CODEX, FLT, RUNE, SKIDROW, etc.)
  * **GOG / DRM-Free** (official DRM-free standalone installers)
  * **Repack** (compressed repacks by FitGirl, DODI, ElAmigos)
  * **Retail / ISO** (1:1 disc image dumps)
  * **Portable / Unpacked** (pre-installed, direct-play folders)
  * **Early Access / Beta**
* **Game Component Tracking**: Games are not single static files. Gamearr tracks:
  * **Base Game**
  * **Versioned Updates & Patches** (e.g. `v1.0.4`, `Hotfix 2`)
  * **DLCs & Expansions**
* **Indexer Game Categories**:
  * Default Newznab & Torznab categories mapped to **PC Games (`4000`)** and **Console Games (`1000`)** instead of video/audio categories.
* **Gaming Metadata Providers**:
  * Metadata discovery designed for **IGDB**, **Steam**, and **RAWG** instead of TMDb/TVDb.

---

## 🚀 Getting Started

### Using Docker (Recommended)

1. Create a `docker-compose.yml` file:

```yaml
services:
  gamearr:
    image: gamearr:latest
    build:
      context: .
      dockerfile: Dockerfile
    container_name: gamearr
    environment:
      - PUID=1000
      - PGID=1000
      - TZ=Etc/UTC
    volumes:
      - ./config:/config
      - /path/to/games:/games
      - /path/to/downloads:/downloads
    ports:
      - "8484:8484"
    restart: unless-stopped
```

2. Start the container:

```bash
docker compose up -d
```

3. Open **`http://localhost:8484`** in your browser.

---

## 🛠️ Architecture & Solution Structure

Gamearr retains the robust, proven `*arr` architecture while pivoting the domain logic:

```
src/
├── Gamearr.sln                  # Master .NET Solution
├── Gamearr.Api.V3/              # REST API v3 controllers & models
│   └── Games/                   # Game & GameLookup API controllers
├── Gamearr.Http/                # Web host, HTTP pipeline, & authentication
├── NzbDrone.Core/               # Core business logic & database layer
│   ├── Games/                   # Game, GameFile, GameMetadata domain models
│   ├── Qualities/               # Game qualities (Scene, GOG, Repack, ISO, etc.)
│   ├── Indexers/                # Newznab / Torznab game categories
│   ├── Download/                # Download clients (qBittorrent, Deluge, Transmission, etc.)
│   └── Organizer/               # Game folder & file naming conventions
└── frontend/                    # Modern React / TypeScript UI
    └── src/
        ├── App/AppRoutes.tsx    # Routes including /games and /game/:titleSlug
        └── typings/Game.ts      # TypeScript interfaces for Games & Components
```

---

## 🔧 Building from Source

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or newer
* [Node.js](https://nodejs.org/) (v18+) and [Yarn](https://yarnpkg.com/)

### 1. Build the Frontend
```bash
yarn install
yarn build
```

### 2. Build the Backend
```bash
dotnet restore src/Gamearr.sln
dotnet build src/Gamearr.sln -c Release
```

### 3. Run Gamearr
```bash
dotnet run --project src/NzbDrone/Gamearr.csproj
```

---

## 📄 License
Gamearr is open-source software licensed under the **GNU General Public License v3.0 (GPL-3.0)**, preserving the license of its upstream foundations.
