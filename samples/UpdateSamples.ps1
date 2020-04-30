$filePath = Join-Path $PSScriptRoot 'SmokeTestInputs.txt'
$fileContent = Get-Content $filePath
$firstLineSplit = ($fileContent | Select-Object -First 1) -Split '/'
$oldHashIndex = $firstLineSplit.IndexOf('blob') + 1
$oldHash = $firstLineSplit[$oldHashIndex]
$latestHash = (git ls-remote https://github.com/Azure/azure-rest-api-specs.git | Select-Object -First 1) -Split '\s+' | Select-Object -First 1
$smokeTestLines = foreach($line in $fileContent)
{
    $line -Replace $oldHash, $latestHash
}
$smokeTestLines | Out-File -FilePath $filePath