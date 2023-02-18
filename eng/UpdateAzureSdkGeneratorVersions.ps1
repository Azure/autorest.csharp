param([string]$AutorestCSharpVersion, [string]$CadlEmitterVersion, [string]$SdkRepoRoot)

Import-Module "$PSScriptRoot\UpdateGeneratorMetadata.psm1" -DisableNameChecking -Force;

$SdkRepoRoot = Resolve-Path $SdkRepoRoot

UpdateGeneratorMetaData $AutorestCSharpVersion $CadlEmitterVersion $SdkRepoRoot
