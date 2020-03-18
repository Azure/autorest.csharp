param($Token, $BuildNumber, $Sha, $WorkingDirectory, $PackageJson, $CoverageUser, $CoveragePass)

$WorkingDirectory = Resolve-Path $WorkingDirectory
$RepoRoot = Resolve-Path "$PSScriptRoot/.."

cp $PackageJson $WorkingDirectory -Force

pushd $WorkingDirectory
try
{
   $currentVersion = node -p -e "require('./package.json').version";
   $devVersion="$currentVersion-dev.$BuildNumber"

   Write-Host "Setting version to $devVersion"

   npm version --no-git-tag-version $devVersion | Out-Null;
   
   $file = npm pack -q;
   $name = [System.IO.Path]::GetFileNameWithoutExtension($file)

   Write-Host "Publishing $file"

   cmd /c "npx -q publish-release --token $Token --repo autorest.csharp --owner azure --name $name --tag $devVersion --notes=prerelease-build --prerelease --editRelease false --assets $file --target_commitish $Sha 2>&1"
}
finally
{
    popd
}


pushd $RepoRoot
try
{
    # set the version in the root package.json so coverage-push can pick it up

   npm version --no-git-tag-version $devVersion | Out-Null;
   
   npm run coverage-push --prefix node_modules/@microsoft.azure/autorest.testserver -- autorest.csharp feature/v3 skip $CoverageUser $CoveragePass
}
finally
{
    popd
}
