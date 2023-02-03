#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TEvolvers/TEvolvers.csproj", "TEvolvers/"]
RUN dotnet restore "TEvolvers/TEvolvers.csproj"
COPY . .
WORKDIR "/src/TEvolvers"
RUN dotnet build "TEvolvers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TEvolvers.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN ln -fs /usr/share/zoneinfo/America/Bogota /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

ENTRYPOINT ["dotnet", "TEvolvers.dll"]