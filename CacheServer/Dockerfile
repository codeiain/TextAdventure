FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime  
WORKDIR /myworkingdirectory  
EXPOSE 443  
EXPOSE 80  
  
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build  
WORKDIR /src  
COPY ["CacheServer.csproj", ""]  
RUN dotnet restore "./CacheServer.csproj"  
COPY . .  
WORKDIR "/src/."  
RUN dotnet build "CacheServer.csproj" -c Release -o /app/build  
  
FROM build AS publish  
RUN dotnet publish "CacheServer.csproj" -c Release -o /app/publish  
  
FROM base AS final  
WORKDIR /myworkingdirectory  
COPY --from=publish /app/publish .  
ENTRYPOINT ["dotnet", "CacheServer.dll"]  