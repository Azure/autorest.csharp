// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace httpInfrastructure.Models
{
    /// <summary> The D. </summary>
    public partial class D
    {
        /// <summary> Initializes a new instance of D. </summary>
        internal D()
        {
        }

        /// <summary> Initializes a new instance of D. </summary>
        /// <param name="httpStatusCode"></param>
        internal D(string httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        /// <summary> Gets the http status code. </summary>
        public string HttpStatusCode { get; }
    }
}
