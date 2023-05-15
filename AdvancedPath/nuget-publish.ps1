dotnet build -c Release
dotnet pack -c Release
dotnet nuget push .\bin\Release\*.nupkg --api-key $env:NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate