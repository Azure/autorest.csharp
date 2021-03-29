# <img align="center" src="./images/logo.png">  FAQ

1. What version of AutoRest C# should I use?
    If your project is a part of `azure-sdk-for-net` repo please follow the steps in [Using C# generation in azure-sdk-net repo][generate_with_sdk_repo] and avoid using autorest command line directly.

    Otherwise, we highly recommend you use the latest AutoRest C# version published to [npm][autorest_npm]. The latest version
    is the default if you use flag `--csharp`, though you may need to run an `autorest --reset` if it seems
    the latest version is not being grabbed.

    If you *really* want to use an older version of AutoRest C#,
    you can specify the version with the flag `--use`, i.e. `--use=@microsoft.azure/autorest.csharp@2.3.82`.

<!-- LINKS -->
[generate_with_sdk_repo]: https://github.com/Azure/autorest.csharp#use-in-azure-sdk-net-repo
[min_dependencies]: ./client/initializing.md#minimum-dependencies-of-your-client
[autorest_npm]: https://www.npmjs.com/package/@autorest/csharp