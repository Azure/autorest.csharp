# <img align="center" src="./images/logo.png">  FAQ

1. What version of AutoRest C# should I use?

    We highly recommend you use the latest AutoRest C# version published to [npm][autorest_npm]. The latest version
    is the default if you use flag `--csharp`, though you may need to run an `autorest --reset` if it seems
    the latest version is not being grabbed.

    If you *really* want to use an older version of AutoRest C#,
    you can specify the version with the flag `--use`, i.e. `--use=@autorest/csharp@5.x.x`.


<!-- LINKS -->
[min_dependencies]: ./client/initializing.md#minimum-dependencies-of-your-client
[autorest_npm]: https://www.npmjs.com/package/@autorest/csharp