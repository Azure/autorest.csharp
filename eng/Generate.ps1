$ErrorActionPreference = "Stop"


function Invoke-Block([scriptblock]$cmd) {
    $cmd | Out-String | Write-Verbose
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

$repoRoot = "$PSScriptRoot\..\"
$paths = "$repoRoot\samples\Xkcd\readme.md", "$repoRoot\samples\Dns\readme.md"

foreach ($path in $paths)
{
    Invoke-Block { autorest  --debug --verbose --input-file:$path }
}