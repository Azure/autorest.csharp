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
    node node_modules/@cadl-lang/compiler/dist/core/cli.js compile $projectPath/$testName.cadl --emit @azure-tools/cadl-csharp --option @azure-tools/cadl-csharp.emitter-output-dir=$projectPath --option @azure-tools/cadl-csharp.skipSDKGeneration=true --option @azure-tools/cadl-csharp.save-inputs=true
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
    node node_modules/@cadl-lang/compiler/dist/core/cli.js compile $projectPath/$testName.cadl --emit @azure-tools/cadl-csharp --option @azure-tools/cadl-csharp.emitter-output-dir=$projectPath --option @azure-tools/cadl-csharp.skipSDKGeneration=true --option @azure-tools/cadl-csharp.save-inputs=true
    if (!$?) {
        Pop-Location
        throw "Failed to emit cadl model for $testName."
    }
}

Pop-Location
