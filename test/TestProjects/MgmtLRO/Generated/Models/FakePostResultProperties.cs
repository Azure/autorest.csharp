// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtLRO.Models
{
    /// <summary> The FakePostResultProperties. </summary>
    internal partial class FakePostResultProperties
    {
        /// <summary> Initializes a new instance of FakePostResultProperties. </summary>
        internal FakePostResultProperties()
        {
        }

        /// <summary> Initializes a new instance of FakePostResultProperties. </summary>
        /// <param name="bar"> Bar property. </param>
        internal FakePostResultProperties(string bar)
        {
            Bar = bar;
        }

        /// <summary> Bar property. </summary>
        public string Bar { get; }
    }
}
