// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
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
                    var mgmtExtensionOperations = context.Library.GetNonResourceOperations(ResourceTypeBuilder.ResourceGroups);

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
            // every method goes here, will have their first path parameter (aka the first parameter) as the `resourceGroupName`
            // in the resource group extension, we need different parameter lists between the parameter declaration part and the parameter invocation
            // in the parameter declaration, we should not put the `resourceGroupName` in the method signature
            // but in parameter invocation, we need to pass a value for `resourceGroupName`
            // instead of `Id.ResourceGroupName` as in normal ResourceContainer or ResourceOperation, we need to pass `resourceGroup.Id.Name`
            var methodParameters = clientMethod.RestClientMethod.Parameters.Skip(1);
            WriteExensionClientMethod(writer, restClient, clientMethod,
                // skip the first parameter, aka the resource group name parameter
                clientMethod.RestClientMethod.Parameters.Skip(1),
                async);
        }
        private void WriteListMethod(CodeWriter writer, MgmtRestClient restClient, PagingMethod pagingMethod, bool async)
        {
            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, restClient, pagingMethod,
                // skip the first parameter, aka the resource group name parameter
                pagingMethod.Method.Parameters.Skip(1),
                $"", async);
        }

        private IEnumerable<ParameterMapping> BuildPolishedParameterMapping(RestClientMethod method)
        {
            var mapping = BuildParameterMapping(method).ToArray();
            var first = mapping.First();
            first.IsPassThru = false;
            first.ValueExpression = $"{ExtensionOperationVariableName}.Id.Name";
            mapping[0] = first;
            return mapping;
        }

        // we need to pass the first parameter as `resourceGroup.Id.Name` because we are in an extension class
        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
            {
                valueExpression = $"{ExtensionOperationVariableName}.Id.Name";
                return false;
            }

            return true;
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // override to do nothing since we have passed the resourceGroupName in `ShouldPassThrough` function
        }
    }
}
