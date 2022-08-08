// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal class ResourceCollectionMockTestWriter : MgmtMockTestBaseWriter<ResourceCollection>
    {
        public ResourceCollectionMockTestWriter(MgmtMockTestProvider<ResourceCollection> resourceCollectionTest) : base(resourceCollectionTest)
        {
        }

        protected override void WriteTestMethodBody(MockTestCase testCase)
        {
            _writer.Line($"// Example: {testCase.Name}");

            _writer.Line();
            var collectionName = WriteGetCollection(testCase);

            WriteTestOperation(collectionName, testCase);
        }

        protected CodeWriterDeclaration WriteGetCollection(MockTestCase testCase)
        {
            var parent = testCase.Parent;
            Debug.Assert(parent is not null);
            var parentVar = WriteGetResource(parent, testCase);

            // now we have the parent resource, get the collection from that resource
            // TODO -- we might should look this up inside the code project for correct method name
            var getResourceCollectionMethodName = $"Get{This.Target.Resource.ResourceName.ResourceNameToPlural()}";
            var collectionName = new CodeWriterDeclaration("collection");
            _writer.Append($"var {collectionName:D} = {parentVar}.{getResourceCollectionMethodName}(");
            var parameterValues = testCase.ParameterValueMapping;
            // iterate over the ResourceCollection.ExtraConstructorParameters to get extra parameters for the GetCollection method
            foreach (var extraParameter in This.Target.ExtraConstructorParameters)
            {
                if (parameterValues.TryGetValue(extraParameter.Name, out var value))
                {
                    _writer.AppendExampleParameterValue(extraParameter, value);
                    _writer.AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw(");");

            return collectionName;
        }
    }
}
