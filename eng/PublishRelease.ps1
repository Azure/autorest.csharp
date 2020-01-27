param($Token, $BuildNumber, $Sha, $WorkingDirectory, $PackageJson, $Artifacts)

$Artifacts = Resolve-Path $Artifacts
$WorkingDirectory = Resolve-Path $WorkingDirectory

cp $PackageJson $WorkingDirectory -Force

pushd $WorkingDirectory
try
{
   $currentVersion = node -p -e "require('./package.json').version";
   $devVersion="$currentVersion-dev.$BuildNumber"

   npm version --no-git-tag-version $devVersion
   npm pack

   $file = Get-ChildItem . -Filter *.tgz
   $name = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)

   cp $file $Artifacts
   npx publish-release --token $Token --repo autorest.csharp --owner azure --name $name --tag $name --notes='prerelease build' --prerelease --editRelease false --assets $file.FullName --target_commitish $Sha
}
finally
{
    popd
}