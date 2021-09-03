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
    }
}
