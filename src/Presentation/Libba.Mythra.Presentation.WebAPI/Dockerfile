#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/Libba.Mythra.Presentation.WebAPI/Libba.Mythra.Presentation.WebAPI.csproj", "src/Presentation/Libba.Mythra.Presentation.WebAPI/"]
RUN dotnet restore "./src/Presentation/Libba.Mythra.Presentation.WebAPI/Libba.Mythra.Presentation.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Libba.Mythra.Presentation.WebAPI"
RUN dotnet build "./Libba.Mythra.Presentation.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Libba.Mythra.Presentation.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Libba.Mythra.Presentation.WebAPI.dll"]