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
    /// <summary>
    /// A <see cref="RequestPath"/> represents a parsed request path in the swagger which corresponds to an operation. For instance, `/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines`
    /// </summary>
    internal struct RequestPath : IEquatable<RequestPath>, IReadOnlyList<Segment>
    {
        /// <summary>
        /// This is a placeholder of request path for "any" resources in other RPs
        /// </summary>
        public static readonly RequestPath Any = new(new[] { new Segment("*") });
        /// <summary>
        /// The <see cref="RequestPath"/> of a resource group resource
        /// </summary>
        public static readonly RequestPath ResourceGroup = new(new[] {
            new Segment("subscriptions"),
            new Segment(new Reference("subscriptionId", typeof(string)), true, true),
            new Segment("resourceGroups"),
            new Segment(new Reference("resourceGroupName", typeof(string)), true, true)
        });

        /// <summary>
        /// The <see cref="RequestPath"/> of a subscription resource
        /// </summary>
        public static readonly RequestPath Subscription = new(new[] {
            new Segment("subscriptions"),
            new Segment(new Reference("subscriptionId", typeof(string)), true, true)
        });

        /// <summary>
        /// The <see cref="RequestPath"/> of tenants
        /// </summary>
        public static readonly RequestPath Tenant = new(new Segment[] { });

        /// <summary>
        /// The <see cref="RequestPath"/> of a management group resource
        /// </summary>
        public static readonly RequestPath ManagementGroup = new(new[] {
            new Segment("providers"),
            new Segment("Microsoft.Management"),
            new Segment("managementGroups"),
            // We use strict = false because we usually see the name of management group is different in different RPs. Some of them are groupId, some of them are groupName, etc
            new Segment(new Reference("managementGroupId", typeof(string)), true, false)
        });

        private IReadOnlyList<Segment> _segments;

        /// <summary>
        /// Constructs the <see cref="RequestPath"/> instance using the information in a <see cref="RestClientMethod"/>
        /// Only the information about request path is used, other information, like HttpMethod is not used.
        /// This is based on the facts that the paths of different operations under the same path are the same - they could have different non-path parameters, but path parameters must be the same
        /// </summary>
        /// <param name="method"></param>
        public RequestPath(RestClientMethod method)
        {
            var segments = method.Request.PathSegments
                .SelectMany(pathSegment => ParsePathSegment(pathSegment))
                .ToList();
            _segments = CheckByIdPath(segments);
            SerializedPath = method.Operation.GetHttpPath();
        }

        private static IReadOnlyList<Segment> CheckByIdPath(IReadOnlyList<Segment> segments)
        {
            // if this is a byId request path, we need to make it strict, since it might be accidentally to be any scope request path's parent
            if (segments.Count != 1)
                return segments;
            var first = segments.First();
            if (first.IsConstant)
                return segments;
            if (!first.SkipUrlEncoding)
                return segments;

            // this is a ById request path
            return new List<Segment> { new Segment(first.Reference, first.Escape, true) };
        }

        public bool IsById => Count == 1 && this.First().SkipUrlEncoding;

        /// <summary>
        /// Constructs the <see cref="RequestPath"/> instance using a collection of <see cref="Segment"/>
        /// This is used for the request path that does not come from the swagger document, or an incomplete request path
        /// </summary>
        /// <param name="segments"></param>
        public RequestPath(IEnumerable<Segment> segments)
        {
            _segments = segments.ToArray();
            SerializedPath = Segment.BuildSerializedSegments(segments);
        }

        /// <summary>
        /// The raw request path of this <see cref="RequestPath"/> instance
        /// </summary>
        public string SerializedPath { get; }

        /// <summary>
        /// Check if this <see cref="RequestPath"/> is the ancestor (aka prefix) of <code other/>
        /// Note that this.IsAncestorOf(this) will return false which indicates that this method is testing the "proper ancestor" like a proper subset.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsAncestorOf(RequestPath other)
        {
            // To be the parent of other, you must at least be shorter than other.
            if (other.Count <= Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                // we need the segment to be identical when strict is true (which is the default value)
                // when strict is false, we also need the segment to be identical if it is constant.
                // but if it is a reference, we only require they have the same type, do not require they have the same variable name.
                // This case happens a lot during the management group parent detection - different RP calls this different things
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Trim this from the other and return the <see cref="RequestPath"/> that remain.
        /// The result is "other - this" by removing this as a prefix of other.
        /// If this == other, return empty request path
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">if this.IsAncestorOf(other) is false</exception>
        public RequestPath TrimAncestorFrom(RequestPath other)
        {
            if (this == other)
                return RequestPath.Tenant;
            if (!this.IsAncestorOf(other))
                throw new InvalidOperationException($"Request path {this} is not parent of {other}");
            // this is a parent, we can safely just return from the length of this
            return new RequestPath(other._segments.Skip(this.Count));
        }

        /// <summary>
        /// Trim the scope out of this request path.
        /// If this is already a scope path, return the empty request path, aka the RequestPath.Tenant
        /// </summary>
        /// <returns></returns>
        public RequestPath TrimScope()
        {
            var scope = this.GetScopePath();
            if (scope == this)
                return Tenant; // if myself is a scope path, we return the empty path after the trim.
            return scope.TrimAncestorFrom(this);
        }

        public RequestPath Append(RequestPath other)
        {
            return new RequestPath(this._segments.Concat(other._segments));
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
            return new Segment(pathSegment.Value, pathSegment.Escape).AsIEnumerable();
        }

        public int Count => _segments.Count;

        public Segment this[int index] => _segments[index];

        public bool Equals(RequestPath other)
        {
            if (Count != other.Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

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
