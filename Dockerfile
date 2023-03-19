FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY src .

WORKDIR /app/BellinghamChessClub

RUN dotnet restore && dotnet build && dotnet publish -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /app

RUN curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg

COPY --from=build /publish ./

EXPOSE 5000

ENTRYPOINT dotnet BellinghamChessClub.dll
