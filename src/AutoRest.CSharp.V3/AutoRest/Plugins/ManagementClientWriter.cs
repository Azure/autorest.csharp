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
                    if (ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
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
                        if (ManagementClientWriterHelpers.IsHostParameter(parameter))
                        {
                            continue;
                        }

                        writer.WriteParameter(parameter);
                    }

                    writer.Append($"{typeof(TokenCredential)} tokenCredential, {title}ManagementClientOptions options = null) : this(");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        // Pass the default host
                        if (ManagementClientWriterHelpers.IsHostParameter(parameter))
                        {
                            writer.Append($"{parameter.DefaultValue?.Value:L}, ");
                            continue;
                        }

                        writer.Append($"{parameter.Name},");
                    }

                    writer.Line($"tokenCredential, options)");
                    using (writer.Scope())
                    {
                    }

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {title}ManagementClient");
                    writer.Append($"public {title}ManagementClient(");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        writer.WriteParameter(parameter, false);
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
                        using (writer.Scope($"public virtual {client.Type} Get{client.Type.Name}()"))
                        {
                            writer.Append($"return new {client.Type}(");
                            foreach (var parameter in client.RestClient.Parameters)
                            {
                                if (ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
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

            using (writer.Scope($"namespace {context.Configuration.Namespace}"))
            {
                writer.WriteXmlDocumentationSummary($"Client options for {title}.");
                using (writer.Scope($"public class {title}ManagementClientOptions: {typeof(ClientOptions)}"))
                {
                }
            }
        }

        private static string ToVersionProperty(string s)
        {
            return "V" + s.Replace(".", "_").Replace('-', '_');
        }
    }
}