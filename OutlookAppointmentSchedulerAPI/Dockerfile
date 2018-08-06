FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 49921
EXPOSE 44336

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY OutlookAppointmentSchedulerAPI/OutlookAppointmentSchedulerAPI.csproj OutlookAppointmentSchedulerAPI/
RUN dotnet restore OutlookAppointmentSchedulerAPI/OutlookAppointmentSchedulerAPI.csproj
COPY . .
WORKDIR /src/OutlookAppointmentSchedulerAPI
RUN dotnet build OutlookAppointmentSchedulerAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OutlookAppointmentSchedulerAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OutlookAppointmentSchedulerAPI.dll"]
