param($Artifacts, $Token, $BuildNumber, $Sha)

$file = Get-ChildItem $Artifacts -Filter *.tgz
$name = $file.Name

npx publish-release --token $Token --repo autorest.csharp --owner azure --name $name --tag $name --notes='prerelease build' --prerelease --editRelease false --assets $file.FullName --target_commitish $Sha
