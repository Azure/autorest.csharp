// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace NameConflicts.Models
{
    /// <summary> The HttpMessage. </summary>
    public partial class HttpMessage
    {
        /// <summary> Initializes a new instance of HttpMessage. </summary>
        public HttpMessage()
        {
        }

        /// <summary> Initializes a new instance of HttpMessage. </summary>
        /// <param name="property"></param>
        internal HttpMessage(string property)
        {
            Property = property;
        }

        /// <summary> Gets or sets the property. </summary>
        public string Property { get; set; }
    }
}
