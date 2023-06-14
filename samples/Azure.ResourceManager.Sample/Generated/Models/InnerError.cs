// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Inner error details.
    /// Serialized Name: InnerError
    /// </summary>
    public partial class InnerError
    {
        /// <summary> Initializes a new instance of InnerError. </summary>
        internal InnerError()
        {
        }

        /// <summary> Initializes a new instance of InnerError. </summary>
        /// <param name="exceptiontype">
        /// The exception type.
        /// Serialized Name: InnerError.exceptiontype
        /// </param>
        /// <param name="errordetail">
        /// The internal error message or exception dump.
        /// Serialized Name: InnerError.errordetail
        /// </param>
        internal InnerError(string exceptiontype, string errordetail)
        {
            Exceptiontype = exceptiontype;
            Errordetail = errordetail;
        }

        /// <summary>
        /// The exception type.
        /// Serialized Name: InnerError.exceptiontype
        /// </summary>
        public string Exceptiontype { get; }
        /// <summary>
        /// The internal error message or exception dump.
        /// Serialized Name: InnerError.errordetail
        /// </summary>
        public string Errordetail { get; }
    }
}
