param($BuildNumber, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$localVersion = "0.0.0-beta.$BuildNumber"

# Pack autorest.csharp nuget package "Microsoft.Azure.AutoRest.CSharp"
Push-Location $repoRoot
dotnet pack /p:OfficialBuildId=$localVersion -o $StagingDirectory -warnaserror -c Release
Pop-Location

# Pack autorest.csharp npm package "@autorest/csharp"
$artifactsPath = Resolve-Path (Join-Path $repoRoot '/artifacts/bin/AutoRest.CSharp/Release/net6.0/')
Push-Location $artifactsPath
npm version --no-git-tag-version $localVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location