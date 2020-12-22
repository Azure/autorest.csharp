# <img align="center" src="../images/logo.png">  Generating C# Clients in the azure-sdk-for-net Repo

Generating a client with the [`azure-sdk-for-net`][azure_sdk_for_net] repo allows you to better customize your generated code.

1. Run `dotnet build /t:GenerateCode` in the directory that contains your `.csproj` file.

2. This executes [these targets][targets].

3. Refer also to [azure-sdk-for-net/CONTRIBUTING.md][contributing] for more details.

<!-- LINKS -->
[azure_sdk_for_net]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk
[targets]: https://github.com/Azure/autorest.csharp/blob/feature/v3/src/AutoRest.CSharp/build/CodeGeneration.targets
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md#on-boarding-new-generated-code-library