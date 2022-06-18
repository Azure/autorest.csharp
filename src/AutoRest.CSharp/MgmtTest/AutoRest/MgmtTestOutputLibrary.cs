// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.MgmtTest.AutoRest
{
    internal class MgmtTestOutputLibrary
    {
        private MockTestDefinitionModel _mockTestModel;
        public MgmtTestOutputLibrary()
        {
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
                    var operationId = exampleGroup.Operation.OperationId!;
                    var providersAndOperations = FindTypeProvidersFromOperationId(operationId);
                    foreach ((var provider, var clientOperation) in providersAndOperations)
                    {
                        MgmtTypeProvider owner;
                        if (provider is Resource)
                            owner = provider;
                        else
                            owner = clientOperation.Resource ?? provider;
                        result.AddInList(owner, new MockTestCase(operationId, provider, clientOperation, example));
                    }
                }
            }

            return result;
        }

        private IEnumerable<(MgmtTypeProvider Provider, MgmtClientOperation ClientOperation)> FindTypeProvidersFromOperationId(string operationId)
        {
            // it is possible that an operationId does not exist in the MgmtOutputLibrary, because some of the operations are removed by design. For instance, `Operations_List`.
            if (EnsureOperationIdToProviders().TryGetValue(operationId, out var result))
                return result;
            return Enumerable.Empty<(MgmtTypeProvider Provider, MgmtClientOperation ClientOperation)>();
        }

        private Dictionary<string, List<(MgmtTypeProvider Provider, MgmtClientOperation ClientOperation)>>? _operationIdToProviders;
        private Dictionary<string, List<(MgmtTypeProvider Provider, MgmtClientOperation ClientOperation)>> EnsureOperationIdToProviders()
        {
            if (_operationIdToProviders != null)
                return _operationIdToProviders;

            _operationIdToProviders = new Dictionary<string, List<(MgmtTypeProvider, MgmtClientOperation)>>();
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
                        // TODO -- simplify the Operation.OperationId to OperationId directly once this issue resolves https://github.com/Azure/azure-sdk-tools/issues/3454
                        _operationIdToProviders.AddInList(restOperation.Operation.OperationId!, (provider, clientOperation));
                    }
                }
            }

            return _operationIdToProviders;
        }

        private IEnumerable<ResourceCollectionMockTest>? _resourceCollectionMockTests;
        public IEnumerable<ResourceCollectionMockTest> ResourceCollectionMockTests => _resourceCollectionMockTests ??= EnsureResourceCollectionMockTests();

        private IEnumerable<ResourceMockTest>? _resourceMockTests;
        public IEnumerable<ResourceMockTest> ResourceMockTests => _resourceMockTests ??= EnsureResourceMockTests();

        private IEnumerable<ResourceCollectionMockTest> EnsureResourceCollectionMockTests()
        {
            foreach ((var provider, var testCases) in MockTestCases)
            {
                if (provider.GetType() != typeof(ResourceCollection))
                    continue;

                yield return new ResourceCollectionMockTest((ResourceCollection)provider, testCases);
            }
        }

        private IEnumerable<ResourceMockTest> EnsureResourceMockTests()
        {
            foreach ((var resource, var testCases) in MockTestCases)
            {
                if (resource.GetType() != typeof(Resource))
                    continue;

                yield return new ResourceMockTest((Resource)resource, testCases);
            }
        }
    }
}
