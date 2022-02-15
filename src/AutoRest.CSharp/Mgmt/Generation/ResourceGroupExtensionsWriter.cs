// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        public ResourceGroupExtensionsWriter(CodeWriter writer, Output.ResourceGroupExtensions resourceGroupExtensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, resourceGroupExtensions, context, typeof(ResourceGroup))
        {
        }

        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override string ExtensionOperationVariableName => "resourceGroup";

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();

                    WriteExtensionClientGet();

                    // Write other orphan operations with the parent of ResourceGroup
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        WriteMethodWrapper(clientOperation, true);
                        WriteMethodWrapper(clientOperation, false);
                    }
                }
            }
        }
    }
}
