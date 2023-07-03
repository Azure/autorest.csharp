$repoRoot = Resolve-Path "$PSScriptRoot\.."
Push-Location $repoRoot

Write-Host "node -v"
node -v

Write-Host "npm -v"
npm -v

npx --yes @azure-tools/typespec-bump-deps@latest ".\src\TypeSpec.Extension\Emitter.Csharp\package.json"
npx --yes @azure-tools/typespec-bump-deps@latest ".\package.json" --add-npm-overrides


if (test-path '.\node_modules') {
    Remove-Item '.\node_modules' -Force -Recurse
}

if (test-path '.\src\TypeSpec.Extension\Emitter.Csharp\node_modules') {
    Remove-Item '.\src\TypeSpec.Extension\Emitter.Csharp\node_modules' -Force -Recurse
}

Remove-Item '.\package-lock.json' -Force

npm install
node -p -e "require('./node_modules/@typespec/compiler/package.json').version"

git add './package.json' './package-lock.json' './src/TypeSpec.Extension/Emitter.Csharp/package.json'

Pop-Location
