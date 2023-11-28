// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtSafeFlatten.Models
{
    /// <summary>
    /// The LayerOneBaseType.
    /// Please note <see cref="LayerOneBaseType"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="LayerOneBarType"/> and <see cref="LayerOneFooType"/>.
    /// </summary>
    public abstract partial class LayerOneBaseType
    {
        /// <summary> Initializes a new instance of <see cref="LayerOneBaseType"/>. </summary>
        protected LayerOneBaseType()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LayerOneBaseType"/>. </summary>
        /// <param name="name"></param>
        internal LayerOneBaseType(LayerOneTypeName name)
        {
            Name = name;
        }

        /// <summary> Gets or sets the name. </summary>
        internal LayerOneTypeName Name { get; set; }
    }
}
