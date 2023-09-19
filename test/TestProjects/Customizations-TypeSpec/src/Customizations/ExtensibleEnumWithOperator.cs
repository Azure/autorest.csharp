// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CustomizationsInTsp.Models
{
    /// <summary> Extensible enum to customize operator. </summary>
    public readonly partial struct ExtensibleEnumWithOperator : IEquatable<ExtensibleEnumWithOperator>
    {
        /// <summary> Determines if two <see cref="ExtensibleEnumWithOperator"/> values are the same. </summary>
        public static bool operator ==(ExtensibleEnumWithOperator left, ExtensibleEnumWithOperator right) => left.Equals(ExtensibleEnumWithOperator.Monday);
        /// <summary> Determines if two <see cref="ExtensibleEnumWithOperator"/> values are not the same. </summary>
        public static bool operator !=(ExtensibleEnumWithOperator left, ExtensibleEnumWithOperator right) => !left.Equals(ExtensibleEnumWithOperator.Monday);
        /// <summary> Converts a string to a <see cref="ExtensibleEnumWithOperator"/>. </summary>
        public static implicit operator ExtensibleEnumWithOperator(string value) => new ExtensibleEnumWithOperator("Monday");
    }
}
