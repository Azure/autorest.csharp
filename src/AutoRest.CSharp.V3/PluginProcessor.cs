using System;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.Utilities;
using AutoRest.CSharp.V3.PipelineModels;
//using SharpYaml.Serialization;

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
                var testItem = await autoRest.GetValue<string>("test-item");
                var debugger = await autoRest.GetValue<string>("csharp-v2.debugger");

                var files = await autoRest.ListInputs();
                if (!files.Any())
                {
                    throw new Exception("Generator did not receive the code model file.");
                }

                var codeModel = await autoRest.ReadFile(files.FirstOrDefault());
                //codeModel = String.Join(Environment.NewLine, codeModel.ToLines().Where(l => !l.Contains("uid:")));
                //codeModel = Regex.Replace(codeModel, @"(.*)!<!.*>(.*)", "$1$2", RegexOptions.Multiline);
                //codeModel = codeModel.Replace("<!CodeModel>", "<CodeModel>");
                //codeModel = codeModel.Replace("!<!CodeModel>", "");
                //codeModel = codeModel.Replace("primitives:", "primitives: !<!Primitives>");
                //var settings = new SerializerSettings();
                ////settings.RegisterTagMapping("!CodeModel", typeof(CodeModel));
                //var serializer = new Serializer(settings);
                //var cmClass = serializer.Deserialize<CodeModel>(codeModel);

                var cmClass = CodeModelDeserializer.CreateCodeModel(codeModel);

                var inputFiles = await autoRest.GetValue<string[]>("input-file");
                var inputFileMessage = new Message { Channel = Channel.Fatal, Text = inputFiles.FirstOrDefault() };
                await autoRest.Message(inputFileMessage);

                await autoRest.WriteFile("CodeModel-new.yaml", codeModel, "source-file-csharp");
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
