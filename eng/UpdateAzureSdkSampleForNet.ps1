param([string]$AutorestCSharpVersion, [string]$CadlEmitterVersion, [string]$SdkRepoRoot, [string[]]$ServiceDirectoryFilters = @("*"))

Import-Module "$PSScriptRoot\UpdateGeneratorMetadata.psm1" -DisableNameChecking -Force;

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

UpdateGeneratorMetaData $AutorestCSharpVersion $CadlEmitterVersion $SdkRepoRoot

Write-Host "Generating Azure SDK Samples..."
foreach ($filter in $ServiceDirectoryFilters) {
    Write-Host 'Generating projects under service directory ' -ForegroundColor Green -NoNewline
    Write-Host "$filter" -ForegroundColor Yellow
    dotnet msbuild /restore /t:GenerateTests /p:ServiceDirectory=$filter "$SdkRepoRoot\eng\service.proj"
    if ($LastExitCode -ne 0) {
        Write-Error 'Generation error'
        exit 1
    }
}
