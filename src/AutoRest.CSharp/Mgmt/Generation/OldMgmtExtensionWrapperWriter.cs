// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class OldMgmtExtensionWrapperWriter : MgmtClientBaseWriter
    {
        private OldMgmtExtensionsWrapper _wrapper;
        public OldMgmtExtensionWrapperWriter(OldMgmtExtensionsWrapper extensionsWrapper) : base(new CodeWriter(), extensionsWrapper)
        {
            _wrapper = extensionsWrapper;
        }

        protected internal override void WriteImplementations()
        {
            foreach (var extension in _wrapper.Extensions)
            {
                if (extension.IsEmpty)
                    continue;
                var extensionWriter = extension switch
                {
                    ArmClientExtensions armClientExtensions => new OldArmClientExtensionsWriter(_writer, armClientExtensions),
                    _ when extension.ArmCoreType == typeof(ArmResource) => new OldArmResourceExtensionsWriter(_writer, extension),
                    _ => new OldMgmtExtensionWriter(_writer, extension)
                };
                extensionWriter.WriteImplementations();
                _writer.Line();
            }
        }
    }
}
