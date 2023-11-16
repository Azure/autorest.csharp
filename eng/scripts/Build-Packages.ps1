#Requires -Version 7.0

param(
    [string] $BuildNumber,
    [string] $Output,
    [switch] $Prerelease,
    [switch] $PublishInternal
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/preview/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

$artifactsPath = "$root/artifacts"
$outputPath = $Output ? $Output : "$artifactsPath/ci-build"

# try to remove the artifacts folder if it exists
if (Test-Path $artifactsPath) {
    Remove-Item -Recurse -Force $artifactsPath
}

# create the output folders
$artifactsPath = New-Item -ItemType Directory -Force -Path $artifactsPath | Select-Object -ExpandProperty FullName
$outputPath = New-Item -ItemType Directory -Force -Path $outputPath | Select-Object -ExpandProperty FullName

$generatorVersion = node -p -e "require('$root/src/AutoRest.CSharp/package.json').version"
$emitterVersion = node -p -e "require('$root/src/TypeSpec.Extension/Emitter.Csharp/package.json').version"

if ($BuildNumber) {
    # set package versions
    $versionTag = $Prerelease ? "-alpha" : "-beta"

    # TODO: Remove 'x' suffix before merge    
    $generatorVersion = "$generatorVersion$versionTag.$BuildNumber.x"
    Write-Host "Setting output variable 'generatorVersion' to $generatorVersion"
    Write-Host "##vso[task.setvariable variable=generatorVersion;isoutput=true]$generatorVersion"

    $emitterVersion = "$emitterVersion$versionTag.$BuildNumber.x"
    Write-Host "Setting output variable 'emitterVersion' to $emitterVersion"
    Write-Host "##vso[task.setvariable variable=emitterVersion;isoutput=true]$emitterVersion"
}

# build the nuget package

$versionOption = $BuildNumber ? "/p:Version=$generatorVersion" : ""

Write-Host "Working in $root"
Push-Location $root
try
{
    Invoke-LoggedCommand "dotnet pack src/AutoRest.CSharp/AutoRest.CSharp.csproj $versionOption -o $outputPath/packages -warnaserror -c Release" -GroupOutput
}
finally
{
    Pop-Location
}

# pack the c# npm package
Push-Location "$artifactsPath/bin/AutoRest.CSharp/Release/net7.0/"
try {
    Write-Host "Working in $PWD"
    if ($BuildNumber) {
      Invoke-LoggedCommand "npm version --no-git-tag-version $generatorVersion" -GroupOutput
    }

    $file = Invoke-LoggedCommand "npm pack -q"
    Copy-Item $file -Destination "$outputPath/packages"
}
finally
{
    Pop-Location
}

# build and pack the emitter
Push-Location "$root/src/TypeSpec.Extension/Emitter.Csharp"
try {
    Write-Host "Working in $PWD"
    Invoke-LoggedCommand "npm run build" -GroupOutput

    if ($BuildNumber) {
        Write-Host "Updating package.json use the new @autorest/csharp version`n"

        $packageJson = Get-Content -Raw "package.json" | ConvertFrom-Json -AsHashtable

        $packageJson.version = $emitterVersion
        $packageJson.dependencies["@autorest/csharp"] = $generatorVersion

        $packageJson | ConvertTo-Json -Depth 100 | Out-File -Path "package.json" -Encoding utf8 -NoNewline -Force
    }

    #pack the emitter
    $file = Invoke-LoggedCommand "npm pack -q"
    Copy-Item $file -Destination "$outputPath/packages"
}
finally
{
    Pop-Location
}

if ($PublishInternal) {
    $feedUrl = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest/npm/registry"

    $overrides = @{
        "@autorest/csharp" = "$feedUrl/@autorest/csharp/-/csharp-$generatorVersion.tgz"
        "@azure-tools/typespec-csharp" = "$feedUrl/@azure-tools/typespec-csharp/-/typespec-csharp-$emitterVersion.tgz"
    }
} else {
    $overrides = @{}
}

$overrides | ConvertTo-Json | Set-Content "$outputPath/overrides.json"

$packageMatrix = [ordered]@{
    "generator" = $generatorVersion
    "emitter" = $emitterVersion
}

$packageMatrix | ConvertTo-Json | Set-Content "$outputPath/package-versions.json"
