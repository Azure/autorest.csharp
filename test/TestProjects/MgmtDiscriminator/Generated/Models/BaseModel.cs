// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> The BaseModel. </summary>
    public partial class BaseModel
    {
        /// <summary> Initializes a new instance of BaseModel. </summary>
        public BaseModel()
        {
        }

        /// <summary> Initializes a new instance of BaseModel. </summary>
        /// <param name="optionalString"></param>
        internal BaseModel(string optionalString)
        {
            OptionalString = optionalString;
        }

        /// <summary> Gets or sets the optional string. </summary>
        public string OptionalString { get; set; }
    }
}
