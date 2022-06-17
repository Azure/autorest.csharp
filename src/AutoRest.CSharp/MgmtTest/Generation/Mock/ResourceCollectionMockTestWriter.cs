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

            // we will always use the Async version of methods
            if (testCase.ClientOperation.IsPagingOperation)
            {
                _writer.Append($"await foreach (var _ in ");
                WriteTestMethodInvocation(collectionName, testCase);
                using (_writer.Scope($")"))
                { }
            }
            else
            {
                _writer.Append($"await ");
                WriteTestMethodInvocation(collectionName, testCase);
                _writer.LineRaw(";");
            }
        }

        protected CodeWriterDeclaration WriteGetParent(MgmtTypeProvider parent, MockTestCase testCase)
            => parent switch
            {
                Resource parentResource => WriteGetResourceParent(parentResource, testCase),
                MgmtExtensions parentExtension => WriteGetExtensionParent(parentExtension, testCase),
                _ => throw new InvalidOperationException($"Unknown parent {parent.GetType()}"),
            };

        protected CodeWriterDeclaration WriteGetResourceParent(Resource parentResource, MockTestCase testCase)
        {
            var idVar = new CodeWriterDeclaration($"{parentResource.Type.Name}Id".ToVariableName());
            _writer.Append($"var {idVar:D} = {parentResource.Type}.CreateResourceIdentifier(");
            foreach (var value in testCase.ComposeResourceIdentifierParameterValues(parentResource.RequestPath))
            {
                _writer.Append(value).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
            var parentVar = new CodeWriterDeclaration(parentResource.Type.Name.ToVariableName());
            _writer.Line($"var {parentVar:D} = GetArmClient().Get{parentResource.Type.Name}({idVar});");

            return parentVar;
        }

        protected CodeWriterDeclaration WriteGetExtensionParent(MgmtExtensions parentExtension, MockTestCase testCase)
        {
            var parentVar = new CodeWriterDeclaration(parentExtension.ResourceName.ToVariableName());
            if (parentExtension == MgmtContext.Library.TenantExtensions)
            {
                _writer.UseNamespace("System.Linq");
                _writer.Line($"var {parentVar:D} = GetArmClient().GetTenants().First();");
            }
            else
            {
                var idVar = new CodeWriterDeclaration($"{parentExtension.ArmCoreType.Name}Id".ToVariableName());
                _writer.Append($"var {idVar:D} = {parentExtension.ArmCoreType}.CreateResourceIdentifier(");
                foreach (var value in testCase.ComposeResourceIdentifierParameterValues(parentExtension.ContextualPath))
                {
                    _writer.Append(value).AppendRaw(",");
                }
                _writer.RemoveTrailingComma();
                _writer.LineRaw(");");
                _writer.Line($"var {parentVar:D} = GetArmClient().Get{parentExtension.ArmCoreType.Name}({idVar});");
            }

            return parentVar;
        }

        protected CodeWriterDeclaration WriteGetCollection(MgmtTypeProvider parent, MockTestCase testCase)
        {
            var parentVar = WriteGetParent(parent, testCase);

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

        protected void WriteTestMethodInvocation(CodeWriterDeclaration collectionName, MockTestCase testCase)
        {
            var clientOperation = testCase.ClientOperation;
            var methodName = CreateMethodName(clientOperation.Name);
            _writer.Append($"{collectionName}.{methodName}(");
            foreach (var parameter in clientOperation.MethodParameters)
            {
                if (testCase.ParameterValueMapping.TryGetValue(parameter.Name, out var parameterValue))
                {
                    _writer.AppendExampleParameterValue(parameter, parameterValue);
                    _writer.AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")");
        }
    }
}
