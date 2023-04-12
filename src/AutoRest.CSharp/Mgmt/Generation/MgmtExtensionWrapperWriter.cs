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
        private MgmtExtensionWrapper This { get; }

        public MgmtExtensionWrapperWriter(MgmtExtensionWrapper extensionWrapper) : base(new CodeWriter(), extensionWrapper)
        {
            This = extensionWrapper;
        }

        protected override void WritePrivateHelpers()
        {
            foreach (var extensionClient in This.ExtensionClients)
            {
                if (extensionClient.IsEmpty)
                    continue;

                foreach (var method in extensionClient.FactoryMethods)
                {
                    _writer.Line();

                    using (_writer.WriteMethodDeclaration(method.Signature))
                    {
                        method.MethodBodyImplementation(_writer);
                    }
                }
            }

            base.WritePrivateHelpers();
        }

        protected internal override void WriteImplementations()
        {
            WritePrivateHelpers();

            foreach (var extension in This.Extensions)
            {
                if (extension.IsEmpty)
                    continue;

                MgmtExtensionWriter.GetWriter(_writer, extension).WriteImplementations();
                _writer.Line();
            }
        }
    }
}
