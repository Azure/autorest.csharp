#Requires -Version 6.0

param([switch]$noReset)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

. (Join-Path $PSScriptRoot 'DownloadSharedSource.ps1')
. (Join-Path $PSScriptRoot 'Generate.ps1') -noRun

try
{
    Write-Host 'Downloading shared source files...'
    Invoke-DownloadSharedSource

    if (-not $noReset)
    {
        Invoke-AutoRest '--reset'
    }

    Write-Host 'Generating test clients...'
    Invoke-Generate @PSBoundParameters
}
catch
{
    Write-Host -ForegroundColor Red $_
    exit 1
}
