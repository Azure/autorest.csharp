param(
    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,

    [string[]]$ServiceDirectoryFilters = @("*"),
    
    [switch]$ShowSummary
    )

$ErrorActionPreference = 'Stop'

Write-Host "Generating Azure SDK Codes..."
foreach ($filter in $ServiceDirectoryFilters) {
    Write-Host 'Generating projects under service directory ' -ForegroundColor Green -NoNewline
    Write-Host "$filter" -ForegroundColor Yellow
    if ($ShowSummary)
    {
        dotnet msbuild /restore /t:GenerateCode /p:ServiceDirectory=$filter /v:n /ds "$SdkRepoRoot\eng\service.proj"
    }
    else
    {
        dotnet msbuild /restore /t:GenerateCode /p:ServiceDirectory=$filter "$SdkRepoRoot\eng\service.proj"
    }
    if ($LastExitCode -ne 0) {
        Write-Error 'Generation error'
        exit 1
    }
}
