// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xml_service.Models
{
    /// <summary> The JsonOutput. </summary>
    public partial class JsonOutput
    {
        /// <summary> Initializes a new instance of JsonOutput. </summary>
        internal JsonOutput()
        {
        }

        /// <summary> Initializes a new instance of JsonOutput. </summary>
        /// <param name="id"></param>
        internal JsonOutput(int? id)
        {
            Id = id;
        }

        /// <summary> Gets the id. </summary>
        public int? Id { get; }
    }
}
