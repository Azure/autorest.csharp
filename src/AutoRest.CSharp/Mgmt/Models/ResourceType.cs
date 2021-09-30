// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal struct ResourceType : IEquatable<ResourceType>, IReadOnlyList<Segment>
    {
        public static readonly ResourceType ResourceGroup = new(new[] {
            new Segment("Microsoft.Resources"),
            new Segment("resourceGroups")
        });

        public static readonly ResourceType Subscription = new(new[] {
            new Segment("Microsoft.Resources"),
            new Segment("subscriptions")
        });

        public static readonly ResourceType Tenant = new(new Segment[] {
            new Segment("Microsoft.Resources"),
            new Segment("tenants")
        });

        public static readonly ResourceType ManagementGroup = new(new[] {
            new Segment("Microsoft.ManagementGroups"),
            new Segment("managementGroups")
        });

        private IReadOnlyList<Segment> _segments;

        public ResourceType(string path)
            : this(path.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(segment => new Segment(segment)).ToList())
        {
        }

        public ResourceType(RequestPath path) : this(ParseRequestPath(path))
        {
        }

        private ResourceType(IReadOnlyList<Segment> segments)
        {
            _segments = segments;
            SerializedType = Segment.BuildSerializedSegments(segments, false);
            IsConstant = _segments.All(segment => segment.IsConstant);
        }

        private static IReadOnlyList<Segment> ParseRequestPath(RequestPath path)
        {
            var segment = new List<Segment>();
            // find providers
            int index = path.ToList().IndexOf(Segment.Providers);
            if (index < 0)
                throw new ArgumentException($"Could not set ResourceType for operations group {path}. No {Segment.Providers} string found in the URI");
            segment.Add(path[index + 1]);
            segment.AddRange(path.Skip(index + 1).Where((_, index) => index % 2 != 0));

            return segment;
        }

        public bool IsConstant { get; }

        public string SerializedType { get; }

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
