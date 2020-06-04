#Requires -Version 6.0
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

$downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
Get-ChildItem $downloadPath -Filter *.cs | Remove-Item;
$files = 'ClientDiagnostics.cs', 'DiagnosticScope.cs', 'DiagnosticScopeFactory.cs', 'ContentTypeUtilities.cs', 'HttpMessageSanitizer.cs', 'OperationHelpers.cs', 'TaskExtensions.cs'
$baseUrl = 'https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/'

foreach ($file in $files)
{
    $text = (Invoke-WebRequest -Uri "$baseUrl/$file").Content
    $text.Trim() | Out-File (Join-Path $downloadPath $file)
}
