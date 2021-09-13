// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Management.Storage.Models
{
    /// <summary> The signed permissions for the account SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p). </summary>
    public readonly partial struct Permissions : IEquatable<Permissions>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of Permissions. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Permissions(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RValue = "r";
        private const string DValue = "d";
        private const string WValue = "w";
        private const string LValue = "l";
        private const string AValue = "a";
        private const string CValue = "c";
        private const string UValue = "u";
        private const string PValue = "p";

        /// <summary> r. </summary>
        public static Permissions R { get; } = new Permissions(RValue);
        /// <summary> d. </summary>
        public static Permissions D { get; } = new Permissions(DValue);
        /// <summary> w. </summary>
        public static Permissions W { get; } = new Permissions(WValue);
        /// <summary> l. </summary>
        public static Permissions L { get; } = new Permissions(LValue);
        /// <summary> a. </summary>
        public static Permissions A { get; } = new Permissions(AValue);
        /// <summary> c. </summary>
        public static Permissions C { get; } = new Permissions(CValue);
        /// <summary> u. </summary>
        public static Permissions U { get; } = new Permissions(UValue);
        /// <summary> p. </summary>
        public static Permissions P { get; } = new Permissions(PValue);
        /// <summary> Determines if two <see cref="Permissions"/> values are the same. </summary>
        public static bool operator ==(Permissions left, Permissions right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Permissions"/> values are not the same. </summary>
        public static bool operator !=(Permissions left, Permissions right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Permissions"/>. </summary>
        public static implicit operator Permissions(string value) => new Permissions(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Permissions other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Permissions other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
