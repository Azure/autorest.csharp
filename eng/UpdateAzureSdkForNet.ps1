param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$CadlEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"))

Import-Module "$PSScriptRoot\UpdateGeneratorMetadata.psm1" -DisableNameChecking -Force;

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

UpdateGeneratorMetaData $AutorestCSharpVersion $CadlEmitterVersion $SdkRepoRoot

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',')"
