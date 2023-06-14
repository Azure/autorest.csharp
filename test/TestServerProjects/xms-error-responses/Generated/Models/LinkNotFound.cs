// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The LinkNotFound. </summary>
    internal partial class LinkNotFound : NotFoundErrorBase
    {
        /// <summary> Initializes a new instance of LinkNotFound. </summary>
        internal LinkNotFound()
        {
            WhatNotFound = "InvalidResourceLink";
        }

        /// <summary> Initializes a new instance of LinkNotFound. </summary>
        /// <param name="someBaseProp"></param>
        /// <param name="reason"></param>
        /// <param name="whatNotFound"></param>
        /// <param name="whatSubAddress"></param>
        internal LinkNotFound(string someBaseProp, string reason, string whatNotFound, string whatSubAddress) : base(someBaseProp, reason, whatNotFound)
        {
            WhatSubAddress = whatSubAddress;
            WhatNotFound = whatNotFound ?? "InvalidResourceLink";
        }

        /// <summary> Gets the what sub address. </summary>
        public string WhatSubAddress { get; }
    }
}
