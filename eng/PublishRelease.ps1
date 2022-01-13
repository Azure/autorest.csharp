param($NpmToken, $GitHubToken, $BuildNumber, $Sha, $WorkingDirectory, $CoverageUser, $CoveragePass, $CoverageDirectory)

$WorkingDirectory = Resolve-Path $WorkingDirectory
$RepoRoot = Resolve-Path "$PSScriptRoot/.."

Push-Location $WorkingDirectory
try {
    $currentVersion = node -p -e "require('./package.json').version";
    $devVersion = "$currentVersion-beta.$BuildNumber"

    Write-Host "Setting version to $devVersion"

    npm version --no-git-tag-version $devVersion | Out-Null;
   
    $file = npm pack -q;
    $name = "AutoRest C# v$devVersion"

    Write-Host "Publishing $file on GitHub!"
    
    npx -q publish-release --token $GitHubToken --repo autorest.csharp --owner azure --name $name --tag v$devVersion --notes=prerelease-build --prerelease --editRelease false --assets $file --target_commitish $Sha 2>&1

    $filePath = Join-Path $WorkingDirectory '.npmrc'
    $env:NPM_TOKEN = $NpmToken
    "//registry.npmjs.org/:_authToken=$env:NPM_TOKEN" | Out-File -FilePath $filePath

    Write-Host "Publishing $file on Npm!"
    
    npm publish $file --access public
}
finally {
    Pop-Location
}

Push-Location $RepoRoot
try {
    # set the version in the root package.json so coverage can pick it up

    npm version --no-git-tag-version $devVersion | Out-Null;
   
    $CoverageDirectory = Resolve-Path $CoverageDirectory

    npm run coverage --prefix node_modules/@microsoft.azure/autorest.testserver -- publish --repo=Azure/autorest.csharp --ref=refs/heads/feature/v3 --githubToken=skip --azStorageAccount=$CoverageUser --azStorageAccessKey=$CoveragePass --coverageDirectory=$CoverageDirectory
}
finally {
    Pop-Location
}
