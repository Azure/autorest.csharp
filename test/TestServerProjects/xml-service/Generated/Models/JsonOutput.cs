// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> The JsonOutput. </summary>
    public partial class JsonOutput
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="JsonOutput"/>. </summary>
        internal JsonOutput()
        {
        }

        /// <summary> Initializes a new instance of <see cref="JsonOutput"/>. </summary>
        /// <param name="id"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal JsonOutput(int? id, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the id. </summary>
        public int? Id { get; }
    }
}
