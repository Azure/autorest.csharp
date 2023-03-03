param($BuildNumber, $StagingDirectory)

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

$matchString = "(\d{8})\.(\d+)"
$localVersion = 0
If ($BuildNumber -match $matchString) {
    $minorVersion = [int]$Matches[2] + 500
    $localVersion = "$($Matches[1]).$minorVersion"
}
else {
    throw "Invalid build number"
}

Write-Host "Private version: $localVersion"

# Pack autorest.csharp nuget package "Microsoft.Azure.AutoRest.CSharp"
Push-Location $repoRoot
dotnet pack /p:OfficialBuildId=$localVersion -o $StagingDirectory -warnaserror -c Release
Pop-Location

# Pack autorest.csharp npm package "@autorest/csharp"
$artifactsPath = Resolve-Path (Join-Path $repoRoot '/artifacts/bin/AutoRest.CSharp/Release/net6.0/')
Push-Location $artifactsPath
$currentVersion = node -p -e "require('./package.json').version";
$devVersion = "$currentVersion-beta.$localVersion"
npm version --no-git-tag-version $devVersion | Out-Null;
$file = npm pack -q;
Copy-Item $file -Destination $StagingDirectory
Pop-Location

Write-Host "##vso[task.setvariable variable=autorestVersion]$devVersion"