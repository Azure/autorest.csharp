// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace SpecialWords.Models
{
    /// <summary>
    /// This is a base model has discriminator name containing dot.
    /// Please note <see cref="BaseModel"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedModel"/>.
    /// </summary>
    public abstract partial class BaseModel
    {
        /// <summary> Initializes a new instance of BaseModel. </summary>
        protected BaseModel()
        {
        }

        /// <summary> Initializes a new instance of BaseModel. </summary>
        /// <param name="modelKind"> Discriminator. </param>
        internal BaseModel(string modelKind)
        {
            ModelKind = modelKind;
        }

        /// <summary> Discriminator. </summary>
        internal string ModelKind { get; set; }
    }
}
