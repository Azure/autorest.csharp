// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.MgmtTest.AutoRest
{
    internal class MgmtTestOutputLibrary
    {
        private MockTestDefinitionModel _mockTestModel;
        public MgmtTestOutputLibrary(CodeModel codeModel, SourceInputModel sourceInputModel)
        {
            MgmtContext.Initialize(new BuildContext<MgmtOutputLibrary>(codeModel, sourceInputModel));

            // force trigger the model initialization
            foreach (var _ in MgmtContext.Library.ResourceSchemaMap)
            {
            }

            _mockTestModel = MgmtContext.CodeModel.TestModel!.MockTest;
        }

        private Dictionary<MgmtTypeProvider, List<MockTestCase>>? _mockTestCases;
        internal Dictionary<MgmtTypeProvider, List<MockTestCase>> MockTestCases => _mockTestCases ??= EnsureMockTestCases();

        private Dictionary<MgmtTypeProvider, List<MockTestCase>> EnsureMockTestCases()
        {
            var result = new Dictionary<MgmtTypeProvider, List<MockTestCase>>();
            foreach (var exampleGroup in _mockTestModel.ExampleGroups)
            {
                var withSuffix = exampleGroup.Examples.Count > 1;
                foreach (var example in exampleGroup.Examples)
                {
                    // we need to find which resource or resource collection this test case belongs
                    var operationId = exampleGroup.OperationId;
                    var exampleOperations = FindCarriersFromOperationId(operationId);
                    foreach (var exampleOperation in exampleOperations)
                    {
                        // if the provider is a resource, the owner is the resource (this includes the ResourceCollection). Otherwise, for instance the extensions, use the ClientOperation.Resource as its owner. Use provider as fallback
                        // This controls which test class this test operation will go to
                        var carrier = exampleOperation.Carrier;
                        var owner = carrier is Resource ? carrier : (exampleOperation.Operation.Resource ?? carrier);
                        result.AddInList(owner, new MockTestCase(operationId, carrier, exampleOperation.Operation, example));
                    }
                }
            }

            return result;
        }

        private IEnumerable<ExampleOperation> FindCarriersFromOperationId(string operationId)
        {
            // it is possible that an operationId does not exist in the MgmtOutputLibrary, because some of the operations are removed by design. For instance, `Operations_List`.
            if (EnsureOperationIdToProviders().TryGetValue(operationId, out var result))
                return result;
            return Enumerable.Empty<ExampleOperation>();
        }

        private Dictionary<string, List<ExampleOperation>>? _operationIdToProviders;
        private Dictionary<string, List<ExampleOperation>> EnsureOperationIdToProviders()
        {
            if (_operationIdToProviders != null)
                return _operationIdToProviders;

            _operationIdToProviders = new Dictionary<string, List<ExampleOperation>>();
            // iterate all the resources and resource collection
            var mgmtProviders = MgmtContext.Library.ArmResources.Cast<MgmtTypeProvider>()
                .Concat(MgmtContext.Library.ResourceCollections)
                .Concat(MgmtContext.Library.ExtensionWrapper.Extensions);
            foreach (var provider in mgmtProviders)
            {
                foreach (var clientOperation in provider.AllOperations)
                {
                    // we skip the convenient methods, AddTag, SetTags, DeleteTags, etc
                    if (clientOperation.IsConvenientOperation)
                        continue;
                    foreach (var restOperation in clientOperation)
                    {
                        _operationIdToProviders.AddInList(restOperation.OperationId, new ExampleOperation(provider, clientOperation));
                    }
                }
            }

            return _operationIdToProviders;
        }

        private MgmtMockTestProvider<MgmtExtensionsWrapper>? _extensionWrapperMockTest;
        public MgmtMockTestProvider<MgmtExtensionsWrapper> ExtensionWrapperMockTest => _extensionWrapperMockTest ??= new MgmtMockTestProvider<MgmtExtensionsWrapper>(MgmtContext.Library.ExtensionWrapper, Enumerable.Empty<MockTestCase>());

        private IEnumerable<MgmtMockTestProvider<MgmtExtensions>>? _extensionMockTests;
        public IEnumerable<MgmtMockTestProvider<MgmtExtensions>> ExtensionMockTests => _extensionMockTests ??= EnsureMockTestProviders<MgmtExtensions>();

        private IEnumerable<MgmtMockTestProvider<ResourceCollection>>? _resourceCollectionMockTests;
        public IEnumerable<MgmtMockTestProvider<ResourceCollection>> ResourceCollectionMockTests => _resourceCollectionMockTests ??= EnsureMockTestProviders<ResourceCollection>();

        private IEnumerable<MgmtMockTestProvider<Resource>>? _resourceMockTests;
        public IEnumerable<MgmtMockTestProvider<Resource>> ResourceMockTests => _resourceMockTests ??= EnsureMockTestProviders<Resource>();

        private IEnumerable<MgmtMockTestProvider<TProvider>> EnsureMockTestProviders<TProvider>() where TProvider : MgmtTypeProvider
        {
            foreach ((var owner, var testCases) in MockTestCases)
            {
                if (owner.GetType() == typeof(TProvider))
                    yield return new MgmtMockTestProvider<TProvider>((TProvider)owner, testCases);
            }
        }
    }
}
