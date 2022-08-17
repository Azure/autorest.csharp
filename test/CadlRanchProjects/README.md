# How to add a cadl ranch test

1. Checkout this PR by `gh pr checkout 2563`
2. Run `npm install` at the root folder
3. Get your cadl ranch test name under `node_modules\@azure-tools\cadl-ranch-specs\http\*\<test name>`, e.g., `primitive-properties`
4. Add this test name to `$cadlRanchProjectNames` in `eng/Generate.ps1`  https://github.com/Azure/autorest.csharp/blob/f185a6678597096d4a984a3c3664261688f0f50d/eng/Generate.ps1#L241
4. Run `.\eng\Generate.ps1 <test name>`
5. Then you get error as 
```
Could not find file 'D:\GIT\autorest.csharp\test\CadlRanchProjects\primitive-properties\Generated\Configuration.json'
```
6. Manually create `Configuration.json` under folder `test\CadlRanchProjects\<test name>\Generated` and `<test name>.csproj` file under folder `test\CadlRanchProjects\<test name>` as we did before.
7. Run `.\eng\Generate.ps1 <test name>` again, and you will see the SDK under `test\CadlRanchProjects\<test name>\Generated`.