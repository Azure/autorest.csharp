param(
    [Parameter(Mandatory)]
    [string]$ContainingFolder
)

$ContainingFolder = Resolve-Path $ContainingFolder

"registry=https://pkgs.dev.azure.com/azure-sdk/_packaging/azure-sdk-for-net-private/npm/registry/`n`nalways-auth=true" | Out-File -FilePath (Join-Path $ContainingFolder '.npmrc')