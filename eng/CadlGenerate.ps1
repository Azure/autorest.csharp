#Requires -Version 7.0

$ErrorActionPreference = 'Stop'

param($filter)
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
    node node_modules/@cadl-lang/compiler/dist/core/cli.js compile --output-path $projectPath/Generated $projectPath/$testName.cadl --emit @azure-tools/cadl-csharp
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
    node node_modules/@cadl-lang/compiler/dist/core/cli.js compile --output-path $projectPath/Generated $projectPath/$testName.cadl --emit @azure-tools/cadl-csharp
}

Pop-Location
