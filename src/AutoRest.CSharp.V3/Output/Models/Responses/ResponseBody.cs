// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal abstract class ResponseBody
    {
        public abstract CSharpType Type { get; }
    }
}
