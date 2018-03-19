@echo off
echo *** Building Proteus.Bot.Builder.Extensions.Telemetry
setlocal
setlocal enabledelayedexpansion
setlocal enableextensions
set errorlevel=0
mkdir ..\..\nuget
erase /s ..\..\nuget\Proteus.Bot.Builder.Extensions.Telemetry*nupkg
msbuild /property:Configuration=release Proteus.Bot.Builder.Extensions.Telemetry.csproj 
for /f %%v in ('powershell -noprofile "(Get-Command .\bin\release\Microsoft.Bot.Builder.dll).FileVersionInfo.FileVersion"') do set builder=%%v
for /f %%v in ('powershell -noprofile "(Get-Command .\bin\release\Proteus.Bot.Builder.Extensions.Telemetry.dll).FileVersionInfo.FileVersion"') do set version=%%v
..\..\packages\NuGet.CommandLine.4.5.1\tools\NuGet.exe pack Proteus.Bot.Builder.Extensions.Telemetry.nuspec -symbols -properties version=%version%;builder=%builder% -OutputDirectory ..\..\nuget
echo *** Finished building Proteus.Bot.Builder.Extensions.Telemetry

