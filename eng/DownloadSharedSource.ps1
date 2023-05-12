#Requires -Version 6.0
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

$sparseCheckoutFile = ".git/info/sparse-checkout"
$gitRemoteUrl = "https://github.com/Azure/azure-sdk-for-net.git"
$gitRemoteBranchName = "main"
$azCoreSharedPath = "sdk/core/Azure.Core/src/Shared/"
$armCoreSharedPath = "sdk/resourcemanager/Azure.ResourceManager/src/Shared/"

function InitializeSparseGitClone([string]$repo) {
    git clone --no-checkout --filter=tree:0 $repo .
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
    git sparse-checkout init
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
    Remove-Item $sparseCheckoutFile -Force
}

function AddSparseCheckoutPath([string]$subDirectory) {
    if (!(Test-Path $sparseCheckoutFile) -or !((Get-Content $sparseCheckoutFile).Contains($subDirectory))) {
        Write-Output $subDirectory >> $sparseCheckoutFile
    }
}

function GetSDKCloneDir() {
    $root = git rev-parse --show-toplevel

    $sparseSpecCloneDir = "$root/sdk"
    New-Item $sparseSpecCloneDir -Type Directory -Force | Out-Null
    $createResult = Resolve-Path $sparseSpecCloneDir
    return $createResult
}

$sdkCloneDir = GetSDKCloneDir
Write-Host "Setting up sparse clone for $gitRemoteUrl at $sdkCloneDir"

Push-Location $sdkCloneDir.Path
try {
    if (!(Test-Path ".git")) {
        Write-Host "Initializing sparse clone for $gitRemoteUrl"
        InitializeSparseGitClone $gitRemoteUrl
        AddSparseCheckoutPath $azCoreSharedPath
        AddSparseCheckoutPath $armCoreSharedPath
        $commitHash = git rev-parse $gitRemoteBranchName
        git checkout $commitHash
    }
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}
finally {
    Pop-Location
}

function CopyFilesToDestination([string]$sdkCloneRoot, [string]$dirName, [string]$dest, [string[]]$files) {
    $source = Join-Path $sdkCloneRoot $dirName
    foreach ($file in $files) {
        $sourceFile = Join-Path $source $file
        $destFile = Join-Path $dest $file
        # to avoid the format issues (the file is required to end by a newline)
        # here we read all the content in the source file, and then output it into the destination file
        Write-Host "Copying $file"
        $text = Get-Content -Path $sourceFile
        $text | Out-File -FilePath $destFile
    }
}

try {
    Write-Host "Downloading Azure.Core.Shared"
    $downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
    Write-Host "Removing the existing files in " $downloadPath
    Get-ChildItem $downloadPath -Filter *.cs | Remove-Item;
    $files = @('AsyncLockWithValue.cs', 'ClientDiagnostics.cs', 'DiagnosticScope.cs', 'DiagnosticScopeFactory.cs', 'ContentTypeUtilities.cs', 'HttpMessageSanitizer.cs',
        'OperationInternalBase.cs', 'OperationInternal.cs', 'OperationInternalOfT.cs', 'TaskExtensions.cs', 'Argument.cs', 'Multipart/MultipartFormDataContent.cs',
        'Multipart/MultipartContent.cs', 'AzureKeyCredentialPolicy.cs', 'AppContextSwitchHelper.cs',
        'OperationPoller.cs', 'FixedDelayWithNoJitterStrategy.cs', 'SequentialDelayStrategy.cs',
        'ForwardsClientCallsAttribute.cs', 'AsyncLockWithValue.cs', 'VoidValue.cs')
    
    CopyFilesToDestination $sdkCloneDir $azCoreSharedPath $downloadPath $files
    
    Write-Host "Downloading management Shared"
    $downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Management.Shared')
    Write-Host "Removing the existing files in " $downloadPath
    Get-ChildItem $downloadPath -Filter *.cs | Remove-Item;
    $files = 'SharedExtensions.cs', 'ManagedServiceIdentityTypeV3Converter.cs'
    
    CopyFilesToDestination $sdkCloneDir $armCoreSharedPath $downloadPath $files
}
finally {
    Write-Host "Removing the sparse checkout files in" $sdkCloneDir
    Remove-Item $sdkCloneDir -Force -Recurse
}
