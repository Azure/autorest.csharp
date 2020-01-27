param($Token, $BuildNumber, $Sha, $WorkingDirectory, $Artifacts)

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