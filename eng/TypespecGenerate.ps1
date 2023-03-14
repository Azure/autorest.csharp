#Requires -Version 7.0
param($filter)

$ErrorActionPreference = 'Stop'
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$cadlProjectPath = Join-Path $repoRoot "src/CADL.Extension/Emitter.Csharp"
Push-Location $repoRoot

# testProjects
$testEmitterPath = (Join-Path $cadlProjectPath "test/TestProjects")

foreach ($directory in Get-ChildItem $testEmitterPath -Directory)
{
    $testName = $directory.Name
    if ($filter -and $filter -ne $testName) {
        continue;
    }
    Write-Host "Emit CADL json for $testName"
    $projectPath = Join-Path $testEmitterPath $testName
    #clean up
    if (Test-Path $projectPath/Generated)
    {
        Remove-Item $projectPath/Generated -Force -Recurse
    }
    node node_modules/@typespec/compiler/dist/core/cli/cli.js compile $projectPath/$testName.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=$projectPath --option @azure-tools/typespec-csharp.skipSDKGeneration=true --option @azure-tools/typespec-csharp.save-inputs=true
    if (!$?) {
        Pop-Location
        throw "Failed to emit cadl model for $testName."
    }

}

# samples
$samplePath = (Join-Path $cadlProjectPath "samples")

foreach ($directory in Get-ChildItem $samplePath -Directory)
{
    $testName = $directory.Name
    if ($filter -and $filter -ne $testName) {
        continue;
    }
    Write-Host "Emit CADL json for $testName"
    $projectPath = Join-Path $samplePath $testName
     #clean up
     if (Test-Path $projectPath/Generated)
     {
         Remove-Item $projectPath/Generated -Force -Recurse
     }
    node node_modules/@typespec/compiler/dist/core/cli/cli.js compile $projectPath/$testName.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=$projectPath --option @azure-tools/typespec-csharp.skipSDKGeneration=true --option @azure-tools/typespec-csharp.save-inputs=true
    if (!$?) {
        Pop-Location
        throw "Failed to emit typespec model for $testName."
    }
}

Pop-Location
