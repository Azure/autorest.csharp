// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
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

        public static async Task<bool> Start(IPluginCommunication autoRest)
        {
            // AutoRest sends an empty Object as a 'true' value. When the configuration item is not present, it sends a Null value.
            if ((await autoRest.GetValue<JsonElement?>($"{autoRest.PluginName}.attach")).IsObject())
            {
                DebuggerAwaiter.AwaitAttach();
            }
            try
            {
                Configuration configuration = new Configuration(autoRest);

                IPlugin plugin = Plugins[autoRest.PluginName]();
                CodeModel codeModel = new CodeModel();
                if (plugin.DeserializeCodeModel)
                {
                    string codeModelFileName = (await autoRest.ListInputs()).FirstOrDefault();
                    if (codeModelFileName.IsNullOrEmpty()) throw new Exception("Generator did not receive the code model file.");

                    string codeModelYaml = await autoRest.ReadFile(codeModelFileName);

                    if (configuration.SaveCodeModel)
                    {
                        await autoRest.WriteFile("CodeModel.yaml", codeModelYaml, "source-file-csharp");
                    }

                    codeModel = CodeModelSerialization.DeserializeCodeModel(codeModelYaml);
                }

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
