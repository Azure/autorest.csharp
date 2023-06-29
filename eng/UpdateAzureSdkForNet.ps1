param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$TypeSpecEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"),

    [string]$ProjectListOverrideFile,

    [switch]$ShowSummary,

    [bool]$UseInternalFeed = $false)

$ErrorActionPreference = 'Stop'

Invoke-Expression "$PSScriptRoot\UpdateGeneratorMetadata.ps1 -AutorestCSharpVersion $AutorestCSharpVersion -TypeSpecEmitterVersion $TypeSpecEmitterVersion -SdkRepoRoot $SdkRepoRoot -UseInternalFeed `$$UseInternalFeed"

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',') -ProjectListOverrideFile $ProjectListOverrideFile $(if ($ShowSummary) {'-ShowSummary'})"
