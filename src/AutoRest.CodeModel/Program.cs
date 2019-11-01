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
        private const string Path = "AutoRest.CSharp.V3/Pipeline/Generated";
        private static readonly string Namespace = Path.Replace("/", ".");

        private static void Main()
        {
            using var webClient = new WebClient();
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/perks/master/codemodel/.resources/all-in-one/json/code-model.json", "../code-model.json");

            var schemaJsonLines = File.ReadAllLines("../code-model.json");
            var schemaJson = String.Join(Environment.NewLine, schemaJsonLines)
                // Fixes + and - enum values that cannot be generated into C# enum names
                .Replace("\"+\"", "\"plus\"").Replace("\"-\"", "\"minus\"")
                // Makes Choices only have string values
                .Replace($"          \"type\": [{Environment.NewLine}            \"string\",{Environment.NewLine}            \"number\",{Environment.NewLine}            \"boolean\"{Environment.NewLine}          ]{Environment.NewLine}", $"          \"type\": \"string\"{Environment.NewLine}");
            var schema = JsonSchema.FromJsonAsync(schemaJson).GetAwaiter().GetResult();
            var settings = new CSharpGeneratorSettings
            {
                Namespace = Namespace,
                HandleReferences = true,
                //GenerateOptionalPropertiesAsNullable = true,
                TypeAccessModifier = "internal"
            };
            var rawFile = new CSharpGenerator(schema, settings).GenerateFile();
            var cleanFile = String.Join(Environment.NewLine, rawFile.ToLines()
                    // Converts Newtonsoft attributes to YamlDotNet attributes
                    .Where(l => !l.Contains("Newtonsoft.Json.JsonConverter")
                                && !l.Contains("Newtonsoft.Json.JsonExtensionData"))
                    .Select(l => Regex.Replace(l, @"(.*\[)Newtonsoft\.Json\.JsonProperty\((.*""),?.*(\)\])",
                        "$1YamlDotNet.Serialization.YamlMember(Alias = $2$3", RegexOptions.Singleline).TrimEnd()))
                // Workaround for anyOf SecurityScheme types
                .Replace($"        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();{Environment.NewLine}{Environment.NewLine}        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties{Environment.NewLine}        {{{Environment.NewLine}            get {{ return _additionalProperties; }}{Environment.NewLine}            set {{ _additionalProperties = value; }}{Environment.NewLine}        }}{Environment.NewLine}", String.Empty)
                .Replace("class HTTPSecurityScheme", "class HTTPSecurityScheme : System.Collections.Generic.Dictionary<string, object>")
                .Replace("class SecurityScheme", "class SecurityScheme : System.Collections.Generic.Dictionary<string, object>")
                // Fixes stray blank lines from the C# generator
                .Replace($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}", Environment.NewLine)
                .Replace($"{Environment.NewLine}{Environment.NewLine}    }}", $"{Environment.NewLine}    }}")
                // Replaces the alias to correctly match the schema from the C# generation fix above
                .Replace("\"plus\"", "\"+\"")
                .Replace("\"minus\"", "\"-\"")
                // Weird generation issue workaround
                .Replace($"{Namespace}.bool.True", "true")
                // Set properties to be single quoted
                .Replace("Alias = \"version\"", "ScalarStyle = YamlDotNet.Core.ScalarStyle.SingleQuoted, Alias = \"version\"")
                // Cases CSharp properly
                .Replace("CSharpLanguage Csharp", "CSharpLanguage CSharp");

            var fileWithOrdering = OrderCalculator.InsertOrderValues(cleanFile);
            //var fileWithNullable = Regex.Replace(fileWithOrdering, @"( \w+ { get; set; })(?! =)", "?$1");

            var lines = fileWithOrdering.ToLines().ToArray();
            //var firstLine = lines.First();
            var fileWithNullable = String.Join(Environment.NewLine, lines.Zip(lines.Skip(1).Append(String.Empty))
                //.Where(ll => !ll.First.Contains("System.ComponentModel.DataAnnotations.Required") && ll.Second.Contains("{ get; set; }"))
                .Select(ll =>
                {
                    var isNullableProperty = !ll.First.Contains("System.ComponentModel.DataAnnotations.Required") && ll.Second.Contains("{ get; set; }");
                    return isNullableProperty ? Regex.Replace(ll.Second, @"( \w+ { get; set; })", "?$1") : ll.Second;
                })
                .SkipLast(1)
                .Prepend(lines.First()));
            //foreach(var line in nullableLines)
            //{
            //    line.Second = Regex.Replace(line.Second, @"( \w+ { get; set; })", "?$1");
            //}
            File.WriteAllText($"../../{Path}/CodeModel.cs", fileWithNullable);
        }
    }
}
