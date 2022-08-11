// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal class Sample : MockTestCase
    {
        public Sample(MockTestCase testCase) : base(testCase.OperationId, testCase.Carrier, testCase.Operation, testCase._example)
        {
        }

        protected override ExampleValue ReplacePathParameterValue(string serializedName, CSharpType type, ExampleValue value)
        {
            // the samples do not override anything
            return value;
        }
    }
}
