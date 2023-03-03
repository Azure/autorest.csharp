param($BuildNumber, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'CADL.Extension' 'Emitter.Csharp')
$artifactsPath = Resolve-Path (Join-Path $repoRoot '/artifacts/bin/AutoRest.CSharp/Release/net6.0/')
$localVersion = "0.0.0-beta.$BuildNumber"

# Pack autorest.csharp nuget package "Microsoft.Azure.AutoRest.CSharp"
Push-Location $repoRoot
dotnet pack /p:OfficialBuildId=$localVersion -o $StagingDirectory -warnaserror -c Release
Pop-Location

# Pack emitter npm package "@azure-tools/cadl-csharp"
Push-Location $emitterPath
Remove-Item azure-tools-cadl-csharp-*.tgz
npm run build
npm pack
$emitterPackagePath = (Get-ChildItem azure-tools-cadl-csharp-*.tgz) -replace "\\", "/"
Copy-Item $emitterPackagePath -Destination $StagingDirectory
Pop-Location

# Pack autorest.csharp npm package "@autorest/csharp"
Push-Location $artifactsPath
$currentVersion = node -p -e "require('./package.json').version";
npm version --no-git-tag-version $localVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location