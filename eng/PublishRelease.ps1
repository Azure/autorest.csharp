param($NpmToken, $GitHubToken, [string]$BuildNumber, $Sha, $AutorestArtifactDirectory, $typespecEmitterDirectory)

$AutorestArtifactDirectory = Resolve-Path $AutorestArtifactDirectory
$RepoRoot = Resolve-Path "$PSScriptRoot/.."

Push-Location $AutorestArtifactDirectory
try {
    $currentVersion = node -p -e "require('./package.json').version";
    $devVersion = "$currentVersion-beta.$BuildNumber"

    Write-Host "Setting version to $devVersion"

    npm version --no-git-tag-version $devVersion | Out-Null;
   
    $file = npm pack -q;
    $name = "AutoRest C# v$devVersion"

    Write-Host "Publishing autorest $file on GitHub!"
    
    npx -q publish-release --token $GitHubToken --repo autorest.csharp --owner azure --name $name --tag v$devVersion --notes=prerelease-build --prerelease --editRelease false --assets $file --target_commitish $Sha 2>&1

    $env:NPM_TOKEN = $NpmToken
    "//registry.npmjs.org/:_authToken=$env:NPM_TOKEN" | Out-File -FilePath (Join-Path $AutorestArtifactDirectory '.npmrc')

    Write-Host "Publishing $file on Npm!"
    
    npm publish $file --access public
}
finally {
    Pop-Location
}

$typespecEmitterDirectory = Resolve-Path $typespecEmitterDirectory

Push-Location $typespecEmitterDirectory
try {
    $autorestVersion = $devVersion
    $currentVersion = node -p -e "require('./package.json').version";
    $devVersion = "$currentVersion-beta.$BuildNumber"

    $attemptCount = 0
    $maxAttempts = 4
    while($true) {
        Write-Host "Installing @autorest/csharp@$autorestVersion and updating package.json"
        npm install @autorest/csharp@$autorestVersion --save-exact
        $attemptCount += 1

        if($LASTEXITCODE -eq 0) {
            break
        }

        if($attemptCount -eq $maxAttempts) {
            Write-Host "Failed to install @autorest/csharp@$autorestVersion. Exiting..."
            exit 1
        }

        Write-Host "Failed to install @autorest/csharp@$autorestVersion. Retrying in 5 seconds..."
        Start-Sleep -Seconds 15
    }

    Write-Host "Setting TypeSpec Emitter version to $devVersion"
    npm version --no-git-tag-version $devVersion | Out-Null;

    Write-Host "Packing TypeSpec emitter..."
    $file = npm pack -q;

    Write-Host "Publishing $file on Npm..."
    "//registry.npmjs.org/:_authToken=$env:NPM_TOKEN" | Out-File -FilePath (Join-Path $typespecEmitterDirectory '.npmrc')
    npm publish $file --access public
    
    Write-Host "##vso[task.setvariable variable=TypeSpecEmitterVersion;isoutput=true]$devVersion"
}
finally {
    Pop-Location
}
