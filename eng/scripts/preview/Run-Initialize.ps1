#Requires -Version 7.0

param(
  [string] $UseTypeSpecNext
)


$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../../..").Path.Replace('\', '/')
. "$root/eng/scripts/preview/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

[bool]$UseTypeSpecNext = $UseTypeSpecNext -ieq "true"

Push-Location $root
try {
  if (Test-Path "$root/node_modules") {
    Remove-Item -Recurse -Force "$root/node_modules"
  }
    
  if (Test-Path "$root/src/TypeSpec.Extension/Emitter.Csharp/node_modules") {
    Remove-Item -Recurse -Force "$root/src/TypeSpec.Extension/Emitter.Csharp/node_modules"
  }

  # install and list npm packages

  if ($UseTypeSpecNext) {
    if (Test-Path "$root/package-lock.json") {
      Remove-Item -Force "$root/package-lock.json"
    }

    Write-Host "Using TypeSpec.Next"
    Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --add-npm-overrides package.json"
    Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --use-peer-ranges ./src/TypeSpec.Extension/Emitter.Csharp/package.json"
    Invoke-LoggedCommand "npm install"

    # Write-Host "Adding package.json files to git index to avoid diff detection"
    # Invoke "git add ./package.json ./package-lock.json ./src/TypeSpec.Extension/Emitter.Csharp/package.json"
  }
  else {
    Invoke-LoggedCommand "npm ci"
  }

  Invoke-LoggedCommand "npm ls -a" -GroupOutput
}
finally {
  Pop-Location
}
