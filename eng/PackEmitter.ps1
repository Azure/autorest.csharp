param($AutorestVersion, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'CADL.Extension' 'Emitter.Csharp')

# Pack emitter npm package "@azure-tools/cadl-csharp"
Push-Location $emitterPath
"registry=https://pkgs.dev.azure.com/azure-sdk/_packaging/azure-sdk-for-net-private/npm/registry/`n`nalways-auth=true" | Out-File -FilePath (Join-Path $emitterPath '.npmrc')
npm install -g vsts-npm-auth
vsts-npm-auth -config .npmrc
npm install @autorest/csharp@$AutorestVersion --save-exact
npm run build
npm version --no-git-tag-version $AutorestVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location