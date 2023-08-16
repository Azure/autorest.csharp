// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The SubResource.
    /// Serialized Name: SubResource
    /// </summary>
    public partial class SubResource
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.SubResource
        ///
        /// </summary>
        public SubResource()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.SubResource
        ///
        /// </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SubResource(string id, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            _rawData = rawData;
        }

        /// <summary>
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </summary>
        public string Id { get; set; }
    }
}
