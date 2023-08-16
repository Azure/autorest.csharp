// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> The JsonInput. </summary>
    public partial class JsonInput
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.JsonInput
        ///
        /// </summary>
        public JsonInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.JsonInput
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal JsonInput(int? id, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the id. </summary>
        public int? Id { get; set; }
    }
}
