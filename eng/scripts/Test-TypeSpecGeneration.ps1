#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

Write-Host 'Generating test TypeSpec json...'
& "$root/eng/scripts/Generate-TypeSpec.ps1"

Write-Host 'Checking generated file differences...'
& "$root/eng/scripts/Check-GitChanges.ps1 -Exceptions `":!package*.json :!**/package.json`""
if (!$?)
{
    Write-Error 'Generated code is not up to date, please run eng/scripts/Generate-TypeSpec.ps1'
}
