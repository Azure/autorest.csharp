param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$CadlEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"),

    [string]$ProjectListOverrideFile,

    [bool]$UseInternalFeed = $false,

    [switch]$ShowSummary)

$ErrorActionPreference = 'Stop'

Invoke-Expression "$PSScriptRoot\UpdateGeneratorMetadata.ps1 -AutorestCSharpVersion $AutorestCSharpVersion -CadlEmitterVersion $CadlEmitterVersion -SdkRepoRoot $SdkRepoRoot -UseInternalFeed `$$UseInternalFeed"

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',') -ProjectListOverrideFile $ProjectListOverrideFile $(if ($ShowSummary) {'-ShowSummary'})"
