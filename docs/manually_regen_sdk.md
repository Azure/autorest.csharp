### Validate generator changes against Azure SDK before merging your autorest.csharp PR

When the automatic PR is created for azure-sdk-for-net if there are any issues found all other changes to autorest.csharp are blocked until those issues are resolved.  This means we should be certain that the changes we are making create the expected result in azure-sdk-for-net prior to merging our PR. 

- Run `dotnet pack /p:OfficialBuildId=yyyyMMdd.100` at the root directory of this repository to package up a version of the generator
  - Since there can be real versions with the same date starting at `.100` can ensure no conflicts with official builds.
  - This will place a nupkg file at this location `[RepoRoot]\artifacts\packages\Debug`
- Edit the nuget configuration file [here](https://github.com/Azure/azure-sdk-for-net/blob/main/NuGet.Config) to have a new source `<add key="DEBUG" value="[RepoRoot]\artifacts\packages\Debug" />`
  - This is not intended to be checked in but is a temporary change so `dotnet restore` can find the package
- Update the [Packages.Data.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/Packages.Data.props#L156) file to have Microsoft.Azure.AutoRest.Csharp use the new local version you created in step 1
  - This is not intended to be checked in but is a temporary change so `dotnet restore` can find the package
- If your generator PR needs to apply to typespec projects, or your generator PR changes anything in our emitter (the `src\TypeSpec.Extension\Emitter.Csharp` project), you will need to
  1. Update the `version` in `src\TypeSpec.Extension\Emitter.Csharp\package.json`
  2. Run `npm pack` command in `src\TypeSpec.Extension\Emitter.Csharp` directory. This will produce a pack like `src\TypeSpec.Extension\Emitter.Csharp\azure-tools-typespec-csharp-x.y.z.tgz` where `x.y.z` is the version number you set in step 1.
  3. Change the emitter version used in our `azure-sdk-for-net` repo in this file `eng\emitter-package.json` like this:
  ```diff
  {
    "main": "dist/src/index.js",
    "dependencies": {
  -   "@azure-tools/typespec-csharp": "0.1.11-beta.20230212.4"
  +   "@azure-tools/typespec-csharp": "/absolute/path/to/src/TypeSpec.Extension/Emitter.Csharp/azure-tools-typespec-csharp-x.y.z.tgz"
    }
  }
  ```
  4. Locate the `dll` file generated for the generator, usually it could be found `autorest.csharp` repository in this directory: `artifacts\bin\AutoRest.CSharp\Debug\net6.0\AutoRest.CSharp.dll`
- At this point there are several ways to generate but the idea is to generate and test all projects that will be affected by your PR.  There are tools such as [this](https://github.com/ArcturusZhang/Regen) which are written to handle specific cases.  If you are unsure you should run against all projects to be safe.

To regen and test everything in azure-sdk-for-net after you have updated to use your new local build do the following:

- First generate all projects in the repo by executing `dotnet build [RepoRoot]/eng/service.proj /t:GenerateCode`. If your generator PR needs to apply to typespec projects, or your generator PR changes anything in our emitter (the `src\TypeSpec.Extension\Emitter.Csharp` project), you will need to run `dotnet build [RepoRoot]/eng/service.proj /t:GenerateCode  /p:typespecAdditionalOptions="csharpGeneratorPath=/absolute/path/to/artifacts/bin/AutoRest.CSharp/Debug/net6.0/AutoRest.CSharp.dll`.
- Next we want to at minimum run the tests against the new generated code by using `dotnet test [RepoRoot]/eng/service.proj --filter "(TestCategory!=Manually) & (TestCategory!=Live)"`
- For non GA libraries there could be API changes so we want to run the Export-API script with no parameters which will update any projects that now have an API change `[RepoRoot]\eng\scripts\Export-API.ps1`
- Finally it is very possible that we will need to make test case changes or snippet changes especially for non GA libraries which have expected changes.  All of these should be made in the branch and included in the PR to demonstrate all resulting changes from the autorest.csharp PR.

Once all of that is successful, we can commit all of the local changes except the NuGet file and `Packages.Data.props` and push those to a branch.  
