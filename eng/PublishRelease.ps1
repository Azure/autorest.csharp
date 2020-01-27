param($Token, $BuildNumber, $Sha, $WorkingDirectory, $PackageJson)

$WorkingDirectory = Resolve-Path $WorkingDirectory

cp $PackageJson $WorkingDirectory -Force

pushd $WorkingDirectory
try
{
   $currentVersion = node -p -e "require('./package.json').version";
   $devVersion="$currentVersion-dev.$BuildNumber"

   Write-Host "Setting version to $devVersion"

   npm version --no-git-tag-version $devVersion > Out-Null;
   
   $file = npm pack -q;
   $name = [System.IO.Path]::GetFileNameWithoutExtension($file)

   Write-Host "Publishing $file"

   cmd /c "npx -q publish-release --token $Token --repo autorest.csharp --owner azure --name $name --tag $name --notes=prerelease-build --prerelease --editRelease false --assets $file --target_commitish $Sha 2>&1"
}
finally
{
    popd
}