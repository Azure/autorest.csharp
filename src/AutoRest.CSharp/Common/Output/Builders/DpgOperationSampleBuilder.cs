// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Samples.Models;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class DpgOperationSampleBuilder
    {
        private readonly LowLevelClient? _client;
        private readonly IReadOnlyList<InputClientExample>? _clientExamples;
        private readonly INamedTypeSymbol? _existingType;

        public DpgOperationSampleBuilder()
        {
            _client = null;
            _clientExamples = null;
            _existingType = null;
        }

        public DpgOperationSampleBuilder(LowLevelClient client, IReadOnlyList<InputClientExample>? clientExamples, INamedTypeSymbol? existingType)
        {
            _client = client;
            _clientExamples = clientExamples;
            _existingType = existingType;
        }

        public IReadOnlyList<DpgOperationSample> BuildSamples(InputOperation operation, MethodSignature protocolMethodSignature, MethodSignature? convenienceMethodSignature, InputType? requestBodyType, CSharpType? responseType, CSharpType? pageItemType)
        {
            // we do not generate any sample if these variables are null
            // they are only null when HLC calling methods in this class
            if (_client is null || _clientExamples is null)
            {
                return Array.Empty<DpgOperationSample>();
            }

            var shouldGenerateSample = ShouldGenerateSample(_client, protocolMethodSignature);
            if (!shouldGenerateSample)
            {
                return Array.Empty<DpgOperationSample>();
            }

            // short version samples
            var shouldGenerateShortVersion = ShouldGenerateShortVersion(protocolMethodSignature, convenienceMethodSignature);
            var clientInvocationChain = GetClientInvocationChain(_client);
            var samples = new List<DpgOperationSample>();
            foreach (var (exampleKey, clientParameters) in _clientExamples)
            {
                if (!shouldGenerateShortVersion && exampleKey != ExampleMockValueBuilder.ShortVersionMockExampleKey)
                {
                    continue; // skip the short example when we decide not to generate it
                }

                if (operation.Examples.FirstOrDefault(e => e.Key == exampleKey) is {} operationExample)
                {
                    // add protocol method sample
                    samples.Add(new(clientInvocationChain, protocolMethodSignature, requestBodyType, responseType, pageItemType, clientParameters, operationExample, false, exampleKey));

                    // add convenience method sample
                    if (convenienceMethodSignature != null && convenienceMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    {
                        samples.Add(new(clientInvocationChain, convenienceMethodSignature, requestBodyType, responseType, pageItemType, clientParameters, operationExample, true, exampleKey));
                    }
                }
            }

            return samples;
        }

        /// <summary>
        /// Get the methods to be called to get the client, it should be like `Client(...).GetXXClient(..).GetYYClient(..)`.
        /// It's composed of a constructor of non-subclient and a optional list of subclient factory methods.
        /// </summary>
        /// <returns></returns>
        private static IReadOnlyList<MethodSignatureBase> GetClientInvocationChain(LowLevelClient client)
        {
            var callChain = new Stack<MethodSignatureBase>();
            while (client.FactoryMethod != null)
            {
                callChain.Push(client.FactoryMethod.Signature);
                if (client.ParentClient == null)
                {
                    break;
                }

                client = client.ParentClient;
            }
            callChain.Push(client.GetEffectiveCtor()!);

            return callChain.ToArray();
        }

        // TODO -- this needs a refactor when we consolidate things around customization code https://github.com/Azure/autorest.csharp/issues/3370
        private bool ShouldGenerateShortVersion(MethodSignature protocolMethodSignature, MethodSignatureBase? convenienceMethodSignature)
        {
            if (convenienceMethodSignature is not null)
            {
                if (convenienceMethodSignature.Parameters.Count == protocolMethodSignature.Parameters.Count - 1 &&
                    !convenienceMethodSignature.Parameters.Last().Type.Equals(typeof(CancellationToken)))
                {
                    bool allEqual = true;
                    for (int i = 0; i < convenienceMethodSignature.Parameters.Count; i++)
                    {
                        if (!convenienceMethodSignature.Parameters[i].Type.Equals(protocolMethodSignature.Parameters[i].Type))
                        {
                            allEqual = false;
                            break;
                        }
                    }
                    if (allEqual)
                    {
                        return false;
                    }
                }
            }
            else if (_existingType is {} && SourceInputHelper.TryGetExistingMethod(_existingType, protocolMethodSignature, out _))
            {
                return false;
            }

            return true;
        }

        private static bool ShouldGenerateSample(LowLevelClient client, MethodSignature protocolMethodSignature)
            => protocolMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                !protocolMethodSignature.Attributes.Any(a => a.Type.Equals(typeof(ObsoleteAttribute))) &&
                !client.IsMethodSuppressed(protocolMethodSignature) &&
                (client.IsSubClient || client.GetEffectiveCtor() is not null);
    }
}
