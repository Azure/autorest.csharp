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
                .Replace("return (int)result == 2", "return result is int resultInt && resultInt == 2");
            File.WriteAllText($"../../{Path}/DiagnosticScope.cs", cleanFile);

            cachePath = "../cache/ArrayBufferWriter.cs";
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/core/Azure.Core/src/Shared/ArrayBufferWriter.cs", cachePath);
            File.WriteAllText($"../../{Path}/ArrayBufferWriter.cs", File.ReadAllText(cachePath));
        }
    }
}
