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
        private static readonly Segment ProviderSegment = "providers";
        private IReadOnlyList<Segment> _segments;

        public ResourceType(RequestPath path) : this(ParseRequestPath(path))
        {
        }

        private ResourceType(IReadOnlyList<Segment> segments)
        {
            _segments = segments;
            SerializedType = Segment.BuildSerializedSegments(segments);
            IsConstant = _segments.All(segment => segment.IsConstant);
        }

        private static IReadOnlyList<Segment> ParseRequestPath(RequestPath path)
        {
            var segment = new List<Segment>();
            // find providers
            int index = path.ToList().IndexOf(ProviderSegment);
            if (index < 0)
                throw new ArgumentException($"Could not set ResourceType for operations group {path}. No {ProviderSegment} string found in the URI");
            segment.Add(path[index + 1]);
            segment.AddRange(path.Skip(index + 1).TakeWhile((_, index) => index % 2 != 0));

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
    }
}
