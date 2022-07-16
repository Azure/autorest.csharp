// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ClientOptionsTypeProvider : TypeProvider
    {
        public FormattableString Description { get; }
        public IReadOnlyList<ApiVersion> ApiVersions { get;}
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public ClientOptionsTypeProvider(BuildContext context) : base(context)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            DefaultName = $"{clientPrefix}ClientOptions";
            DefaultAccessibility = "public";
            Description = $"Client options for {clientPrefix}Client.";

            ApiVersions = ConvertApiVersions(CodeModelConverter.GetApiVersions(context.CodeModel));
        }

        public ClientOptionsTypeProvider(IReadOnlyList<string> versions, string name, string ns, FormattableString description, SourceInputModel? sourceInputModel) : base(ns, sourceInputModel)
        {
            DefaultName = name;
            DefaultAccessibility = "public";
            Description = description;

            ApiVersions = ConvertApiVersions(versions);
        }

        private static ApiVersion[] ConvertApiVersions(IReadOnlyList<string> versions) =>
            versions.Select((v, i) => new ApiVersion(ToVersionProperty(v), $"Service version \"{v}\"", i + 1, v)).ToArray();

        public record ApiVersion(string Name, string Description, int Value, string StringValue);

        private static string ToVersionProperty(string s) => "V" + s.Replace(".", "_").Replace('-', '_');
    }
}
