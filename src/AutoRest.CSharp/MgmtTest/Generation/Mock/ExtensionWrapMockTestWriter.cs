// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal class ExtensionWrapMockTestWriter : MgmtMockTestBaseWriter<OldMgmtExtensionsWrapper>
    {
        private IEnumerable<MgmtMockTestProvider<OldMgmtExtensions>> _extensionTests;
        public ExtensionWrapMockTestWriter(MgmtMockTestProvider<OldMgmtExtensionsWrapper> testWrapper, IEnumerable<MgmtMockTestProvider<OldMgmtExtensions>> extensionTests) : base(testWrapper)
        {
            _extensionTests = extensionTests;
        }

        protected override void WriteTestMethods()
        {
            foreach (var extensionTest in _extensionTests)
            {
                var extensionWriter = new ExtensionMockTestWriter(_writer, extensionTest);
                extensionWriter.Write();
            }

            _writer.Line();
        }
    }
}
