// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Request parameter that contains authorization claims for copy operation. </summary>
    public partial class CopyAuthorizationResult
    {
        /// <summary> Initializes a new instance of CopyAuthorizationResult. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="accessToken"> Token claim used to authorize the request. </param>
        /// <param name="expirationDateTimeTicks"> The time when the access token expires. The date is represented as the number of seconds from 1970-01-01T0:0:0Z UTC until the expiration time. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="accessToken"/> is null. </exception>
        public CopyAuthorizationResult(string modelId, string accessToken, long expirationDateTimeTicks)
        {
            Argument.AssertNotNull(modelId, nameof(modelId));
            Argument.AssertNotNull(accessToken, nameof(accessToken));

            ModelId = modelId;
            AccessToken = accessToken;
            ExpirationDateTimeTicks = expirationDateTimeTicks;
        }

        /// <summary> Model identifier. </summary>
        public string ModelId { get; set; }
        /// <summary> Token claim used to authorize the request. </summary>
        public string AccessToken { get; set; }
        /// <summary> The time when the access token expires. The date is represented as the number of seconds from 1970-01-01T0:0:0Z UTC until the expiration time. </summary>
        public long ExpirationDateTimeTicks { get; set; }
    }
}
