param($SdkRepoRoot, [switch]$skipGenerateTest)

& (Join-Path $PSScriptRoot 'UpdateLocalReference.ps1') -SdkRepoRoot $SdkRepoRoot

dotnet msbuild /restore /t:GenerateCode "$SdkRepoRoot\eng\service.proj"

if (-not $skipGenerateTest) {
    dotnet msbuild /restore /t:GenerateTests "$SdkRepoRoot\eng\service.proj"
}
