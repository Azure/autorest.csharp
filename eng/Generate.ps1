#Requires -Version 6.0
param($name, [switch]$noDebug, [switch]$reset, [switch]$noBuild, [switch]$fast, [switch]$updateLaunchSettings, [switch]$clean = $true)

$ErrorActionPreference = 'Stop'

function Invoke($command)
{
    Write-Host "> $command"
    pushd $repoRoot
    cmd /c "$command 2>&1"
    popd
    
    if($LastExitCode -ne 0)
    {
        Write-Error "Command failed to execute: $command"
    }
}

function Invoke-AutoRest($baseOutput, $title, $autoRestArguments)
{
    $outputPath = Join-Path $baseOutput $title
    $namespace = $title.Replace('-', '_')
    $command = "npx --no-install -p @autorest/autorest -c `"autorest $script:debugFlags $autoRestArguments --title=$title --namespace=$namespace`""

    if ($fast)
    {
        $codeModel = Join-Path $baseOutput $title "CodeModel.yaml"
        $command = "dotnet run --project $script:autorestPluginProject --no-build -- --plugin=csharpgen --title=$title --namespace=$namespace --standalone --input-file=$codeModel --output-folder=$outputPath"
    }

    if ($clean)
    {
        Get-ChildItem $outputPath -Filter Generated -Directory -Recurse | Remove-Item -Force -Recurse;
    }

    Invoke $command
}

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$debugFlags = if (-not $noDebug) { '--debug', '--verbose' }

$swaggerDefinitions = @{};

# Test server test configuration
$testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
$autorestPluginProject = Resolve-Path (Join-Path $repoRoot 'src' 'AutoRest.CSharp.V3')
$launchSettings = Join-Path $autorestPluginProject 'Properties' 'launchSettings.json'
$configurationPath = Join-Path $testServerDirectory 'readme.tests.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$testNames =
    'additionalProperties',
    #'azure-composite-swagger',
    #'azure-parameter-grouping',
    #'azure-report',
    #'azure-resource',
    #'azure-resource-x',
    #'azure-special-properties',
    'body-array',
    'body-boolean',
    #'body-boolean.quirks',
    'body-byte',
    'body-complex',
    'body-date',
    'body-datetime',
    'body-datetime-rfc1123',
    'body-dictionary',
    'body-duration',
    'body-file',
    #'body-formdata',
    #'body-formdata-urlencoded',
    'body-integer',
    'body-number',
    #'body-number.quirks',
    'body-string',
    #'body-string.quirks',
    #'complex-model',
    #'composite-swagger',
    #'composite-swagger.quirks',
    'custom-baseUrl',
    'custom-baseUrl-more-options',
    'custom-baseUrl-paging',
    'extensible-enums-swagger',
    #'head',
    'header',
    #'head-exceptions',
    'httpInfrastructure',
    #'httpInfrastructure.quirks',
    #'lro',
    'model-flattening',
    'paging',
    #'parameter-flattening',
    #'report',
    #'required-optional',
    #'storage',
    #'subscriptionId-apiVersion',
    'url',
    'validation',
    'xml-service',
    #'xms-error-responses',
    'url-multi-collectionFormat';

foreach ($testName in $testNames)
{
    $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
    $swaggerDefinitions[$testName] = @{
        'title'=$testName;
        'output'=$testServerDirectory;
        'arguments'="--require=$configurationPath --input-file=$inputFile"
    }
}

# Local test projects
$testSwaggerPath = Join-Path $repoRoot 'test' 'TestProjects'
$configurationPath = Join-Path $testSwaggerPath 'readme.md'

foreach ($directory in Get-ChildItem $testSwaggerPath -Directory)
{
    $testName = $directory.Name
    $inputFile = Join-Path $directory "$testName.json"
    $swaggerDefinitions[$testName] = @{
        'title'=$testName;
        'output'=$testSwaggerPath;
        'arguments'="--require=$configurationPath --input-file=$inputFile"
    }
}
# Sample configuration
$projectNames = 'AppConfiguration';
    #'CognitiveServices.TextAnalytics',
    #'CognitiveSearch';

foreach ($projectName in $projectNames)
{
    $projectDirectory = Join-Path $repoRoot 'samples' $projectName
    $configurationPath = Join-Path $projectDirectory 'readme.md'

    $swaggerDefinitions[$projectName] = @{
        'title'=$projectName;
        'output'=$projectDirectory;
        'arguments'="--require=$configurationPath"
    }
}

if ($updateLaunchSettings)
{
    $settings = @{
        'profiles' = [ordered]@{}
    };

    foreach ($key in $swaggerDefinitions.Keys | Sort-Object)
    {
        $definition = $swaggerDefinitions[$key];
        $outputPath = (Join-Path $definition.output $key).Replace($repoRoot, "`$(SolutionDir)")
        $codeModel = Join-Path $outputPath 'CodeModel.yaml'
        $namespace = $definition.title.Replace('-', '_')

        $settings.profiles[$key] = @{
            'commandName'='Project';
            'commandLineArgs'="--standalone --input-codemodel=$codeModel --plugin=csharpgen --output-folder=$outputPath --namespace=$namespace"
        }
    }

    $settings | ConvertTo-Json | Out-File $launchSettings
}

if ($reset -or $env:TF_BUILD)
{
    Invoke 'npx --no-install -p @autorest/autorest -c "autorest --reset"'
}

if (!$noBuild)
{
    dotnet build $autorestPluginProject
}

$keys = if (![string]::IsNullOrWhiteSpace($name)) { $name } else { $swaggerDefinitions.Keys }

foreach ($key in $keys)
{
    $definition = $swaggerDefinitions[$key];
    Invoke-AutoRest $definition.output $definition.title $definition.arguments
}

