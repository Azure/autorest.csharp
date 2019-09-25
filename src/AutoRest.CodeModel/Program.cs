using System.IO;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace AutoRest.CodeModel
{
    internal static class Program
    {
        private static void Main()
        {
            //var codeModelJson = File.ReadAllText("code-model.json");
            //var schema = JsonSchema.FromJsonAsync(codeModelJson).Result;
            var schema = JsonSchema.FromFileAsync("code-model.json").Result;
            var settings = new CSharpGeneratorSettings
            {
                HandleReferences = true,
                GenerateOptionalPropertiesAsNullable = true
            };
            var generator = new CSharpGenerator(schema, settings);
            var file = generator.GenerateFile();
            File.WriteAllText("CodeModel.cs", file);
            //var types = generator.GenerateTypes();
        }
    }
}
