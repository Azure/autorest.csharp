param($AutorestVersion, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'CADL.Extension' 'Emitter.Csharp')

# Pack emitter npm package "@azure-tools/cadl-csharp"
Push-Location $emitterPath
npm run build

$packageFile = "$emitterPath\package.json"
(Get-Content -Raw $packageFile) -replace `
    '"@autorest/csharp": ".*?"',
"`"@autorest/csharp`": `"$AutorestVersion`"" | `
    Set-Content $packageFile -NoNewline

$currentVersion = node -p -e "require('./package.json').version";
$alphaVersion = "$currentVersion-alpha.$BuildNumber"
Write-Host "Alpha version: $alphaVersion"

npm version --no-git-tag-version $alphaVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location

Write-Host "##vso[task.setvariable variable=emitterVersion;isoutput=true]$alphaVersion"