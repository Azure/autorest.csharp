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

function Invoke-Cadl($baseOutput, $projectName, $mainFile, $sharedSource="", $fast="", $debug="")
{
    if (!(Test-Path $baseOutput)) {
        New-Item $baseOutput -ItemType Directory
    }

    $baseOutput = Resolve-Path -Path $baseOutput
    $baseOutput = $baseOutput -replace "\\", "/"
    $outputPath = Join-Path $baseOutput "Generated"
    $outputPath = $outputPath -replace "\\", "/"
    #clean up
    if (Test-Path $outputPath) {
        Remove-Item $outputPath/* -Include *.* -Exclude *Configuration.json*
    }
    # emit cadl json
    $repoRootPath = Join-Path $PSScriptRoot ".."
    $repoRootPath = Resolve-Path -Path $repoRootPath
    Push-Location $repoRootPath
    # node node_modules\@cadl-lang\compiler\dist\core\cli.js compile --output-path $outputPath "$baseOutput\$projectName.cadl" --emit @azure-tools/cadl-csharp
    $emitCommand = "node node_modules/@cadl-lang/compiler/dist/core/cli.js compile --output-path $outputPath $mainFile --emit @azure-tools/cadl-csharp"
    Invoke $emitCommand
    Pop-Location

    $dotnetArguments = $debug ? "--no-build --debug" : "--no-build" 
    $command = "dotnet run --project $script:AutoRestPluginProject $dotnetArguments --standalone $outputPath"
    Invoke $command
    Invoke "dotnet build $baseOutput --verbosity quiet /nologo"
}

function Invoke-CadlSetup()
{
    # build emitter
    $emitterPath = Join-Path $PSScriptRoot ".." "src" "CADL.Extension" "Emitter.Csharp"
    $emitterPath = Resolve-Path -Path $emitterPath
    Push-Location $emitterPath
    npm ci
    npm run build
    npm pack
    Pop-Location

    # install cadl and emitter
    $repoRoot = Join-Path $PSScriptRoot ".."
    $repoRoot = Resolve-Path $repoRoot
    Push-Location $repoRoot
    npm ci
    $packages = Get-ChildItem $repoRoot -Filter azure-tools-cadl-csharp-*.tgz -Recurse | Select-Object -ExpandProperty FullName | Resolve-Path -Relative
    if ($packages) {
        $package = $packages;
        if ($packages.count -gt 1) {
            $package = $packages[0]
        }
        npm install $package
    }
    git checkout $repoRoot/package.json
    git checkout $repoRoot/package-lock.json
    Pop-Location
}
function Get-AutoRestProject()
{
    $AutoRestPluginProject;
}

Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Invoke-AutoRest"
Export-ModuleMember -Function "AutoRest-Reset"
Export-ModuleMember -Function "Get-AutoRestProject"
Export-ModuleMember -Function "Invoke-Cadl"
Export-ModuleMember -Function "Invoke-CadlSetup"