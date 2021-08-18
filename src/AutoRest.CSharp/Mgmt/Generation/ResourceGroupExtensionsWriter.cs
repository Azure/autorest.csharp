// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ResourceGroups];

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroup);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary($"{Description}");
                using (writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in context.Library.ArmResources)
                    {
                        if (resource.OperationGroup.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.ResourceGroups))
                        {
                            writer.Line($"#region {resource.Type.Name}");
                            if (resource.OperationGroup.TryGetSingletonResourceSuffix(context.Configuration.MgmtConfiguration, out var singletonResourceSuffix))
                            {
                                WriteGetSingletonResourceMethod(writer, resource, singletonResourceSuffix);
                            }
                            else
                            {
                                // a non-singleton resource must have a resource container
                                WriteGetResourceContainerMethod(writer, resource.ResourceContainer!);
                            }
                            writer.LineRaw("#endregion");
                            writer.Line();
                        }
                        else if ((resource.OperationGroup.IsScopeResource(context.Configuration.MgmtConfiguration) || resource.OperationGroup.IsExtensionResource(context.Configuration.MgmtConfiguration))
                            && resource.OperationGroup.Operations.Any(op => op.ParentResourceType() == ResourceTypeBuilder.ResourceGroups))
                        {
                            writer.Line($"#region {resource.Type.Name}");
                            if (resource.OperationGroup.TryGetSingletonResourceSuffix(context.Configuration.MgmtConfiguration, out var singletonResourceSuffix))
                            {
                                WriteGetSingletonResourceMethod(writer, resource, singletonResourceSuffix);
                            }
                            else
                            {
                                // a non-singleton resource must have a resource container
                                WriteGetResourceContainerMethod(writer, resource.ResourceContainer!);
                            }
                            writer.LineRaw("#endregion");
                            writer.Line();
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
                            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", true);
                            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", false);
                        }

                        foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                        {
                            WriteExtensionClientMethod(writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, context, true, mgmtExtensionOperation.RestClient);
                            WriteExtensionClientMethod(writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, context, false, mgmtExtensionOperation.RestClient);
                        }

                        writer.LineRaw("#endregion");
                        writer.Line();
                    }
                }
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
