#requires -version 5

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

$repoRoot = Resolve-Path "$PSScriptRoot/.."

[string[]] $errors = @()

function LogError([string]$message) {
    if ($env:TF_BUILD) {
        Write-Host "##vso[task.logissue type=error]$message"
    }
    Write-Host -f Red "error: $message"
    $script:errors += $message
}

function Invoke-Block([scriptblock]$cmd) {
    $cmd | Out-String | Write-Verbose
    try
    {
        & $cmd

        # Need to check both of these cases for errors as they represent different items
        # - $?: did the powershell script block throw an error
        # - $lastexitcode: did a windows command executed by the script block end in error
        if ((-not $?) -or ($lastexitcode -ne 0)) {
            if ($error -ne $null)
            {
                Write-Warning $error[0]
            }
            throw "Command failed to execute: $cmd"
        }
    }
    catch
    {
        LogError $_
    }
}

try {
    Write-Host "Downloading files"
    Invoke-Block {
        & $PSScriptRoot\DownloadSharedSource.ps1 @script:PSBoundParameters
    }

    Write-Host "Generate test clients"
    Invoke-Block {
        & $PSScriptRoot\Generate.ps1 @script:PSBoundParameters
    }

    Write-Host "git diff"
    & git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
    if ($LastExitCode -ne 0) {
        $status = git status -s | Out-String
        $status = $status -replace "`n","`n    "
        LogError "Generated code is not up to date. You may need to run eng\Update-Snippets.ps1 or sdk\storage\generate.ps1 or eng\Export-API.ps1"
    }
}
finally {
    Write-Host ""
    Write-Host "Summary:"
    Write-Host ""
    Write-Host "   $($errors.Length) error(s)"
    Write-Host ""

    foreach ($err in $errors) {
        Write-Host -f Red "error : $err"
    }

    if ($errors.Length -ne 0) {
        exit 1
    }
    exit 0
}
