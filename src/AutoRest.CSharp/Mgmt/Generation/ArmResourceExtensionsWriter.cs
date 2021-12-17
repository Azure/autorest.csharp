// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmResourceExtensionsWriter : MgmtExtensionWriter
    {
        public ArmResourceExtensionsWriter(CodeWriter writer, Output.MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context) : base(writer, extensions, context)
        {
        }

        protected override string Description => "A class to add extension methods to ArmResource.";
        protected override string ExtensionOperationVariableName => "armResource";

        protected override Type ExtensionOperationVariableType => typeof(ArmResource);

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();
                }
            }
        }
    }
}
