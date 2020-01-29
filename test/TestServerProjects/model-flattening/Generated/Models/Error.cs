// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace model_flattening.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Error
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int? Status { get; set; }
        public string Message { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public Error ParentError { get; set; }
    }
}
