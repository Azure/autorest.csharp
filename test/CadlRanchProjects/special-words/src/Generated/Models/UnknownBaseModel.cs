// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace SpecialWords.Models
{
    /// <summary> Unknown version of BaseModel. </summary>
    internal partial class UnknownBaseModel : BaseModel
    {
        /// <summary> Initializes a new instance of UnknownBaseModel. </summary>
        internal UnknownBaseModel()
        {
        }

        /// <summary> Initializes a new instance of UnknownBaseModel. </summary>
        /// <param name="modelKind"> Discriminator. </param>
        internal UnknownBaseModel(string modelKind) : base(modelKind)
        {
        }
    }
}
