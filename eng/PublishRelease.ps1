param($Token, $BuildNumber, $Sha, $WorkingDirectory, $PackageJson)

$Artifacts = Resolve-Path $Artifacts
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
   $name = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)

   Write-Host "Publishing $file"

   npx publish-release --token $Token --repo autorest.csharp --owner azure --name $name --tag $name --notes='prerelease build' --prerelease --editRelease false --assets $file.FullName --target_commitish $Sha
}
finally
{
    popd
}