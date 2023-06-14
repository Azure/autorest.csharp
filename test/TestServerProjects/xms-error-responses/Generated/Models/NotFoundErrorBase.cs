// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary>
    /// The NotFoundErrorBase.
    /// Please note <see cref="NotFoundErrorBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AnimalNotFound"/> and <see cref="LinkNotFound"/>.
    /// </summary>
    internal partial class NotFoundErrorBase : BaseError
    {
        /// <summary> Initializes a new instance of NotFoundErrorBase. </summary>
        internal NotFoundErrorBase()
        {
        }

        /// <summary> Initializes a new instance of NotFoundErrorBase. </summary>
        /// <param name="someBaseProp"></param>
        /// <param name="reason"></param>
        /// <param name="whatNotFound"></param>
        internal NotFoundErrorBase(string someBaseProp, string reason, string whatNotFound) : base(someBaseProp)
        {
            Reason = reason;
            WhatNotFound = whatNotFound;
        }

        /// <summary> Gets the reason. </summary>
        public string Reason { get; }
        /// <summary> Gets or sets the what not found. </summary>
        internal string WhatNotFound { get; set; }
    }
}
