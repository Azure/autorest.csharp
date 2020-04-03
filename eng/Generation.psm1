$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$autorestBinary = Join-Path $repoRoot 'node_modules' '.bin' 'autorest-beta'

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

function Invoke-Autorest($baseOutput, $title, $autoRestArguments)
{
    $outputPath = Join-Path $baseOutput $title
    $namespace = $title.Replace('-', '_')
    $command = "$script:autorestBinary $script:debugFlags $autoRestArguments --title=$title --namespace=$namespace --output-folder=$outputPath"

    if ($fast)
    {
        $codeModel = Join-Path $baseOutput $title "CodeModel.yaml"
        $command = "dotnet run --project $script:autorestPluginProject --no-build -- --plugin=csharpgen --title=$title --namespace=$namespace --standalone --input-file=$codeModel --output-folder=$outputPath --shared-source-folder=$script:sharedSource --save-code-model=true"
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

Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Invoke-Autorest"
Export-ModuleMember -Function "Autorest-Reset"