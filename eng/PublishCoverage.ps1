param($Token, $Version, $CoverageUser, $CoveragePass)

$RepoRoot = Resolve-Path "$PSScriptRoot/.."

pushd $RepoRoot
try
{
    # set the version in the root package.json so coverage-push can pick it up

   npm version --no-git-tag-version $Version | Out-Null;
   
   npm run coverage-push --prefix node_modules/@microsoft.azure/autorest.testserver -- Azure/autorest.csharp refs/heads/feature/v3 skip $CoverageUser $CoveragePass
}
finally
{
    popd
}
