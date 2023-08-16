// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Inner error details.
    /// Serialized Name: InnerError
    /// </summary>
    public partial class InnerError
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.InnerError
        ///
        /// </summary>
        internal InnerError()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.InnerError
        ///
        /// </summary>
        /// <param name="exceptiontype">
        /// The exception type.
        /// Serialized Name: InnerError.exceptiontype
        /// </param>
        /// <param name="errordetail">
        /// The internal error message or exception dump.
        /// Serialized Name: InnerError.errordetail
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal InnerError(string exceptiontype, string errordetail, Dictionary<string, BinaryData> rawData)
        {
            Exceptiontype = exceptiontype;
            Errordetail = errordetail;
            _rawData = rawData;
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
