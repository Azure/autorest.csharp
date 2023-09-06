// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines options to control Cross-Origin Resource Sharing (CORS) for an index. </summary>
    public partial class CorsOptions
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="CorsOptions"/>. </summary>
        /// <param name="allowedOrigins"> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single '*' to allow all origins (not recommended). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="allowedOrigins"/> is null. </exception>
        public CorsOptions(IEnumerable<string> allowedOrigins)
        {
            Argument.AssertNotNull(allowedOrigins, nameof(allowedOrigins));

            AllowedOrigins = allowedOrigins.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="CorsOptions"/>. </summary>
        /// <param name="allowedOrigins"> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single '*' to allow all origins (not recommended). </param>
        /// <param name="maxAgeInSeconds"> The duration for which browsers should cache CORS preflight responses. Defaults to 5 minutes. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal CorsOptions(IList<string> allowedOrigins, long? maxAgeInSeconds, Dictionary<string, BinaryData> rawData)
        {
            AllowedOrigins = allowedOrigins;
            MaxAgeInSeconds = maxAgeInSeconds;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="CorsOptions"/> for deserialization. </summary>
        internal CorsOptions()
        {
        }

        /// <summary> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single '*' to allow all origins (not recommended). </summary>
        public IList<string> AllowedOrigins { get; }
        /// <summary> The duration for which browsers should cache CORS preflight responses. Defaults to 5 minutes. </summary>
        public long? MaxAgeInSeconds { get; set; }
    }
}
