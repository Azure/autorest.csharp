// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Management;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ManagementGroupExtensionsWriter : MgmtExtensionWriter
    {
        public ManagementGroupExtensionsWriter(CodeWriter writer, ManagementGroupExtensions extensions, BuildContext<MgmtOutputLibrary> context) : base(writer, extensions, context)
        {
        }

        protected override string Description => "A class to add extension methods to ManagementGroup.";

        protected override string ExtensionOperationVariableName => "managementGroup";

        protected override Type ExtensionOperationVariableType => typeof(ManagementGroup);

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
                }
            }
        }
    }
}
