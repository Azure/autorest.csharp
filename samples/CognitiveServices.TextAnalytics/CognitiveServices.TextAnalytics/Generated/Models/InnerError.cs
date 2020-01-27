// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class InnerError
    {
        /// <summary> Error code. </summary>
        public InnerErrorCode Code { get; set; }
        /// <summary> Error message. </summary>
        public string Message { get; set; }
        /// <summary> Error target. </summary>
        public string Target { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public InnerError Innererror { get; set; }
    }
}
