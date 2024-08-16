// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal class Sample : MockTestCase
    {
        public Sample(MockTestCase testCase) : base(testCase.OperationId, testCase.Carrier, testCase.Operation, testCase._inputOperation, testCase._example)
        {
        }

        protected override string GetMethodName(bool hasSuffix)
            => base.GetMethodName(true); // sample will always use a full name

        protected override InputTypeExample ReplacePathParameterValue(string serializedName, CSharpType type, InputTypeExample value)
        {
            // the samples do not override anything
            return value;
        }

        public string ExampleFilepath => _example.FilePath;
    }
}
