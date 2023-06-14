// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtOperations.Models
{
    /// <summary> The TestAvailabilitySet. </summary>
    public partial class TestAvailabilitySet
    {
        /// <summary> Initializes a new instance of TestAvailabilitySet. </summary>
        internal TestAvailabilitySet()
        {
        }

        /// <summary> Initializes a new instance of TestAvailabilitySet. </summary>
        /// <param name="bar"> specifies the bar. </param>
        internal TestAvailabilitySet(string bar)
        {
            Bar = bar;
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; }
    }
}
