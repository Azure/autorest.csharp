param($BuildNumber, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$currentVersion = ""
$codegenPath = Join-Path $repoRoot "src" "AutoRest.CSharp"
Push-Location $codegenPath
$currentVersion = node -p -e "require('./package.json').version";
Pop-Location

$alphaVersion = "$currentVersion-alpha.$BuildNumber"
Write-Host "Alpha version: $alphaVersion"

# Pack autorest.csharp nuget package "Microsoft.Azure.AutoRest.CSharp"
Push-Location $repoRoot
dotnet pack /p:Version=$alphaVersion -o $StagingDirectory -warnaserror -c Release
Pop-Location

# Pack autorest.csharp npm package "@autorest/csharp"
$artifactsPath = Resolve-Path (Join-Path $repoRoot '/artifacts/bin/AutoRest.CSharp/Release/net6.0/')
Push-Location $artifactsPath
npm version --no-git-tag-version $alphaVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location

Write-Host "##vso[task.setvariable variable=autorestVersion;isoutput=true]$alphaVersion"