#Requires -Version 6.0
param($name, [switch]$noDebug, [switch]$reset, [switch]$noBuild, [switch]$noProjectBuild, [switch]$fast, [switch]$updateLaunchSettings, [switch]$clean = $true)

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
    $command = "$script:autorestBinary $script:debugFlags $autoRestArguments --title=$title --namespace=$namespace"

    if ($fast)
    {
        $codeModel = Join-Path $baseOutput $title "CodeModel.yaml"
        $command = "dotnet run --project $script:autorestPluginProject --no-build -- --plugin=csharpgen --title=$title --namespace=$namespace --standalone --input-file=$codeModel --output-folder=$outputPath --shared-source-folder=$script:sharedSource --save-code-model=true"
    }

    if ($clean)
    {
        Get-ChildItem $outputPath -Filter Generated -Directory -Recurse | Get-ChildItem -File -Recurse | Remove-Item -Force
    }

    Invoke $command
}

# General configuration
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$debugFlags = if (-not $noDebug) { '--debug', '--verbose' }

$swaggerDefinitions = @{};

# Test server test configuration
$autorestBinary = Join-Path $repoRoot 'node_modules' '.bin' 'autorest-beta'
$testServerDirectory = Join-Path $repoRoot 'test' 'TestServerProjects'
$sharedSource = Join-Path $repoRoot 'src' 'assets'
$autorestPluginProject = Resolve-Path (Join-Path $repoRoot 'src' 'AutoRest.CSharp.V3')
$launchSettings = Join-Path $autorestPluginProject 'Properties' 'launchSettings.json'
$configurationPath = Join-Path $testServerDirectory 'readme.tests.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$testNames =
    'additionalProperties',
    #'azure-parameter-grouping',
    #'azure-special-properties',
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
    #'body-formdata',
    'body-integer',
    'body-number',
    'body-string',
    'custom-baseUrl',
    'custom-baseUrl-more-options',
    'custom-baseUrl-paging',
    'extensible-enums-swagger',
    'header',
    'httpInfrastructure',
    'lro',
    #'media_types',
    'model-flattening',
    'paging',
    #'required-optional',
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
$projectNames =
    'AppConfiguration',
    'CognitiveServices.TextAnalytics',
    'CognitiveSearch',
    'Azure.AI.FormRecognizer',
    'Azure.Storage.Tables',
    'Azure.Storage.Management',
    'Azure.Network.Management.Interface'

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

    $sharedSourceNormalized = $sharedSource.Replace($repoRoot, '$(SolutionDir)')
    foreach ($key in $swaggerDefinitions.Keys | Sort-Object)
    {
        $definition = $swaggerDefinitions[$key];
        $outputPath = (Join-Path $definition.output $key).Replace($repoRoot, '$(SolutionDir)')
        $codeModel = Join-Path $outputPath 'CodeModel.yaml'
        $namespace = $definition.title.Replace('-', '_')

        $settings.profiles[$key] = @{
            'commandName'='Project';
            'commandLineArgs'="--standalone --input-codemodel=$codeModel --plugin=csharpgen --output-folder=$outputPath --namespace=$namespace --shared-source-folder=$sharedSourceNormalized --save-code-model=true"
        }
    }

    $settings | ConvertTo-Json | Out-File $launchSettings
}

if ($reset -or $env:TF_BUILD)
{
    Invoke "$script:autorestBinary --reset"
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
    $projectPath = $definition.output;
    if (!$noProjectBuild)
    {
        Invoke "dotnet build $projectPath --verbosity quiet /nologo"
    }
}

