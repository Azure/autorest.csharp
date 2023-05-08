// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace CustomizationsInCadl.Models
{
    /// <summary> Model to add additional serializable property. </summary>
    public partial class ModelToAddAdditionalSerializableProperty
    {
        /// <summary> New property to serialize. </summary>
        [CodeGenMemberSerialization("additionalSerializableProperty")]
        public int AdditionalSerializableProperty { get; set; }
    }
}
