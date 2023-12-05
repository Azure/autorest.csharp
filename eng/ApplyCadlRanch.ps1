param($CadlRanchPath)

if (-not $CadlRanchPath) {
    $CadlRanchPath = "$PSScriptRoot\..\..\cadl-ranch" # if cadl-ranch path is not provided, then expect it to be in the same folder as this repo and folder name is cadl-ranch
}

Push-Location $CadlRanchPath
pnpm build
Pop-Location

$specPathSource = "$CadlRanchPath\packages\cadl-ranch-specs\http"
$mockAPIPathSource = "$CadlRanchPath\packages\cadl-ranch-specs\dist\http"

$specPathDestination = "$PSScriptRoot\..\node_modules\@azure-tools\cadl-ranch-specs\http"
$mockAPIPathDestination = "$PSScriptRoot\..\node_modules\@azure-tools\cadl-ranch-specs\dist\http"

if (Test-Path -Path $specPathDestination) {
    Get-ChildItem $specPathDestination | Remove-Item -Force -Recurse
    Remove-Item $specPathDestination -Force
}

if (Test-Path -Path $mockAPIPathDestination) {
    Get-ChildItem $mockAPIPathDestination | Remove-Item -Force -Recurse
    Remove-Item $mockAPIPathDestination -Force
}

Copy-Item -Path $specPathSource -Destination "$specPathDestination\.." -Recurse
Copy-Item -Path $mockAPIPathSource -Destination "$mockAPIPathDestination\.." -Recurse
