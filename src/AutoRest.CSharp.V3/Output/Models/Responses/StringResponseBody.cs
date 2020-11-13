// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class StringResponseBody: ResponseBody
    {
        public override CSharpType Type { get; } = typeof(string);
    }
}