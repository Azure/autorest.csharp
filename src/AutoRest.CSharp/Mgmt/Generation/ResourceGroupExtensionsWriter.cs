// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        public ResourceGroupExtensionsWriter(CodeWriter writer, ResourceGroupExtensions resourceGroupExtensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, resourceGroupExtensions, context)
        {
        }

        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override CSharpType TypeOfThis => _extensions.Type;

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroup);

        protected override TypeProvider This => _extensions;

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource container entries
                    WriteChildResourceEntries();

                    // Write RestOperations
                    foreach (var restClient in _extensions.RestClients)
                    {
                        WriteGetRestOperations(restClient);
                    }

                    // Write other orphan operations with the parent of ResourceGroup
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        WriteMethod(clientOperation, clientOperation.Name, true);
                        WriteMethod(clientOperation, clientOperation.Name, false);
                    }

                    //var mgmtExtensionOperations = Context.Library.GetNonResourceOperations(ResourceTypeBuilder.ResourceGroups);

                    //foreach (var mgmtExtensionOperation in mgmtExtensionOperations)
                    //{
                    //    _writer.Line($"#region {mgmtExtensionOperation.SchemaName}");
                    //WriteGetRestOperations(_writer, mgmtExtensionOperation.RestClient);

                    //    // despite that we should only have one method, but we still using an IEnumerable
                    //    foreach (var pagingMethod in mgmtExtensionOperation.PagingMethods)
                    //    {
                    //WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", true);
                    //        WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", false);
                    //    }

                    //    foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                    //    {
                    //WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, true, mgmtExtensionOperation.RestClient);
                    //        WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, false, mgmtExtensionOperation.RestClient);
                    //    }

                    //    _writer.LineRaw("#endregion");
                    //    _writer.Line();
                    //}
                }
            }
        }
    }
}
