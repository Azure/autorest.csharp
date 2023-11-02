// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Parameter group. </summary>
    public partial class RequestOptions
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="RequestOptions"/>. </summary>
        public RequestOptions()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RequestOptions"/>. </summary>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RequestOptions(Guid? xMsClientRequestId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            XMsClientRequestId = xMsClientRequestId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The tracking ID sent with the request to help with debugging. </summary>
        public Guid? XMsClientRequestId { get; set; }
    }
}
