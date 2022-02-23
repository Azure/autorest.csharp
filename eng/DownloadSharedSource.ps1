#Requires -Version 6.0
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

function DownloadAll([string[]]$files, [string]$baseUrl, [string]$downloadPath)
{
    foreach ($file in $files)
    {
        Write-Host "Downloading" $file
        $text = (Invoke-WebRequest -Uri "$baseUrl/$file").Content
        $text.Trim() | Out-File (Join-Path $downloadPath $file)
    }
}

$downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
Get-ChildItem $downloadPath -Filter *.cs | Remove-Item;
$files = 'ClientDiagnostics.cs', 'DiagnosticScope.cs', 'DiagnosticScopeFactory.cs', 'ContentTypeUtilities.cs', 'HttpMessageSanitizer.cs', 'OperationInternalBase.cs', 'OperationInternal.cs', 'OperationInternalOfT.cs', 'TaskExtensions.cs', 'Argument.cs', 'Multipart/MultipartFormDataContent.cs', 'Multipart/MultipartContent.cs', 'AzureKeyCredentialPolicy.cs', 'AppContextSwitchHelper.cs'
$baseUrl = 'https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/core/Azure.Core/src/Shared/'
DownloadAll $files $baseUrl $downloadPath

#Download management Shared
$filesToDownload = 'SharedExtensions.cs', 'HttpMessageUtilities.cs'
$filesToPreserve = 'ArmOperationHelpers.cs', 'RealArmOperation.cs', 'RealArmOperationOfT.cs'
$downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Management.Shared')
Get-ChildItem $downloadPath -Filter *.cs | where Name -NotIn $filesToPreserve | Remove-Item;
$baseUrl = 'https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/resourcemanager/Azure.ResourceManager/src/Shared/'
DownloadAll $filesToDownload $baseUrl $downloadPath
