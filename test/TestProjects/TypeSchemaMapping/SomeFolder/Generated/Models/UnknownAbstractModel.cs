// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The UnknownAbstractModel. </summary>
    internal partial class UnknownAbstractModel : AbstractModel
    {
        /// <summary> Initializes a new instance of UnknownAbstractModel. </summary>
        /// <param name="discriminatorProperty"></param>
        internal UnknownAbstractModel(string discriminatorProperty) : base(discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty ?? "Unknown";
        }
    }
}
