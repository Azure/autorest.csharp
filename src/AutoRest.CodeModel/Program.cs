using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NJsonSchema.Generation;
using NJsonSchema.Infrastructure;

namespace AutoRest.CodeModel
{
    internal static class Program
    {
        private static void Main()
        {
            using var webClient = new WebClient();
            webClient.DownloadFile(@"https://raw.githubusercontent.com/Azure/perks/master/codemodel/.resources/all-in-one/json/code-model.json", "../code-model.json");

            var schemaJsonLines = File.ReadAllLines("../code-model.json");
            var schemaJsonLinesList = schemaJsonLines.ToList();
            var indexIncrementer = 0;
            var absentAdditionalPropertiesGroups = schemaJsonLines
                .Zip(schemaJsonLines.Skip(1).Append(String.Empty), (c, n) => (Current: c, Next: n))
                .Select((p, i) => (Index: i, p.Current, p.Next))
                .Where(g =>
                    g.Current.Contains("\"type\":")
                    && g.Current.Contains(",")
                    //&& !g.Next.Contains("\"enum\":")
                    && !g.Next.Contains("\"additionalProperties\""));
            foreach (var (index, current, _) in absentAdditionalPropertiesGroups)
            {
                var spaces = String.Join(String.Empty, current.TakeWhile(c => c == ' '));
                schemaJsonLinesList.Insert(index + 1 + indexIncrementer++, $"{spaces}\"additionalProperties\": false,");
            }

            var schemaJson = String.Join(Environment.NewLine, schemaJsonLinesList)
                .Replace("\"+\"", "\"plus\"").Replace("\"-\"", "\"minus\"");
                //.Replace($"\"Language\": {{{Environment.NewLine}      \"type\": \"object\",{Environment.NewLine}      \"additionalProperties\": false,"
                //    , $"\"Language\": {{{Environment.NewLine}      \"type\": \"object\",{Environment.NewLine}      \"additionalProperties\": true,");

            //var codeModelJson = File.ReadAllText("../code-model.json")
            //    .Replace("\"+\"", "\"plus\"").Replace("\"-\"", "\"minus\"");
            var schema = JsonSchema.FromJsonAsync(schemaJson).GetAwaiter().GetResult();
            //var schema = JsonSchema.FromJsonAsync(schemaJson).Result;


            //var schema = JsonSchema.FromJsonAsync(codeModelJson, ".", s =>
            //{
            //    var generatorSettings = new JsonSchemaGeneratorSettings();
            //    generatorSettings.ActualSerializerSettings.
            //    var schemaResolver = new JsonSchemaResolver(s, generatorSettings);
            //    var resolver = new JsonReferenceResolver(schemaResolver);


            //    return resolver;
            //}).Result;
            //schema.AllowAdditionalProperties = false;

            //var generator = new FixedAdditionalPropertiesJsonSchemaGenerator(new JsonSchemaGeneratorSettings());
            //var schema = generator.g

            //Func<JsonSchema, JsonReferenceResolver> CreateJsonReferenceResolverFactory() => s =>
            //{
            //    s.AllowAdditionalProperties = s.AdditionalPropertiesSchema != null;
            //    foreach (var (_, property) in s.ActualProperties)
            //    {
            //        property.AllowAdditionalProperties = property.AdditionalPropertiesSchema != null;
            //    }

            //    return new JsonReferenceResolver(new JsonSchemaAppender(s, new DefaultTypeNameGenerator()));
            //};

            //var schema = JsonSchemaSerialization.FromJsonAsync(codeModelJson, SchemaType.JsonSchema, null,
            //    CreateJsonReferenceResolverFactory(), JsonSchema.CreateJsonSerializerContractResolver(SchemaType.JsonSchema))
            //    .GetAwaiter().GetResult();

            var settings = new CSharpGeneratorSettings
            {
                Namespace = "AutoRest.CSharp.V3.PipelineModels",
                HandleReferences = true,
                GenerateOptionalPropertiesAsNullable = true,
                TypeAccessModifier = "internal"
            };
            var rawFile = new CSharpGenerator(schema, settings).GenerateFile();
            var cleanFile = String.Join(Environment.NewLine, rawFile.ToLines()
                    .Where(l => !l.Contains("Newtonsoft.Json.JsonConverter") &&
                                !l.Contains("Newtonsoft.Json.JsonExtensionData") &&
                                !l.Contains("defaultProperties"))
                    .Select(l => Regex.Replace(l, @"(.*\[)Newtonsoft\.Json\.JsonProperty\((.*""),?.*(\)\])",
                        "$1YamlDotNet.Serialization.YamlMember(Alias = $2$3", RegexOptions.Singleline).TrimEnd()))
                //.Select(l => Regex.Replace(l, @"(.*\[)Newtonsoft\.Json\.JsonProperty(.*""),?.*(\)\])",
                //    "$1SharpYaml.Serialization.YamlMember$2$3", RegexOptions.Singleline).TrimEnd()))
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
                .Replace("Languages(", "LanguagesOfSchemaMetadata(");
            //.Replace("ICollection<Primitives>", "ICollection<object>");
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

        //private class CustomJsonSchema : JsonSchema
        //{

        //}

        //https://github.com/RicoSuter/NJsonSchema/blob/1580d4f3583292ecfa7eb988d75279d3b4d90012/src/NJsonSchema/Infrastructure/IgnoreEmptyCollectionsContractResolver.cs#L1-L44
        //private class CustomIgnoreEmptyCollectionsContractResolver : PropertyRenameAndIgnoreSerializerContractResolver
        //{
        //    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        //    {
        //        var property = base.CreateProperty(member, memberSerialization);
        //        if ((property.Required == Required.Default || property.Required == Required.DisallowNull)
        //            && (property.PropertyType != typeof(string) && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(property.PropertyType.GetTypeInfo())))
        //            property.ShouldSerialize = instance =>
        //            {
        //                var enumerable = instance != null ? property.ValueProvider.GetValue(instance) as IEnumerable : null;
        //                return enumerable == null || enumerable.GetEnumerator().MoveNext();
        //            };

        //        return property;
        //    }
        //}

        //https://stackoverflow.com/a/38815581/294804
        //private class FixedAdditionalPropertiesJsonSchemaGenerator : JsonSchemaGenerator
        //{
        //    public FixedAdditionalPropertiesJsonSchemaGenerator(JsonSchemaGeneratorSettings settings) : base(settings) { }

        //    protected override void GenerateObject(JsonSchema schema, JsonTypeDescription typeDescription, JsonSchemaResolver schemaResolver)
        //    {
        //        base.GenerateObject(schema, typeDescription, schemaResolver);
        //        schema.AllowAdditionalProperties = schema.AdditionalPropertiesSchema != null;
        //    }
        //}
    }
}
