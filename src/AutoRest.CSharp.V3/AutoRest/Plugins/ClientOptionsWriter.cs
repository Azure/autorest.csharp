// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Writers;
using AutoRest.CSharp.V3.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class ClientOptionsWriter
    {
        public static void WriteClientOptions(CodeWriter writer, BuildContext context)
        {
            var title = context.Configuration.Title;
            var apiVersions = context.CodeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .Select(v=> (Version: v, Name: ToVersionProperty(v)))
                .ToArray();

            using (writer.Scope($"namespace {context.Configuration.Namespace}"))
            {
                writer.WriteXmlDocumentationSummary($"Client options for {title}.");
                using (writer.Scope($"public class {title}ManagementClientOptions: {typeof(ClientOptions)}"))
                {
                    writer.Line($"private const ServiceVersion LatestVersion = ServiceVersion.{apiVersions.Last().Name};");

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

                    writer.Line($"internal string Version {{ get; }}");

                    writer.WriteXmlDocumentationSummary($"Initializes new instance of {title}ManagementClientOptions.");
                    using (writer.Scope($"public {title}ManagementClientOptions(ServiceVersion version = LatestVersion)"))
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