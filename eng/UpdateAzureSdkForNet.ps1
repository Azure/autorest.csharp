param($NewVersion)

function UpdateValue([Parameter(ValueFromPipeline=$true)]$content, $name, $value)
{
    Write-Host "Updating $name to $value"
    return $content -replace "<$name>.*?</$name>", "<$name>$value</$name>";
}

$RepoRoot = Resolve-Path "$PSScriptRoot/.."

if (!$NewVersion)
{
    $NewVersion = "$RepoRoot\artifacts\bin\AutoRest.CSharp.V3\Debug\netcoreapp3.0"
}


$SdkRepoRoot = Resolve-Path azure-sdk-for-net

if ((Get-Content -Raw "$RepoRoot\readme.md") -match "version: ([\.\d]+)")
{
    $CoreVersion = $Matches[1];
}

if ((Get-Content -Raw "$RepoRoot\package.json") -match "`"@autorest/autorest`": `"(.*?)`"")
{
    $AutoRestVersion = $Matches[1];
}

#git clone --depth 1 --branch master https://github.com/azure/azure-sdk-for-net

$CodeGenerationTargetsPath = "$SdkRepoRoot\eng\CodeGeneration.targets"

Get-Content -Raw $CodeGenerationTargetsPath | `
    UpdateValue -Name "_AutoRestCSharpVersion" -Value $NewVersion | `
    UpdateValue -Name "_AutoRestCoreVersion" -Value $CoreVersion | `
    UpdateValue -Name "_AutoRestVersion" -Value $AutoRestVersion | `
    Set-Content $CodeGenerationTargetsPath

$CodeGenerationTargets | Write-Host;

Remove-Item -v -Recurse -Force "$SdkRepoRoot\sdk\core\Azure.Core\src\Shared\AutoRest\"
Copy-Item -v  -Recurse -Force "$RepoRoot\src\assets\Generator.Shared\" "$SdkRepoRoot\sdk\core\Azure.Core\src\Shared\AutoRest\"

dotnet msbuild /t:GenerateCode "$SdkRepoRoot\eng\service.proj"