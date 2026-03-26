param(
    [Parameter(Mandatory)]
    [string]$ContainingFolder
)

$ContainingFolder = Resolve-Path $ContainingFolder

"registry=https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js/npm/registry/ `n`nalways-auth=true" | Out-File -FilePath (Join-Path $ContainingFolder '.npmrc')
