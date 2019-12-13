#Requires -Version 6.0
param($name, [switch]$noDebug, [switch]$reset, [switch]$noBuild, [switch]$fast)

$ErrorActionPreference = 'Stop'

function Invoke-AutoRest($baseOutput, $title, $autoRestArguments)
{
    $command = "npx autorest-beta $script:debugFlags $autoRestArguments"
    if ($title)
    {
        $namespace = $title.Replace('-', '_')
        $command = "$command --title=$title --namespace=$namespace"
    }

    if ($fast)
    {
        $codeModel = Join-Path $baseOutput $title "CodeModel.yaml"
        $outputPath = Join-Path $baseOutput $title
        $command = "dotnet run --project $script:autorestPluginProject --no-build -- --plugin=cs-modeler --title=$title --namespace=$namespace --standalone --input-file=$codeModel --output-path=$outputPath"
    }
    
    Write-Host "> $command"
    cmd /c "$command 2>&1"

    if($LastExitCode -ne 0)
    {
        Write-Error "Command failed to execute: $command"
    }
}

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$debugFlags = if (-not $noDebug) { '--debug', '--verbose' }

# Test server test configuration
$testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
$autorestPluginProject = Resolve-Path (Join-Path $repoRoot 'src' 'AutoRest.CSharp.V3')
$configurationPath = Join-Path $testServerDirectory 'readme.tests.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$testNames = if ($name) { $name } else
{
    'body-integer',
    'body-number',
    'body-string',
    'extensible-enums-swagger',
    'url-multi-collectionFormat',
    'url',
    'body-complex',
    'custom-baseUrl',
    'custom-baseUrl-more-options',
    'header'
}

if ($reset -or $env:TF_BUILD)
{
    Invoke-AutoRest $null $null '--reset'
}

if (!$noBuild)
{
    dotnet build $autorestPluginProject
}

foreach ($testName in $testNames)
{
    $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
    Invoke-AutoRest $testServerDirectory $testName "--require=$configurationPath --input-file=$inputFile"
}

# Sample configuration
$sampleDirectory = Join-Path $repoRoot 'samples'
$projectNames = 'AppConfiguration'

foreach ($projectName in $projectNames)
{
    $projectDirectory = Join-Path $sampleDirectory $projectName
    $configurationPath = Join-Path $projectDirectory 'readme.md'
    Invoke-AutoRest $projectDirectory $projectName "--require=$configurationPath"
}