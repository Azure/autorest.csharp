﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override string ExtensionClassType => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ResourceGroups];

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroupOperations);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(Description);
                using (writer.Scope($"{Accessibility} static partial class {ExtensionClassType}"))
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
                            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, $"", true);
                            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, $"", false);
                        }

                        foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                        {
                            WriteExtensionClientMethod(writer, mgmtExtensionOperation.OperationGroup, clientMethod, context, true, mgmtExtensionOperation.RestClient.Type.Name);
                            WriteExtensionClientMethod(writer, mgmtExtensionOperation.OperationGroup, clientMethod, context, false, mgmtExtensionOperation.RestClient.Type.Name);
                        }

                        writer.LineRaw("#endregion");
                        writer.Line();
                    }
                }
            }
        }

        private void WriteGetContainers(CodeWriter writer, Resource armResource, ResourceContainer container)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {container.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("resourceGroup", $"The <see cref=\"{typeof(ResourceGroupOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{container.Type.Name}\" /> object.");
            using (writer.Scope($"public static {container.Type} Get{armResource.Type.Name.ToPlural()} (this {typeof(ResourceGroupOperations)} resourceGroup)"))
            {
                writer.Line($"return new {container.Type.Name}(resourceGroup);");
            }
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
