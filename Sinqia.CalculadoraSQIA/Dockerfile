FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["./Sinqia.CalculadoraSQIA/Sinqia.CalculadoraSQIA.Api.csproj", "."]
COPY ["../Sinqia.CalculadoraSQIA.Application/Sinqia.CalculadoraSQIA.Application.csproj", "../Sinqia.CalculadoraSQIA.Application/"]
COPY ["../Sinqia.CalculadoraSQIA.Domain/Sinqia.CalculadoraSQIA.Domain.csproj", "../Sinqia.CalculadoraSQIA.Domain/"]
COPY ["../Sinqia.CalculadoraSQIA.Infrastructure/Sinqia.CalculadoraSQIA.Infrastructure.csproj", "../Sinqia.CalculadoraSQIA.Infrastructure/"]

RUN dotnet restore "Sinqia.CalculadoraSQIA.Api.csproj"

COPY ../ .

WORKDIR "/src"
RUN dotnet publish "Sinqia.CalculadoraSQIA/Sinqia.CalculadoraSQIA.Api.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Sinqia.CalculadoraSQIA.Api.dll"]
