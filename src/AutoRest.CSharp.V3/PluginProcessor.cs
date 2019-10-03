using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.Utilities;
using AutoRest.CSharp.V3.PipelineModels;

namespace AutoRest.CSharp.V3
{
    internal static class PluginProcessor
    {
        public static string[] PluginNames { get; } = { "csharp-v3" };

        public static async Task<bool> Start(AutoRestInterface autoRest)
        {
            // AutoRest sends an empty Object as a 'true' value. When the configuration item is not present, it sends a Null value.
            if ((await autoRest.GetValue<JsonElement?>($"{autoRest.PluginName}.debugger")).IsObject())
            {
                DebuggerAwaiter.Await();
            }
            try
            {
                var codeModelFile = (await autoRest.ListInputs()).FirstOrDefault();
                if (codeModelFile.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

                var codeModelYaml = await autoRest.ReadFile(codeModelFile);
                //codeModelYaml = String.Join(Environment.NewLine, codeModelYaml.ToLines().Where(l => !l.Contains("uid:")));
                //codeModelYaml = Regex.Replace(codeModelYaml, @"(.*)!<!.*>(.*)", "$1$2", RegexOptions.Multiline);
                //codeModelYaml = codeModelYaml.Replace("<!CodeModel>", "<CodeModel>");
                //codeModelYaml = codeModelYaml.Replace("!<!CodeModel>", "");
                //codeModelYaml = codeModelYaml.Replace("primitives:", "primitives: !<!Primitives>");
                //codeModelYaml = codeModelYaml.Replace("https: ", "https:");
                //codeModelYaml = codeModelYaml.Replace("!<!Metadata>", "!<!OperationGroup>");
                //codeModelYaml = String.Join(Environment.NewLine, codeModelYaml.ToLines());
                //codeModelYaml = codeModelYaml.Replace($"{Environment.NewLine}    x-ms-metadata:{Environment.NewLine}      - url: 'https: //xkcd.com/json.html'", String.Empty);
                //codeModelYaml = codeModelYaml.Replace("          internal: true", $"          internal: true{Environment.NewLine}          coolCat: 'make me some bacon'");

                var inputFile = (await autoRest.GetValue<string[]>("input-file")).FirstOrDefault();
                await autoRest.Message(new Message { Channel = Channel.Fatal, Text = inputFile });
                var fileName = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}.yaml";
                await autoRest.WriteFile(fileName, codeModelYaml, "source-file-csharp");
                //codeModelYaml = await autoRest.ReadFile(fileName);

                var codeModel = CodeModelDeserializer.CreateCodeModel(codeModelYaml);

                return true;
            }
            catch (Exception e)
            {
                await autoRest.Message(new Message { Channel = Channel.Fatal, Text = e.ToString() });
                return false;
            }
        }
    }
}
