#Requires -Version 7.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

Push-Location $root
try {
    # check if shared code is up to date
    & "$root/eng/scripts/Check-SharedCode.ps1"

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

    # run E2E Test for TypeSpec emitter
    & "$root/eng/scripts/Test-TypeSpecGeneration.ps1"
}
finally {
    Pop-Location
}
