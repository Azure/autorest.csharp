#Requires -Version 7.0

param(
    [string] $Exceptions
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../../..").Path.Replace('\', '/')
. "$root/eng/scripts/preview/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

$diffExcludes = @(
    'package.json'
    'package-lock.json'
    'src/TypeSpec.Extension/Emitter.Csharp/package.json'
) | ForEach-Object { "`":(exclude)$_`"" } | Join-String -Separator ' '

Invoke-LoggedCommand "git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code -- $diffExcludes" -IgnoreExitCode

if($LastExitCode -ne 0) {
    throw "Changes detected"
}
