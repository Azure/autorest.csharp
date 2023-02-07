#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

Write-Host 'Generating test CADL json...'
& (Join-Path $PSScriptRoot 'CadlGenerate.ps1')

Write-Host 'Checking generated file differences...'
git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
if ($LastExitCode -ne 0)
{
    Write-Error 'Generated code is not up to date, please run CadlGenerate.ps1'
}