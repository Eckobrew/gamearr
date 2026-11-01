# Gamearr - Video Game PVR & Collection Manager
# Multi-stage Dockerfile

# Stage 1: Frontend Build
FROM node:20-alpine AS frontend-builder
WORKDIR /app
COPY package.json yarn.lock ./
RUN yarn install --frozen-lockfile --network-timeout 100000
COPY frontend ./frontend
RUN yarn build

# Stage 2: Backend Build (.NET 8/10 SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS backend-builder
WORKDIR /src
COPY src/ ./src/
COPY --from=frontend-builder /app/_output/UI ./_output/UI
RUN dotnet restore src/Gamearr.sln
RUN dotnet publish src/NzbDrone/Gamearr.csproj -c Release -o /app/publish -r linux-x64 --no-self-contained

# Stage 3: Runtime Environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
LABEL maintainer="Gamearr Team"
LABEL org.opencontainers.image.title="Gamearr"
LABEL org.opencontainers.image.description="Gamearr is a PVR for video games for Usenet and BitTorrent users"

ENV PUID=1000 \
    PGID=1000 \
    TZ=Etc/UTC \
    GAMEARR_PORT=8484 \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

RUN apk add --no-cache \
    bash \
    curl \
    sqlite-libs \
    su-exec \
    tzdata

WORKDIR /app
COPY --from=backend-builder /app/publish ./
COPY --from=frontend-builder /app/_output/UI ./UI

VOLUME ["/config", "/games", "/downloads"]
EXPOSE 8484

ENTRYPOINT ["dotnet", "Gamearr.dll", "-nobrowser", "-data=/config"]
