param($name, [switch]$noDebug, [switch]$noRun)

function Invoke-AutoRest($autoRestArguments) {
    $command = "npx autorest-beta $autoRestArguments"
    Write-Host "> $command"
    Invoke-Expression $command
    if($LastExitCode -gt 0)
    {
        throw "Command failed to execute: $command"
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
        $autoRestArguments = "$debugFlags --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace"
        Invoke-AutoRest $autoRestArguments
    }

    # Sample configuration
    $sampleDirectory = Join-Path $repoRoot 'samples'
    $projectNames = 'AppConfiguration'

    foreach ($projectName in $projectNames)
    {
        $projectDirectory = Join-Path $sampleDirectory $projectName
        $configurationPath = Join-Path $projectDirectory 'readme.md'
        $autoRestArguments = "$debugFlags --require=$configurationPath"
        Invoke-AutoRest $autoRestArguments
    }
}

if(-not $noRun)
{
    $ErrorActionPreference = 'Stop'
    try
    {
        Invoke-Generate $name $noDebug
    }
    catch
    {
        Write-Host -ForegroundColor Red $_
        exit 1
    }
}