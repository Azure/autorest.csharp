// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Parameter group. </summary>
    public partial class RequestOptions
    {
        /// <summary> Initializes a new instance of RequestOptions. </summary>
        public RequestOptions()
        {
        }

        /// <summary> The tracking ID sent with the request to help with debugging. </summary>
        public Guid? XMsClientRequestId { get; set; }
    }
}
