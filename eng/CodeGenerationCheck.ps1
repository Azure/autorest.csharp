#Requires -Version 6.0
param([string]$Filter = '')

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

Write-Host "Generating test projects under "$Filter"..."
& (Join-Path $PSScriptRoot 'Generate.ps1') -Filter "$Filter" -reset
Write-Host 'Code generation is completed.'

Write-Host 'Checking generated files difference...'
git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
if ($LastExitCode -ne 0) {
    Write-Error 'Generated codes are not up to date. Please run: eng/Generate.ps1'
    exit 1
}
Write-Host 'Done. No change is detected.'
