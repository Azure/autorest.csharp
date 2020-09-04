#Requires -Version 7.0
param($filter, [switch]$continue, [switch]$reset, [switch]$noBuild, [switch]$fast, [switch]$updateLaunchSettings, [switch]$clean = $true, [String[]]$Exclude = "SmokeTests", $parallel = 5)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

$ErrorActionPreference = 'Stop'

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$swaggerDefinitions = @{};

# Test server test configuration
$autoRestPluginProject = (Get-AutoRestProject)
$testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
$sharedSource = Join-Path $repoRoot 'src' 'assets'
$configurationPath = Join-Path $repoRoot 'readme.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$testNames =
    'additionalProperties',
    'azure-parameter-grouping',
    'azure-special-properties',
    'body-array',
    'body-boolean',
    'body-byte',
    'body-complex',
    'body-date',
    'body-datetime',
    'body-datetime-rfc1123',
    'body-dictionary',
    'body-duration',
    'body-file',
    'body-formdata',
    'body-integer',
    'body-number',
    'body-string',
    'body-time',
    'custom-baseUrl',
    'custom-baseUrl-more-options',
    'custom-baseUrl-paging',
    'extensible-enums-swagger',
    'header',
    'httpInfrastructure',
    'lro',
    'media_types',
    'model-flattening',
    'multiple-inheritance',
    'non-string-enum',
    'object-type',
    'paging',
    'required-optional',
    'subscriptionId-apiVersion',
    'url',
    'url-multi-collectionFormat',
    'validation',
    'xml-service',
    'xms-error-responses',
    'constants';

if (!($Exclude -contains "TestServer"))
{
    foreach ($testName in $testNames)
    {
        $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
        $swaggerDefinitions[$testName] = @{
            'projectName'=$testName;
            'output'=$testServerDirectory;
            'arguments'="--require=$configurationPath --input-file=$inputFile"
        }
    }
}


if (!($Exclude -contains "TestProjects"))
{
    # Local test projects
    $testSwaggerPath = Join-Path $repoRoot 'test' 'TestProjects'

    foreach ($directory in Get-ChildItem $testSwaggerPath -Directory)
    {
        $testName = $directory.Name
        $inputFile = Join-Path $directory "$testName.json"
        $swaggerDefinitions[$testName] = @{
            'projectName'=$testName;
            'output'=$testSwaggerPath;
            'arguments'="--require=$configurationPath --input-file=$inputFile"
        }
    }
}
# Sample configuration
$projectNames =
    'SignalR',
    'AppConfiguration',
    'CognitiveServices.TextAnalytics',
    'CognitiveSearch',
    'Azure.AI.FormRecognizer',
    'Azure.Storage.Tables',
    'Azure.Management.Storage',
    'Azure.Network.Management.Interface'

if (!($Exclude -contains "Samples"))
{
    foreach ($projectName in $projectNames)
    {
        $projectDirectory = Join-Path $repoRoot 'samples' $projectName
        $sampleConfigurationPath = Join-Path $projectDirectory 'readme.md'
        $swaggerDefinitions[$projectName] = @{
            'projectName'=$projectName;
            'output'=$projectDirectory;
            'arguments'="--require=$sampleConfigurationPath"
        }
    }
}

# Smoke tests
if (!($Exclude -contains "SmokeTests"))
{
    foreach ($input in Get-Content (Join-Path $PSScriptRoot "SmokeTestInputs.txt"))
    {
        if ($input -match "^(?<input>[^#].*?specification/(?<name>[\w-]+(/[\w-]+)+)/readme.md)(:(?<args>.*))?")
        {
            $input = $Matches["input"]
            $args = $Matches["args"]
            $projectName = $Matches["name"].Replace("/", "-");

            $projectDirectory = Join-Path $repoRoot 'samples' 'smoketests' $projectName

            $swaggerDefinitions[$projectName] = @{
                'projectName'=$projectName;
                'output'=$projectDirectory;
                'arguments'="--require=$configurationPath $args $input"
            }
        }
    }
}

if ($updateLaunchSettings)
{
    $launchSettings = Join-Path $autoRestPluginProject 'Properties' 'launchSettings.json'
    $settings = @{
        'profiles' = [ordered]@{}
    };

    $sharedSourceNormalized = $sharedSource.Replace($repoRoot, '$(SolutionDir)')
    foreach ($key in $swaggerDefinitions.Keys | Sort-Object)
    {
        $definition = $swaggerDefinitions[$key];
        $outputPath = (Join-Path $definition.output $key).Replace($repoRoot, '$(SolutionDir)')
        $codeModel = Join-Path $outputPath 'CodeModel.yaml'

        $settings.profiles[$key] = [ordered]@{
            'commandName'='Project';
            'commandLineArgs'="--standalone $outputPath"
        }
    }

    $settings | ConvertTo-Json | Out-File $launchSettings
}

if ($reset -or $env:TF_BUILD)
{
    AutoRest-Reset;
}

if (!$noBuild)
{
    Invoke "dotnet build $autoRestPluginProject"
}

$keys = $swaggerDefinitions.Keys | Sort-Object;
if (![string]::IsNullOrWhiteSpace($filter))
{ 
    Write-Host "Using filter: $filter"
    if ($continue)
    {
        $keys = $keys.Where({$_ -match $filter},'SkipUntil') 
        Write-Host "Continuing with $keys"
    }
    else
    {
        $keys = $keys.Where({$_ -match $filter}) 
    }
}

$keys | %{ $swaggerDefinitions[$_] } | ForEach-Object -Parallel {
    Import-Module "$using:PSScriptRoot\Generation.psm1" -DisableNameChecking;
    Invoke-AutoRest $_.output $_.projectName $_.arguments $using:sharedSource $using:fast $using:clean;
} -ThrottleLimit $parallel

