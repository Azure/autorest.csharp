// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AppConfiguration.Models.V10
{
    /// <summary> Azure App Configuration error object. </summary>
    public partial class Error
    {
        /// <summary> The type of the error. </summary>
        public string? Type { get; set; }
        /// <summary> A brief summary of the error. </summary>
        public string? Title { get; set; }
        /// <summary> The name of the parameter that resulted in the error. </summary>
        public string? Name { get; set; }
        /// <summary> A detailed description of the error. </summary>
        public string? Detail { get; set; }
        /// <summary> The HTTP status code that the error maps to. </summary>
        public int? Status { get; set; }
    }
}
