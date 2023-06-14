// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The DerivedFromAbstractModel. </summary>
    public partial class DerivedFromAbstractModel : AbstractModel
    {
        /// <summary> Initializes a new instance of DerivedFromAbstractModel. </summary>
        internal DerivedFromAbstractModel()
        {
            DiscriminatorProperty = "DerivedFromAbstractModel";
        }

        /// <summary> Initializes a new instance of DerivedFromAbstractModel. </summary>
        /// <param name="discriminatorProperty"></param>
        internal DerivedFromAbstractModel(string discriminatorProperty) : base(discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty ?? "DerivedFromAbstractModel";
        }
    }
}
