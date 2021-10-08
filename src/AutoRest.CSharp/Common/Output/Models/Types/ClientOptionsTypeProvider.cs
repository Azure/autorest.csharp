// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ClientOptionsTypeProvider : TypeProvider
    {
        public string DefaultClientName { get; }
        public IReadOnlyList<ApiVersion> ApiVersions { get;}
        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility { get; }

        public ClientOptionsTypeProvider(BuildContext context) : base(context)
        {
            DefaultClientName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            DefaultName = $"{DefaultClientName}ClientOptions";
            DefaultNamespace = context.DefaultNamespace;
            DefaultAccessibility = "public";

            ApiVersions = context.CodeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .Select((v, i) => new ApiVersion(ToVersionProperty(v), $"Service version \"{v}\"", i + 1, v))
                .ToArray();
        }

        public record ApiVersion(string Name, string Description, int Value, string StringValue);

        private static string ToVersionProperty(string s) => "V" + s.Replace(".", "_").Replace('-', '_');
    }
}
