param($Version, $PullRequestNumber, $SdkRepoRoot)

$RemoteName = "origin"
$BranchName = "autorest/pr$PullRequestNumber"
Write-Host "Branch name: $BranchName"

# Fetch and checkout remote branch if it already exists otherwise create a new branch.
git ls-remote --exit-code --heads $RemoteName $BranchName
if ($LASTEXITCODE -eq 0) {
    Write-Host "git fetch $RemoteName $BranchName"
    git fetch $RemoteName $BranchName
    Write-Host "git checkout $BranchName."
    git checkout $BranchName
} else {
    Write-Host "git checkout -b $BranchName."
    git checkout -b $BranchName
}

$SdkRepoRoot = Resolve-Path $SdkRepoRoot
$PackageJson = Resolve-Path "$SdkRepoRoot\package.json"
$PackagesProps = Resolve-Path "$SdkRepoRoot\eng\Packages.Data.props"

Write-Host "$PackageJson"
Write-Host "$PackagesProps"