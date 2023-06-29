#Requires -Version 7.0
param($filter)

$ErrorActionPreference = 'Stop'
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$typespecProjectPath = Join-Path $repoRoot "src/TypeSpec.Extension/Emitter.Csharp"
Push-Location $repoRoot

# testProjects
$testEmitterPath = (Join-Path $typespecProjectPath "test/TestProjects")

foreach ($directory in Get-ChildItem $testEmitterPath -Directory)
{
    $testName = $directory.Name
    if ($filter -and $filter -ne $testName) {
        continue;
    }
    Write-Host "Emit TypeSpec json for $testName"
    $projectPath = Join-Path $testEmitterPath $testName
    #clean up
    if (Test-Path $projectPath/Generated)
    {
        Remove-Item $projectPath/Generated -Force -Recurse
    }
    node node_modules/@typespec/compiler/cmd/tsp.js compile $projectPath/$testName.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=$projectPath --option @azure-tools/typespec-csharp.skipSDKGeneration=true --option @azure-tools/typespec-csharp.save-inputs=true
    if (!$?) {
        Pop-Location
        throw "Failed to emit typespec model for $testName."
    }

}

# samples
$samplePath = (Join-Path $typespecProjectPath "samples")

foreach ($directory in Get-ChildItem $samplePath -Directory)
{
    $testName = $directory.Name
    if ($filter -and $filter -ne $testName) {
        continue;
    }
    Write-Host "Emit TypeSpec json for $testName"
    $projectPath = Join-Path $samplePath $testName
     #clean up
     if (Test-Path $projectPath/Generated)
     {
         Remove-Item $projectPath/Generated -Force -Recurse
     }
    node node_modules/@typespec/compiler/cmd/tsp.js compile $projectPath/$testName.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=$projectPath --option @azure-tools/typespec-csharp.skipSDKGeneration=true --option @azure-tools/typespec-csharp.save-inputs=true
    if (!$?) {
        Pop-Location
        throw "Failed to emit typespec model for $testName."
    }
}

Pop-Location
