// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithInternalModel. </summary>
    public partial class ModelWithInternalModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithInternalModel"/>. </summary>
        internal ModelWithInternalModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithInternalModel"/>. </summary>
        /// <param name="internalProperty"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithInternalModel(InternalModel internalProperty, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            InternalProperty = internalProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
