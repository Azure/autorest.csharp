// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// A <see cref="RequestPath"/> represents a parsed request path in the swagger which corresponds to an operation. For instance, `/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines`
    /// </summary>
    internal struct RequestPath : IEquatable<RequestPath>, IReadOnlyList<Segment>
    {
        private const string _providerPath = "/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
        private const string _featurePath = "/subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features";

        internal const string ManagementGroupScopePrefix = "/providers/Microsoft.Management/managementGroups";
        internal const string ResourceGroupScopePrefix = "/subscriptions/{subscriptionId}/resourceGroups";
        internal const string SubscriptionScopePrefix = "/subscriptions";
        internal const string TenantScopePrefix = "/tenants";

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
            new Segment(new Reference("resourceGroupName", typeof(string)), true, false)
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
            : this(method.Request.PathSegments, method.Operation.GetHttpPath())
        {
        }

        public static RequestPath FromPathSegments(PathSegment[] pathSegments, string httpPath)
        {
            return new RequestPath(pathSegments, httpPath);
        }

        private RequestPath(PathSegment[] pathSegments, string httpPath)
        {
            int index = 0;
            var segments = pathSegments
                .SelectMany(pathSegment => ParsePathSegment(pathSegment, ref index))
                .ToList();
            _segments = CheckByIdPath(segments);
            SerializedPath = httpPath;
        }

        private bool? _isExpandable = null;
        public bool IsExpandable => _isExpandable ??= GetIsExpandable();

        private bool GetIsExpandable()
        {
            for (int i = 0; i < _segments.Count; i++)
            {
                var segment = _segments[i];
                if (i % 2 == 0 &&
                    segment.IsReference &&
                    !segment.Reference.Type.IsFrameworkType &&
                    segment.Reference.Type.Implementation is EnumType)
                    return true;
            }
            return false;
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
        /// Check if this <see cref="RequestPath"/> is a prefix path of <code other/>
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
            if (TryTrimAncestorFrom(other, out var diff))
                return diff;

            throw new InvalidOperationException($"Request path {this} is not parent of {other}");
        }

        public bool TryTrimAncestorFrom(RequestPath other, [MaybeNullWhen(false)] out RequestPath diff)
        {
            diff = default;
            if (this == other)
            {
                diff = RequestPath.Tenant;
                return true;
            }
            if (this.IsAncestorOf(other))
            {
                diff = new RequestPath(other._segments.Skip(this.Count));
                return true;
            }
            // Handle the special case of trim provider from feature
            else if (this.SerializedPath == _providerPath && other.SerializedPath.StartsWith(_featurePath))
            {
                diff = new RequestPath(other._segments.Skip(this.Count + 2));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Trim the scope out of this request path.
        /// If this is already a scope path, return the empty request path, aka the RequestPath.Tenant
        /// </summary>
        /// <returns></returns>
        public RequestPath TrimScope()
        {
            var scope = this.GetScopePath();
            // The scope for /subscriptions is /subscriptions/{subscriptionId}, we identify such case with scope.Count > this.Count.
            if (scope == this || scope.Count > this.Count)
                return Tenant; // if myself is a scope path, we return the empty path after the trim.
            return scope.TrimAncestorFrom(this);
        }

        public RequestPath Append(RequestPath other)
        {
            return new RequestPath(this._segments.Concat(other._segments));
        }

        public RequestPath ApplyHint(ResourceTypeSegment hint)
        {
            if (hint.Count == 0)
                return this;
            int hintIndex = 0;
            List<Segment> newPath = new List<Segment>();
            int thisIndex = 0;
            for (; thisIndex < _segments.Count; thisIndex++)
            {
                var segment = this[thisIndex];
                if (segment.IsExpandable)
                {
                    newPath.Add(hint[hintIndex]);
                    hintIndex++;
                }
                else
                {
                    if (segment.Equals(hint[hintIndex]))
                    {
                        hintIndex++;
                    }
                    newPath.Add(segment);
                }
                if (hintIndex >= hint.Count)
                {
                    thisIndex++;
                    break;
                }
            }

            //copy remaining items in this
            for (; thisIndex < _segments.Count; thisIndex++)
            {
                newPath.Add(_segments[thisIndex]);
            }
            return new RequestPath(newPath);
        }

        public IEnumerable<RequestPath> Expand(MgmtConfiguration config)
        {
            // we first get the resource type
            var resourceType = this.GetResourceType(config);

            // if this resource type is a constant, we do not need to expand it
            if (resourceType.IsConstant)
                return this.AsIEnumerable();

            // otherwise we need to expand them (the resource type is not a constant)
            // first we get all the segment that is not a constant
            var possibleValueMap = new Dictionary<Segment, IEnumerable<Segment>>();
            foreach (var segment in resourceType.Where(segment => segment.IsReference && !segment.Reference.Type.IsFrameworkType))
            {
                var type = segment.Reference.Type.Implementation;
                switch (type)
                {
                    case EnumType enumType:
                        possibleValueMap.Add(segment, enumType.Values.Select(v => new Segment(v.Value, segment.Escape, segment.IsStrict, enumType.Type)));
                        break;
                    default:
                        throw new InvalidOperationException($"The resource type {this} contains variables in it, but it is not an enum type, therefore we cannot expand it. Please double check and/or override it in `request-path-to-resource-type` section.");
                }
            }

            // construct new resource types to make the resource types constant again
            // here we are traversing the segments in this resource type as a tree:
            // if the segment is constant, just add it into the result
            // if the segment is not a constant, we need to add its all possible values (they are all constants) into the result
            // first we build the levels
            var levels = this.Select(segment => segment.IsConstant || !possibleValueMap.ContainsKey(segment) ?
                segment.AsIEnumerable() :
                possibleValueMap[segment]);
            // now we traverse the tree to get the result
            var queue = new Queue<List<Segment>>();
            foreach (var level in levels)
            {
                // initialize
                if (queue.Count == 0)
                {
                    foreach (var _ in level)
                        queue.Enqueue(new List<Segment>());
                }
                // get every element in queue out, and push the new results back
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var list = queue.Dequeue();
                    foreach (var segment in level)
                    {
                        // push the results back with a new element on it
                        queue.Enqueue(new List<Segment>(list) { segment });
                    }
                }
            }

            return queue.Select(list => new RequestPath(list));
        }

        private static IEnumerable<Segment> ParsePathSegment(PathSegment pathSegment, ref int segmentIndex)
        {
            // we explicitly skip the `uri` variable in the path (which should be `endpoint`)
            CSharpType valueType = pathSegment.Value.Type;
            if (valueType.IsFrameworkType &&
                valueType.FrameworkType == typeof(Uri))
            {
                segmentIndex++;
                return Enumerable.Empty<Segment>();
            }
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
                    var pieces = ((string)value).Split('/', StringSplitOptions.RemoveEmptyEntries);
                    segmentIndex += pieces.Length;
                    return pieces.Select(s => new Segment(s));
                }
            }

            segmentIndex++;
            //for now we only assume expand variables are in the key slot which will be an odd slot
            CSharpType? expandableType = (segmentIndex % 2 == 0) && !valueType.IsFrameworkType && valueType.Implementation is EnumType ? valueType : null;

            // this is either a constant but not string type, or it is not a constant, we just keep the information in this path segment
            return new Segment(pathSegment.Value, pathSegment.Escape, expandableType: expandableType).AsIEnumerable();
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
