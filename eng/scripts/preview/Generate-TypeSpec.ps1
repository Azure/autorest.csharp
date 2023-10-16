#Requires -Version 7.0

param(
    [string] $Filter
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../../..").Path.Replace('\', '/')
Set-ConsoleEncoding

$typespecProjectPath = "$root/src/TypeSpec.Extension/Emitter.Csharp"

Push-Location $root
try {
    # testProjects
    $testEmitterPath = "$typespecProjectPath/test/TestProjects"

    foreach ($directory in Get-ChildItem $testEmitterPath -Directory) {
        $testName = $directory.Name
        if ($filter -and $filter -ne $testName) {
            continue;
        }
        Write-Host "Emit TypeSpec json for $testName"
        $projectPath = "$testEmitterPath/$testName"
        #clean up
        if (Test-Path $projectPath/Generated) {
            Remove-Item $projectPath/Generated -Force -Recurse
        }

        Invoke-LoggedCommand "npx --no tsp compile $projectPath/$testName.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=$projectPath --option @azure-tools/typespec-csharp.skipSDKGeneration=true --option @azure-tools/typespec-csharp.save-inputs=true"

        if ($LASTEXITCODE -ne 0) {
            throw "Failed to emit typespec model for $testName."
        }
    }

    # samples
    $samplesPath = "$typespecProjectPath/samples"

    foreach ($directory in Get-ChildItem $samplesPath -Directory) {
        $testName = $directory.Name
        if ($filter -and $filter -ne $testName) {
            continue;
        }
        Write-Host "Emit TypeSpec json for $testName"
        $projectPath = "$samplesPath/$testName"
        #clean up
        if (Test-Path $projectPath/Generated) {
            Remove-Item $projectPath/Generated -Force -Recurse
        }

        Invoke-LoggedCommand "npx --no tsp compile $projectPath/$testName.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=$projectPath --option @azure-tools/typespec-csharp.skipSDKGeneration=true --option @azure-tools/typespec-csharp.save-inputs=true"
        
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to emit typespec model for $testName."
        }
    }
}
finally {
    Pop-Location
}
