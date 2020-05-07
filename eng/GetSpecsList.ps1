# Navigate to your local specs repo Git clone and run this script from there
$repoPath = [regex]::Escape((Get-Location).Path)
$partialPaths = Get-ChildItem -Path 'specification' -File -Filter 'readme.md' -Recurse |
    Where-Object { $_.Name -clike 'readme.md' } |
    ForEach-Object { $_.FullName -replace "^$repoPath", '' }
$filePath = Join-Path $PSScriptRoot 'SpecsList.txt'
$partialPaths | Out-File -FilePath $filePath