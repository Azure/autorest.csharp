﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.Core;
using AutoRest.Core.Extensibility;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Azure.Model;
using AutoRest.CSharp.Model;
using AutoRest.CSharp.azure.Templates;

namespace AutoRest.CSharp.Azure.JsonRpcClient
{
    public sealed class PluginCsa : Azure.PluginCsa
    {
        public PluginCsa()
        {
            Context.Add(new Factory<AzureMethodTemplate, AutoRest.CSharp.jsonrpc.Templates.AzureMethodTemplate>());
        }
    }
}
