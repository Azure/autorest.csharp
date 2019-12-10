#Requires -Version 6.0
param($name, [switch]$noDebug, [switch]$noReset)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

try
{
    Write-Host 'Downloading shared source files...'
    & (Join-Path $PSScriptRoot 'DownloadSharedSource.ps1')

    Write-Host 'Generating test clients...'
    & (Join-Path $PSScriptRoot 'Generate.ps1') @PSBoundParameters

    Write-Host 'Checking generated file differences...'
    git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
    if ($LastExitCode -ne 0) {
        $status = (git status -s | Out-String) -replace '`n','`n    '
        throw 'Generated code is not up to date. Please run: eng/Generate.ps1'
    }
}
catch
{
    Write-Host -ForegroundColor Red $_
    exit 1
}
