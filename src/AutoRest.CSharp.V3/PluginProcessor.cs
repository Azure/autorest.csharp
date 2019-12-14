// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3
{
    internal static class PluginProcessor
    {
        //https://stackoverflow.com/a/26750/294804
        private static readonly Type[] PluginTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == typeof(IPlugin).Namespace && t.IsClass && !t.IsAbstract && typeof(IPlugin).IsAssignableFrom(t) && t.GetCustomAttribute<PluginNameAttribute>(true) != null)
            .ToArray();
        public static readonly Dictionary<string, Func<IPlugin>> Plugins = PluginTypes
            .ToDictionary(pt => pt.GetCustomAttribute<PluginNameAttribute>(true)!.PluginName, pt => (Func<IPlugin>)(() => (IPlugin)Activator.CreateInstance(pt)!));
        public static readonly string[] PluginNames = Plugins.Keys.ToArray();

        public static async Task<bool> Start(IAutoRestInterface autoRest)
        {
            // AutoRest sends an empty Object as a 'true' value. When the configuration item is not present, it sends a Null value.
            if ((await autoRest.GetValue<JsonElement?>($"{autoRest.PluginName}.attach")).IsObject())
            {
                DebuggerAwaiter.AwaitAttach();
            }
            try
            {
                var plugin = Plugins[autoRest.PluginName]();
                var codeModel = new CodeModel();
                if (plugin.DeserializeCodeModel)
                {
                    var codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
                    if (codeModelFileName.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

                    var codeModelYaml = await autoRest.ReadFile(codeModelFileName);

                    await autoRest.WriteFile("CodeModel.yaml", codeModelYaml, "source-file-csharp");

                    codeModel = Serialization.DeserializeCodeModel(codeModelYaml);
                }
                var configuration = new Configuration(autoRest);
                await plugin.Execute(autoRest, codeModel, configuration);
                return true;
            }
            catch (Exception e)
            {
                await autoRest.Fatal(e.ToString());
                return false;
            }
        }
    }
}
