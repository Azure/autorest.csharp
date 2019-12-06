param($name, [switch]$noDebug)
$ErrorActionPreference = 'Stop'

function Invoke-Block([scriptblock]$cmd) {
    $cmd | Out-String | Write-Verbose
    & $cmd

    # Need to check both of these cases for errors as they represent different items
    # - $?: did the powershell script block throw an error
    # - $lastexitcode: did a windows command executed by the script block end in error
    if ((-not $?) -or ($lastexitcode -ne 0)) {
        if ($error -ne $null)
        {
            Write-Warning $error[0]
        }
        throw "Command failed to execute: $cmd"
    }
}

function Invoke-AutoRest($debugFlags, $testConfiguration, $outputFolder, $inputFile, $name, $namespace, $repoRoot) {
    Invoke-Block {
        $outputFlag = if($outputFolder) { "--output-folder=$outputFolder" } else { '' }
        $inputFlag = if($inputFile) { "--input-file=$inputFile" } else { '' }
        $titleFlag = if($name) { "--title=$name" } else { '' }
        $namespaceFlag = if($namespace) { "--namespace=$namespace" } else { '' }
        $command = "npx autorest-beta $debugFlags $testConfiguration $outputFlag $inputFlag $titleFlag $namespaceFlag"
        $commandText = $command.Replace($repoRoot, "`$(SolutionDir)")

        Write-Host ">" $commandText
        
        & cmd /c "$command 2>&1"
    }
}

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$debugFlags = if (-not $noDebug) { '--debug', '--verbose' }

# Test server test configuration
$testServerTestProject = Join-Path $repoRoot 'test' 'AutoRest.TestServer.Tests'
$testConfiguration = Join-Path $testServerTestProject 'readme.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$testNames = if ($name) { $name } else { 'url', 'body-string', 'body-complex', 'custom-baseUrl', 'custom-baseUrl-more-options' }

foreach ($testName in $testNames)
{
    $outputFolder = Join-Path $testServerTestProject $testName
    $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
    $namespace = $testName.Replace('-', '_')
    Invoke-AutoRest $debugFlags $testConfiguration $outputFolder $inputFile $testName $namespace $repoRoot
}

# Sample configuration
$sampleDirectory = Join-Path $repoRoot 'samples'
$projectNames = 'AppConfiguration'

foreach ($projectName in $projectNames)
{
    $projectDirectory = Join-Path $sampleDirectory $projectName
    $configurationPath = Join-Path $projectDirectory 'readme.md'
    Invoke-AutoRest $debugFlags $configurationPath -repoRoot $repoRoot
}