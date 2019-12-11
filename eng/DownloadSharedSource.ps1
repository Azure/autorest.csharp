#Requires -Version 6.0
$ErrorActionPreference = 'Stop'

$currentProgressPreference = $ProgressPreference
$ProgressPreference = 'SilentlyContinue'

$downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
$files = 'ClientDiagnostics.cs', 'ArrayBufferWriter.cs', 'DiagnosticScope.cs'
$baseUrl = 'https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/'

foreach ($file in $files)
{
    $text = Invoke-WebRequest -Uri "$baseUrl/$file";
    $text.Content.Replace('#nullable enable', '#pragma warning disable CS8600, CS8604, CS8605').Trim() | Out-File (Join-Path $downloadPath $file)
}

$ProgressPreference = $currentProgressPreference