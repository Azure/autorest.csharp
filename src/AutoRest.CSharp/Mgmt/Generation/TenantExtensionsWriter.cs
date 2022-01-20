// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class TenantExtensionsWriter : MgmtExtensionWriter
    {
        public TenantExtensionsWriter(CodeWriter writer, Output.MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, extensions, context, typeof(Tenant))
        {
        }

        protected override string Description => "A class to add extension methods to Tenant.";
        protected override string ExtensionOperationVariableName => "tenant";

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();

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
