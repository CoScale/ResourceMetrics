@echo off

if [%1]==[] goto usage

set "nugetAapiKey=%1"

call dotnet restore
call dotnet msbuild /t:Publish /p:Configuration=Release

nuget push .\bin\Release\ResourceMetrics.1.0.0.nupkg %nugetAapiKey% -Source https://api.nuget.org/v3/index.json

goto :eof
:usage
@echo Usage: %0 ^<nuget api key^>
exit /B 1
