#Requires -Version 7.0

param(
    [string] $Exceptions
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
Set-ConsoleEncoding

& "$root/eng/scripts/Download-SharedSource.ps1"

Write-Host 'Checking file difference...'
& "$root/eng/scripts/Check-GitChanges.ps1" -Exceptions ":!package*.json :!**/package.json"

if (!$?)
{
    Write-Error 'Shared source files are updated. Please run eng/scripts/DownloadSharedSource.ps1'
    exit 1
}
Write-Host 'Done. No change is detected.'
