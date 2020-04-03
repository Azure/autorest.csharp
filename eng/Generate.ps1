#Requires -Version 6.0
param($name, [switch]$continue, [switch]$noDebug, [switch]$reset, [switch]$noBuild, [switch]$noProjectBuild, [switch]$fast, [switch]$updateLaunchSettings, [switch]$clean = $true, [String[]]$Exclude = "SmokeTests")

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
    $command = "$script:autorestBinary $script:debugFlags $autoRestArguments --title=$title --namespace=$namespace --output-folder=$outputPath"

    if ($fast)
    {
        $codeModel = Join-Path $baseOutput $title "CodeModel.yaml"
        $command = "dotnet run --project $script:autorestPluginProject --no-build -- --plugin=csharpgen --title=$title --namespace=$namespace --standalone --input-file=$codeModel --output-folder=$outputPath --shared-source-folder=$script:sharedSource --save-code-model=true"
    }

    if ($clean)
    {
        if (Test-Path $outputPath)
        {
            Get-ChildItem $outputPath -Filter Generated -Directory -Recurse | Get-ChildItem -File -Recurse | Remove-Item -Force
            New-Item -ItemType Directory -Force -Path $outputPath
        }
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
$configurationPath = Join-Path $repoRoot 'readme.md'
$testServerSwaggerPath = Join-Path $repoRoot 'node_modules' '@microsoft.azure' 'autorest.testserver' 'swagger'
$testNames =
    'additionalProperties',
    'azure-parameter-grouping',
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
    'media_types',
    'model-flattening',
    #'non-string-enum',
    'paging',
    #'required-optional',
    'url',
    'validation',
    'xml-service',
    #'xms-error-responses',
    'url-multi-collectionFormat';

if (!($Exclude -contains "TestServer"))
{
    foreach ($testName in $testNames)
    {
        $inputFile = Join-Path $testServerSwaggerPath "$testName.json"
        $swaggerDefinitions[$testName] = @{
            'title'=$testName;
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
            'title'=$testName;
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
    'Azure.Storage.Management',
    'Azure.Network.Management.Interface'

if (!($Exclude -contains "Samples"))
{
    foreach ($projectName in $projectNames)
    {
        $projectDirectory = Join-Path $repoRoot 'samples' $projectName
        $sampleConfigurationPath = Join-Path $projectDirectory 'readme.md'

        $swaggerDefinitions[$projectName] = @{
            'title'=$projectName;
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
        if ($input -match "^[^#].*?specification/([\w-]+(/[\w-]+)+)/readme.md")
        {
            $projectName = $Matches[1].Replace("/", "-");

            $projectDirectory = Join-Path $repoRoot 'samples' 'smoketests' $projectName

            $swaggerDefinitions[$projectName] = @{
                'title'=$projectName;
                'output'=$projectDirectory;
                'arguments'="--require=$configurationPath $input"
            }
        }
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

        $settings.profiles[$key] = [ordered]@{
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

$keys = $swaggerDefinitions.Keys | Sort-Object;
if (![string]::IsNullOrWhiteSpace($name))
{ 
    if ($continue)
    {
        $keys = $keys.Where({$_ -eq $name},'SkipUntil') 
        Write-Host "Continuing with $keys"
    }
    else
    {
        $keys = $name
    }
}

foreach ($key in $keys)
{
    $definition = $swaggerDefinitions[$key];
    Invoke-AutoRest $definition.output $definition.title $definition.arguments
    $projectPath = Join-Path $definition.output $definition.title;
    if (!$noProjectBuild)
    {
        Invoke "dotnet build $projectPath --verbosity quiet /nologo"
    }
}

