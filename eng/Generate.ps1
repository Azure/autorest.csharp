param($name, [switch]$noDebug, [switch]$noRun, [switch]$noReset)

# function Invoke-Block([scriptblock]$cmd) {
#     $cmd | Out-String | Write-Verbose
#     & $cmd

#     # Need to check both of these cases for errors as they represent different items
#     # - $?: did the powershell script block throw an error
#     # - $lastexitcode: did a windows command executed by the script block end in error
#     if ((-not $?) -or ($lastexitcode -ne 0)) {
#         if ($error -ne $null)
#         {
#             Write-Warning $error[0]
#         }
#         throw "Command failed to execute: $cmd"
#     }
# }

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

    # Write-Host $noReset
    # if (-not $noReset)
    # {
    #     Invoke-AutoRest "--reset" $repoRoot
    # }

    foreach ($testName in $testNames)
    {
        # trap {"ERROR AAAGGGHHH"}

        $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
        $namespace = $testName.Replace('-', '_')
        $autoRestArguments = "$debugFlags --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace"
        Invoke-AutoRest $autoRestArguments $repoRoot
        # $commandText = "npx autorest-beta $autoRestArguments".Replace($repoRoot, "`$(SolutionDir)")
        # Write-Host "> $commandText"
        # try{
            # autorest-beta --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace *>&1


            # $ErrorActionPreference = 'Continue'
            # $error.Clear()
            # autorest-beta --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace 2>&1
            # $ErrorActionPreference = 'Stop'
            # if($error.Count -gt 0) {
            #     exit 1
            # }


            # autorest-beta --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace
            # Invoke-Expression "npx autorest-beta --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace"
            # if($LastExitCode -gt 0) {
            #     Write-Error "Failure"
            # }

            # $ErrorActionPreference = 'Stop'
            # Write-Host "TestExe was executed and the next line, as well."
            # . { autorest-beta --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace }
            # Invoke-Expression "autorest-beta --debug --verbose --require=$configurationPath --input-file=$inputFile --title=$testName --namespace=$namespace 2>&1" -ErrorVariable e
            # if($e){
            #     throw $e.Exception
            # }



            # $csprojFile = Join-Path $testServerDirectory $testName "$testName.csproj"
            # dotnet build $csprojFile --verbosity quiet /nologo


            # throw "FAILUREEEEE"
        # }
        # catch{
        #     #  Write-Error $_.Exception | Format-List -Force
        #     #  Write-Warning $error[0]
        #     Write-Warning $error[0]
        #     Write-Error "Failed"
        # }
        
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

if(-not $noRun)
{
    $ErrorActionPreference = 'Stop'
    Invoke-Generate $name $noDebug
}