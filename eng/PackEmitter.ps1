param([string]$BuildNumber, $AutorestVersion, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'TypeSpec.Extension' 'Emitter.Csharp')

# Pack emitter npm package "@azure-tools/typespec-csharp"
Push-Location $emitterPath
try {
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

    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}

Write-Host "##vso[task.setvariable variable=TypeSpecEmitterVersion;isoutput=true]$alphaVersion"
