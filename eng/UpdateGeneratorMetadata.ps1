param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot)

$ErrorActionPreference = 'Stop'

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

Write-Host "Updating Autorest.CSharp($AutorestCSharpVersion) int Packages.Data.props under $SdkRepoRoot"

$PackagesProps = "$SdkRepoRoot\eng\Packages.Data.props"
(Get-Content -Raw $PackagesProps) -replace `
    '<PackageReference Update="Microsoft.Azure.AutoRest.CSharp" Version=".*?" />',
"<PackageReference Update=`"Microsoft.Azure.AutoRest.CSharp`" Version=`"$AutorestCSharpVersion`" PrivateAssets=`"All`" />" | `
    Set-Content $PackagesProps -NoNewline
