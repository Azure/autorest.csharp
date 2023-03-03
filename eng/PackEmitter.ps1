param($AutorestVersion, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'CADL.Extension' 'Emitter.Csharp')

# Pack emitter npm package "@azure-tools/cadl-csharp"
Push-Location $emitterPath
npm run build

$packageFile = "$emitterPath\package.json"
(Get-Content -Raw $packageFile) -replace `
    '"@azure-tools/cadl-csharp": ".*?"',
"`"@azure-tools/cadl-csharp`": `"$AutorestVersion`"" | `
    Set-Content $packageFile -NoNewline
    
npm version --no-git-tag-version $AutorestVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location