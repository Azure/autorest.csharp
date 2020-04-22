// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Writers;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.V3.AutoRest.Plugins
{
    internal class ManagementClientWriter
    {
        public static void WriteAggregateClient(CodeWriter writer, BuildContext context)
        {
            var title = context.Configuration.LibraryName;
            using (writer.Scope($"namespace {context.Configuration.Namespace}"))
            {
                Dictionary<string, Parameter> allParameters = new Dictionary<string, Parameter>();
                foreach (var parameter in context.Library.Clients.SelectMany(p => p.RestClient.Parameters))
                {
                    if (ManagementClientWriterHelpers.IsHostParameter(parameter) ||
                        ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
                    {
                        continue;
                    }

                    allParameters[parameter.Name] = parameter;
                }

                writer.WriteXmlDocumentationSummary($"{title} service management client.");
                using (writer.Scope($"public class {title}ManagementClient"))
                {
                    writer.Line($"private readonly {title}ManagementClientOptions _options;");
                    writer.Line($"private readonly {typeof(TokenCredential)} _tokenCredential;");
                    foreach (var parameter in allParameters.Values)
                    {
                        writer.Line($"private readonly {parameter.Type} _{parameter.Name};");
                    }

                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {title}ManagementClient for mocking.");
                    using (writer.Scope($"protected {title}ManagementClient()"))
                    {
                    }
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {title}ManagementClient");
                    writer.Append($"public {title}ManagementClient(");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        writer.WriteParameter(parameter);
                    }

                    writer.Append($"{typeof(TokenCredential)} tokenCredential, {title}ManagementClientOptions options = null)");

                    using (writer.Scope())
                    {
                        writer.Line($"_options = options ?? new {title}ManagementClientOptions();");
                        writer.Line($"_tokenCredential = tokenCredential;");

                        foreach (Parameter parameter in allParameters.Values)
                        {
                            writer.Line($"_{parameter.Name} = {parameter.Name};");
                        }

                    }
                    writer.Line();

                    foreach (var client in context.Library.Clients)
                    {
                        writer.WriteXmlDocumentationSummary($"Creates a new instance of {client.Type.Name}");
                        using (writer.Scope($"public {client.Type} Get{client.Type.Name}()"))
                        {
                            writer.Append($"return new {client.Type}(");
                            foreach (var parameter in client.RestClient.Parameters)
                            {
                                if (ManagementClientWriterHelpers.IsHostParameter(parameter) ||
                                    ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
                                {
                                    continue;
                                }

                                writer.Append($"_{parameter.Name}, ");
                            }

                            writer.Line($"_tokenCredential, _options);");
                        }

                        writer.Line();
                    }
                }

            }
        }

        public static void WriteClientOptions(CodeWriter writer, BuildContext context)
        {
            var title = context.Configuration.LibraryName;
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