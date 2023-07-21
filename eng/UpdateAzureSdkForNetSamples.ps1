param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$TypeSpecEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"),

    [switch]$ShowSummary
    )

$ErrorActionPreference = 'Stop'

Invoke-Expression "$PSScriptRoot\UpdateGeneratorMetadata.ps1 -AutorestCSharpVersion $AutorestCSharpVersion -TypeSpecEmitterVersion $TypeSpecEmitterVersion -SdkRepoRoot $SdkRepoRoot"

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkSamples.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',') $(if ($ShowSummary) {'-ShowSummary'})"
