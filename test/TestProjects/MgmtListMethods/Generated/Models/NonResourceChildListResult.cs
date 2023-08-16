// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtListMethods.Models
{
    /// <summary> The List of Non Resource Child operation response. </summary>
    internal partial class NonResourceChildListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtListMethods.Models.NonResourceChildListResult
        ///
        /// </summary>
        internal NonResourceChildListResult()
        {
            Value = new ChangeTrackingList<NonResourceChild>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtListMethods.Models.NonResourceChildListResult
        ///
        /// </summary>
        /// <param name="value"> The list of Non Resource Child. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NonResourceChildListResult(IReadOnlyList<NonResourceChild> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> The list of Non Resource Child. </summary>
        public IReadOnlyList<NonResourceChild> Value { get; }
    }
}
