$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$autoRestBinary = "npx --no-install autorest"
$AutoRestPluginProject = Resolve-Path (Join-Path $repoRoot 'src' 'AutoRest.CSharp')

function Invoke($command)
{
    Write-Host "> $command"
    pushd $repoRoot
    if ($IsLinux -or $IsMacOs)
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

function Invoke-AutoRest($baseOutput, $projectName, $autoRestArguments, $sharedSource, $fast, $debug)
{
    $outputPath = Join-Path $baseOutput "Generated"
    if ($projectName -eq "TypeSchemaMapping")
    {
        $outputPath = Join-Path $baseOutput "SomeFolder" "Generated"
    }

    if ($fast -or ($projectName -eq "CadlFirstTest") -or ($projectName -eq "CadlPetStore"))
    {
        $dotnetArguments = $debug ? "--no-build --debug" : "--no-build" 
        $command = "dotnet run --project $script:AutoRestPluginProject $dotnetArguments --standalone $outputPath"
    }
    else
    {
        $namespace = $projectName.Replace('-', '_')
        $command = "$script:autoRestBinary $autoRestArguments  --skip-upgrade-check  --namespace=$namespace --output-folder=$outputPath"
    }

    Invoke $command
    Invoke "dotnet build $baseOutput --verbosity quiet /nologo"
}

function AutoRest-Reset()
{
    Invoke "$script:autoRestBinary --reset"
}

function Get-AutoRestProject()
{
    $AutoRestPluginProject;
}

Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Invoke-AutoRest"
Export-ModuleMember -Function "AutoRest-Reset"
Export-ModuleMember -Function "Get-AutoRestProject"