using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.V3.Common.JsonRpc;
using AutoRest.CSharp.V3.Common.Plugins;
using AutoRest.CSharp.V3.Common.Utilities;

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
                AutoRestDebugger.Await();
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

                var inputFiles = await autoRest.GetValue<string[]>("input-file");
                var inputFileMessage = new Message { Channel = Channel.Fatal, Text = inputFiles.FirstOrDefault() };
                await autoRest.Message(inputFileMessage);

                await autoRest.WriteFile("CodeModel.yaml", codeModel, "source-file-csharp");
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
