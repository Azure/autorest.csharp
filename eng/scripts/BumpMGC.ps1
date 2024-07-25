#Requires -Version 7.0

<#
.SYNOPSIS
    This script will help to fetch the latest build artifacts from a PR build and update the 'package.json' file with the latest MGC package.
.PARAMETER PRNumber
    The PR number for which the latest build artifacts need to be fetched.
.EXAMPLE
    .\BumpMGC.ps1 -PRNumber 1234
    This command will fetch the latest build artifacts for PR 1234 and update the 'package.json' file with the latest MGC package.
.EXAMPLE
    .\BumpMGC.ps1 1234
    Using positional parameter to specify the PR number.
.EXAMPLE
    .\BumpMGC.ps1 -PRNumber 1234 -Verbose
    This command will fetch the latest build artifacts for PR 1234 and update the 'package.json' file with the latest MGC package, meanwhile dumping the verbose output.
.EXAMPLE
    .\BumpMGC.ps1 1234 -Verbose
    Using positional parameter to specify the PR number and dumping the verbose output.
#>
[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [string] $PRNumber
)

$ErrorActionPreference = 'Stop'
# save the current preferences to restore later
$CurrentVerbosePreference = $VerbosePreference
if ($Verbose) {
    $VerbosePreference = 'Continue'
}

<#
.SYNOPSIS
    This function will generate the download URL for the MGC Node package from the download URL of the MGC build artifact.
.PARAMETER ArtifactDownloadUrl
    The download URL of the MGC build artifact.
#>
function Get-Node-Package-DownloadUrl([string] $ArtifactDownloadUrl) {
    $url = [System.Uri]::new($ArtifactDownloadUrl)
    # $baseUrl = $url.GetComponents([System.UriComponents]::SchemeAndServer -bor [System.UriComponents]::Path, [System.UriFormat]::UriEscaped)
    $baseUrl = $url.GetLeftPart([System.UriPartial]::Path)
    Write-Verbose "BaseUrl: $baseUrl"
    $query = [System.Web.HttpUtility]::ParseQueryString($url.Query)
    $query.Set("format", "file") 
    $query.Set("subPath", "/packages/typespec-http-client-csharp-0.1.9-alpha.$($BuildJson.buildNumber).tgz")

    $newUrl = $baseUrl + "?" + $query.ToString()
    Write-Verbose "Node Package Download URL: $newUrl"

    return $newUrl
}

<#
.SYNOPSIS
    This function will format the JSON string with the specified indentation.
.DESCRIPTION
    Powershell official ConvertTo-Json cmdlet does not provide an option to specify the indentation level. It's always 2 spaces. This function will format the JSON string with the specified indentation.
.PARAMETER json
    The JSON string to be formatted.
.PARAMETER indentation
    The indentation level to be used for formatting. Default is 4.
#>
function Format-Json([Parameter(Mandatory, ValueFromPipeline)][string] $json, [int]$indentation = 4) {
  $indent = 0;
  ($json -Split '\n' |
    % {
      if ($_ -match '[\}\]]') {
        # This line contains  ] or }, decrement the indentation level
        $indent--
      }
      $line = (' ' * $indent * $indentation) + $_.TrimStart().Replace(':  ', ': ')
      if ($_ -match '[\{\[]') {
        # This line contains [ or {, increment the indentation level
        $indent++
      }
      $line
  }) -Join "`n"
}

$RootPath = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
$PackageJsonFilePath = "$RootPath/src/TypeSpec.Extension/Emitter.Csharp/package.json"

Write-Host "Querying DevOps for the latest build for PR '$PRNumber'..."
$BuildJson = (az pipelines build list --organization "https://dev.azure.com/azure-sdk" --project "public" --branch "refs/pull/$PRNumber/merge" --top 1 --query "[0]"  --output json | ConvertFrom-Json)
Write-Host 'Done'
Write-Verbose "Build Json: $($BuildJson | ConvertTo-Json)"

Write-Host "Querying DevOps for the latest build artifacts for Build ID '$($BuildJson.id)'..."
$MGCArtifactDownloadUrl = (az pipelines runs artifact list --org "https://dev.azure.com/azure-sdk" --project "public" --run-id $BuildJson.id --query "[?name=='build_artifacts_csharp'].resource.downloadUrl | [0]" --output tsv)
Write-Host 'Done'
Write-Verbose "MGC Artifact Download URL: $MGCArtifactDownloadUrl"

Write-Host "Updating 'package.json' with the latest MGC package..."
$MGCNodePackageDownloadUrl = Get-Node-Package-DownloadUrl $MGCArtifactDownloadUrl
Write-Verbose "MGC Node Package Download URL: $MGCNodePackageDownloadUrl"

$PackageJson = Get-Content $PackageJsonFilePath | Out-String | ConvertFrom-Json
$PackageJson.dependencies."@typespec/http-client-csharp" = $MGCNodePackageDownloadUrl
$PackageJson | ConvertTo-Json | Format-Json | Set-Content $PackageJsonFilePath
Write-Host "Done. 'package.json' is updated successfully."

$VerbosePreference = $CurrentVerbosePreference
