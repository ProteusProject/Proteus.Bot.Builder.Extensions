@echo off
echo *** Building Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter
setlocal
setlocal enabledelayedexpansion
setlocal enableextensions
set errorlevel=0
mkdir ..\..\nuget
erase /s ..\..\nuget\Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter*nupkg
msbuild /property:Configuration=release Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter.csproj 
for /f %%v in ('powershell -noprofile "(Get-Command .\bin\release\Proteus.Bot.Builder.Extensions.Telemetry.dll).FileVersionInfo.FileVersion"') do set telemetry=%%v
for /f %%v in ('powershell -noprofile "(Get-Command .\bin\release\Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter.dll).FileVersionInfo.FileVersion"') do set version=%%v
..\..\packages\NuGet.CommandLine.4.5.1\tools\NuGet.exe pack Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter.nuspec -symbols -properties version=%version%;telemetry=%telemetry% -OutputDirectory ..\..\nuget
echo *** Finished building Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter

