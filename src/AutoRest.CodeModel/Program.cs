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
                //// Fixes + and - enum values that cannot be generated into C# enum names
                //.Replace("\"+\"", "\"plus\"").Replace("\"-\"", "\"minus\"")
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
                // Workaround for anyOf SecurityScheme types
                //.Replace($"        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();{Environment.NewLine}{Environment.NewLine}        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties{Environment.NewLine}        {{{Environment.NewLine}            get {{ return _additionalProperties; }}{Environment.NewLine}            set {{ _additionalProperties = value; }}{Environment.NewLine}        }}{Environment.NewLine}", String.Empty)
                //.Replace("class HTTPSecurityScheme", "class HTTPSecurityScheme : System.Collections.Generic.Dictionary<string, object>")
                //.Replace("class SecurityScheme", "class SecurityScheme : System.Collections.Generic.Dictionary<string, object>")
                // Fixes stray blank lines from the C# generator
                .Replace($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}", Environment.NewLine)
                .Replace($"{Environment.NewLine}{Environment.NewLine}    }}", $"{Environment.NewLine}    }}")
                // Replaces the alias to correctly match the schema from the C# generation fix above
                //.Replace("\"plus\"", "\"+\"")
                //.Replace("\"minus\"", "\"-\"")
                // Weird generation issue workaround
                .Replace($"{Namespace}.bool.True", "true")
                //// Set properties to be single quoted
                //.Replace("Alias = \"version\"", "ScalarStyle = YamlDotNet.Core.ScalarStyle.SingleQuoted, Alias = \"version\"")
                // Cases CSharp properly
                //.Replace("CSharpLanguage Csharp", "CSharpLanguage CSharp")
                // Fix for issue with Solution Error Visualizer
                // https://marketplace.visualstudio.com/items?itemName=VisualStudioPlatformTeam.SolutionErrorVisualizer&ssr=false#review-details
                .Replace("#pragma warning disable // Disable all warnings", $"#pragma warning disable // Disable all warnings{Environment.NewLine}    #nullable enable");
                // Class names that conflict with project class names
                //.Replace("HttpHeader", "HttpResponseHeader")
                //.Replace("class Parameter", "class RequestParameter")
                //.Replace(": Parameter", ": RequestParameter")
                //.Replace("<Parameter>", "<RequestParameter>")
                //.Replace("public Parameter OriginalParameter { get; set; } = new Parameter();", "public RequestParameter OriginalParameter { get; set; } = new RequestParameter();")
                //.Replace("public Parameter GroupedBy", "public RequestParameter GroupedBy")
                //.Replace("class Request ", "class ServiceRequest ")
                //.Replace("public Request Request { get; set; } = new Request();", "public ServiceRequest Request { get; set; } = new ServiceRequest();")
                //.Replace("class Response ", "class ServiceResponse ")
                //.Replace(": Response", ": ServiceResponse")
                //.Replace("<Response>", "<ServiceResponse>")
                //.Replace($"class SerializationFormat{Environment.NewLine}", $"class SerializationFormatMetadata{Environment.NewLine}")
                //.Replace("public SerializationFormat ", "public SerializationFormatMetadata ")
                //.Replace(": SerializationFormat", ": SerializationFormatMetadata");

            var lines = cleanFile.ToLines().ToArray();
            var fileWithNullable = String.Join(Environment.NewLine, lines.Zip(lines.Skip(1).Append(String.Empty))
                .Select(ll =>
                {
                    var isNullableProperty = !ll.First.Contains("System.ComponentModel.DataAnnotations.Required") && ll.Second.Contains("{ get; set; }");
                    return isNullableProperty ? Regex.Replace(ll.Second, @"( \w+ { get; set; })", "?$1") : ll.Second;
                })
                .SkipLast(1)
                .Prepend(lines.First()));
            //var fileWithNullableFix = fileWithNullable
            //    // Fix for issue with Solution Error Visualizer
            //    // https://marketplace.visualstudio.com/items?itemName=VisualStudioPlatformTeam.SolutionErrorVisualizer&ssr=false#review-details
            //    // https://stackoverflow.com/a/54973095/294804
            //    .Replace("public string Version { get; set; }", "public string Version { get; set; } = null!;")
            //    .Replace("public string Message { get; set; }", "public string Message { get; set; } = null!;")
            //    .Replace("public string Url { get; set; }", "public string Url { get; set; } = null!;")
            //    .Replace("public string Name { get; set; }", "public string Name { get; set; } = null!;")
            //    .Replace("public string Description { get; set; }", "public string Description { get; set; } = null!;")
            //    .Replace("public string Value { get; set; }", "public string Value { get; set; } = null!;")
            //    .Replace("public string SerializedName { get; set; }", "public string SerializedName { get; set; } = null!;")
            //    .Replace("public string Target { get; set; }", "public string Target { get; set; } = null!;")
            //    .Replace("public string Source { get; set; }", "public string Source { get; set; } = null!;")
            //    .Replace("public string Title { get; set; }", "public string Title { get; set; } = null!;")
            //    .Replace("public string Key { get; set; }", "public string Key { get; set; } = null!;")
            //    .Replace("public object Value { get; set; }", "public object Value { get; set; } = null!;")
            //    .Replace("public string AuthorizationUrl { get; set; }", "public string AuthorizationUrl { get; set; } = null!;")
            //    .Replace("public string TokenUrl { get; set; }", "public string TokenUrl { get; set; } = null!;")
            //    .Replace("public string Scheme { get; set; }", "public string Scheme { get; set; } = null!;")
            //    .Replace("public string OpenIdConnectUrl { get; set; }", "public string OpenIdConnectUrl { get; set; } = null!;")
            //    .Replace("public string Path { get; set; }", "public string Path { get; set; } = null!;")
            //    .Replace("public string Uri { get; set; }", "public string Uri { get; set; } = null!;")
            //    .Replace("public string Header { get; set; }", "public string Header { get; set; } = null!;");
            File.WriteAllText($"../../src/{Path}/CodeModel.cs", fileWithNullable);
        }
    }
}
