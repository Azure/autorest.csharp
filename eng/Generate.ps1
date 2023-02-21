#Requires -Version 7.0
param($filter, [switch]$continue, [switch]$reset, [switch]$noBuild, [switch]$fast, [switch]$debug, [String[]]$Exclude = "SmokeTests", $parallel = 5)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

$ErrorActionPreference = 'Stop'

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$swaggerDefinitions = @{};
$swaggerTestDefinitions = @{};
$cadlDefinitions = @{};

# Test server test configuration
$testProjectDataFile = Join-Path $repoRoot 'eng' 'testProjects.json'
$autoRestPluginProject = (Get-AutoRestProject)
$testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
$sharedSource = Join-Path $repoRoot 'src' 'assets'
$configurationPath = Join-Path $repoRoot 'readme.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$cadlRanchFilePath = Join-Path $repoRoot 'node_modules' '@azure-tools' 'cadl-ranch-specs' 'http'
$cadlEmitOptions = '--option @azure-tools/cadl-csharp.save-inputs=true --option @azure-tools/cadl-csharp.clear-output-folder=true'

function Add-Swagger ([string]$name, [string]$output, [string]$arguments) {
    $swaggerDefinitions[$name] = @{
        'projectName' = $name;
        'output'      = $output;
        'arguments'   = $arguments
    }
}

function Add-Swagger-Test ([string]$name, [string]$output, [string]$arguments) {
    $swaggerTestDefinitions[$name] = @{
        'projectName' = $name;
        'output'      = $output;
        'arguments'   = $arguments
    }
}

function Add-Cadl([string]$name, [string]$output, [string]$mainFile = "", [string]$arguments = "") {
    $cadlDefinitions[$name] = @{
        'projectName' = $name;
        'output'      = $output;
        'mainFile'    = $mainFile;
        'arguments'   = "$cadlEmitOptions $arguments"
    }
}

function Add-TestServer-Swagger ([string]$testName, [string]$projectSuffix, [string]$testServerDirectory, [string]$additionalArgs = "") {
    $projectDirectory = Join-Path $testServerDirectory $testName
    $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
    $inputReadme = Join-Path $projectDirectory "readme.md"
    Add-Swagger "$testName$projectSuffix" $projectDirectory "--require=$configurationPath --try-require=$inputReadme --input-file=$inputFile $additionalArgs"
}

function Add-CadlRanch-Cadl([string]$testName, [string]$projectPrefix, [string]$cadlRanchProjectsDirectory) {
    $projectDirectory = Join-Path $cadlRanchProjectsDirectory $testName
    $cadlMain = Join-Path $cadlRanchFilePath $testName "main.cadl"
    Add-Cadl "$projectPrefix$testName" $projectDirectory $cadlMain
}

$testData = Get-Content $testProjectDataFile -Encoding utf8 -Raw | ConvertFrom-Json

if (!($Exclude -contains "TestServer")) {
    foreach ($testName in $testData["TestServerProjects"]) {
        Add-TestServer-Swagger $testName "" $testServerDirectory "--generation1-convenience-client"
    }
}

$llcArgs = "--data-plane=true --security=AzureKey --security-header-name=Fake-Subscription-Key"

$testServerLowLevelDirectory = Join-Path $repoRoot 'test' 'TestServerProjectsLowLevel'
$testNamesLowLevel = $testData["TestServerProjectsLowLevel"]
$testNamesLowLevelWithoutArgs = $testData["TestServerProjectsLowLevelNoArgs"]

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
        $testArguments = "--require=$readmeConfigurationPath"
    }
    else {
        $inputFile = Join-Path $directory "$testName.json"
        $testArguments = "--require=$configurationPath --input-file=$inputFile --generation1-convenience-client"
    }

    if ($forTest) {
        Add-Swagger-Test $testName $directory $testArguments
    }
    else {
        if ($testName.EndsWith("Cadl")) {
            Add-Cadl $testName $directory
        }
        else {
            Add-Swagger $testName $directory $testArguments
        }
    }
}

if (!($Exclude -contains "TestProjects")) {
    # Local test projects
    $testProjectRoot = Join-Path $repoRoot 'test' 'TestProjects'

    foreach ($directory in Get-ChildItem $testProjectRoot -Directory) {
        $testName = $directory.Name
        $readmeConfigurationPath = Join-Path $directory "readme.md"
        $testArguments = $null
        $srcFolder = Join-Path $directory "src"
        $testsFolder = Join-Path $directory "tests"

        if ((Test-Path -Path $srcFolder) -And (Test-Path -Path $testsFolder)) {
            Add-Directory $testName $srcFolder $FALSE
            Add-Directory $testName $testsFolder $TRUE
            continue
        }
        if ($testName.EndsWith("Cadl")) {
            Add-Cadl $testName $directory "" "--option @azure-tools/cadl-csharp.generate-convenience-methods=false"
        }
        else {
            if (Test-Path $readmeConfigurationPath) {
                $testArguments = "--require=$readmeConfigurationPath"
            }
            else {
                $inputFile = Join-Path $directory "$testName.json"
                $testArguments = "--require=$configurationPath --input-file=$inputFile --generation1-convenience-client"
            }

            Add-Swagger $testName $directory $testArguments
        }
    }
}


if (!($Exclude -contains "Samples")) {
    $sampleProjectsRoot = Join-Path $repoRoot 'samples'

    foreach ($directory in Get-ChildItem $sampleProjectsRoot -Directory) {
        $sampleName = $directory.Name
        $projectDirectory = Join-Path $sampleProjectsRoot $sampleName
        $sampleConfigurationPath = Join-Path $projectDirectory 'readme.md'
        if (Test-Path $sampleConfigurationPath) {
            # for swagger samples
            Add-Swagger $sampleName $projectDirectory "--require=$sampleConfigurationPath"
        }
        else {
            # for cadl projects
            $cadlMain = Join-Path $projectDirectory "main.cadl"
            $cadlClient = Join-Path $projectDirectory "client.cadl"
            $mainCadlFile = if (Test-Path $cadlClient) { Resolve-Path $cadlClient } else { Resolve-Path $cadlMain }
            Add-Cadl $sampleName $projectDirectory $mainCadlFile
        }
    }
}

# Cadl projects
$cadlRanchProjectDirectory = Join-Path $repoRoot 'test' 'CadlRanchProjects'

$cadlRanchProjectPaths = $testData["CadlRanchProjects"]

if (!($Exclude -contains "CadlRanchProjects")) {
    foreach ($testPath in $cadlRanchProjectPaths) {
        Add-CadlRanch-Cadl $testPath "cadl-" $cadlRanchProjectDirectory
    }
}

# TODO: remove later after cadl-ranch fixes the discriminator tests
Add-Cadl "inheritance-cadl" (Join-Path $cadlRanchProjectDirectory "inheritance")

# Smoke tests
if (!($Exclude -contains "SmokeTests")) {
    foreach ($input in Get-Content (Join-Path $PSScriptRoot "SmokeTestInputs.txt")) {
        if ($input -match "^(?<input>[^#].*?specification/(?<name>[\w-]+(/[\w-]+)+)/readme.md)(:(?<args>.*))?") {
            $input = $Matches["input"]
            $args = $Matches["args"]
            $projectName = $Matches["name"].Replace("/", "-");

            $projectDirectory = Join-Path $repoRoot 'samples' 'smoketests' $projectName

            Add-Swagger $projectName $projectDirectory "--generation1-convenience-client --require=$configurationPath $args $input"
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
$cadlDefinitions.Keys | ForEach-Object {
    $testProjectEntries[$_] = $cadlDefinitions[$_];
}

foreach ($key in Sort-FileSafe ($testProjectEntries.Keys)) {
    $definition = $testProjectEntries[$key];

    if ($definition.output.Contains("\smoketests\")) {
        #skip writing the smoketests since these aren't actually defined locally
        #these get added when a filter is used so it can find the filter using
        #all possible sources
        continue;
    }

    # TODO: remove later after candl ranch fixes the discriminator test
    if ($definition.output.Contains("\CadlRanchProjects\inheritance")) {
        continue;
    }

    $outputPath = Join-Path $definition.output "Generated"
    if ($key -eq "TypeSchemaMapping") {
        $outputPath = Join-Path $definition.output "SomeFolder" "Generated"
    }
    $outputPath = $outputPath.Replace($repoRoot, '$(SolutionDir)')

    $settings.profiles[$key] = [ordered]@{
        'commandName'     = 'Project';
        'commandLineArgs' = "--standalone $outputPath"
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
    $cadlCount = ([string]::IsNullOrWhiteSpace($filter) ? $cadlDefinitions : $cadlDefinitions.Keys.Where({ $_ -match $filter })).Count
    $swaggerCount = $keys.Count - $cadlCount
    if ($swaggerCount -gt 0) {
        AutoRest-Reset;
    }

    if ($cadlCount -gt 0) {
        Invoke-CadlSetup
    }
}

if (!$noBuild) {
    Invoke "dotnet build $autoRestPluginProject"

    #build the emitter
    $emitterDir = "$PSScriptRoot/../src/CADL.Extension/Emitter.Csharp"
    Invoke "npm --prefix $emitterDir run build"
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

$keys | % { $cadlDefinitions[$_] } | ForEach-Object -Parallel {
    if ($_.output -ne $null) {
        Import-Module "$using:PSScriptRoot\Generation.psm1" -DisableNameChecking;
        Invoke-Cadl $_.output $_.projectName $_.mainFile $_.arguments $using:sharedSource $using:fast $using:debug;
    }
} -ThrottleLimit $parallel
