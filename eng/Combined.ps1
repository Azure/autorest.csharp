#Requires -Version 6.0

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

function Invoke-DownloadSharedSource
{
    $downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
    $files = "ClientDiagnostics.cs", "ArrayBufferWriter.cs", "DiagnosticScope.cs"
    $baseUrl = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/"

    foreach ($file in $files)
    {
        $text = Invoke-WebRequest -Uri "$baseUrl/$file";
        $text.Content.Replace("#nullable enable", "#pragma warning disable CS8600, CS8604, CS8605").Trim() | Out-File (Join-Path $downloadPath $file)
    }
}

function Invoke-AutoRest($autoRestArguments, $repoRoot) {
    $command = "npx autorest-beta $autoRestArguments"
    $commandText = $command.Replace($repoRoot, "`$(SolutionDir)")
    Write-Host "> $commandText"
    Invoke-Expression $command
    if($LastExitCode -gt 0) {
        Write-Error "Failure"
    }
}

function Invoke-Generate($name, [switch]$noDebug, [switch]$noReset)
{
    # General configuration
    $repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
    $debugFlags = if (-not $noDebug) { '--debug', '--verbose' }

    # Test server test configuration
    $testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
    $configurationPath = Join-Path $testServerDirectory 'readme.tests.md'
    $testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
    $testNames = if ($name) { $name } else { 'url', 'body-string', 'body-complex', 'custom-baseUrl', 'custom-baseUrl-more-options', 'header' }

    # if (-not $noReset)
    # {
    #     Invoke-AutoRest "--reset" $repoRoot
    # }

    foreach ($testName in $testNames)
    {
        $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
        $namespace = $testName.Replace('-', '_')
        $autoRestArguments = "$debugFlags --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace"
        Invoke-AutoRest $autoRestArguments $repoRoot
    }

    # Sample configuration
    $sampleDirectory = Join-Path $repoRoot 'samples'
    $projectNames = 'AppConfiguration'

    foreach ($projectName in $projectNames)
    {
        $projectDirectory = Join-Path $sampleDirectory $projectName
        $configurationPath = Join-Path $projectDirectory 'readme.md'
        $autoRestArguments = "$debugFlags --require=$configurationPath"
        Invoke-AutoRest $autoRestArguments $repoRoot
    }
}

# try
# {
    Write-Host "Downloading files"
    Invoke-DownloadSharedSource

    Write-Host "Generate test clients"
    Invoke-Generate @script:PSBoundParameters

    Write-Host "git diff"
    & git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
    if ($LastExitCode -ne 0) {
        $status = git status -s | Out-String
        $status = $status -replace "`n","`n    "
        Write-Error "Generated code is not up to date. You may need to run eng\Update-Snippets.ps1 or sdk\storage\generate.ps1 or eng\Export-API.ps1"
    }
# }
# catch
# {
#     exit 1
# }
