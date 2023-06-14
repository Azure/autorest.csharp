// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary>
    /// The AbstractModel.
    /// Please note <see cref="AbstractModel"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedFromAbstractModel"/>.
    /// </summary>
    public abstract partial class AbstractModel
    {
        /// <summary> Initializes a new instance of AbstractModel. </summary>
        protected AbstractModel()
        {
        }

        /// <summary> Initializes a new instance of AbstractModel. </summary>
        /// <param name="discriminatorProperty"></param>
        internal AbstractModel(string discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }

        /// <summary> Gets or sets the discriminator property. </summary>
        internal string DiscriminatorProperty { get; set; }
    }
}
