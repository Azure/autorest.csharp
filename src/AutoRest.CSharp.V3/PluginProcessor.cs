using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3
{
    internal static class PluginProcessor
    {
        //public static Dictionary<string, Func<IPlugin>> Plugins = new Dictionary<string, Func<IPlugin>>
        //{
        //    { SerializeTester.PluginName, () => new SerializeTester() },
        //    { ModelCreator.PluginName, () => new ModelCreator() },
        //    { SerializeTester.PluginName, () => new SerializeTester() },
        //    { SerializeTester.PluginName, () => new SerializeTester() },
        //};

        //https://stackoverflow.com/a/26750/294804
        private static readonly Type[] PluginTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == typeof(IPlugin).Namespace && t.IsClass && !t.IsAbstract && typeof(IPlugin).IsAssignableFrom(t) && t.GetCustomAttribute<PluginNameAttribute>(true) != null)
            .ToArray();
        public static readonly Dictionary<string, Func<IPlugin>> Plugins = PluginTypes
            .ToDictionary(pt => pt.GetCustomAttribute<PluginNameAttribute>(true)!.PluginName, pt => (Func<IPlugin>)(() => (IPlugin)Activator.CreateInstance(pt)!));
        public static readonly string[] PluginNames = Plugins.Keys.ToArray();

        public static async Task<bool> Start(AutoRestInterface autoRest)
        {
            // AutoRest sends an empty Object as a 'true' value. When the configuration item is not present, it sends a Null value.
            if ((await autoRest.GetValue<JsonElement?>($"{autoRest.PluginName}.debugger-attach")).IsObject())
            {
                DebuggerAwaiter.Await();
            }
            try
            {
                //var codeModelFile = (await autoRest.ListInputs()).FirstOrDefault();
                //if (codeModelFile.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

                //var codeModelYaml = await autoRest.ReadFile(codeModelFile);
                //var inputFile = (await autoRest.GetValue<string[]>("input-file")).FirstOrDefault();
                ////await autoRest.Message(new Message { Channel = Channel.Fatal, Text = inputFile });
                //var fileName = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}.yaml";
                //await autoRest.WriteFile(fileName, codeModelYaml, "source-file-csharp");

                //var codeModel = Serialization.DeserializeCodeModel(codeModelYaml);
                //var fileName2 = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Serial.yaml";
                //var codeModelYamlSerial = codeModel.Serialize();
                //await autoRest.WriteFile(fileName2, codeModelYamlSerial, "source-file-csharp");
                //var codeModel2 = Serialization.DeserializeCodeModel(codeModelYamlSerial);
                //var codeModelYamlDeserial = codeModel2.Serialize();
                //var fileName3 = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}-Deserial.yaml";
                //await autoRest.WriteFile(fileName3, codeModelYamlDeserial, "source-file-csharp");

                var codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
                if (codeModelFileName.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

                var codeModelYaml = await autoRest.ReadFile(codeModelFileName);
                var codeModel = Serialization.DeserializeCodeModel(codeModelYaml);
                var configuration = Configuration.Create(autoRest);

                var plugin = Plugins[autoRest.PluginName]();
                await plugin.Execute(autoRest, codeModel, configuration);
                if (plugin.ReserializeCodeModel)
                {
                    await autoRest.WriteFile("CodeModel.yaml", codeModel.Serialize(), "source-file-csharp");
                }
                //await new ModelCreator(autoRest, codeModel, configuration).Execute();

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
