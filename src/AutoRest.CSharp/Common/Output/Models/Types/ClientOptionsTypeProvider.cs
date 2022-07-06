// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ClientOptionsTypeProvider : TypeProvider
    {
        private static TextInfo TextInfo = new CultureInfo("en-us", false).TextInfo;
        public FormattableString Description { get; }
        public IReadOnlyList<ApiVersion> ApiVersions { get;}
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public ClientOptionsTypeProvider(BuildContext context, string name, string? clientName) : base(context)
        {
            DefaultName = name;
            DefaultAccessibility = "public";
            if (clientName != null)
            {
                Description = $"Client options for {clientName}.";
            }
            else
            {
                Description = $"Client options for {context.DefaultLibraryName} library clients.";
            }

            ApiVersions = context.CodeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .Select((v, i) => new ApiVersion(ToVersionProperty(v), $"Service version \"{v}\"", i + 1, v))
                .ToArray();
        }

        public record ApiVersion(string Name, string Description, int Value, string StringValue);

        private static string ToVersionProperty(string s) => TextInfo.ToTitleCase("V" + s.Replace(".", "_").Replace('-', '_'));
    }
}
