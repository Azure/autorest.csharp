// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;
using NUnit.Framework;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgTestCase : DpgOperationSample
    {
        private readonly DpgTestBaseProvider _testBaseProvider;
        public DpgTestCase(DpgOperationSample sample, DpgTestBaseProvider testBase) : base(sample._client, sample._method, sample._inputClientParameterExamples, sample._inputOperationExample, sample.IsConvenienceSample, sample.ExampleKey)
        {
            _testBaseProvider = testBase;
        }

        //protected override IReadOnlyList<MethodSignatureBase> GetClientInvocation()
        //{
        //    var chain = base.GetClientInvocation().ToArray();

        //    // get the root client
        //    var client = Client;
        //    while (client.ParentClient != null)
        //    {
        //        client = client.ParentClient;
        //    }
        //    chain[0] = _testBaseProvider.CreateClientMethods[client];

        //    return chain;
        //}

        //protected override string GetMethodName(bool isAsync)
        //{
        //    var builder = new StringBuilder().Append(OperationMethodSignature.Name);
        //    if (IsAllParametersUsed)
        //    {
        //        builder.Append("_AllParameters");
        //    }
        //    if (IsConvenienceSample)
        //    {
        //        builder.Append("_Convenience");
        //    }
        //    if (isAsync)
        //    {
        //        builder.Append("_Async");
        //    }
        //    return builder.ToString();
        //}

        //protected override CSharpAttribute[] Attributes => new[] { new CSharpAttribute(typeof(TestAttribute)), new CSharpAttribute(typeof(IgnoreAttribute), "Skipping this test case because this is only for scaffolding the test cases") };
    }
}
