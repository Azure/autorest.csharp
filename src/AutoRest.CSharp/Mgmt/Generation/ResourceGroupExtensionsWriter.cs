// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        protected string Description = "A class to add extension methods to ResourceGroup.";
        protected string Accessibility = "public";
        protected string Type = "ResourceGroupExtensions";

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroupOperations);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(Description);
                using (writer.Scope($"{Accessibility} static partial class {Type}"))
                {
                    foreach (var resource in context.Library.ArmResource)
                    {
                        if (resource.OperationGroup.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.ResourceGroups))
                        {
                            foreach (var container in context.Library.ResourceContainers)
                            {
                                if (container.ResourceName == resource.Type.Name)
                                {
                                    writer.Line($"#region {resource.Type.Name}s");
                                    WriteGetContainers(writer, resource, container);
                                    writer.LineRaw("#endregion");
                                    writer.Line();
                                }
                            }
                        }
                    }

                    // write the standalone list operations with the parent of a subscription
                    var mgmtExtensionOperations = context.Library.GetMgmtExtensionOperations(ResourceTypeBuilder.ResourceGroups);

                    foreach (var mgmtExtensionOperation in mgmtExtensionOperations)
                    {
                        writer.Line($"#region {mgmtExtensionOperation.SchemaName}");
                        WriteGetRestOperations(writer, mgmtExtensionOperation.RestClient);

                        // despite that we should only have one method, but we still using an IEnumerable
                        foreach (var pagingMethod in mgmtExtensionOperation.PagingMethods)
                        {
                            WriteListMethod(writer, mgmtExtensionOperation.RestClient, pagingMethod, true);

                            WriteListMethod(writer, mgmtExtensionOperation.RestClient, pagingMethod, false);
                        }

                        foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                        {
                            WriteClientMethod(writer, mgmtExtensionOperation.RestClient, clientMethod, true);
                            WriteClientMethod(writer, mgmtExtensionOperation.RestClient, clientMethod, false);
                        }

                        writer.LineRaw("#endregion");
                        writer.Line();
                    }
                }
            }
        }

        private void WriteGetContainers(CodeWriter writer, Mgmt.Output.Resource armResource, ResourceContainer container)
        {
            // TODO: Find a solution to convert from single to plural
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {container.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("resourceGroup", $"The <see cref=\"{typeof(ResourceGroupOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{container.Type.Name}\" /> object.");
            using (writer.Scope($"public static {container.Type} Get{armResource.Type.Name}s (this {typeof(ResourceGroupOperations)} resourceGroup)"))
            {
                writer.Line($"return new {container.Type.Name}(resourceGroup);");
            }
        }

        private void WriteClientMethod(CodeWriter writer, MgmtRestClient restClient, ClientMethod clientMethod, bool async)
        {
            WriteClientMethod(writer, restClient, clientMethod,
                // skip the first parameter, aka the resource group name parameter
                // this client method has a parent of resource group (otherwise we cannot be here), therefore its first parameter must be resource group
                clientMethod.RestClientMethod.Parameters.Skip(1).Select(p => new ParameterMapping(p, false, p.Name)),
                async);
        }
        private void WriteListMethod(CodeWriter writer, MgmtRestClient restClient, PagingMethod pagingMethod, bool async)
        {
            WriteListMethod(writer, pagingMethod.PagingResponse.ItemType, restClient, pagingMethod,
                // skip the first parameter, aka the resource group name parameter
                // this client method has a parent of resource group (otherwise we cannot be here), therefore its first parameter must be resource group
                pagingMethod.Method.Parameters.Skip(1).Select(p => new ParameterMapping(p, false, p.Name)),
                $"",
                async);
        }
    }
}
