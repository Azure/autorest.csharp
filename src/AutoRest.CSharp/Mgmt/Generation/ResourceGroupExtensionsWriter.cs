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
        public ResourceGroupExtensionsWriter(CodeWriter writer, Output.ResourceGroupExtensions resourceGroupExtensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, resourceGroupExtensions, context)
        {
        }

        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroup);

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    WriteDefaultNamespace(_writer);

                    // Write resource collection entries
                    WriteChildResourceEntries();

                    // Write RestOperations
                    foreach (var restClient in _extensions.RestClients)
                    {
                        WriteGetRestOperations(restClient);
                    }

                    // Write other orphan operations with the parent of ResourceGroup
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        WriteMethod(clientOperation, true);
                        WriteMethod(clientOperation, false);
                    }
                }
            }
        }
    }
}
