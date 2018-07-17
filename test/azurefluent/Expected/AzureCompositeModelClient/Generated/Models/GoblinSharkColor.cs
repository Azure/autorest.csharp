// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AzureCompositeModelClient.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for GoblinSharkColor.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(GoblinSharkColorConverter))]
    public struct GoblinSharkColor : System.IEquatable<GoblinSharkColor>
    {
        private GoblinSharkColor(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly GoblinSharkColor Pink = "pink";

        public static readonly GoblinSharkColor Gray = "gray";

        public static readonly GoblinSharkColor Brown = "brown";


        /// <summary>
        /// Underlying value of enum GoblinSharkColor
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for GoblinSharkColor
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue == null ? null : UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type GoblinSharkColor
        /// </summary>
        public bool Equals(GoblinSharkColor e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to GoblinSharkColor
        /// </summary>
        public static implicit operator GoblinSharkColor(string value)
        {
            return new GoblinSharkColor(value);
        }

        /// <summary>
        /// Implicit operator to convert GoblinSharkColor to string
        /// </summary>
        public static implicit operator string(GoblinSharkColor e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum GoblinSharkColor
        /// </summary>
        public static bool operator == (GoblinSharkColor e1, GoblinSharkColor e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum GoblinSharkColor
        /// </summary>
        public static bool operator != (GoblinSharkColor e1, GoblinSharkColor e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for GoblinSharkColor
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is GoblinSharkColor && Equals((GoblinSharkColor)obj);
        }

        /// <summary>
        /// Returns for hashCode GoblinSharkColor
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
