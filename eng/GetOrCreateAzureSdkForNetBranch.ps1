param($Version, $PullRequestNumber, $SdkRepoRoot, $PackageSource)

$RemoteName = "origin"
$BranchName = "autorest/pr$PullRequestNumber"
$SdkRepoRoot = Resolve-Path $SdkRepoRoot
$RepoRoot = Resolve-Path "$PSScriptRoot/.."

Write-Host "`nversion: $BranchName"
Write-Host "pull request number: $PullRequestNumber"
Write-Host "autorest repo root: $RepoRoot"
Write-Host "azure-sdk-for-net repo root: $SdkRepoRoot"
Write-Host "package source: $PackageSource`n"

# Fetch and checkout remote branch if it already exists otherwise create a new branch.
git --git-dir=$SdkRepoRoot\.git ls-remote --exit-code --heads $RemoteName $BranchName
if ($LASTEXITCODE -eq 0) {
    Write-Host "git --git-dir=$SdkRepoRoot\.git fetch $RemoteName $BranchName"
    git --git-dir=$SdkRepoRoot\.git fetch $RemoteName $BranchName
    Write-Host "git --git-dir=$SdkRepoRoot\.git checkout $BranchName."
    git --git-dir=$SdkRepoRoot\.git checkout $BranchName
} else {
    Write-Host "git --git-dir=$SdkRepoRoot\.git checkout -b $BranchName."
    git --git-dir=$SdkRepoRoot\.git checkout -b $BranchName

    $NuGetConfig = Resolve-Path "$SdkRepoRoot\NuGet.Config"
    Write-Host "Add local path to $NuGetConfig"
    $NuGetConfigDocument = [xml](get-content $NuGetConfig)
    $LocalSourceNode = $NuGetConfigDocument.CreateElement("add")
    $LocalSourceNode.SetAttribute("key", "local")
    $LocalSourceNode.SetAttribute("value", $PackageSource)
    $NuGetConfigDocument.configuration.packageSources.AppendChild($LocalSourceNode)
    $NuGetConfigDocument.Save("$pathToConfig")

    Write-Host (get-content $pathToConfig)
}

$PackagesProps = Resolve-Path "$SdkRepoRoot\eng\Packages.Data.props"
Write-Host "$PackagesProps"