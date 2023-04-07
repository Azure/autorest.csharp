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
$npmInstallCommand = "npm install --prefix $SdkRepoRoot @azure-tools/typespec-csharp@$CadlEmitterVersion --no-package-lock --omit=dev"
Write-Host($npmInstallCommand)
Invoke-Expression $npmInstallCommand

if (Test-Path "package.json") {
    rm package.json
}
Pop-Location

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',') $(if ($ShowSummary) {'-ShowSummary'})"
