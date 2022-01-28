// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmResourceExtensionsWriter : MgmtExtensionWriter
    {
        private MgmtExtensions This { get; }

        public ArmResourceExtensionsWriter(MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context)
            : base(extensions, context)
        {
            This = extensions;
        }

        public override void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();
                }
            }
        }
    }
}
