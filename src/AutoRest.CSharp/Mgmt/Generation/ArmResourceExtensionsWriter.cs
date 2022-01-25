// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmResourceExtensionsWriter : MgmtExtensionWriter
    {
        public ArmResourceExtensionsWriter(CodeWriter writer, Output.MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context, bool isArmCore = false)
            : base(writer, extensions, context, typeof(ArmResource), isArmCore)
        {
        }

        protected override string Description => IsArmCore ? "A class representing the operations that can be performed over a specific resource." : "A class to add extension methods to ArmResource.";
        protected override string ExtensionOperationVariableName => IsArmCore ? "this" : "armResource";

        public override void Write()
        {
            var theNamespace = IsArmCore ? "Azure.ResourceManager.Core" : Context.DefaultNamespace;
            var modifier = IsArmCore ? "abstract" : "static";
            var className = IsArmCore ? nameof(ArmResource) : TypeNameOfThis;
            using (_writer.Namespace(theNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} {modifier} partial class {className}"))
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();
                }
            }
        }
    }
}
