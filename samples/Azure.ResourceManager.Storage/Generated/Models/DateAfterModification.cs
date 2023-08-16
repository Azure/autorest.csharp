// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Object to define the number of days after object last modification Or last access. Properties daysAfterModificationGreaterThan and daysAfterLastAccessTimeGreaterThan are mutually exclusive. </summary>
    public partial class DateAfterModification
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.DateAfterModification
        ///
        /// </summary>
        public DateAfterModification()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.DateAfterModification
        ///
        /// </summary>
        /// <param name="daysAfterModificationGreaterThan"> Value indicating the age in days after last modification. </param>
        /// <param name="daysAfterLastAccessTimeGreaterThan"> Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DateAfterModification(float? daysAfterModificationGreaterThan, float? daysAfterLastAccessTimeGreaterThan, Dictionary<string, BinaryData> rawData)
        {
            DaysAfterModificationGreaterThan = daysAfterModificationGreaterThan;
            DaysAfterLastAccessTimeGreaterThan = daysAfterLastAccessTimeGreaterThan;
            _rawData = rawData;
        }

        /// <summary> Value indicating the age in days after last modification. </summary>
        public float? DaysAfterModificationGreaterThan { get; set; }
        /// <summary> Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy. </summary>
        public float? DaysAfterLastAccessTimeGreaterThan { get; set; }
    }
}
