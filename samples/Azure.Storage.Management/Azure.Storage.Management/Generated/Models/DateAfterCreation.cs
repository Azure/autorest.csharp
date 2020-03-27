// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Object to define the number of days after creation. </summary>
    public partial class DateAfterCreation
    {
        /// <summary> Initializes a new instance of DateAfterCreation. </summary>
        /// <param name="daysAfterCreationGreaterThan"> Value indicating the age in days after creation. </param>
        public DateAfterCreation(float daysAfterCreationGreaterThan)
        {
            DaysAfterCreationGreaterThan = daysAfterCreationGreaterThan;
        }

        /// <summary> Value indicating the age in days after creation. </summary>
        public float DaysAfterCreationGreaterThan { get; }
    }
}
