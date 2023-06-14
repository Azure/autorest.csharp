// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace httpInfrastructure.Models
{
    /// <summary> The C. </summary>
    public partial class C
    {
        /// <summary> Initializes a new instance of C. </summary>
        internal C()
        {
        }

        /// <summary> Initializes a new instance of C. </summary>
        /// <param name="httpCode"></param>
        internal C(string httpCode)
        {
            HttpCode = httpCode;
        }

        /// <summary> Gets the http code. </summary>
        public string HttpCode { get; }
    }
}
