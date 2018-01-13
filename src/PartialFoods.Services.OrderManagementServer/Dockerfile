# WARNING: each time you run this the build image produces a 'spare' 1.93GB docker image
# clean out your docker images periodically after running this
FROM microsoft/dotnet:2.0.5-sdk-2.1.4 as publish
WORKDIR /publish
COPY PartialFoods.Services.OrderManagementServer.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --output ./out

FROM microsoft/dotnet:2.0.5-runtime
WORKDIR /app
COPY --from=publish /publish/out .
ADD appsettings.json /app 
ENTRYPOINT ["dotnet", "PartialFoods.Services.OrderManagementServer.dll"]