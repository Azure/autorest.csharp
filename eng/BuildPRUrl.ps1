param($SourceBranch)

$matchString = "refs/pull/(\d+)/\w+"
$PRUrl = ""
if ($SourceBranch -match $matchString) {
    $PRUrl = "https://github.com/Azure/autorest.csharp/pull/$($Matches[1])"
}
else {
    $PRUrl = $SourceBranch
}

Write-Host "##vso[task.setvariable variable=PRUrl;isoutput=true]$PRUrl"