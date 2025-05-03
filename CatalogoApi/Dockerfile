FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

RUN dotnet tool install --global dotnet-ef --version 6.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

COPY . .

RUN dotnet restore
RUN dotnet build -c Release
CMD ["sh", "-c", "dotnet ef database update && dotnet run --urls http://0.0.0.0:5000"]