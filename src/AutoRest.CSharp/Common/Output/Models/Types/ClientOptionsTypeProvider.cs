// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ClientOptionsTypeProvider : TypeProvider
    {
        private static TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;

        public FormattableString Description { get; }
        public IReadOnlyList<ApiVersion> ApiVersions { get; }
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
                .Select((v, i) => new ApiVersion(NormalizeVersion(v), $"Service version \"{v}\"", i + 1, v))
                .ToArray();
        }

        public record ApiVersion(string Name, string Description, int Value, string StringValue);

        internal static string NormalizeVersion(string version) =>
            TextInfo.ToTitleCase(new StringBuilder("V")
                .Append(version.StartsWith("v", true, CultureInfo.InvariantCulture) ? version.Substring(1) : version)
                .Replace(' ', '_')
                .Replace('-', '_')
                .Replace('.', '_')
                .ToString());
    }
}
