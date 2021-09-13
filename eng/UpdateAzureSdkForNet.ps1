param($Version, $SdkRepoRoot)

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

Write-Host "Running $Version, $SdkRepoRoot"

$RepoRoot = Resolve-Path "$PSScriptRoot/.."

$PackagesProps = "$SdkRepoRoot\eng\Packages.Data.props"

(Get-Content -Raw $PackagesProps) -replace`
    '<PackageReference Update="Microsoft.Azure.AutoRest.CSharp" Version=".*?" />',
    "<PackageReference Update=`"Microsoft.Azure.AutoRest.CSharp`" Version=`"$Version`" PrivateAssets=`"All`" />" | `
    Set-Content $PackagesProps -NoNewline

$Env:NODE_OPTIONS = "--max-old-space-size=4096"
dotnet msbuild /restore /t:GenerateCode "$SdkRepoRoot\eng\service.proj"
