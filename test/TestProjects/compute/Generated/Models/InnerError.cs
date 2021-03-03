// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace compute.Models
{
    /// <summary> Inner error details. </summary>
    public partial class InnerError
    {
        /// <summary> Initializes a new instance of InnerError. </summary>
        internal InnerError()
        {
        }

        /// <summary> Initializes a new instance of InnerError. </summary>
        /// <param name="exceptiontype"> The exception type. </param>
        /// <param name="errordetail"> The internal error message or exception dump. </param>
        internal InnerError(string exceptiontype, string errordetail)
        {
            Exceptiontype = exceptiontype;
            Errordetail = errordetail;
        }

        /// <summary> The exception type. </summary>
        public string Exceptiontype { get; }
        /// <summary> The internal error message or exception dump. </summary>
        public string Errordetail { get; }
    }
}
