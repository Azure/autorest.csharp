param($NpmToken, $GitHubToken, $BuildNumber, $Sha, $WorkingDirectory, $PackageJson, $CoverageUser, $CoveragePass)

$WorkingDirectory = Resolve-Path $WorkingDirectory
$RepoRoot = Resolve-Path "$PSScriptRoot/.."

Copy-Item $PackageJson $WorkingDirectory -Force

Push-Location $WorkingDirectory
try {
    $currentVersion = node -p -e "require('./package.json').version";
    $devVersion = "$currentVersion-beta.$BuildNumber"

    Write-Host "Setting version to $devVersion"

    npm version --no-git-tag-version $devVersion | Out-Null;
   
    $file = npm pack -q;
    $name = "AutoRest C# v$devVersion"

    Write-Host "Publishing $file on GitHub!"
    
    cmd /c ""npx -q publish-release --token $GitHubToken --repo autorest.csharp --owner azure --name $name --tag v$devVersion --notes=prerelease-build --prerelease --editRelease false --assets $file --target_commitish $Sha 2>&1""

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
    # set the version in the root package.json so coverage-push can pick it up

    npm version --no-git-tag-version $devVersion | Out-Null;
   
    npm run coverage-push --prefix node_modules/@microsoft.azure/autorest.testserver -- Azure/autorest.csharp refs/heads/feature/v3 skip $CoverageUser $CoveragePass
}
finally {
    Pop-Location
}
