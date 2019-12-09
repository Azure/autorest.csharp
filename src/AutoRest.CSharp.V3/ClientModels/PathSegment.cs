// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class PathSegment
    {
        public PathSegment(ConstantOrParameter value, bool escape, SerializationFormat format)
        {
            Value = value;
            Escape = escape;
            Format = format;
        }

        public ConstantOrParameter Value { get; }
        public bool Escape { get; }
        public SerializationFormat Format { get; }
    }
}
