#Requires -Version 7.0
Set-StrictMode -Version 3.0

$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

function CopyAll([string[]]$files, [string]$source, [string]$destination)
{
    foreach ($file in $files)
    {
        Write-Host "Copying $file to $destination"
        Copy-Item (Join-Path $source $file) (Join-Path $destination $file)
    }
}

Write-Host 'Downloading shared source files...'

$clonedPath = "$root/artifacts/azure-sdk-for-net-shared"
$azCoreSharedPath = "sdk/core/Azure.Core/src/Shared/"
$armCoreSharedPath = "sdk/resourcemanager/Azure.ResourceManager/src/Shared/"

if (Test-Path $clonedPath) {
    Remove-Item $clonedPath -Recurse -Force
}

Invoke-LoggedCommand "git clone --no-checkout --filter=tree:0 https://github.com/Azure/azure-sdk-for-net.git $clonedPath"

Push-Location $clonedPath
try {
    Invoke-LoggedCommand "git sparse-checkout init"
    Invoke-LoggedCommand "git sparse-checkout set --no-cone $azCoreSharedPath $armCoreSharedPath"
    Invoke-LoggedCommand "git checkout"
}
finally {
    Pop-Location
}

$files = @(
    'AppContextSwitchHelper.cs',
    'Argument.cs',
    'AsyncLockWithValue.cs',
    'AzureKeyCredentialPolicy.cs',
    'AzureResourceProviderNamespaceAttribute.cs',
    'ChangeTrackingDictionary.cs',
    'ChangeTrackingList.cs',
    'ClientDiagnostics.cs',
    'DiagnosticScope.cs',
    'DiagnosticScopeFactory.cs',
    'HttpMessageSanitizer.cs',
    'FixedDelayWithNoJitterStrategy.cs',
    'ForwardsClientCallsAttribute.cs',
    'FormUrlEncodedContent.cs',
    'HttpPipelineExtensions.cs',
    'IOperationSource.cs',
    'IUtf8JsonSerializable.cs',
    'IXmlSerializable.cs',
    'JsonElementExtensions.cs',
    'NextLinkOperationImplementation.cs',
    'NoValueResponseOfT.cs',
    'OperationFinalStateVia.cs',
    'OperationInternalBase.cs',
    'OperationInternal.cs',
    'OperationInternalOfT.cs',
    'OperationPoller.cs',
    'Optional.cs',
    'Page.cs',
    'PageableHelpers.cs',
    'ProtocolOperation.cs',
    'ProtocolOperationHelpers.cs',
    'RawRequestUriBuilder.cs',
    'RequestContentHelper.cs',
    'RequestHeaderExtensions.cs',
    'RequestUriBuilderExtensions.cs',
    'ResponseHeadersExtensions.cs',
    'ResponseWithHeaders.cs',
    'ResponseWithHeadersOfTHeaders.cs',
    'ResponseWithHeadersOfTOfTHeaders.cs',
    'SequentialDelayStrategy.cs',
    'StringRequestContent.cs',
    'TaskExtensions.cs',
    'TrimmingAttribute.cs',
    'TypeFormatters.cs',
    'Utf8JsonRequestContent.cs',
    'Utf8JsonWriterExtensions.cs',
    'VoidValue.cs',
    'XElementExtensions.cs',
    'XmlWriterContent.cs',
    'XmlWriterExtensions.cs',
    'Multipart/MultipartContent.cs',
    'Multipart/MultipartFormDataContent.cs'
)

$sourcePath = "$clonedPath/sdk/core/Azure.Core/src/Shared/"
$destinationPath = "$root/src/assets/Azure.Core.Shared"

Get-ChildItem $destinationPath -Filter *.cs | Remove-Item;
CopyAll $files $sourcePath $destinationPath

#Download management Shared
$files = @(
    'SharedExtensions.cs',
    'ManagedServiceIdentityTypeV3Converter.cs'
)

$sourcePath = "$clonedPath/sdk/resourcemanager/Azure.ResourceManager/src/Shared"
$destinationPath = "$root/src/assets/Management.Shared"

Get-ChildItem $destinationPath -Filter *.cs | Remove-Item;
CopyAll $files $sourcePath $destinationPath

# Waiting before deleting the cloned repo to avoid file locking issues
Start-Sleep -Seconds 1
Remove-Item $clonedPath -Recurse -Force -ErrorAction SilentlyContinue
Write-Host 'Shared source files are downloaded'
