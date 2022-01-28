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
        public ArmResourceExtensionsWriter(Output.MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context)
            : base(extensions, context)
        {
        }

        public override void Write()
        {
            var theNamespace = IsArmCore ? "Azure.ResourceManager.Core" : Context.DefaultNamespace;
            var modifier = IsArmCore ? "abstract" : "static";
            var className = IsArmCore ? nameof(ArmResource) : TypeNameOfThis;
            using (_writer.Namespace(theNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Extension.Description}");
                using (_writer.Scope($"{Accessibility} {modifier} partial class {className}"))
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();
                }
            }
        }
    }
}
