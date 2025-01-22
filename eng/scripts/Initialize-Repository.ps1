#Requires -Version 7.0

param(
    [string] $BuildArtifactsPath,
    [switch] $UseTypeSpecNext
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

if ($UseTypeSpecNext) {
    Write-Host "##vso[build.addbuildtag]typespec_next"
}

Push-Location $root
try {
    if (Test-Path "$root/node_modules") {
        Remove-Item -Recurse -Force "$root/node_modules"
    }

    if (Test-Path "$root/src/TypeSpec.Extension/Emitter.Csharp/node_modules") {
        Remove-Item -Recurse -Force "$root/src/TypeSpec.Extension/Emitter.Csharp/node_modules"
    }

    # install and list npm packages
  
    if ($BuildArtifactsPath) {
        $lockFilesPath = Resolve-Path "$BuildArtifactsPath/lock-files"
        # if we were passed a build_artifacts path, use the package.json and package-lock.json from there
        Write-Host "Using package.json, emitter/package.json and package-lock.json from $lockFilesPath"
        Copy-Item "$lockFilesPath/package.json" './package.json' -Force
        Copy-Item "$lockFilesPath/package-lock.json" './package-lock.json' -Force
        Copy-Item "$lockFilesPath/test/package.json" './test/UnbrandedProjects/package.json' -Force
        Copy-Item "$lockFilesPath/emitter/package.json" './src/TypeSpec.Extension/Emitter.Csharp/package.json' -Force

        Invoke-LoggedCommand "npm ci"
    }
    elseif ($UseTypeSpecNext) {
        if (Test-Path "$root/package-lock.json") {
            Remove-Item -Force "$root/package-lock.json"
        }

        Write-Host "Using TypeSpec.Next"
        Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --add-npm-overrides package.json"
        Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --use-peer-ranges ./src/TypeSpec.Extension/Emitter.Csharp/package.json"
        Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --add-npm-overrides ./test/UnbrandedProjects/package.json"
        Invoke-LoggedCommand "npm install"
    }
    else {
        Invoke-LoggedCommand "npm ci"
    }

    Invoke-LoggedCommand "npm ls -a" -GroupOutput

    Write-Host "Listing environment variables"
    Get-ChildItem env: | Sort-Object Name | Format-Table -AutoSize

    $artifactStagingDirectory = $env:Build_ArtifactStagingDirectory
    if ($artifactStagingDirectory -and !$BuildArtifactsPath) {
        $lockFilesPath = "$artifactStagingDirectory/lock-files"
        New-Item -ItemType Directory -Path "$lockFilesPath/emitter" | Out-Null
        New-Item -ItemType Directory -Path "$lockFilesPath/test" | Out-Null
        
        Write-Host "Copying package.json, emitter/package.json, test/UnbrandedProjects/package.json, and package-lock.json to $lockFilesPath"
        Copy-Item './package.json'  "$lockFilesPath/package.json" -Force
        Copy-Item './package-lock.json' "$lockFilesPath/package-lock.json" -Force
        Copy-Item './test/UnbrandedProjects/package.json' "$lockFilesPath/test/package.json" -Force
        Copy-Item './src/TypeSpec.Extension/Emitter.Csharp/package.json' "$lockFilesPath/emitter/package.json" -Force
    }
}
finally {
    Pop-Location
}
