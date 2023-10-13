#Requires -Version 7.0

param(
    [string] $Exceptions
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
$root = (Resolve-Path "$PSScriptRoot/../..").Path.Replace('\', '/')
. "$root/eng/scripts/CommandInvocation-Helpers.ps1"
Set-ConsoleEncoding

Invoke-LoggedCommand "git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code -- $Exceptions"

exit $LastExitCode
