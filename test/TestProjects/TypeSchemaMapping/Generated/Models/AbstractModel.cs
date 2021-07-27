// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The AbstractModel. </summary>
    public partial class AbstractModel
    {
        /// <summary> Initializes a new instance of AbstractModel. </summary>
        internal AbstractModel()
        {
        }

        /// <summary> Initializes a new instance of AbstractModel. </summary>
        /// <param name="discriminatorProperty"></param>
        internal AbstractModel(string discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }

        internal string DiscriminatorProperty { get; set; }
    }
}
