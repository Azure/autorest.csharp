// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace httpInfrastructure.Models
{
    /// <summary> The MyException. </summary>
    public partial class MyException
    {
        /// <summary> Initializes a new instance of MyException. </summary>
        internal MyException()
        {
        }

        /// <summary> Initializes a new instance of MyException. </summary>
        /// <param name="statusCode"></param>
        internal MyException(string statusCode)
        {
            StatusCode = statusCode;
        }

        /// <summary> Gets the status code. </summary>
        public string StatusCode { get; }
    }
}
