// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace NameConflicts.Models
{
    /// <summary> The Response. </summary>
    public partial class Response
    {
        /// <summary> Initializes a new instance of Response. </summary>
        public Response()
        {
        }

        /// <summary> Initializes a new instance of Response. </summary>
        /// <param name="property"></param>
        internal Response(string property)
        {
            Property = property;
        }

        /// <summary> Gets or sets the property. </summary>
        public string Property { get; set; }
    }
}
