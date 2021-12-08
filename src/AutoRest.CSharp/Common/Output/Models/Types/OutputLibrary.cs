// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class OutputLibrary
    {
        public abstract CSharpType FindTypeForSchema(Schema schema);
        public abstract CSharpType? FindTypeByName(string originalName);
    }
}
