// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace AutoRest.CodeModel
{
    internal static class Program
    {
        private const string Path = "AutoRest.CSharp.V3/Input/Generated";
        private static readonly string Namespace = "AutoRest.CSharp.V3.Input";

        private static void Main()
        {
            using var webClient = new WebClient();
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/perks/master/codemodel/.resources/all-in-one/json/code-model.json", "code-model.json");

            var schemaJson = File.ReadAllText("code-model.json")
                // Makes Choices only have string values
                .Replace("          \"type\": [\n            \"string\",\n            \"number\",\n            \"boolean\"\n          ]\n", $"          \"type\": \"string\"\n");

            var schema = JsonSchema.FromJsonAsync(schemaJson).GetAwaiter().GetResult();
            var settings = new CSharpGeneratorSettings
            {
                Namespace = Namespace,
                HandleReferences = true,
                TypeAccessModifier = "internal",
                TypeNameGenerator = new CustomTypeNameGenerator(),
                PropertyNameGenerator = new CustomPropertyNameGenerator(),
                EnumNameGenerator = new CustomEnumNameGenerator()
            };
            var rawFile = new CSharpGenerator(schema, settings).GenerateFile();
            var cleanFile = String.Join(Environment.NewLine, rawFile.ToLines()
                    // Converts Newtonsoft attributes to YamlDotNet attributes
                    .Where(l => !l.Contains("Newtonsoft.Json.JsonConverter")
                                && !l.Contains("Newtonsoft.Json.JsonExtensionData"))
                    .Select(l => Regex.Replace(l, @"(.*\[)Newtonsoft\.Json\.JsonProperty\((.*""),?.*(\)\])",
                        "$1YamlDotNet.Serialization.YamlMember(Alias = $2$3", RegexOptions.Singleline).TrimEnd()))
                // Removes AdditionalProperties property from types as they are required to derive from IDictionary<string, object> for deserialization to work properly
                .Replace($"        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();{Environment.NewLine}{Environment.NewLine}        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties{Environment.NewLine}        {{{Environment.NewLine}            get {{ return _additionalProperties; }}{Environment.NewLine}            set {{ _additionalProperties = value; }}{Environment.NewLine}        }}{Environment.NewLine}", String.Empty)
                // Fixes stray blank lines from the C# generator
                .Replace($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}", Environment.NewLine)
                .Replace($"{Environment.NewLine}{Environment.NewLine}    }}", $"{Environment.NewLine}    }}")
                // Weird generation issue workaround
                .Replace($"{Namespace}.bool.True", "true");

            var lines = cleanFile.ToLines().ToArray();
            var fileWithNullable = String.Join(Environment.NewLine, lines.Zip(lines.Skip(1).Append(String.Empty))
                .Select(ll =>
                {
                    var isNullableProperty = !ll.First.Contains("System.ComponentModel.DataAnnotations.Required") && ll.Second.Contains("{ get; set; }");
                    return isNullableProperty ? Regex.Replace(ll.Second, @"( \w+ { get; set; })", "?$1") : ll.Second;
                })
                .SkipLast(1)
                .Prepend(lines.First()));
            File.WriteAllText($"../../src/{Path}/CodeModel.cs", fileWithNullable);
        }
    }
}
