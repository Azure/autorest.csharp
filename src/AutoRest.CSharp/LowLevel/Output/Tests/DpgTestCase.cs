// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;
using NUnit.Framework;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgTestCase : DpgOperationSample
    {
        private readonly DpgTestBaseProvider _testBaseProvider;
        public DpgTestCase(DpgOperationSample sample, DpgTestBaseProvider testBase) : base(sample.Client, sample.Method, sample._inputClientParameterExamples, sample._inputOperationExample, sample.IsConvenienceSample, sample.ExampleKey)
        {
            _testBaseProvider = testBase;
        }

        protected override IReadOnlyList<MethodSignatureBase> GetClientInvocationChain(LowLevelClient client)
        {
            var chain = base.GetClientInvocationChain(client).ToArray();

            // TODO -- replace this with the client factory method in test base
            chain[0] = Client.GetEffectiveCtorWithClientOptions()!;

            return chain;
        }

        protected override string GetMethodName(bool isAsync)
        {
            var builder = new StringBuilder().Append(_operationMethodSignature.Name);
            if (_useAllParameters)
            {
                builder.Append("_AllParameters");
            }
            if (IsConvenienceSample)
            {
                builder.Append("_Convenience");
            }
            if (isAsync)
            {
                builder.Append("_Async");
            }
            return builder.ToString();
        }

        protected override CSharpAttribute[] Attributes => new[] { new CSharpAttribute(typeof(TestAttribute)) };
    }
}
