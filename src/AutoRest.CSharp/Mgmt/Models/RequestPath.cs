// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal struct RequestPath : IEquatable<RequestPath>, IReadOnlyList<Segment>
    {
        private IReadOnlyList<Segment> segments;
        private string _stringValue;

        public RequestPath(ClientMethod clientMethod) : this(clientMethod.RestClientMethod)
        {
        }

        public RequestPath(RestClientMethod method)
        {
            segments = method.Request.PathSegments
                .SelectMany(pathSegment => ParsePathSegment(pathSegment))
                .ToList();
            _stringValue = $"/{string.Join('/', segments)}";
        }

        public int Count => segments.Count;

        public Segment this[int index] => segments[index];

        public bool IsChildOf(RequestPath other)
        {
            if (other.Count >= Count)
                return false;
            for (int i = 0; i < other.Count; i++)
            {
                if (!other[i].Equals(this[i]))
                    return false;
            }
            return true;
        }

        private static IEnumerable<Segment> ParsePathSegment(PathSegment pathSegment)
        {
            // we explicitly skip the `uri` variable in the path (which should be `endpoint`)
            if (pathSegment.Value.Type.IsFrameworkType &&
                pathSegment.Value.Type.FrameworkType == typeof(Uri))
                return Enumerable.Empty<Segment>();
            if (pathSegment.Value.IsConstant)
            {
                // in this case, we have a constant in this path segment, which might contains slashes
                // we need to split it into real segments
                // For instance we might get "/providers/Microsoft.Storage/blobServices/default" here
                // we will never get null in this constant since it comes from request path
                var type = pathSegment.Value.Constant.Type;
                var value = pathSegment.Value.Constant.Value!;
                // if this is a string type
                if (type.IsFrameworkType && type.FrameworkType == typeof(string))
                {
                    return ((string)value).Split('/', StringSplitOptions.RemoveEmptyEntries).Select(s => new Segment(s));
                }
            }
            // this is either a constant but not string type, or it is not a constant, we just keep the information in this path segment
            return new Segment(pathSegment.Value).SingleItemAsIEnumerate();
        }

        public bool Equals(RequestPath other)
        {
            return this._stringValue == other._stringValue;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (RequestPath)obj;
            return other.Equals(this);
        }

        public IEnumerator<Segment> GetEnumerator() => segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => segments.GetEnumerator();

        public override int GetHashCode() => _stringValue.GetHashCode();

        public override string? ToString() => _stringValue;
    }
}
