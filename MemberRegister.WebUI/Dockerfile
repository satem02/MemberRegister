FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["MemberRegister.WebUI/MemberRegister.WebUI.csproj", "MemberRegister.WebUI/"]
RUN dotnet restore "MemberRegister.WebUI/MemberRegister.WebUI.csproj"
COPY . .
WORKDIR "/src/MemberRegister.WebUI"
RUN dotnet build "MemberRegister.WebUI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MemberRegister.WebUI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MemberRegister.WebUI.dll"]
