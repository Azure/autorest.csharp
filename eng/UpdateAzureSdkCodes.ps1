param(
    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,

    [string[]]$ServiceDirectoryFilters = @("*"),

    [string]$ProjectListOverrideFile = '',
    
    [switch]$ShowSummary
)

$ErrorActionPreference = 'Stop'

Write-Host "Generating Azure SDK Codes..."
if($ProjectListOverrideFile) {
    Write-Host 'Generating projects in override file ' -ForegroundColor Green -NoNewline
    Write-Host "$ProjectListOverrideFile" -ForegroundColor Yellow
    if ($ShowSummary) {
        dotnet msbuild /restore /t:GenerateCode /p:ProjectListOverrideFile=$ProjectListOverrideFile /v:n /ds "$SdkRepoRoot\eng\service.proj"
    }
    else {
        dotnet msbuild /restore /t:GenerateCode /p:ProjectListOverrideFile=$ProjectListOverrideFile "$SdkRepoRoot\eng\service.proj"
    }
    if ($LastExitCode -ne 0) {
        Write-Error 'Generation error'
        exit 1
    }
}
else {
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
}
