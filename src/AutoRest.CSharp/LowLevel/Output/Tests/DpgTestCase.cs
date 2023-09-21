// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Samples.Models;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgTestCase : DpgOperationSample
    {
        public DpgTestCase(LowLevelClient client, LowLevelClientMethod method, IEnumerable<InputParameterExample> inputClientParameterExamples, InputOperationExample inputOperationExample, bool isConvenienceSample, string exampleKey) : base(client, method, inputClientParameterExamples, inputOperationExample, isConvenienceSample, exampleKey)
        {
        }

        protected override IReadOnlyList<MethodSignatureBase> GetClientInvocationChain(LowLevelClient client)
        {
            var chain = base.GetClientInvocationChain(client).ToArray();

            return chain;
        }
    }
}
