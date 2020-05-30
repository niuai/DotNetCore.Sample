#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["DotNetCore.Sample/DotNetCore.Sample.csproj", "DotNetCore.Sample/"]
RUN dotnet restore "DotNetCore.Sample/DotNetCore.Sample.csproj"

COPY ["DotNetCore.SubWeb/DotNetCore.SubWeb.csproj", "DotNetCore.SubWeb/"]
RUN dotnet restore "DotNetCore.SubWeb/DotNetCore.SubWeb.csproj"

COPY . .

WORKDIR "/src/DotNetCore.Sample"
RUN dotnet build "DotNetCore.Sample.csproj" -c Release -o /app/build

WORKDIR "/src/DotNetCore.SubWeb"
RUN dotnet build "DotNetCore.SubWeb.csproj" -c Release -o /app/build

WORKDIR "/src"
FROM build AS publish
RUN dotnet publish "DotNetCore.Sample/DotNetCore.Sample.csproj" -c Release -o /app/publish
RUN dotnet publish "DotNetCore.SubWeb/DotNetCore.SubWeb.csproj" -c Release -o /app/publish

COPY start.sh /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD [ "/app/start.sh" ]