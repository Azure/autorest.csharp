// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.AutoRest.Communication;
using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal interface IPlugin
    {
        Task<bool> Execute(IPluginCommunication autoRest);
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
