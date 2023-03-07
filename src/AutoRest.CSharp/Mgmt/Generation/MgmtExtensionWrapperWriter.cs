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
    internal class MgmtExtensionWrapperWriter : MgmtClientBaseWriter
    {
        private MgmtExtensionWrapper _wrapper;
        public MgmtExtensionWrapperWriter(MgmtExtensionWrapper extensionsWrapper) : base(new CodeWriter(), extensionsWrapper)
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
                    // TODO -- temporarily removed
                    //ArmClientExtensions armClientExtensions => new ArmClientExtensionsWriter(_writer, armClientExtensions),
                    _ when extension.ArmCoreType == typeof(ArmResource) => new ArmResourceExtensionWriter(_writer, extension),
                    _ => new MgmtExtensionWriter(_writer, extension)
                };
                extensionWriter.WriteImplementations();
                _writer.Line();
            }
        }
    }
}
