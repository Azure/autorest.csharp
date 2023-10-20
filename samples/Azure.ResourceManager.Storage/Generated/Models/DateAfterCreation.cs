// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Object to define the number of days after creation. </summary>
    internal partial class DateAfterCreation
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DateAfterCreation"/>. </summary>
        /// <param name="daysAfterCreationGreaterThan"> Value indicating the age in days after creation. </param>
        public DateAfterCreation(float daysAfterCreationGreaterThan)
        {
            DaysAfterCreationGreaterThan = daysAfterCreationGreaterThan;
        }

        /// <summary> Initializes a new instance of <see cref="DateAfterCreation"/>. </summary>
        /// <param name="daysAfterCreationGreaterThan"> Value indicating the age in days after creation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DateAfterCreation(float daysAfterCreationGreaterThan, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            DaysAfterCreationGreaterThan = daysAfterCreationGreaterThan;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DateAfterCreation"/> for deserialization. </summary>
        internal DateAfterCreation()
        {
        }

        /// <summary> Value indicating the age in days after creation. </summary>
        public float DaysAfterCreationGreaterThan { get; set; }
    }
}
