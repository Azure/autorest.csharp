﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.AutoRest.Communication;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class Configuration
    {
        public string OutputFolder { get; }
        public string Namespace { get; }
        public string Title { get; }
        public bool IncludeCsProj { get; }

        public Configuration(IPluginCommunication autoRest)
        {
            OutputFolder = new Uri(autoRest.GetValue<string?>("output-folder").GetAwaiter().GetResult() ?? "Generated").LocalPath;
            Namespace = autoRest.GetValue<string?>("namespace").GetAwaiter().GetResult() ?? "Sample";
            Title = autoRest.GetValue<string?>("title").GetAwaiter().GetResult() ?? "Sample";
            IncludeCsProj = autoRest.GetValue<bool?>("include-csproj").GetAwaiter().GetResult() ?? true;
        }
    }
}
