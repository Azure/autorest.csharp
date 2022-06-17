// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output;
using AutoRest.CSharp.MgmtTest.Output.Mock;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal class ResourceMockTestWriter : MgmtMockTestBaseWriter
    {
        private ResourceMockTest This { get; }

        public ResourceMockTestWriter(CodeWriter writer, ResourceMockTest resourceMockTest) : base(writer, resourceMockTest)
        {
            This = resourceMockTest;
        }

        protected override void WriteTestMethodBody(MockTestCase testCase)
        {
            _writer.Line($"// Example: {testCase.Name}");

            _writer.Line();
            var resourceName = WriteGetResource(This.Resource, testCase);

            WriteTestOperation(resourceName, testCase);
        }
    }
}
