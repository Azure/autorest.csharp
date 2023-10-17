#Requires -Version 7.0
param($filter, [switch]$continue, [switch]$reset, [switch]$noBuild, [switch]$fast, [switch]$debug, [String[]]$Exclude = "SmokeTests", $parallel = 5)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

$ErrorActionPreference = 'Stop'

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$swaggerDefinitions = @{};
$swaggerTestDefinitions = @{};
$tspDefinitions = @{};

# Test server test configuration
$testProjectDataFile = Join-Path $repoRoot 'eng' 'testProjects.json'
$autoRestPluginProject = (Get-AutoRestProject)
$testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
$sharedSource = Join-Path $repoRoot 'src' 'assets'
$configurationPath = Join-Path $repoRoot 'readme.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$cadlRanchFilePath = Join-Path $repoRoot 'node_modules' '@azure-tools' 'cadl-ranch-specs' 'http'
$typespecEmitOptions = '--option @azure-tools/typespec-csharp.save-inputs=true --option @azure-tools/typespec-csharp.clear-output-folder=true'

function Add-Swagger ([string]$name, [string]$output, [string]$arguments, [string]$launchSettingsArgs="") {
    $swaggerDefinitions[$name] = @{
        'projectName' = $name;
        'output'      = $output;
        'arguments'   = $arguments;
        'launchSettingsArgs' = $launchSettingsArgs
    }
}

function Add-Swagger-Test ([string]$name, [string]$output, [string]$arguments, [string]$launchSettingsArgs="") {
    $swaggerTestDefinitions[$name] = @{
        'projectName' = $name;
        'output'      = $output;
        'arguments'   = $arguments;
        'launchSettingsArgs' = $launchSettingsArgs
    }
}

function Add-TypeSpec([string]$name, [string]$output, [string]$mainFile="", [string]$arguments="", [string]$launchSettingsArgs="") {
    if($output.EndsWith("tests")) { return }

    if ($mainFile -eq "") {
        $mainFile = Get-TypeSpec-Entry $output
    }
    $tspDefinitions[$name] = @{
        'projectName' = $name;
        'output'      = $output;
        'mainFile'    = $mainFile;
        'arguments'   = "$typespecEmitOptions $arguments";
        'launchSettingsArgs' = $launchSettingsArgs
    }
}

function Add-TestServer-Swagger ([string]$testName, [string]$projectSuffix, [string]$testServerDirectory, [string]$additionalArgs = "") {
    $projectDirectory = Join-Path $testServerDirectory $testName
    if(Test-Path "$projectDirectory/*.sln" || $projectDirectory.Contains("NewProject-")) {
        $projectDirectory = Join-path $projectDirectory "src"
    }
    $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
    $inputReadme = Join-Path $projectDirectory "readme.md"
    Add-Swagger "$testName$projectSuffix" $projectDirectory "--require=$configurationPath --try-require=$inputReadme --input-file=$inputFile $additionalArgs --clear-output-folder=true"
}

function Add-CadlRanch-TypeSpec([string]$testName, [string]$projectPrefix, [string]$cadlRanchProjectsDirectory, [string]$outputProjectDir="") {
    $projectDirectory = Join-Path $cadlRanchProjectsDirectory $testName
    if ($outputProjectDir -ne "") {
        $projectDirectory = $outputProjectDir
    }
    $configFile = Join-Path $projectDirectory "tspconfig.yaml"
    if (Test-Path $configFile) {
        $configString = "--config=$configFile "
    }
    $projectDirectory = Join-Path $projectDirectory "src"
    $tspMain = Join-Path $cadlRanchFilePath $testName "main.tsp"
    $clientTsp = Join-Path $cadlRanchFilePath $testName "client.tsp"
    $mainTypeSpecFile = If (Test-Path $clientTsp) { Resolve-Path $clientTsp } Else { Resolve-Path $tspMain}
    Add-TypeSpec "$projectPrefix$testName" $projectDirectory $mainTypeSpecFile "$configString--option @azure-tools/typespec-csharp.new-project=true" "-n"
}

function Get-TypeSpec-Entry([System.IO.DirectoryInfo]$directory) {
    $tspDirectory = $directory
    if($tspDirectory.FullName.EndsWith("src")) {
        $tspDirectory = $directory.Parent
    }

    $clientPath = Join-Path $tspDirectory "client.tsp"
    if (Test-Path $clientPath) {
        return $clientPath
    }

    $mainPath = Join-Path $tspDirectory "main.tsp"
    if (Test-Path $mainPath) {
        return $mainPath
    }

    $projectNamePath = Join-Path $tspDirectory "$($tspDirectory.Name).tsp"
    if (Test-Path $projectNamePath) {
        return $projectNamePath
    }
    
    throw "There is no client.tsp or main.tsp or other tsp file named after project name" 
}

$testData = Get-Content $testProjectDataFile -Encoding utf8 -Raw | ConvertFrom-Json

$testNames = $testData.TestServerProjects
if (!($Exclude -contains "TestServer")) {
    foreach ($testName in $testNames) {
        Add-TestServer-Swagger $testName "" $testServerDirectory "--generation1-convenience-client"
    }
}

$llcArgs = "--data-plane=true --security=AzureKey --security-header-name=Fake-Subscription-Key"

$testServerLowLevelDirectory = Join-Path $repoRoot 'test' 'TestServerProjectsLowLevel'
$testNamesLowLevel = $testData.TestServerProjectsLowLevel
$testNamesLowLevelWithoutArgs = $testData.TestServerProjectsLowLevelNoArgs

if (!($Exclude -contains "TestServerLowLevel")) {
    foreach ($testName in $testNamesLowLevel) {
        Add-TestServer-Swagger $testName "-LowLevel" $testServerLowLevelDirectory $llcArgs
    }

    foreach ($testName in $testNamesLowLevelWithoutArgs) {
        Add-TestServer-Swagger $testName "-LowLevel" $testServerLowLevelDirectory
    }
}

function Add-Directory ([string]$testName, [string]$directory, [boolean]$forTest) {
    $readmeConfigurationPath = Join-Path $directory "readme.md"
    $testArguments = $null
    if (Test-Path $readmeConfigurationPath) {
        $testArguments = "--require=$readmeConfigurationPath --clear-output-folder=true"
    }
    else {
        $inputFile = Join-Path $directory "$testName.json"
        $testArguments = "--require=$configurationPath --input-file=$inputFile --generation1-convenience-client --clear-output-folder=true"
    }

    if ($forTest) {
        if(Test-Path "$directory/readme.md") {
            Add-Swagger-Test $testName $directory $testArguments
        }
    }
    else {
        if ($testName.EndsWith("TypeSpec")) {
            Add-TypeSpec $testName $directory "" "--option @azure-tools/typespec-csharp.new-project=true" "-n"
        }
        else {
            Add-Swagger $testName $directory $testArguments
        }
    }
}

function Add-TestProjects-Directory($directory) {
    $testName = $directory.Name
    if ($testName -eq "ConvenienceInitial-TypeSpec") {
        return;
    }

    if ($testName -eq "sdk") {
        foreach ($serviceDir in Get-ChildItem $directory -Directory) {
            if ($serviceDir.Name -eq "core") {
                continue;
            }
            foreach($projectDir in Get-ChildItem $serviceDir -Directory) {
                Add-TestProjects-Directory $projectDir
            }
        }
        return;
    }

    $readmeConfigurationPath = Join-Path $directory "readme.md"
    $tspConfigConfigurationPath = Join-Path $directory "tspconfig.yaml"
    $possibleInputJsonFilePath = Join-Path $directory "$testName.json"
    $testArguments = $null
    $srcFolder = Join-Path $directory "src"
    $testsFolder = Join-Path $directory "tests"

    if ((Test-Path -Path $srcFolder) -And (Test-Path -Path $testsFolder)) {
        Add-Directory $testName $srcFolder $FALSE
        Add-Directory $testName $testsFolder $TRUE
        return
    }

    # if tspconfig.yaml exists, we treat it as a typespec project
    if (Test-Path $tspConfigConfigurationPath) {
        $directoryToUse = $directory
        $launchSettingsArgs = ""
        $options = ""
        if ($directory.FullName.Contains("\sdk\")) {
            $directoryToUse = $srcFolder
        }
        if ($directory.FullName.Contains(".NewProject.")) {
            $launchSettingsArgs = "-n"
        }
        if ($directory.FullName.Contains("\UnbrandedProjects\")) {
            if ($directoryToUse.Name -ne "src") {
                $directoryToUse = Join-Path $directoryToUse "src"
            }
            $launchSettingsArgs = "-n"
            $options = "--option @azure-tools/typespec-csharp.new-project=true"
        }
        Add-TypeSpec $testName $directoryToUse "" $options $launchSettingsArgs
    }
    elseif (Test-Path $readmeConfigurationPath) {
        $testArguments = "--require=$readmeConfigurationPath --clear-output-folder=true"
        Add-Swagger $testName $directory $testArguments
    }
    elseif (Test-Path $possibleInputJsonFilePath) {
        $testArguments = "--require=$configurationPath --input-file=$possibleInputJsonFilePath --generation1-convenience-client --clear-output-folder=true"
        Add-Swagger $testName $directory $testArguments
    }
    else {
        throw "There is no tspconfig.yaml file or readme.md file or swagger json file $testName.json found in test project $testName"
    }
}

if (!($Exclude -contains "TestProjects")) {
    # Local test projects
    $testProjectRoot = Join-Path $repoRoot 'test' 'TestProjects'

    foreach ($directory in Get-ChildItem $testProjectRoot -Directory) {
        Add-TestProjects-Directory $directory
    }
}

if (!($Exclude -contains "UnbrandedProjects")) {
    # Local test projects
    $testProjectRoot = Join-Path $repoRoot 'test' 'UnbrandedProjects'

    foreach ($directory in Get-ChildItem $testProjectRoot -Directory) {
        Add-TestProjects-Directory $directory
    }
}

if (!($Exclude -contains "Samples")) {
    $sampleProjectsRoot = Join-Path $repoRoot 'samples'

    foreach ($directory in Get-ChildItem $sampleProjectsRoot -Directory) {
        $sampleName = $directory.Name
        $projectDirectory = Join-Path $sampleProjectsRoot $sampleName
        if (Test-Path "$projectDirectory/*.sln") {
            $projectDirectory = Join-Path $projectDirectory "src"
        }
        $sampleConfigurationPath = Join-Path $projectDirectory 'readme.md'
        $tspConfigPath = Join-Path $directory "tspconfig.yaml"

        if (Test-Path $sampleConfigurationPath) {
            # for swagger samples
            Add-Swagger $sampleName $projectDirectory "--require=$sampleConfigurationPath --clear-output-folder=true"
        }
        elseif (Test-Path $tspConfigPath) {
            # for typespec projects
            $tspMain = Join-Path $projectDirectory ".." "main.tsp"
            $tspClient = Join-Path $projectDirectory ".."  "client.tsp"
            $mainTspFile = if (Test-Path $tspClient) { Resolve-Path $tspClient } else { Resolve-Path $tspMain }
            Add-TypeSpec $sampleName $projectDirectory $mainTspFile
        }
        else {
            throw "There is no tspconfig.yaml file or readme.md file found in sample project $sampleName"
        }
    }
}

# TypeSpec projects
$cadlRanchProjectDirectory = Join-Path $repoRoot 'test' 'CadlRanchProjects'

$cadlRanchProjectPaths = $testData.CadlRanchProjects

if (!($Exclude -contains "CadlRanchProjects")) {
    foreach ($testPath in $cadlRanchProjectPaths) {
        Add-CadlRanch-TypeSpec $testPath "typespec-" $cadlRanchProjectDirectory
    }
}

# add Head-As-Boolen project
Add-CadlRanch-TypeSpec "server/path/single" "headAsBoolean-typespec-" $cadlRanchProjectDirectory "$cadlRanchProjectDirectory/server/path/single-headAsBoolean"
# Smoke tests
if (!($Exclude -contains "SmokeTests")) {
    foreach ($input in Get-Content (Join-Path $PSScriptRoot "SmokeTestInputs.txt")) {
        if ($input -match "^(?<input>[^#].*?specification/(?<name>[\w-]+(/[\w-]+)+)/readme.md)(:(?<args>.*))?") {
            $input = $Matches["input"]
            $args = $Matches["args"]
            $projectName = $Matches["name"].Replace("/", "-");

            $projectDirectory = Join-Path $repoRoot 'samples' 'smoketests' $projectName

            Add-Swagger $projectName $projectDirectory "--generation1-convenience-client --require=$configurationPath $args $input --clear-output-folder=true"
        }
    }
}

# Sorting file names that include '-' and '.' is broken in powershell - https://github.com/PowerShell/PowerShell/issues/3425
# So map each to characters invalid for file system use '?' and '|', sort, and then map back
function Sort-FileSafe ($names) {
    return $names | % { $_.replace("-", "?") } | % { $_.replace(".", "|") } | Sort-Object | % { $_.replace("?", "-") } | % { $_.replace("|", ".") }
}

$launchSettings = Join-Path $autoRestPluginProject 'Properties' 'launchSettings.json'
$settings = @{
    'profiles' = [ordered]@{}
};

# here we put the source code generation project (map $swaggerDefinitions) and the test code generation project (map $swaggerTestDefinitions) together
$testProjectEntries = @{};
$swaggerDefinitions.Keys | ForEach-Object {
    $testProjectEntries[$_] = $swaggerDefinitions[$_];
};
$swaggerTestDefinitions.Keys | ForEach-Object {
    $testProjectEntries["$_.Tests"] = $swaggerTestDefinitions[$_];
}
$tspDefinitions.Keys | ForEach-Object {
    $testProjectEntries[$_] = $tspDefinitions[$_];
}

foreach ($key in Sort-FileSafe ($testProjectEntries.Keys)) {
    $definition = $testProjectEntries[$key];

    if ($definition.output.Contains("\smoketests\")) {
        #skip writing the smoketests since these aren't actually defined locally
        #these get added when a filter is used so it can find the filter using
        #all possible sources
        continue;
    }


    $outputPath = Join-Path $definition.output "Generated"
    if ($key -eq "TypeSchemaMapping") {
        $outputPath = Join-Path $definition.output "SomeFolder" "Generated"
    }
    elseif ($key -eq "ConvenienceUpdate-TypeSpec" -or $key -eq "ConvenienceInitial-TypeSpec")
    {
        $outputPath = "$outputPath --existing-project-folder $(Convert-Path $(Join-Path $definition.output ".." ".." "ConvenienceInitial-TypeSpec" "src" "Generated"))"
    }
    $outputPath = $outputPath.Replace($repoRoot, '$(SolutionDir)')
    $launchSettingsArgs = $definition.launchSettingsArgs
    if ($launchSettingsArgs -ne "") {
        $launchSettingsArgs = " $launchSettingsArgs"
    }

    $settings.profiles[$key] = [ordered]@{
        'commandName'     = 'Project';
        'commandLineArgs' = "--standalone $outputPath$launchSettingsArgs"
    }
}

$settings | ConvertTo-Json | Out-File $launchSettings

$keys = $testProjectEntries.Keys | Sort-Object;
if (![string]::IsNullOrWhiteSpace($filter)) { 
    Write-Host "Using filter: $filter"
    if ($continue) {
        $keys = $keys.Where({ $_ -match $filter }, 'SkipUntil') 
        Write-Host "Continuing with $keys"
    }
    else {
        $keys = $keys.Where({ $_ -match $filter }) 
    }
}

if ($reset -or $env:TF_BUILD) {
    $typespecCount = ([string]::IsNullOrWhiteSpace($filter) ? $tspDefinitions : $tspDefinitions.Keys.Where({ $_ -match $filter })).Count
    $swaggerCount = $keys.Count - $typespecCount
    if ($swaggerCount -gt 0) {
        AutoRest-Reset;
    }

    if ($typespecCount -gt 0) {
        Invoke-TypeSpecSetup
    }
}

if (!$noBuild) {
    Invoke "dotnet build $autoRestPluginProject"

    #build the emitter
    Invoke-TypeSpecSetup
}


$keys | % { $swaggerDefinitions[$_] } | ForEach-Object -Parallel {
    if ($_.output -ne $null) {
        Import-Module "$using:PSScriptRoot\Generation.psm1" -DisableNameChecking;
        Invoke-AutoRest $_.output $_.projectName $_.arguments $using:sharedSource $using:fast $using:debug;
    }
} -ThrottleLimit $parallel

$keys | % { $swaggerTestDefinitions[$_] } | ForEach-Object -Parallel {
    if ($_.output -ne $null) {
        Import-Module "$using:PSScriptRoot\Generation.psm1" -DisableNameChecking;
        Invoke-AutoRest $_.output $_.projectName $_.arguments $using:sharedSource $using:fast $using:debug;
    }
} -ThrottleLimit $parallel

$keys | % { $tspDefinitions[$_] } | ForEach-Object -Parallel {
    if ($_.output -ne $null) {
        Import-Module "$using:PSScriptRoot\Generation.psm1" -DisableNameChecking;
        Invoke-TypeSpec $_.output $_.projectName $_.mainFile $_.arguments $using:sharedSource $using:fast $using:debug;
    }
} -ThrottleLimit $parallel
