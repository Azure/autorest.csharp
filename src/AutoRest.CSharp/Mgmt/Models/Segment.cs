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
        public static readonly Segment Providers = "providers";

        private ReferenceOrConstant _value;
        private string _stringValue;

        public Segment(ReferenceOrConstant value, bool escape, bool strict = true)
        {
            _value = value;
            _stringValue = value.IsConstant ? value.Constant.Value?.ToString() ?? "null"
                : $"({value.Reference.Type.Name}){value.Reference.Name}";
            IsStrict = strict;
            Escape = escape;
        }

        public Segment(string value, bool escape = true, bool strict = true)
        {
            _stringValue = value;
            _value = new Constant(value, typeof(string));
            IsStrict = strict;
            Escape = escape;
        }

        /// <summary>
        /// If this is a constant, escape is guranteed to be true, since our segment has been split by slashes.
        /// If this is a reference, escape is false when the corresponding parameter has x-ms-skip-url-encoding = true indicating this might be a scope variable
        /// </summary>
        public bool Escape { get; private set; }
        /// <summary>
        /// Mark if this segment is strict when comparing with each other.
        /// IsStrict only works on Reference and does not work on Constant
        /// If IsStrict is false, and this is a Reference, we will only compare the type is the same when comparing
        /// But when IsStrict is true, or this is a Constant, we will always ensure we have the same value (for constant) or same reference name (for reference) and the same type
        /// </summary>
        public bool IsStrict { get; private set; }

        public bool IsConstant => _value.IsConstant;

        public bool IsReference => !IsConstant;

        public Constant Constant => _value.Constant;

        public string ConstantValue => _value.Constant.Value?.ToString() ?? "null";

        public Reference Reference => _value.Reference;

        public string ReferenceName => _value.Reference.Name;

        private bool Equals(Segment other, bool strict)
        {
            if (strict)
                return ExactEquals(this, other);
            if (this.IsConstant)
                return ExactEquals(this, other);
            // this is a reference, we will only test if the Type is the same
            if (other.IsConstant)
                return ExactEquals(this, other);
            // now other is also a reference
            return this._value.Reference.Type.Equals(other._value.Reference.Type);
        }

        private static bool ExactEquals(Segment left, Segment right)
        {
            return left._stringValue.Equals(right._stringValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool Equals(Segment other) => this.Equals(other, IsStrict && other.IsStrict);

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (Segment)obj;
            return other.Equals(this);
        }

        public override int GetHashCode() => _stringValue.GetHashCode();

        public override string? ToString() => _stringValue;

        internal static string BuildSerializedSegments(IEnumerable<Segment> segments, bool slashPrefix = true)
        {
            var strings = segments.Select(segment => segment.IsConstant ? segment.ConstantValue : $"{{{segment.ReferenceName}}}");
            var prefix = slashPrefix ? "/" : string.Empty;
            return $"{prefix}{string.Join('/', strings)}";
        }

        public static implicit operator Segment(string value) => new Segment(value);

        public static bool operator ==(Segment left, Segment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Segment left, Segment right)
        {
            return !(left == right);
        }
    }
}
