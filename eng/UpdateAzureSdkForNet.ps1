param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$CadlEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"),

    [switch]$ShowSummary)

$ErrorActionPreference = 'Stop'

Invoke-Expression "$PSScriptRoot\UpdateGeneratorMetadata.ps1 -AutorestCSharpVersion $AutorestCSharpVersion -CadlEmitterVersion $CadlEmitterVersion -SdkRepoRoot $SdkRepoRoot"

Push-Location $SdkRepoRoot
Write-Host "Installing emitter version $CadlEmitterVersion at"(Get-Location)
if (Test-Path ".npmrc") {
    Write-Host "Registry file exists."
}
npm install "@azure-tools/typespec-csharp@$CadlEmitterVersion --registry=https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js-test-autorest/npm/registry/" --no-lock-file
Pop-Location

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',') $(if ($ShowSummary) {'-ShowSummary'})"
