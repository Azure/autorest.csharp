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
        public DpgTestCase(DpgOperationSample sample) : base(sample.Client, sample.Method, sample._inputClientParameterExamples, sample._inputOperationExample, sample.IsConvenienceSample, sample.ExampleKey)
        {
        }

        protected override IReadOnlyList<MethodSignatureBase> GetClientInvocationChain(LowLevelClient client)
        {
            var chain = base.GetClientInvocationChain(client).ToArray();

            return chain;
        }
    }
}
