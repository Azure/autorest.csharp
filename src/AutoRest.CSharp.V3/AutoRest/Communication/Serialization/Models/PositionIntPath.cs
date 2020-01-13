// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.AutoRest.Communication.Serialization.Models
{
    internal class PositionIntPath : IPosition
    {
        public int[]? Path { get; set; } = null;

        public override string ToString() => $@"{{{Path.TextOrEmpty($@"""path"":{Path.ToJsonArray()}")}}}";
    }
}
