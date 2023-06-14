// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies a CORS rule for the Blob service. </summary>
    public partial class CorsRule
    {
        /// <summary> Initializes a new instance of CorsRule. </summary>
        /// <param name="allowedOrigins"> Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains. </param>
        /// <param name="allowedMethods"> Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin. </param>
        /// <param name="maxAgeInSeconds"> Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response. </param>
        /// <param name="exposedHeaders"> Required if CorsRule element is present. A list of response headers to expose to CORS clients. </param>
        /// <param name="allowedHeaders"> Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="allowedOrigins"/>, <paramref name="allowedMethods"/>, <paramref name="exposedHeaders"/> or <paramref name="allowedHeaders"/> is null. </exception>
        public CorsRule(IEnumerable<string> allowedOrigins, IEnumerable<CorsRuleAllowedMethodsItem> allowedMethods, int maxAgeInSeconds, IEnumerable<string> exposedHeaders, IEnumerable<string> allowedHeaders)
        {
            Argument.AssertNotNull(allowedOrigins, nameof(allowedOrigins));
            Argument.AssertNotNull(allowedMethods, nameof(allowedMethods));
            Argument.AssertNotNull(exposedHeaders, nameof(exposedHeaders));
            Argument.AssertNotNull(allowedHeaders, nameof(allowedHeaders));

            AllowedOrigins = allowedOrigins.ToList();
            AllowedMethods = allowedMethods.ToList();
            MaxAgeInSeconds = maxAgeInSeconds;
            ExposedHeaders = exposedHeaders.ToList();
            AllowedHeaders = allowedHeaders.ToList();
        }

        /// <summary> Initializes a new instance of CorsRule. </summary>
        /// <param name="allowedOrigins"> Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains. </param>
        /// <param name="allowedMethods"> Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin. </param>
        /// <param name="maxAgeInSeconds"> Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response. </param>
        /// <param name="exposedHeaders"> Required if CorsRule element is present. A list of response headers to expose to CORS clients. </param>
        /// <param name="allowedHeaders"> Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request. </param>
        internal CorsRule(IList<string> allowedOrigins, IList<CorsRuleAllowedMethodsItem> allowedMethods, int maxAgeInSeconds, IList<string> exposedHeaders, IList<string> allowedHeaders)
        {
            AllowedOrigins = allowedOrigins;
            AllowedMethods = allowedMethods;
            MaxAgeInSeconds = maxAgeInSeconds;
            ExposedHeaders = exposedHeaders;
            AllowedHeaders = allowedHeaders;
        }

        /// <summary> Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains. </summary>
        public IList<string> AllowedOrigins { get; }
        /// <summary> Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin. </summary>
        public IList<CorsRuleAllowedMethodsItem> AllowedMethods { get; }
        /// <summary> Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response. </summary>
        public int MaxAgeInSeconds { get; set; }
        /// <summary> Required if CorsRule element is present. A list of response headers to expose to CORS clients. </summary>
        public IList<string> ExposedHeaders { get; }
        /// <summary> Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request. </summary>
        public IList<string> AllowedHeaders { get; }
    }
}
