// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Serialization;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class PathSegment
    {
        public PathSegment(RequestParameter value, bool escape, SerializationFormat format)
        {
            Value = value;
            Escape = escape;
            Format = format;
        }

        public RequestParameter Value { get; }
        public bool Escape { get; }
        public SerializationFormat Format { get; }
    }
}
