// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.MgmtTest.Output.Samples;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.MgmtTest.AutoRest
{
    internal class MgmtTestOutputLibrary
    {
        private readonly InputNamespace _inputNamespace;
        private readonly HashSet<string> _skippedOperations;

        public MgmtTestOutputLibrary(InputNamespace inputNamespace)
        {
            _inputNamespace = inputNamespace;
            _skippedOperations = new HashSet<string>(Configuration.MgmtTestConfiguration?.SkippedOperations ?? []);
        }

        private IEnumerable<MgmtSampleProvider>? _samples;
        public IEnumerable<MgmtSampleProvider> Samples => _samples ??= EnsureSamples();

        private IEnumerable<MgmtSampleProvider> EnsureSamples()
        {
            var result = new Dictionary<MgmtTypeProvider, List<Sample>>();
            foreach (var client in _inputNamespace.Clients)
            {
                foreach (var inputOperation in client.Operations)
                {
                    foreach (var example in inputOperation.Examples)
                    {
                        // we need to find which resource or resource collection this test case belongs
                        var operationId = inputOperation.OperationId!;

                        // skip this operation if we find it in the `skipped-operations` configuration
                        if (_skippedOperations.Contains(operationId))
                            continue;

                        var providerAndOperations = FindCarriersFromOperationId(operationId);
                        foreach (var providerForExample in providerAndOperations)
                        {
                            // the operations on ArmClientExtensions are the same as the tenant extension, therefore we skip it here
                            // the source code generator will never write them if it is not in arm core
                            if (providerForExample.Carrier is ArmClientExtension)
                                continue;
                            var mockTestCase = new Sample(operationId, providerForExample.Carrier, providerForExample.Operation, inputOperation, example);
                            result.AddInList(mockTestCase.Owner, mockTestCase);
                        }
                    }
                }
            }

            foreach ((var owner, var cases) in result)
            {
                yield return new MgmtSampleProvider(owner, cases);
            }
        }

        private IEnumerable<MgmtTypeProviderAndOperation> FindCarriersFromOperationId(string operationId)
        {
            // it is possible that an operationId does not exist in the MgmtOutputLibrary, because some of the operations are removed by design. For instance, `Operations_List`.
            if (EnsureOperationIdToProviders().TryGetValue(operationId, out var result))
                return result;
            return Array.Empty<MgmtTypeProviderAndOperation>();
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
                        _operationNameToProviders.AddInList(restOperation.OperationId, new MgmtTypeProviderAndOperation(provider, clientOperation));
                    }
                }
            }

            return _operationNameToProviders;
        }
    }
}
