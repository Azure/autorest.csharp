// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal struct Segment : IEquatable<Segment>
    {
        private ReferenceOrConstant _value;
        private string _stringValue;

        public Segment(ReferenceOrConstant value)
        {
            _value = value;
            _stringValue = value.IsConstant ? value.Constant.Value?.ToString() ?? "null"
                : $"({value.Reference.Type.Name}){value.Reference.Name}";
        }

        public Segment(string value)
        {
            _stringValue = value;
            _value = new Constant(value, typeof(string));
        }

        public bool IsConstant => _value.IsConstant;
        public bool IsReference => !IsConstant;

        public string Constant => (string)_value.Constant.Value!;

        public string ReferenceName => _value.Reference.Name;

        public bool Equals(Segment other, bool strict)
        {
            if (strict)
                return this.Equals(other);
            if (this.IsConstant)
                return this.Equals(other);
            // this is a reference, we will only test if the Type is the same
            if (other.IsConstant)
                return this.Equals(other);
            // now other is also a reference
            return this._value.Reference.Type.Equals(other._value.Reference.Type);
        }

        public bool Equals(Segment other) => _stringValue.Equals(other._stringValue, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (Segment)obj;
            return other.Equals(this);
        }

        public override int GetHashCode() => _stringValue.GetHashCode();

        public override string? ToString() => _stringValue;

        internal static string BuildSerializedSegments(IEnumerable<Segment> segments)
        {
            var strings = segments.Select(segment => segment.IsConstant ? segment.Constant : $"{{{segment.ReferenceName}}}");
            return $"/{string.Join('/', strings)}";
        }

        public static implicit operator Segment(string value) => new Segment(value);
    }
}
