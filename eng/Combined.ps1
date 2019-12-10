#Requires -Version 6.0
param($name, [switch]$noDebug, [switch]$reset)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

function Invoke-DownloadSharedSource
{
    $currentProgressPreference = $ProgressPreference
    $ProgressPreference = 'SilentlyContinue'

    $downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
    $files = 'ClientDiagnostics.cs', 'ArrayBufferWriter.cs', 'DiagnosticScope.cs'
    $baseUrl = 'https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/'

    foreach ($file in $files)
    {
        $text = Invoke-WebRequest -Uri "$baseUrl/$file";
        $text.Content.Replace('#nullable enable', '#pragma warning disable CS8600, CS8604, CS8605').Trim() | Out-File (Join-Path $downloadPath $file)
    }

    $ProgressPreference = $currentProgressPreference
}

function Invoke-AutoRest($autoRestArguments)
{
    $command = "npx autorest-beta $autoRestArguments"
    Write-Host "> $command"
    Invoke-Expression $command
    if($LastExitCode -ne 0)
    {
        Write-Error "Command failed to execute: $command"
    }
}

function Invoke-Generate($name, [switch]$noDebug)
{
    # General configuration
    $repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
    $debugFlags = if (-not $noDebug) { '--debug', '--verbose' }

    # Test server test configuration
    $testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
    $configurationPath = Join-Path $testServerDirectory 'readme.tests.md'
    $testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
    $testNames = if ($name) { $name } else { 'url', 'body-string', 'body-complex', 'custom-baseUrl', 'custom-baseUrl-more-options', 'header' }

    foreach ($testName in $testNames)
    {
        $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
        $namespace = $testName.Replace('-', '_')
        Invoke-AutoRest "$debugFlags --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace"
    }

    # Sample configuration
    $sampleDirectory = Join-Path $repoRoot 'samples'
    $projectNames = 'AppConfiguration'

    foreach ($projectName in $projectNames)
    {
        $projectDirectory = Join-Path $sampleDirectory $projectName
        $configurationPath = Join-Path $projectDirectory 'readme.md'
        Invoke-AutoRest "$debugFlags --require=$configurationPath"
    }
}

Write-Host 'Downloading shared source files...'
Invoke-DownloadSharedSource

if ($reset)
{
    Invoke-AutoRest '--reset'
}

Write-Host 'Generating test clients...'
Invoke-Generate @PSBoundParameters

Write-Host 'Checking generated file differences...'
git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
if ($LastExitCode -ne 0) {
    Write-Error 'Generated code is not up to date. Please run: eng/Generate.ps1'
}