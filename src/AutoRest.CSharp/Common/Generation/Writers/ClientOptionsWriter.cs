// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ClientOptionsWriter
    {
        public static void WriteClientOptions(CodeWriter writer, BuildContext context)
        {
            var clientOptionsName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            var @namespace = context.DefaultNamespace;
            var apiVersions = context.CodeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .Select(v => (Version: v, Name: ToVersionProperty(v)))
                .ToArray();

            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"Client options for {clientOptionsName}Client.");
                using (writer.Scope($"public partial class {clientOptionsName}ClientOptions: {typeof(ClientOptions)}"))
                {
                    writer.Line($"private const ServiceVersion LatestVersion = ServiceVersion.{apiVersions.Last().Name};");
                    writer.Line();
                    writer.WriteXmlDocumentationSummary("The version of the service to use.");
                    using (writer.Scope($"public enum ServiceVersion"))
                    {
                        int i = 1;
                        foreach (var apiVersion in apiVersions)
                        {
                            writer.WriteXmlDocumentationSummary($"Service version \"{apiVersion.Version}\"");
                            writer.Line($"{apiVersion.Name} = {i:L},");
                            i++;
                        }
                    }

                    writer.Line();
                    writer.Line($"internal string Version {{ get; }}");
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes new instance of {clientOptionsName}ClientOptions.");
                    using (writer.Scope($"public {clientOptionsName}ClientOptions(ServiceVersion version = LatestVersion)"))
                    {
                        writer.Append($"Version = version ");
                        using (writer.Scope($"switch", end: "};"))
                        {
                            foreach (var apiVersion in apiVersions)
                            {
                                writer.Line($"ServiceVersion.{apiVersion.Name} => {apiVersion.Version:L},");
                            }

                            writer.Line($"_ => throw new {typeof(NotSupportedException)}()");
                        }
                    }
                }
            }
        }

        private static string ToVersionProperty(string s)
        {
            return "V" + s.Replace(".", "_").Replace('-', '_');
        }
    }
}
