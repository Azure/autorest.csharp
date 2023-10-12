param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    
    [string[]]$ServiceDirectoryFilters = @("*"),

    [string]$ProjectListOverrideFile,

    [switch]$ShowSummary)

$ErrorActionPreference = 'Stop'

Invoke-Expression "$PSScriptRoot\UpdateAzureSdkCodes.ps1 -SdkRepoRoot $SdkRepoRoot -ServiceDirectoryFilters $($ServiceDirectoryFilters -Join ',') -ProjectListOverrideFile $ProjectListOverrideFile $(if ($ShowSummary) {'-ShowSummary'})"
