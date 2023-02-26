param($SdkRepoRoot)

$SdkRepoRoot = Resolve-Path $SdkRepoRoot
$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$emitterPath = Resolve-Path (Join-Path $repoRoot 'src' 'CADL.Extension' 'Emitter.Csharp')

# Pack local autorest.csharp
$currentDate = $(Get-Date -UFormat "%Y%m%d")
$packageFolder = Resolve-Path (Join-Path $repoRoot "artifacts" "packages" "Debug")
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

# # Update eng\Packages.Data.Props
# $packagesProps = "$SdkRepoRoot\eng\Packages.Data.props"
# (Get-Content -Raw $packagesProps) -replace`
#     '<PackageReference Update="Microsoft.Azure.AutoRest.CSharp" Version=".*?" />',
#     "<PackageReference Update=`"Microsoft.Azure.AutoRest.CSharp`" Version=`"3.0.0-beta.$currentDate.100`" PrivateAssets=`"All`" />" | `
#     Set-Content $packagesProps -NoNewline

# # Pack emitter
# Push-Location $emitterPath
# Remove-Item azure-tools-cadl-csharp-*.tgz
# npm pack
# $emitterPackagePath = (Get-ChildItem azure-tools-cadl-csharp-*.tgz) -replace "\\", "/"
# Pop-Location

# # Update emitter-package.json
# $cadlEmitterProps = "$SdkRepoRoot\eng\emitter-package.json"
# (Get-Content -Raw $cadlEmitterProps) -replace`
#     '"@azure-tools/cadl-csharp": ".*?"',
#     "`"@azure-tools/cadl-csharp`": `"$emitterPackagePath`"" | `
#     Set-Content $cadlEmitterProps -NoNewline

# # Update Cadl-Project-Generate.ps1
# $generateScriptPath = "$SdkRepoRoot\eng\common\scripts\Cadl-Project-Generate.ps1"
# $generateScript = Get-Content -Raw $generateScriptPath
# $cadlCommand = [regex]::matches($generateScript, '\"npx cadl compile.+\"').groups[0].value
# if (-not $cadlCommand.Contains("csharpGeneratorPath")) {
#     $newCommand = '--emit $emitterName$emitterAdditionalOptions' + " --option @azure-tools/cadl-csharp.csharpGeneratorPath=$repoRoot\artifacts\bin\AutoRest.CSharp\Debug\net6.0\AutoRest.CSharp.dll"
#     (Get-Content -Raw $generateScriptPath) -replace`
#         '--emit \$emitterName\$emitterAdditionalOptions',
#         $newCommand | `
#         Set-Content $generateScriptPath -NoNewline
# }

# Generate
# dotnet msbuild /restore /t:GenerateCode "$SdkRepoRoot\eng\service.proj"
# dotnet msbuild /restore /t:GenerateTests "$SdkRepoRoot\eng\service.proj"