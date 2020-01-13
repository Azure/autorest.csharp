// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    internal interface IPlugin
    {
        Task<bool> Execute(IPluginCommunication autoRest, CodeModel codeModel, Configuration configuration);
        bool DeserializeCodeModel => true;
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class PluginNameAttribute : Attribute
    {
        public string PluginName { get; }

        public PluginNameAttribute(string pluginName)
        {
            PluginName = pluginName;
        }
    }
}
