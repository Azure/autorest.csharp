param(
    [Parameter(Mandatory)]
    [string]$AutorestCSharpVersion,

    [Parameter(Mandatory)]
    [string]$CadlEmitterVersion,

    [Parameter(Mandatory)]
    [string]$SdkRepoRoot,

    [bool]$UseInternalFeed = $false)

$ErrorActionPreference = 'Stop'

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

Write-Host "Updating Autorest.CSharp($AutorestCSharpVersion) and Cadl Emitter($CadlEmitterVersion) under $SdkRepoRoot"

$PackagesProps = "$SdkRepoRoot\eng\Packages.Data.props"
(Get-Content -Raw $PackagesProps) -replace `
    '<PackageReference Update="Microsoft.Azure.AutoRest.CSharp" Version=".*?" />',
"<PackageReference Update=`"Microsoft.Azure.AutoRest.CSharp`" Version=`"$AutorestCSharpVersion`" PrivateAssets=`"All`" />" | `
    Set-Content $PackagesProps -NoNewline

$CadlEmitterProps = "$SdkRepoRoot\eng\emitter-package.json"
(Get-Content -Raw $CadlEmitterProps) -replace `
    '"@azure-tools/typespec-csharp": ".*?"',
"`"@azure-tools/typespec-csharp`": `"$CadlEmitterVersion`"" | `
    Set-Content $CadlEmitterProps -NoNewline
