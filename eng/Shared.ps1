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
    cmd /c "$command 2>&1"
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
    $testNames = if ($name) { $name } else { 'body-string', 'extensible-enums-swagger', 'url-multi-collectionFormat', 'url', 'body-complex', 'custom-baseUrl', 'custom-baseUrl-more-options', 'header' }

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