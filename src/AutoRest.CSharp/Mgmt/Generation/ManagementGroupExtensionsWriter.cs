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
        public ManagementGroupExtensionsWriter(CodeWriter writer, ManagementGroupExtensions extensions, BuildContext<MgmtOutputLibrary> context, bool isArmCore = false)
            : base(writer, extensions, context, typeof(ManagementGroup), isArmCore)
        {
        }

        protected override string Description => IsArmCore ? "A Class representing a ManagementGroup along with the instance operations that can be performed on it." : "A class to add extension methods to ManagementGroup.";

        protected override string ExtensionOperationVariableName => IsArmCore ? "this" : "managementGroup";

        public override void Write()
        {
            var theNamespace = IsArmCore ? "Azure.ResourceManager.Management" : Context.DefaultNamespace;
            var staticKeyWord = IsArmCore ? string.Empty : "static ";
            var className = IsArmCore ? nameof(ManagementGroup) : TypeNameOfThis;
            using (_writer.Namespace(theNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} {staticKeyWord}partial class {className}"))
                {
                    WriteProviderDefaultNamespace(_writer);

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
