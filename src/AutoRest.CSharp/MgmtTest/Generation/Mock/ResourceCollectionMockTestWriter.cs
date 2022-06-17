// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.MgmtTest.Generation.Mock
{
    internal class ResourceCollectionMockTestWriter : MgmtMockTestBaseWriter
    {
        private ResourceCollectionMockTest This { get; }
        public ResourceCollectionMockTestWriter(CodeWriter writer, ResourceCollectionMockTest resourceCollectionTest) : base(writer, resourceCollectionTest)
        {
            This = resourceCollectionTest;
        }

        protected override void WriteTestMethodBody(MockTestCase testCase)
        {
            _writer.Line($"// Example: {testCase.Name}");

            var parents = This.ResourceCollection.Resource.Parent();
            // TODO -- find a way to determine which parent to use. Only for prototype, here we use the first
            var parent = parents.First();

            _writer.Line();
            var collectionName = WriteGetCollection(parent, testCase);

            WriteTestOperation(collectionName, testCase);
        }

        protected CodeWriterDeclaration WriteGetCollection(MgmtTypeProvider parent, MockTestCase testCase)
        {
            var parentVar = WriteGetResource(parent, testCase);

            // now we have the parent resource, get the collection from that resource
            // TODO -- we might should look this up inside the code project for correct method name
            var getResourceCollectionMethodName = $"Get{This.ResourceCollection.Resource.ResourceName.ResourceNameToPlural()}";
            var collectionName = new CodeWriterDeclaration("collection");
            _writer.Append($"var {collectionName:D} = {parentVar}.{getResourceCollectionMethodName}(");
            var parameterValues = testCase.ParameterValueMapping;
            // iterate over the ResourceCollection.ExtraConstructorParameters to get extra parameters for the GetCollection method
            foreach (var extraParameter in This.ResourceCollection.ExtraConstructorParameters)
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
