// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Object to define the number of days after creation. </summary>
    internal partial class DateAfterCreation
    {
        /// <summary> Initializes a new instance of DateAfterCreation. </summary>
        /// <param name="daysAfterCreationGreaterThan"> Value indicating the age in days after creation. </param>
        public DateAfterCreation(float daysAfterCreationGreaterThan)
        {
            DaysAfterCreationGreaterThan = daysAfterCreationGreaterThan;
        }

        /// <summary> Value indicating the age in days after creation. </summary>
        public float DaysAfterCreationGreaterThan { get; set; }
    }
}
