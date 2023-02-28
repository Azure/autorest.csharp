param($AutorestCSharpVersion, $CadlEmitterVersion, $SdkRepoRoot)

& (Join-Path $PSScriptRoot 'UpdateOfficialReference.ps1') -AutorestCSharpVersion $AutorestCSharpVersion -CadlEmitterVersion $CadlEmitterVersion -SdkRepoRoot $SdkRepoRoot

dotnet msbuild /restore /t:GenerateCode "$SdkRepoRoot\eng\service.proj"
dotnet msbuild /restore /t:GenerateTests "$SdkRepoRoot\eng\service.proj"
