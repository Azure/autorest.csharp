$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$autorestBinary = Join-Path $repoRoot 'node_modules' '.bin' 'autorest-beta'
$AutorestPluginProject = Resolve-Path (Join-Path $repoRoot 'src' 'AutoRest.CSharp.V3')

function Invoke($command)
{
    Write-Host "> $command"
    pushd $repoRoot
    if ($IsLinux)
    {
        sh -c "$command 2>&1"
    }
    else
    {
        cmd /c "$command 2>&1"
    }
    popd
    
    if($LastExitCode -ne 0)
    {
        Write-Error "Command failed to execute: $command"
    }
}

function Invoke-Autorest($baseOutput, $projectName, $autoRestArguments, $sharedSource, $fast, $clean)
{
    $outputPath = Join-Path $baseOutput $projectName
    $namespace = $projectName.Replace('-', '_')
    $command = "$script:autorestBinary $autoRestArguments --namespace=$namespace --output-folder=$outputPath"

    if ($fast)
    {
        $command = "dotnet run --project $script:AutorestPluginProject --no-build -- --standalone $outputPath"
    }

    if ($clean)
    {
        if (Test-Path $outputPath)
        {
            Get-ChildItem $outputPath -Filter Generated -Directory -Recurse | Get-ChildItem -File -Recurse | Remove-Item -Force
            New-Item -ItemType Directory -Force -Path $outputPath | Out-Null;
        }
    }

    Invoke $command
    Invoke "dotnet build $outputPath --verbosity quiet /nologo"
}

function Autorest-Reset()
{
    Invoke "$script:autorestBinary --reset"
}

function Get-AutorestProject()
{
    $AutorestPluginProject;
}

Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Invoke-Autorest"
Export-ModuleMember -Function "Autorest-Reset"
Export-ModuleMember -Function "Get-AutorestProject"