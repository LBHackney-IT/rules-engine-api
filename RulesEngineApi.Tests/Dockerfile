FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN

WORKDIR /app

# Copy csproj and nuget config and restore as distinct layers
COPY ./RulesEngineApi.sln ./
COPY ./RulesEngineApi/RulesEngineApi.csproj ./RulesEngineApi/
COPY ./RulesEngineApi.Tests/RulesEngineApi.Tests.csproj ./RulesEngineApi.Tests/
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./RulesEngineApi/RulesEngineApi.csproj
RUN dotnet restore ./RulesEngineApi.Tests/RulesEngineApi.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out RulesEngineApi.Tests/RulesEngineApi.Tests.csproj

CMD dotnet test
