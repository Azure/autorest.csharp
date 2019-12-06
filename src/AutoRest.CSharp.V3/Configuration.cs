// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.JsonRpc.MessageModels;

namespace AutoRest.CSharp.V3
{
    internal class Configuration
    {
        public string OutputPath { get; private set; }
        public string Namespace { get; private set; }
        public string Title { get; private set; }
        public bool IncludeCsProj { get; private set; }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        private Configuration() { }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        public static Configuration Create(IAutoRestInterface autoRest) =>
            new Configuration
            {
                OutputPath = autoRest.GetValue<string?>("output-folder").GetAwaiter().GetResult() ?? "Generated",
                Namespace = autoRest.GetValue<string?>("namespace").GetAwaiter().GetResult() ?? "Sample",
                Title = autoRest.GetValue<string?>("title").GetAwaiter().GetResult() ?? "Sample",
                IncludeCsProj = autoRest.GetValue<bool?>("include-csproj").GetAwaiter().GetResult() ?? true
            };
    }
}
