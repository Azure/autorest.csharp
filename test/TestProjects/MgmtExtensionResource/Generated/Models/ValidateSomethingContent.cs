// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExtensionResource.Models
{
    /// <summary> Validate something options. </summary>
    public partial class ValidateSomethingContent
    {
        /// <summary> Initializes a new instance of ValidateSomethingContent. </summary>
        public ValidateSomethingContent()
        {
        }

        /// <summary> The something to validate. </summary>
        public string Something { get; set; }
    }
}
