// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace _Type.Property.Optional.Models
{
    /// <summary> Model with required and optional properties. </summary>
    public partial class RequiredAndOptionalProperty
    {
        /// <summary> Initializes a new instance of RequiredAndOptionalProperty. </summary>
        /// <param name="requiredProperty"> required int property. </param>
        public RequiredAndOptionalProperty(int requiredProperty)
        {
            RequiredProperty = requiredProperty;
        }

        /// <summary> Initializes a new instance of RequiredAndOptionalProperty. </summary>
        /// <param name="optionalProperty"> optional string property. </param>
        /// <param name="requiredProperty"> required int property. </param>
        internal RequiredAndOptionalProperty(string optionalProperty, int requiredProperty)
        {
            OptionalProperty = optionalProperty;
            RequiredProperty = requiredProperty;
        }

        /// <summary> optional string property. </summary>
        public string OptionalProperty { get; set; }
        /// <summary> required int property. </summary>
        public int RequiredProperty { get; set; }
    }
}
