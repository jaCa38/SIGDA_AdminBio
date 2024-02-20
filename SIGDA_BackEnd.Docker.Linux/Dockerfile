#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SIGDA_BackEnd.Docker.Linux/SIGDA_BackEnd.Docker.Linux.csproj", "SIGDA_BackEnd.Docker.Linux/"]
RUN dotnet restore "SIGDA_BackEnd.Docker.Linux/SIGDA_BackEnd.Docker.Linux.csproj"
COPY . .
WORKDIR "/src/SIGDA_BackEnd.Docker.Linux"
RUN dotnet build "SIGDA_BackEnd.Docker.Linux.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGDA_BackEnd.Docker.Linux.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGDA_BackEnd.Docker.Linux.dll"]

ENV SIGDA_RH_PROD_CNN "Data Source=192.168.1.63;Initial Catalog=SRHN;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV SIGDA_RH_QA_CNN "Data Source=192.168.1.63;Initial Catalog=SRHN;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV SIGEIN_PROD_CNN "Data Source=192.168.1.29\\OBSERVER;Initial Catalog=PJG_SIGEIN_50;Persist Security Info=True;User Id=sigda;Password=S4pi123!;Encrypt=False;TrustServerCertificate=True"

ENV SIGDA_CA_PROD_CNN "Data Source=192.168.1.63;Initial Catalog=SIGDA_CA;Persist Security Info=True;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV SIGDA_CA_QA_CNN "Data Source=192.168.1.63;Initial Catalog=SIGDA_CA;Persist Security Info=True;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV SICA_PROD_CNN "server=192.168.1.12;Port=4499;uid=ratilano;pwd=$xXwhi6fZ&&eBxg4%;database=sicadb"

ENV SIGDA_FOTO_PROD_CNN "Data Source=192.168.1.63;Initial Catalog=SIGDA_FOTOCOPIADO;Persist Security Info=True;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV SIGDA_FOTO_QA_CNN "Data Source=192.168.1.63;Initial Catalog=SIGDA_FOTOCOPIADO_QA;Persist Security Info=True;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV CONSEJO_QA "Data Source=192.168.1.63;Initial Catalog=consejo;Persist Security Info=True;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV CONSEJO_PROD "Data Source=187.237.136.71;Initial Catalog=consejo;Persist Security Info=True;User ID=PublicAccess;Password=PU8L1C@cc3S2021;Encrypt=False;TrustServerCertificate=True"

ENV SIGDA_RH1_PROD_CNN "Data Source=192.168.1.63;Initial Catalog=SIGDA_RH;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"

ENV SIGDA_RH1_QA_CNN "Data Source=192.168.1.63;Initial Catalog=SIGDA_RH;User Id=docker;Password=@S1st3m4!78;Encrypt=False;TrustServerCertificate=True"