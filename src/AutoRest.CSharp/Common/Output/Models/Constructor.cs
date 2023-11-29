// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal class Constructor : Method
    {
        public new ConstructorSignature Signature { get; }

        public Constructor(ConstructorSignature signature, MethodBodyStatement body) : base(signature, body)
        {
            Signature = signature;
        }
    }
}
