using System;
using System.Collections.Generic;
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
        private static void Main()
        {
            using var webClient = new WebClient();
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/perks/master/codemodel/.resources/all-in-one/json/code-model.json", "../code-model.json");

            var codeModelJson = File.ReadAllText("../code-model.json")
                .Replace("\"+\"", "\"plus\"").Replace("\"-\"", "\"minus\"");
            var schema = JsonSchema.FromJsonAsync(codeModelJson).Result;

            var settings = new CSharpGeneratorSettings
            {
                Namespace = "AutoRest.CSharp.V3.PipelineModels",
                HandleReferences = true,
                GenerateOptionalPropertiesAsNullable = true,
                TypeAccessModifier = "internal"
            };
            var rawFile = new CSharpGenerator(schema, settings).GenerateFile();
            var cleanFile = String.Join(Environment.NewLine, rawFile.ToLines()
                    .Where(l => !l.Contains("Newtonsoft.Json.JsonConverter") && !l.Contains("Newtonsoft.Json.JsonExtensionData"))
                    .Select(l => Regex.Replace(l, @"(.*\[)Newtonsoft\.Json\.JsonProperty(.*""),?.*(\)\])", "$1SharpYaml.Serialization.YamlMember$2$3", RegexOptions.Singleline).TrimEnd()))
                //.Replace($"    {Environment.NewLine}    {Environment.NewLine}", String.Empty)
                //.Replace($"    {Environment.NewLine}    }}", "    }")
                //.Replace($"    {Environment.NewLine}", Environment.NewLine)
                .Replace($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}", Environment.NewLine)
                .Replace($"{Environment.NewLine}{Environment.NewLine}    }}", $"{Environment.NewLine}    }}")
                .Replace("\"plus\"", "\"+\"")
                .Replace("\"minus\"", "\"-\"")
                .Replace("Language Csharp", "CSharpLanguage Csharp")
                .Replace("SchemaMetadata Csharp", "CSharpSchemaMetadata Csharp")
                .Replace("AutoRest.CSharp.V3.PipelineModels.bool.True", "true")
                .Replace($"class Languages{Environment.NewLine}", $"class Languages_Unused{Environment.NewLine}")
                .Replace("Languages ", "LanguagesOfSchemaMetadata ")
                .Replace("Languages(", "LanguagesOfSchemaMetadata(")
                .Replace("ICollection<Primitives>", "ICollection<object>");
            File.WriteAllText("../../AutoRest.CSharp.V3/PipelineModels/CodeModel.cs", cleanFile);
        }

        //https://stackoverflow.com/a/41176852/294804
        private static IEnumerable<string> ToLines(this string value, bool removeEmptyLines = false)
        {
            using var sr = new StringReader(value);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (removeEmptyLines && String.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
        }
    }
}
