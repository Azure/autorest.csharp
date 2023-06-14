// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Sets the CORS rules. You can include up to five CorsRule elements in the request. </summary>
    internal partial class CorsRules
    {
        /// <summary> Initializes a new instance of CorsRules. </summary>
        public CorsRules()
        {
            CorsRulesValue = new ChangeTrackingList<CorsRule>();
        }

        /// <summary> Initializes a new instance of CorsRules. </summary>
        /// <param name="corsRulesValue"> The List of CORS rules. You can include up to five CorsRule elements in the request. </param>
        internal CorsRules(IList<CorsRule> corsRulesValue)
        {
            CorsRulesValue = corsRulesValue;
        }

        /// <summary> The List of CORS rules. You can include up to five CorsRule elements in the request. </summary>
        public IList<CorsRule> CorsRulesValue { get; }
    }
}
