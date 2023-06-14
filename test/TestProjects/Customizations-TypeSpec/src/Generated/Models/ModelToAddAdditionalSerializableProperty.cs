// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CustomizationsInCadl.Models
{
    /// <summary> Model to add additional serializable property. </summary>
    public partial class ModelToAddAdditionalSerializableProperty
    {
        /// <summary> Initializes a new instance of ModelToAddAdditionalSerializableProperty. </summary>
        /// <param name="requiredInt"> Required int. </param>
        public ModelToAddAdditionalSerializableProperty(int requiredInt)
        {
            RequiredInt = requiredInt;
        }

        /// <summary> Initializes a new instance of ModelToAddAdditionalSerializableProperty. </summary>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="additionalSerializableProperty"> to be removed by post process. </param>
        /// <param name="additionalNullableSerializableProperty"> to be removed by post process. </param>
        internal ModelToAddAdditionalSerializableProperty(int requiredInt, int additionalSerializableProperty, int? additionalNullableSerializableProperty)
        {
            RequiredInt = requiredInt;
            AdditionalSerializableProperty = additionalSerializableProperty;
            AdditionalNullableSerializableProperty = additionalNullableSerializableProperty;
        }
    }
}
