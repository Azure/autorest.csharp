// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ClientOptionsTypeProvider : TypeProvider
    {
        private static TextInfo TextInfo = CultureInfo.InvariantCulture.TextInfo;

        public FormattableString Description { get; }
        public IReadOnlyList<ApiVersion>? ApiVersions { get; }
        public IList<Parameter>? AdditionalProperties { get; private set; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public ClientOptionsTypeProvider(IReadOnlyList<string>? versions, string name, string ns, FormattableString description, SourceInputModel? sourceInputModel) : base(ns, sourceInputModel)
        {
            DefaultName = name;
            DefaultAccessibility = "public";
            Description = description;

            if (versions is not null)
                ApiVersions = ConvertApiVersions(versions);
        }

        public void AddAdditionalProperty(IEnumerable<Parameter> parameters)
        {
            AdditionalProperties ??= new List<Parameter>();
            foreach (var parameter in parameters)
            {
                if (!AdditionalProperties.Any(property => property.Name == parameter.Name))
                {
                    AdditionalProperties.Add(parameter);
                }
            }
        }

        private static ApiVersion[] ConvertApiVersions(IReadOnlyList<string> versions) =>
            versions.Select((v, i) => new ApiVersion(NormalizeVersion(v), $"Service version \"{v}\"", i + 1, v)).ToArray();

        public record ApiVersion(string Name, string Description, int Value, string StringValue);

        internal static string NormalizeVersion(string version) =>
            TextInfo.ToTitleCase(new StringBuilder("V")
                .Append(version.StartsWith("v", true, CultureInfo.InvariantCulture) ? version.Substring(1) : version)
                .Replace('-', '_')
                .Replace('.', '_')
                .ToString());
    }
}
