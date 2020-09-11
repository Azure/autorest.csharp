param($Version, $SdkRepoRoot)

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

Write-Host "Running $Version, $SdkRepoRoot"

$RepoRoot = Resolve-Path "$PSScriptRoot/.."

$PackagesProps = "$SdkRepoRoot\eng\Packages.Data.props"

(Get-Content -Raw $PackagesProps) -replace '<PackageReference Update="AutoRest.CSharp.V3" Version=".*?" />', "<PackageReference Update=`"AutoRest.CSharp.V3`" Version=`"$Version`" />" | `
    Set-Content $PackagesProps -NoNewline

# dotnet msbuild /t:GenerateCode "$SdkRepoRoot\eng\service.proj"