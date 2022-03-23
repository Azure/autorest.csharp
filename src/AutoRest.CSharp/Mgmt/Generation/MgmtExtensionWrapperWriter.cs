// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtExtensionWrapperWriter : MgmtClientBaseWriter
    {
        private MgmtExtensionsWrapper _wrapper;
        public MgmtExtensionWrapperWriter(MgmtExtensionsWrapper extensionsWrapper) : base(new CodeWriter(), extensionsWrapper)
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
                    ArmClientExtensions armClientExtensions => new ArmClientExtensionsWriter(_writer, armClientExtensions),
                    _ => new MgmtExtensionWriter(_writer, extension)
                };
                extensionWriter.WriteImplementations();
                _writer.Line();
            }
        }
    }
}
