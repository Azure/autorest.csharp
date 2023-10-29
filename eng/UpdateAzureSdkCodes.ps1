param(
    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,

    [string[]]$ServiceDirectoryFilters = @("*"),

    [string]$ProjectListOverrideFile = '',
    
    [switch]$ShowSummary
)

$ErrorActionPreference = 'Stop'
Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

Write-Host "Generating Azure SDK Codes..."

if($ProjectListOverrideFile) {
    Write-Host "Initializing npm and npx cache"

    $templatePath = "$SdkRepoRoot/sdk/template/Azure.Template"
    Invoke "dotnet build /t:GenerateCode" -ExecutePath $templatePath
    Invoke "git restore ." -ExecutePath $templatePath
    Invoke "git clean . --force" -ExecutePath $templatePath

    $tempFolder = New-TemporaryFile
    $tempFolder | Remove-Item -Force
    New-Item $tempFolder -ItemType Directory -Force | Out-Null

    Push-Location $tempFolder
    try {
        Copy-Item "$SdkRepoRoot/eng/emitter-package.json" "package.json"
        if(Test-Path "$SdkRepoRoot/eng/emitter-package-lock.json") {
            Copy-Item "$SdkRepoRoot/eng/emitter-package-lock.json" "package-lock.json"
            Invoke "npm ci" -ExecutePath $PWD
        } else {
            Invoke "npm install" -ExecutePath $PWD
        }
    }
    finally {
        Pop-Location
        $tempFolder | Remove-Item -Force -Recurse
    }

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
