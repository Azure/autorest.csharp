// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Extensions;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Sample;
using Azure.ResourceManager;

namespace AutoRest.CSharp.MgmtTest.Generation.Sample
{
    internal class MgmtSampleWriter : MgmtTestWriterBase<MgmtSampleProvider>
    {
        private MockTestCase testCase => This.Sample;

        public MgmtSampleWriter(MgmtSampleProvider sample) : base(sample)
        {
        }

        public override void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    WriteImplementation();
                }
            }
        }

        private void WriteImplementation()
        {
            _writer.Line($"// {This.Sample.Name}");
            _writer.Line($"[NUnit.Framework.TestCase]");
            using (_writer.WriteMethodDeclaration(testCase.GetMethodSignature(false)))
            {
                WriteSampleSteps();
            }
        }

        private void WriteSampleSteps()
        {
            // Write claimers
            _writer.Line($"// this example is just showing the usage of \"{testCase.OperationId}\" operation, for the dependent resources, they will have to be created separately.");
            _writer.Line();

            var clientVar = WriteGetArmClient();
            // TODO -- maybe add a switch here?
            var collectionVar = WriteGetCollection(clientVar);
            var resourceVar = WriteSampleOperation(clientVar, collectionVar);

            _writer.Line($"await {typeof(System.Threading.Tasks.Task)}.Run(() => _ = string.Empty);");
        }

        private CodeWriterDeclaration WriteGetArmClient()
        {
            _writer.Line($"// authenticate your client");
            var clientVar = new CodeWriterDeclaration("client");
            _writer.UseNamespace("Azure.Identity");
            _writer.Line($"{typeof(ArmClient)} {clientVar:D} = new {typeof(ArmClient)}(new DefaultAzureCredential());");
            _writer.Line();

            return clientVar;
        }

        private CodeWriterDeclaration? WriteGetCollection(CodeWriterDeclaration clientVar)
        {
            if (testCase.Carrier is not ResourceCollection collection)
                return null;

            var parent = testCase.Parent;
            Debug.Assert(parent != null);
            _writer.Line($"// we assume you already have this {parent.Type.Name} created");
            _writer.Line($"// if you do not know how to create {parent.Type.Name}, please refer to the document of {parent.Type.Name}");
            var parentVar = WriteGetResource(parent, testCase, $"{clientVar}");

            var resourceName = collection.Resource.ResourceName;
            // now we have the parent resource, get the collection from that resource
            // TODO -- we might should look this up inside the code project for correct method name
            var getResourceCollectionMethodName = $"Get{resourceName.ResourceNameToPlural()}";
            var collectionVar = new CodeWriterDeclaration("collection");
            _writer.Line($"// get the collection of this {collection.Resource.Type.Name}");
            _writer.Append($"{collection.Type.Name} {collectionVar:D} = {parentVar}.{getResourceCollectionMethodName}(");
            var parameterValues = testCase.ParameterValueMapping;
            // iterate over the ResourceCollection.ExtraConstructorParameters to get extra parameters for the GetCollection method
            foreach (var extraParameter in collection.ExtraConstructorParameters)
            {
                if (parameterValues.TryGetValue(extraParameter.Name, out var value))
                {
                    _writer.AppendExampleParameterValue(extraParameter, value);
                    _writer.AppendRaw(",");
                }
            }
            _writer.RemoveTrailingComma();
            _writer.LineRaw(");");

            _writer.Line();

            return collectionVar;
        }

        private CodeWriterDeclaration WriteSampleOperation(CodeWriterDeclaration clientVar, CodeWriterDeclaration? collectionVar)
        {
            // TODO
            return new CodeWriterDeclaration("");
        }
    }
}
