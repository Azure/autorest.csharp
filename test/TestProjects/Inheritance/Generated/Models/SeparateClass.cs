// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The SeparateClass. </summary>
    public partial class SeparateClass
    {
        /// <summary> Initializes a new instance of SeparateClass. </summary>
        public SeparateClass()
        {
        }

        /// <summary> Initializes a new instance of SeparateClass. </summary>
        /// <param name="stringProperty"></param>
        /// <param name="modelProperty">
        /// Please note <see cref="BaseClassWithExtensibleEnumDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DerivedClassWithExtensibleEnumDiscriminator"/> and <see cref="AnotherDerivedClassWithExtensibleEnumDiscriminator"/>.
        /// </param>
        internal SeparateClass(string stringProperty, BaseClassWithExtensibleEnumDiscriminator modelProperty)
        {
            StringProperty = stringProperty;
            ModelProperty = modelProperty;
        }

        /// <summary> Gets or sets the string property. </summary>
        public string StringProperty { get; set; }
        /// <summary>
        /// Gets or sets the model property
        /// Please note <see cref="BaseClassWithExtensibleEnumDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DerivedClassWithExtensibleEnumDiscriminator"/> and <see cref="AnotherDerivedClassWithExtensibleEnumDiscriminator"/>.
        /// </summary>
        public BaseClassWithExtensibleEnumDiscriminator ModelProperty { get; set; }
    }
}
