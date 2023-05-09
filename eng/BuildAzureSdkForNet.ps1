param(
    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,
    [Parameter(Mandatory)]
    [string]$ProjectListOverrideFile,    
    [switch]$ShowSummary
)

$ErrorActionPreference = 'Stop'

Write-Host 'Building Azure SDK projects in override file ' -ForegroundColor Green -NoNewline
Write-Host "$ProjectListOverrideFile" -ForegroundColor Yellow

if ($ShowSummary) {
    dotnet build /p:ProjectListOverrideFile=$ProjectListOverrideFile /v:n /ds "$SdkRepoRoot\eng\service.proj"
}
else {
    dotnet build /p:ProjectListOverrideFile=$ProjectListOverrideFile "$SdkRepoRoot\eng\service.proj"
}

if ($LastExitCode -ne 0) {
    Write-Error 'Build error'
    exit 1
}
