$ErrorActionPreference = "Stop"

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

$repoRoot = "$PSScriptRoot\.."
$testServerTestProject = Resolve-Path "$repoRoot\test\AutoRest.TestServer.Tests"
$testConfiguration = Resolve-Path "$testServerTestProject\readme.md"
$testServerSwagerPath = Resolve-Path "$repoRoot\node_modules\@autorest\test-server\__files\swagger"
$paths = "body-string", "body-complex"

foreach ($path in $paths)
{
    $outputFolder = "$testServerTestProject\$path";
    $inputFile = "$testServerSwagerPath\$path.json"
    $namespace = $path.Replace('-', '_')
    Invoke-Block { 
        Write-Host ">" npx autorest-beta --debug --verbose $testConfiguration --output-folder=$outputFolder --input-file=$inputFile --title=$path --namespace=$namespace
        npx autorest-beta --debug --verbose $testConfiguration --output-folder=$outputFolder --input-file=$inputFile --title=$path --namespace=$namespace
    }
}