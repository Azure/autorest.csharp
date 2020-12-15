param($Token, $BuildNumber, $Sha, $WorkingDirectory, $PackageJson, $CoverageUser, $CoveragePass)

$WorkingDirectory = Resolve-Path $WorkingDirectory
$RepoRoot = Resolve-Path "$PSScriptRoot/.."

Copy-Item $PackageJson $WorkingDirectory -Force

Push-Location $WorkingDirectory
try {
    $currentVersion = node -p -e "require('./package.json').version";
    $devVersion = "$currentVersion.$BuildNumber"

    Write-Host "Setting version to $devVersion"

    npm version --no-git-tag-version $devVersion | Out-Null;
   
    $file = npm pack -q;
   # $name = [System.IO.Path]::GetFileNameWithoutExtension($file)

    Write-Host "Publishing $file"
    
    # git rev-list --parents HEAD --count --full-history

    # cmd /c "//registry.npmjs.org/:_authToken=$(Token)" > ./.npmrc

    cmd /c "npm publish --registry=https://registry.npmjs.org/:_authToken=$Token --access public"
    # npm publish --access public
    
    # cmd /c "npx -q publish-release --token $Token --repo autorest.csharp --owner azure --name $name --tag $devVersion --notes=prerelease-build --prerelease --editRelease false --assets $file --target_commitish $Sha 2>&1"

    # Write-Host "##vso[task.setvariable variable=AutorestCSharpVersion;isSecret=false]https://github.com/Azure/autorest.csharp/releases/download/$devVersion/autorest-csharp-v3-$devVersion.tgz"
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