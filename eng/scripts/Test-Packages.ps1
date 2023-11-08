#Requires -Version 7.0

param(
    [switch] $UnitTests,
    [switch] $GenerationChecks,
    [string] $Filter = "."
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/preview/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

Push-Location $root
try {
    if ($UnitTests) {
        # check if shared code is up to date
        & "$root/eng/scripts/preview/Download-SharedSource.ps1"

        try {
            Write-Host 'Checking for changes in shared source...'
            & "$root/eng/scripts/preview/Check-GitChanges.ps1"
            Write-Host 'Done. No shared source differences detected.'
        }
        catch {
            Write-Error 'Shared source files are updated. Please run eng/scripts/preview/Download-SharedSource.ps1'
        }
        
        # build CADL Ranch Mock Api project
        Push-Location "$root/test/CadlRanchMockApis"
        try {
            Invoke-LoggedCommand "npm run build" -GroupOutput
        }
        finally {
            Pop-Location
        }

        # test the generator
        Invoke-LoggedCommand "dotnet test AutoRest.CSharp.sln /bl:artifacts/logs/debug.binlog --logger `"trx;LogFileName=$root/artifacts/test-results/debug.trx`"" -GroupOutput
        Invoke-LoggedCommand "dotnet test AutoRest.CSharp.sln -c Release /bl:artifacts/logs/release.binlog --logger `"trx;LogFileName=$root/artifacts/test-results/release.trx`"" -GroupOutput

        # test the emitter
        Push-Location "$root/src/TypeSpec.Extension/Emitter.Csharp"
        try {
            Invoke-LoggedCommand "npm run prettier" -GroupOutput
            Invoke-LoggedCommand "npm run build" -GroupOutput
            Invoke-LoggedCommand "npm run test" -GroupOutput
        }
        finally {
            Pop-Location
        }
    }

    if ($GenerationChecks) {
        Set-StrictMode -Version 1
        # run E2E Test for TypeSpec emitter
        Write-Host "Generating test projects ..."
        & "$root/eng/Generate.ps1" -Filter $Filter -Reset
        Write-Host 'Code generation is completed.'

        try {
            Write-Host 'Checking for differences in generated code...'
            & "$root/eng/scripts/preview/Check-GitChanges.ps1"
            Write-Host 'Done. No code generation differences detected.'
        }
        catch {
            Write-Error 'Generated code is not up to date. Please run: eng/Generate.ps1'
        }
    }
}
finally {
    Pop-Location
}
