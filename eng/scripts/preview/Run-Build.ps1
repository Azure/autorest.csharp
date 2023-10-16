#Requires -Version 7.0

param(
    [string] $BuildNumber,
    [string] $PublishTarget,
    [string] $BuildPrereleaseVersion,
    [string] $Output
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../../..").Path.Replace('\', '/')
. "$root/eng/scripts/preview/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

[bool]$BuildPrereleaseVersion = $BuildPrereleaseVersion -ieq "true"

$artifacts = "$root/artifacts"
$output = $Output ? $Output : "$artifacts/ci-build"

# try to remove the artifacts folder if it exists
if (Test-Path "$artifacts") {
    Remove-Item -Recurse -Force "$artifacts"
}

# try to remove the artifacts folder if it exists
if (Test-Path "$output") {
    Remove-Item -Recurse -Force "$output"
}

# create the output folders
$artifacts = New-Item -ItemType Directory -Force -Path "$artifacts" | Select-Object -ExpandProperty FullName
$output = New-Item -ItemType Directory -Force -Path "$output" | Select-Object -ExpandProperty FullName

$generatorVersion = node -p -e "require('$root/src/AutoRest.CSharp/package.json').version"
$emitterVersion = node -p -e "require('$root/src/TypeSpec.Extension/Emitter.Csharp/package.json').version"

if ($BuildNumber) {
    # set package versions
    $versionTag = $BuildPrereleaseVersion ? "-alpha" : "-beta"

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
    Invoke-LoggedCommand "dotnet pack src/AutoRest.CSharp/AutoRest.CSharp.csproj $versionOption -o $output/packages -warnaserror -c Release" -GroupOutput
}
finally
{
    Pop-Location
}

# pack the c# npm package
Push-Location "$artifacts/bin/AutoRest.CSharp/Release/net6.0/"
try {
    Write-Host "Working in $PWD"
    if ($BuildNumber) {
      Invoke-LoggedCommand "npm version --no-git-tag-version $generatorVersion" -GroupOutput
    }

    $file = Invoke-LoggedCommand "npm pack -q"
    Copy-Item $file -Destination "$output/packages"
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
    Copy-Item $file -Destination "$output/packages"
}
finally
{
    Pop-Location
}

$feedUrl = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest@local/npm/registry"

$overrides = @{
    "@autorest/csharp" = "$feedUrl/@autorest/csharp/-/csharp-$generatorVersion.tgz"
    "@azure-tools/typespec-csharp" = "$feedUrl/@azure-tools/typespec-csharp/-/typespec-csharp-$emitterVersion.tgz"
}

$overrides | ConvertTo-Json | Set-Content "$output/overrides.json"

$packageMatrix = [ordered]@{
    "generator" = $generatorVersion
    "emitter" = $emitterVersion
}

$packageMatrix | ConvertTo-Json | Set-Content "$output/package-versions.json"
