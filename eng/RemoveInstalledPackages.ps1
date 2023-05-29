$rootPath = Resolve-Path (Join-Path $PSScriptRoot '..')

$packageLockPath = Join-Path $rootPath "package-lock.json"
if (Test-Path $packageLockPath) {
    Remove-Item $packageLockPath
}

$rootPackagePath = Join-Path $rootPath "node_modules"
if (Test-Path $rootPackagePath) {
    Remove-Item $rootPackagePath -Recurse
}

$emitterPackagePath = Join-Path $rootPath "src" "CADL.Extension" "Emitter.Csharp" "node_modules"
if (Test-Path $emitterPackagePath) {
    Remove-Item $emitterPackagePath -Recurse
}
