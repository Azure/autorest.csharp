param($SdkRepoRoot)

$SdkRepoRoot = Resolve-Path $SdkRepoRoot
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'CADL.Extension' 'Emitter.Csharp')

# Pack local autorest.csharp
$currentDate = $(Get-Date -UFormat "%Y%m%d")
$packageFolder = Join-Path $repoRoot "artifacts" "packages" "Debug"
if (!(Test-Path $packageFolder)) {
    New-Item $packageFolder -ItemType Directory
}
$latestName = Get-ChildItem -Path $packageFolder -Name "Microsoft.Azure.AutoRest.CSharp.3.0.0-beta.$currentDate.*.nupkg" | Sort-Object -Descending -Top 1
$nextVersion = 100
if ($latestName) {
    $matchString = "Microsoft.Azure.AutoRest.CSharp.3.0.0-beta.$currentDate.(\d\d\d).nupkg"
    If ($latestName -match $matchString) {
        $nextVersion = [int]$Matches[1] + 1
    }
}

Push-Location $repoRoot
dotnet pack /p:OfficialBuildId=$currentDate.$nextVersion
Pop-Location

# Pack emitter
Push-Location $emitterPath
Remove-Item azure-tools-cadl-csharp-*.tgz
npm run build
npm pack
$emitterPackagePath = (Get-ChildItem azure-tools-cadl-csharp-*.tgz) -replace "\\", "/"
Pop-Location

# Update Nuget.Config
$nugetConfigPath = "$SdkRepoRoot\NuGet.Config"
$nuGetConfig = [xml](Get-Content -Path $nugetConfigPath)
$xmlAdd = $nuGetConfig.configuration.packageSources.LastChild.clone()
if ($xmlAdd.key -ne "DEBUG") {
    $xmlAdd.key = "DEBUG"
    $xmlAdd.value = "$repoRoot\artifacts\packages\Debug"
    $nuGetConfig.configuration.packageSources.AppendChild($xmlAdd)
    $nuGetConfig.Save($nugetConfigPath)
}

# There is a step depend on https://github.com/Azure/autorest.csharp/pull/3166

# Update eng\Packages.Data.Props and emitter-package.json
& (Join-Path $PSScriptRoot 'UpdateOfficialReference.ps1') -AutorestCSharpVersion "3.0.0-beta.$currentDate.$nextVersion" -CadlEmitterVersion $emitterPackagePath -SdkRepoRoot $SdkRepoRoot
