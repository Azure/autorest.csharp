$rootPath = Resolve-Path (Join-Path $PSScriptRoot '..')

Push-Location $rootPath
$installedVersion = node -p -e "require('./node_modules/@typespec/compiler/package.json').version"
Pop-Location

Write-Host "Installed Tsp version: $installedVersion"

$matchString = "[0-9]+\.[0-9]+\.[0-9]+-dev\.[0-9]+"
if (!($installedVersion -match $matchString)) {
    WRite-Error "Installed Tsp version '$installedVersion' is not a dev version."
    exit 1
}