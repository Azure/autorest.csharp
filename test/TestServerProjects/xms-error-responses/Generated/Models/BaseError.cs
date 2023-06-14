// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The BaseError. </summary>
    internal partial class BaseError
    {
        /// <summary> Initializes a new instance of BaseError. </summary>
        internal BaseError()
        {
        }

        /// <summary> Initializes a new instance of BaseError. </summary>
        /// <param name="someBaseProp"></param>
        internal BaseError(string someBaseProp)
        {
            SomeBaseProp = someBaseProp;
        }

        /// <summary> Gets the some base prop. </summary>
        public string SomeBaseProp { get; }
    }
}
