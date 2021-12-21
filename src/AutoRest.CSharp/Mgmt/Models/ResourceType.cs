﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// A <see cref="ResourceType"/> represents the resource type that derives from a <see cref="RequestPath"/>. It can contain variables in it.
    /// </summary>
    internal struct ResourceType : IEquatable<ResourceType>, IReadOnlyList<Segment>
    {
        public static readonly ResourceType Scope = new(new Segment[0]);

        public static readonly ResourceType Any = new(new[] { new Segment("*") });

        /// <summary>
        /// The <see cref="ResourceType"/> of the resource group resource
        /// </summary>
        public static readonly ResourceType ResourceGroup = new(new[] {
            new Segment("Microsoft.Resources"),
            new Segment("resourceGroups")
        });

        /// <summary>
        /// The <see cref="ResourceType"/> of the subscription resource
        /// </summary>
        public static readonly ResourceType Subscription = new(new[] {
            new Segment("Microsoft.Resources"),
            new Segment("subscriptions")
        });

        /// <summary>
        /// The <see cref="ResourceType"/> of the tenant resource
        /// </summary>
        public static readonly ResourceType Tenant = new(new Segment[] {
            new Segment("Microsoft.Resources"),
            new Segment("tenants")
        });

        /// <summary>
        /// The <see cref="ResourceType"/> of the management group resource
        /// </summary>
        public static readonly ResourceType ManagementGroup = new(new[] {
            new Segment("Microsoft.Management"),
            new Segment("managementGroups")
        });

        private IReadOnlyList<Segment> _segments;

        public static ResourceType ParseRequestPath(RequestPath path)
        {
            // first try our built-in resources
            if (path == RequestPath.Subscription)
                return ResourceType.Subscription;
            if (path == RequestPath.ResourceGroup)
                return ResourceType.ResourceGroup;
            if (path == RequestPath.ManagementGroup)
                return ResourceType.ManagementGroup;
            if (path == RequestPath.Tenant)
                return ResourceType.Tenant;
            if (path == RequestPath.Any)
                return ResourceType.Any;

            return Parse(path);
        }

        public ResourceType(string path)
            : this(path.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(segment => new Segment(segment)).ToList())
        {
        }

        private ResourceType(IReadOnlyList<Segment> segments)
        {
            _segments = segments;
            SerializedType = Segment.BuildSerializedSegments(segments, false);
            IsConstant = _segments.All(segment => segment.IsConstant);
        }

        private static ResourceType Parse(RequestPath path)
        {
            var segment = new List<Segment>();
            // find providers
            int index = path.ToList().LastIndexOf(Segment.Providers);
            if (index < 0)
                throw new ArgumentException($"Could not set ResourceType for operations group {path}. No {Segment.Providers} string found in the URI");
            segment.Add(path[index + 1]);
            segment.AddRange(path.Skip(index + 1).Where((_, index) => index % 2 != 0));

            return new ResourceType(segment);
        }

        /// <summary>
        /// Returns true if every <see cref="Segment"/> in this <see cref="ResourceType"/> is constant
        /// </summary>
        public bool IsConstant { get; }

        public string SerializedType { get; }

        public Segment Namespace => this[0];

        public IEnumerable<Segment> Types => _segments.Skip(1);

        public Segment this[int index] => _segments[index];

        public int Count => _segments.Count;

        public bool Equals(ResourceType other) => SerializedType.Equals(other.SerializedType, StringComparison.InvariantCultureIgnoreCase);

        public IEnumerator<Segment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (ResourceType)obj;
            return other.Equals(this);
        }

        public override int GetHashCode() => SerializedType.GetHashCode();

        public override string? ToString() => SerializedType;

        public static bool operator ==(ResourceType left, ResourceType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ResourceType left, ResourceType right)
        {
            return !(left == right);
        }
    }
}
