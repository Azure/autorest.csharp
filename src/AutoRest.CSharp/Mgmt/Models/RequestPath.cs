// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal struct RequestPath : IEquatable<RequestPath>, IReadOnlyList<Segment>
    {
        public static readonly RequestPath ResourceGroup = new RequestPath(new[] {
            new Segment("subscriptions"),
            new Segment(new Reference("subscriptionId", typeof(string))),
            new Segment("resourceGroups"),
            new Segment(new Reference("resourceGroupName", typeof(string)))
        });

        public static readonly RequestPath Subscription = new RequestPath(new[] {
            new Segment("subscriptions"),
            new Segment(new Reference("subscriptionId", typeof(string)))
        });

        public static readonly RequestPath Tenant = new RequestPath(new Segment[] { });

        public static readonly RequestPath ManagementGroup = new RequestPath(new[] {
            new Segment("providers"),
            new Segment("Microsoft.ManagementGroups"),
            new Segment("managementGroups"),
            new Segment(new Reference("managementGroupId", typeof(string)))
        });

        private IReadOnlyList<Segment> _segments;

        public RequestPath(RestClientMethod method)
        {
            _segments = method.Request.PathSegments
                .SelectMany(pathSegment => ParsePathSegment(pathSegment))
                .ToList();
            SerializedPath = method.Operation.GetHttpPath();
        }

        private RequestPath(IReadOnlyList<Segment> segments)
        {
            _segments = segments;
            SerializedPath = Segment.BuildSerializedSegments(segments);
        }

        public string SerializedPath { get; }

        public int Count => _segments.Count;

        public Segment this[int index] => _segments[index];

        /// <summary>
        /// Check if this <see cref="RequestPath"/> is the parent (aka prefix) of <code other/>
        /// </summary>
        /// <param name="other"></param>
        /// <param name="strict">if true, we will require the parameter name to be the same during the detection</param>
        /// <returns></returns>
        public bool IsParentOf(RequestPath other, bool strict = true)
        {
            // To be the parent of other, you must at least be shorter than other.
            if (other.Count <= Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                // we need the segment to be identical if it is constant.
                // but if it is a reference, we only require they have the same type, do not require they have the same variable name.
                // This case happens a lot during the management group parent detection - different RP calls the name of mgmt group differently
                if (!this[i].Equals(other[i], strict))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Trim this from the other and return the <see cref="Segment"/> that remain.
        /// Return null if this is not a parent of the other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IEnumerable<Segment>? TrimParentFrom(RequestPath other)
        {
            if (!this.IsParentOf(other))
                return null;
            // this is a parent, we can safely just return from the length of this
            return other._segments.Skip(this.Count);
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

        public bool Equals(RequestPath other) => SerializedPath.Equals(other.SerializedPath, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (RequestPath)obj;
            return other.Equals(this);
        }

        public IEnumerator<Segment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        public override int GetHashCode() => SerializedPath.GetHashCode();

        public override string? ToString() => SerializedPath;

        public static bool operator ==(RequestPath left, RequestPath right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RequestPath left, RequestPath right)
        {
            return !(left == right);
        }

        public static implicit operator string(RequestPath requestPath)
        {
            return requestPath.SerializedPath;
        }
    }
}
