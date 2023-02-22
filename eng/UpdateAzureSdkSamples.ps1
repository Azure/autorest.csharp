param(
    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,

    [string[]]$ServiceDirectoryFilters = @("*"),
    
    [switch]$ShowSummary
    )

Write-Host "Generating Azure SDK Samples..."
foreach ($filter in $ServiceDirectoryFilters) {
    Write-Host 'Generating projects under service directory ' -ForegroundColor Green -NoNewline
    Write-Host "$filter" -ForegroundColor Yellow
    if ($ShowSummary) {
        dotnet msbuild /restore /t:GenerateTests /p:ServiceDirectory=$filter /v:n /ds "$SdkRepoRoot\eng\service.proj"
    }
    else {
        dotnet msbuild /restore /t:GenerateTests /p:ServiceDirectory=$filter "$SdkRepoRoot\eng\service.proj"
    }
    if ($LastExitCode -ne 0) {
        Write-Error 'Generation error'
        exit 1
    }
}
