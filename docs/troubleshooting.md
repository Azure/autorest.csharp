# <img align="center" src="./images/logo.png">  Troubleshooting

## Generation Errors

The C# generator doesn't throw any errors itself, so all errors should arise from [main Autorest][main_docs].
If you see a C# error being thrown, it's possible this error was thrown erroneously. Please open an issue
in the [C# repo][autorest_csharp_issues] if you believe that's the case.

Both of these issues should give you enough information to fix the error. If not, please let us know in either the [main repo][autorest_issues], or in the [C# repo][autorest_csharp_repo]. Also let us know if you believe
there are erroneous errors being thrown.

## Debugging

Our [main docs][main_debugging] show you how to pass in flags (`--verbose` / `--debug`) to get more debugging logs for your AutoRest calls.

To debug into the C# generator's code, simply add `--csharp.debugger`, and you should be able to step through our code base.

In addition, you can open the `AutoRest.CSharp.sln` solution and the generator project using existing run profiles for test and sample swaggers. See [launchSettings.json](../../src/AutoRest.CSharp/Properties/launchSettings.json)

<!-- LINKS -->
[main_docs]: https://github.com/Azure/autorest/tree/master/docs/troubleshooting.md
[autorest_csharp_issues]: https://github.com/Azure/autorest.csharp/issues
[main_debugging]: https://github.com/Azure/autorest/tree/master/docs/troubleshooting.md#debugging
[autorest_csharp_repo]: https://github.com/Azure/autorest.csharp