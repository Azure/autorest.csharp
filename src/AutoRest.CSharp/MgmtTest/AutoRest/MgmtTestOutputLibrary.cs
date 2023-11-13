// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Mock;
using AutoRest.CSharp.MgmtTest.Output.Samples;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.MgmtTest.AutoRest
{
    internal class MgmtTestOutputLibrary
    {
        private readonly IReadOnlyList<InputClient> _mockTestModel;
        private readonly MgmtTestConfiguration _mgmtTestConfiguration;
        public MgmtTestOutputLibrary(InputNamespace inputNamespace)
        {
            _mockTestModel = inputNamespace.Clients;
            _mgmtTestConfiguration = Configuration.MgmtTestConfiguration!;
        }

        private IEnumerable<MgmtSampleProvider>? _samples;
        public IEnumerable<MgmtSampleProvider> Samples => _samples ??= EnsureSamples();

        private IEnumerable<MgmtSampleProvider> EnsureSamples()
        {
            foreach ((var owner, var cases) in MockTestCases)
            {
                yield return new MgmtSampleProvider(owner, cases.Select(testCase => new Sample(testCase)));
            }
        }

        private Dictionary<MgmtTypeProvider, List<MockTestCase>>? _mockTestCases;
        internal Dictionary<MgmtTypeProvider, List<MockTestCase>> MockTestCases => _mockTestCases ??= EnsureMockTestCases();

        private Dictionary<MgmtTypeProvider, List<MockTestCase>> EnsureMockTestCases()
        {
            var result = new Dictionary<MgmtTypeProvider, List<MockTestCase>>();
            foreach (var exampleGroup in _mockTestModel)
            {
                var withSuffix = exampleGroup.Examples.Count > 1;
                foreach (var example in exampleGroup.Examples)
                {
                    // we need to find which resource or resource collection this test case belongs
                    var operationName = exampleGroup.Name;

                    // skip this operation if we find it in the `skipped-operations` configuration
                    if (_mgmtTestConfiguration.SkippedOperations.Contains(operationName))
                        continue;

                    var providerAndOperations = FindCarriersFromOperationId(operationName);
                    foreach (var providerForExample in providerAndOperations)
                    {
                        // the operations on ArmClientExtensions are the same as the tenant extension, therefore we skip it here
                        // the source code generator will never write them if it is not in arm core
                        if (providerForExample.Carrier is ArmClientExtension)
                            continue;
                        var mockTestCase = new MockTestCase(operationName, providerForExample.Carrier, providerForExample.Operation, example);
                        result.AddInList(mockTestCase.Owner, mockTestCase);
                    }
                }
            }

            return result;
        }

        private IEnumerable<MgmtTypeProviderAndOperation> FindCarriersFromOperationId(string operationId)
        {
            // it is possible that an operationId does not exist in the MgmtOutputLibrary, because some of the operations are removed by design. For instance, `Operations_List`.
            if (EnsureOperationIdToProviders().TryGetValue(operationId, out var result))
                return result;
            return Enumerable.Empty<MgmtTypeProviderAndOperation>();
        }

        private Dictionary<string, List<MgmtTypeProviderAndOperation>>? _operationNameToProviders;
        private Dictionary<string, List<MgmtTypeProviderAndOperation>> EnsureOperationIdToProviders()
        {
            if (_operationNameToProviders != null)
                return _operationNameToProviders;

            _operationNameToProviders = new Dictionary<string, List<MgmtTypeProviderAndOperation>>();
            // iterate all the resources and resource collection
            var mgmtProviders = MgmtContext.Library.ArmResources.Cast<MgmtTypeProvider>()
                .Concat(MgmtContext.Library.ResourceCollections)
                .Concat(MgmtContext.Library.ExtensionWrapper.Extensions);
            foreach (var provider in mgmtProviders)
            {
                foreach (var clientOperation in provider.AllOperations)
                {
                    // we skip the convenient methods, AddTag, SetTags, DeleteTags, etc, because they do not have a corresponding source of test data
                    if (clientOperation.IsConvenientOperation)
                        continue;
                    foreach (var restOperation in clientOperation)
                    {
                        _operationNameToProviders.AddInList(restOperation.OperationName, new MgmtTypeProviderAndOperation(provider, clientOperation));
                    }
                }
            }

            return _operationNameToProviders;
        }

        private MgmtMockTestProvider<MgmtExtensionWrapper>? _extensionWrapperMockTest;
        public MgmtMockTestProvider<MgmtExtensionWrapper> ExtensionWrapperMockTest => _extensionWrapperMockTest ??= new MgmtMockTestProvider<MgmtExtensionWrapper>(MgmtContext.Library.ExtensionWrapper, Enumerable.Empty<MockTestCase>());

        private IEnumerable<MgmtMockTestProvider<MgmtExtension>>? _extensionMockTests;
        public IEnumerable<MgmtMockTestProvider<MgmtExtension>> ExtensionMockTests => _extensionMockTests ??= EnsureMockTestProviders<MgmtExtension>();

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
