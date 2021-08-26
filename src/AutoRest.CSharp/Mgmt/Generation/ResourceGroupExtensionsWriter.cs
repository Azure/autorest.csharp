// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        private CodeWriter _writer;

        public ResourceGroupExtensionsWriter(CodeWriter writer, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _writer = writer;
        }

        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.ResourceGroups];

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroup);

        public override void WriteExtension()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in Context.Library.ArmResources)
                    {
                        if (resource.OperationGroup.ParentResourceType(Configuration).Equals(ResourceTypeBuilder.ResourceGroups))
                        {
                            _writer.Line($"#region {resource.Type.Name}");
                            if (resource.OperationGroup.TryGetSingletonResourceSuffix(Configuration, out var singletonResourceSuffix))
                            {
                                WriteGetSingletonResourceMethod(_writer, resource, singletonResourceSuffix);
                            }
                            else
                            {
                                // a non-singleton resource must have a resource container
                                WriteGetResourceContainerMethod(_writer, resource.ResourceContainer!);
                            }
                            _writer.LineRaw("#endregion");
                            _writer.Line();
                        }
                        else if ((resource.OperationGroup.IsScopeResource(Configuration) || resource.OperationGroup.IsExtensionResource(Configuration))
                            && resource.OperationGroup.Operations.Any(op => op.ParentResourceType() == ResourceTypeBuilder.ResourceGroups))
                        {
                            _writer.Line($"#region {resource.Type.Name}");
                            if (resource.OperationGroup.TryGetSingletonResourceSuffix(Configuration, out var singletonResourceSuffix))
                            {
                                WriteGetSingletonResourceMethod(_writer, resource, singletonResourceSuffix);
                            }
                            else
                            {
                                // a non-singleton resource must have a resource container
                                WriteGetResourceContainerMethod(_writer, resource.ResourceContainer!);
                            }
                            _writer.LineRaw("#endregion");
                            _writer.Line();
                        }
                    }

                    // write the standalone list operations with the parent of a subscription
                    var mgmtExtensionOperations = Context.Library.GetNonResourceOperations(ResourceTypeBuilder.ResourceGroups);

                    foreach (var mgmtExtensionOperation in mgmtExtensionOperations)
                    {
                        _writer.Line($"#region {mgmtExtensionOperation.SchemaName}");
                        WriteGetRestOperations(_writer, mgmtExtensionOperation.RestClient);

                        // despite that we should only have one method, but we still using an IEnumerable
                        foreach (var pagingMethod in mgmtExtensionOperation.PagingMethods)
                        {
                            WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", true);
                            WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", false);
                        }

                        foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                        {
                            WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, true, mgmtExtensionOperation.RestClient);
                            WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, false, mgmtExtensionOperation.RestClient);
                        }

                        _writer.LineRaw("#endregion");
                        _writer.Line();
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
