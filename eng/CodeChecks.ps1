#Requires -Version 6.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

Write-Host 'Downloading shared source files...'
& (Join-Path $PSScriptRoot 'DownloadSharedSource.ps1')

Write-Host 'Generating test clients...'
& (Join-Path $PSScriptRoot 'Generate.ps1') -reset -updateLaunchSettings

Write-Host 'Checking generated file differences...'
git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
if ($LastExitCode -ne 0)
{
    Write-Error 'Generated code is not up to date. Please run: eng/Generate.ps1'
}