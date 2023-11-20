// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypePropertyValueTypesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.StringLiteralProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <returns> A new <see cref="Models.StringLiteralProperty"/> instance for mocking. </returns>
        public static StringLiteralProperty StringLiteralProperty(StringLiteralPropertyProperty property = default)
        {
            return new StringLiteralProperty(property, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.IntLiteralProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <returns> A new <see cref="Models.IntLiteralProperty"/> instance for mocking. </returns>
        public static IntLiteralProperty IntLiteralProperty(IntLiteralPropertyProperty property = default)
        {
            return new IntLiteralProperty(property, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.FloatLiteralProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <returns> A new <see cref="Models.FloatLiteralProperty"/> instance for mocking. </returns>
        public static FloatLiteralProperty FloatLiteralProperty(FloatLiteralPropertyProperty property = default)
        {
            return new FloatLiteralProperty(property, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.BooleanLiteralProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <returns> A new <see cref="Models.BooleanLiteralProperty"/> instance for mocking. </returns>
        public static BooleanLiteralProperty BooleanLiteralProperty(bool property = default)
        {
            return new BooleanLiteralProperty(property, new Dictionary<string, BinaryData>());
        }
    }
}
