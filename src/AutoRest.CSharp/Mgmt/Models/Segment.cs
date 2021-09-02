// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Models
{
    public struct Segment : IEquatable<Segment>
    {
        private ReferenceOrConstant _value;
        private string _stringValue;

        public Segment(string value)
        {
            _stringValue = value;
            _value = ParseToReferenceOrConstant(value);
        }

        public bool IsConstant => _value.IsConstant;
        public bool IsReference => !IsConstant;

        public string Constant => (string)_value.Constant.Value!;

        public string ReferenceName => _value.Reference.Name;

        public bool Equals(Segment other)
        {
            return _stringValue == other._stringValue;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Segment?;
            if (other is not null)
                return other.Equals(this);
            return false;
        }

        public override int GetHashCode()
        {
            return _stringValue.GetHashCode();
        }

        public override string? ToString()
        {
            return _stringValue;
        }

        public static implicit operator string(Segment other)
        {
            return other._stringValue;
        }

        public static implicit operator Segment(string other)
        {
            return new Segment(other);
        }

        internal static ReferenceOrConstant ParseToReferenceOrConstant(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            if (value.Contains('/'))
                throw new InvalidOperationException($"{nameof(value)} cannot contain '/'");

            if (TryParseReference(value, out var referenceName))
                return new Reference(referenceName, typeof(string));
            return new Constant(value, typeof(string));
        }

        private static bool TryParseReference(string value, [MaybeNullWhen(false)] out string referenceName)
        {
            referenceName = null;
            if (value.StartsWith('{') && value.EndsWith('}'))
            {
                referenceName = value.TrimStart('{').TrimEnd('}');
                return true;
            }

            return false;
        }
    }
}
