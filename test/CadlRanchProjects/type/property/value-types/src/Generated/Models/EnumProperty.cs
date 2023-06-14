// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with enum properties. </summary>
    public partial class EnumProperty
    {
        /// <summary> Initializes a new instance of EnumProperty. </summary>
        /// <param name="property"> Property. </param>
        public EnumProperty(FixedInnerEnum property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public FixedInnerEnum Property { get; set; }
    }
}
