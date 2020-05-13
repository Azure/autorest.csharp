param($Version, $SdkRepoRoot)

Write-Host "Running $Version, $SdkRepoRoot"

function UpdateValue([Parameter(ValueFromPipeline=$true)]$content, $name, $value)
{
    Write-Host "Updating $name to $value"
    return $content -replace "<$name>.*?</$name>", "<$name>$value</$name>";
}

$RepoRoot = Resolve-Path "$PSScriptRoot/.."

if (!$Version)
{
    $Version = "$RepoRoot\artifacts\bin\AutoRest.CSharp.V3\Debug\netcoreapp3.0"
}

if ((Get-Content -Raw "$RepoRoot\readme.md") -match "version: ([\.\d]+)")
{
    $CoreVersion = $Matches[1];
}

if ((Get-Content -Raw "$RepoRoot\package.json") -match "`"@autorest/autorest`": `"(.*?)`"")
{
    $AutoRestVersion = $Matches[1];
}

$CodeGenerationTargetsPath = "$SdkRepoRoot\eng\CodeGeneration.targets"

Get-Content -Raw $CodeGenerationTargetsPath | `
    UpdateValue -Name "_AutoRestCSharpVersion" -Value $Version | `
    UpdateValue -Name "_AutoRestCoreVersion" -Value $CoreVersion | `
    UpdateValue -Name "_AutoRestVersion" -Value $AutoRestVersion | `
    Set-Content $CodeGenerationTargetsPath

$CodeGenerationTargets | Write-Host;

Remove-Item -v -Recurse -Force "$SdkRepoRoot\sdk\core\Azure.Core\src\Shared\AutoRest\"
Copy-Item -v  -Recurse -Force "$RepoRoot\src\assets\Generator.Shared\" "$SdkRepoRoot\sdk\core\Azure.Core\src\Shared\AutoRest\"

dotnet msbuild /t:GenerateCode "$SdkRepoRoot\eng\service.proj"