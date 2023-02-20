param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$CadlEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"))

Invoke-Expression "$PSScriptRoot\UpdateGeneratorMetadata.ps1 -AutorestCSharpVersion $AutorestCSharpVersion -CadlEmitterVersion $CadlEmitterVersion -SdkRepoRoot $SdkRepoRoot"

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',')"
