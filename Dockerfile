FROM mcr.microsoft.com/dotnet/sdk:5.0-focal as serverBuilder
WORKDIR /app
COPY server/*.csproj ./
RUN dotnet restore
RUN ls ./
COPY server/ ./
RUN ls ./
RUN dotnet publish "server.csproj" -c Release -o out
RUN ls /app/out


FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
WORKDIR /app
COPY --from=serverBuilder /app/out/* ./
ENTRYPOINT [ "dotnet", "server.dll" ]
