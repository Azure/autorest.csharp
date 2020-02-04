#Requires -Version 6.0
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

$downloadPath = Resolve-Path (Join-Path $PSScriptRoot '..' 'src' 'assets' 'Azure.Core.Shared')
$files = 'ClientDiagnostics.cs', 'ArrayBufferWriter.cs', 'DiagnosticScope.cs', 'ResponseExceptionExtensions.cs', 'ContentTypeUtilities.cs', 'OperationHelpers.cs'
$baseUrl = 'https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/'

foreach ($file in $files)
{
    $text = (Invoke-WebRequest -Uri "$baseUrl/$file").Content
    $text = $text.Replace('#nullable enable', '#pragma warning disable CS8600, CS8604, CS8605')
    if ($file -eq 'ResponseExceptionExtensions.cs')
    {
        $text = "#nullable disable`n"  + $text
    }
    $text.Trim() | Out-File (Join-Path $downloadPath $file)
}
