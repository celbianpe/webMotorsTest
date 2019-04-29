FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

ENV RELATIONAL_PORT=3306
ENV BASE_ADDRESS="http://desafioonline.webmotors.com.br"
ENV RELATIONAL_USER="root_webmotors"
ENV REDIS_CNN="redis-18588.c92.us-east-1-3.ec2.cloud.redislabs.com:18588"
ENV VEHICLE_ROOT="/api/OnlineChallenge/Vehicles"
ENV RELATIONAL_HOST="db4free.net"
ENV WEB_CLIENT="WEB_MOTORS"
ENV VERSION_ROOT="/api/OnlineChallenge/Version"
ENV RELATIONAL_PASSWORD="PASSWORD123"
ENV MAKE_ROOT="/api/OnlineChallenge/Make"
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV REDIS_PASSWORD="F5uMBH5yzVXFAO0gOPjGMoVysflWiq2b"
ENV MODEL_ROOT="/api/OnlineChallenge/Model"

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Application/Application.csproj", "Application/"]
COPY ["Kernel/Kernel.csproj", "Kernel/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "Application/Application.csproj"
COPY . .
WORKDIR "/src/Application"
RUN dotnet build "Application.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Application.dll"]