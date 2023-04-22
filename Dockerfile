#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IdentityMicroservice.REST/IdentityMicroservice.REST.csproj", "IdentityMicroservice.REST/"]
COPY ["IdentityMicroservice.Business/IdentityMicroservice.Business.csproj", "IdentityMicroservice.Business/"]
COPY ["IdentityMicroservice.Domain/IdentityMicroservice.Domain.csproj", "IdentityMicroservice.Domain/"]
COPY ["IdentityMicroservice.Repository/IdentityMicroservice.Repository.csproj", "IdentityMicroservice.Repository/"]
COPY ["IdentityMicroservice.DataAccess/IdentityMicroservice.DataAccess.csproj", "IdentityMicroservice.DataAccess/"]
COPY ["IdentityMicroservice.Services/IdentityMicroservice.Services.csproj", "IdentityMicroservice.Services/"]
COPY ["IdentityMicroservice.DI/IdentityMicroservice.DI.csproj", "IdentityMicroservice.DI/"]
RUN dotnet restore "IdentityMicroservice.REST/IdentityMicroservice.REST.csproj"
COPY . .
WORKDIR "/src/IdentityMicroservice.REST"
RUN dotnet build "IdentityMicroservice.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityMicroservice.REST.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityMicroservice.REST.dll"]