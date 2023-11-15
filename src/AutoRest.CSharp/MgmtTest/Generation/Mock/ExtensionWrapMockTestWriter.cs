// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Output.Mock;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal class ExtensionWrapMockTestWriter : MgmtMockTestBaseWriter<MgmtExtensionWrapper>
    {
        private IEnumerable<MgmtMockTestProvider<MgmtExtension>> _extensionTests;
        public ExtensionWrapMockTestWriter(MgmtMockTestProvider<MgmtExtensionWrapper> testWrapper, IEnumerable<MgmtMockTestProvider<MgmtExtension>> extensionTests, TypeFactory typeFactory) : base(testWrapper, typeFactory)
        {
            _extensionTests = extensionTests;
        }

        protected override void WriteTestMethods()
        {
            foreach (var extensionTest in _extensionTests)
            {
                var extensionWriter = new ExtensionMockTestWriter(_writer, extensionTest, _typeFactory);
                extensionWriter.Write();
            }

            _writer.Line();
        }
    }
}
