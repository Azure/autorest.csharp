// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtPropertyBag.Models
{
    /// <summary> Foo instance details. </summary>
    public partial class FooPatch
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtPropertyBag.Models.FooPatch
        ///
        /// </summary>
        public FooPatch()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtPropertyBag.Models.FooPatch
        ///
        /// </summary>
        /// <param name="details"> The details of the resource. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FooPatch(string details, Dictionary<string, BinaryData> rawData)
        {
            Details = details;
            _rawData = rawData;
        }

        /// <summary> The details of the resource. </summary>
        public string Details { get; set; }
    }
}
