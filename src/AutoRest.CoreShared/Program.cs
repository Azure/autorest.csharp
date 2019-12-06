// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;

namespace AutoRest.CodeModel
{
    internal static class Program
    {
        private const string Path = "assets/Azure.Core.Shared";

        private static void Main()
        {
            using var webClient = new WebClient();

            var cachePath = "../cache/DiagnosticScope.cs";
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/DiagnosticScope.cs", cachePath);
            var rawFile = File.ReadAllText(cachePath);
            var cleanFile = rawFile
                .Replace("AddAttribute(name, value.ToString());", "AddAttribute(name, value.ToString()!);")
                .Replace("object result = s_getIdFormatMethod.Invoke(activity, Array.Empty<object>());", "object? result = s_getIdFormatMethod.Invoke(activity, Array.Empty<object>());")
                .Replace("return (int)result == 2", "return result is int resultInt && resultInt == 2")
                // Temporarily make public to avoid 'error CS0051: Inconsistent accessibility'
                .Replace("internal readonly struct DiagnosticScope", "public readonly struct DiagnosticScope");
            File.WriteAllText($"../../{Path}/DiagnosticScope.cs", cleanFile);
            File.WriteAllText($"../../AutoRest.CSharp.V3/Azure.Core.Shared/DiagnosticScope.cs", cleanFile);
            //File.WriteAllText($"../../../test/AutoRest.TestServer.Tests/Azure.Core.Shared/DiagnosticScope.cs", cleanFile);

            cachePath = "../cache/ArrayBufferWriter.cs";
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/ArrayBufferWriter.cs", cachePath);
            rawFile = File.ReadAllText(cachePath);
            cleanFile = rawFile
                // Temporarily make public to avoid 'error CS0051: Inconsistent accessibility'
                .Replace("internal sealed class ArrayBufferWriter", "public sealed class ArrayBufferWriter");
            File.WriteAllText($"../../{Path}/ArrayBufferWriter.cs", cleanFile);
            File.WriteAllText($"../../AutoRest.CSharp.V3/Azure.Core.Shared/ArrayBufferWriter.cs", cleanFile);
            //File.WriteAllText($"../../../test/AutoRest.TestServer.Tests/Azure.Core.Shared/ArrayBufferWriter.cs", cleanFile);

            cachePath = "../cache/ClientDiagnostics.cs";
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/ClientDiagnostics.cs", cachePath);
            rawFile = File.ReadAllText(cachePath);
            cleanFile = rawFile
                // Temporarily make public to avoid 'error CS0051: Inconsistent accessibility'
                .Replace("internal sealed class ClientDiagnostics", "public sealed class ClientDiagnostics")
                .Replace("options.GetType().Namespace", "options.GetType().Namespace!");
                //.Replace("ClientOptions options", "Azure.Core.ClientOptions options");
            File.WriteAllText($"../../{Path}/ClientDiagnostics.cs", cleanFile);
            File.WriteAllText($"../../AutoRest.CSharp.V3/Azure.Core.Shared/ClientDiagnostics.cs", cleanFile);
            //File.WriteAllText($"../../../test/AutoRest.TestServer.Tests/Azure.Core.Shared/ClientDiagnostics.cs", cleanFile);
        }
    }
}
