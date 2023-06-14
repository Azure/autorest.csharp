// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Result of the request to calculate template hash. It contains a string of minified template and its hash. </summary>
    public partial class TemplateHashResult
    {
        /// <summary> Initializes a new instance of TemplateHashResult. </summary>
        internal TemplateHashResult()
        {
        }

        /// <summary> Initializes a new instance of TemplateHashResult. </summary>
        /// <param name="minifiedTemplate"> The minified template string. </param>
        /// <param name="templateHash"> The template hash. </param>
        internal TemplateHashResult(string minifiedTemplate, string templateHash)
        {
            MinifiedTemplate = minifiedTemplate;
            TemplateHash = templateHash;
        }

        /// <summary> The minified template string. </summary>
        public string MinifiedTemplate { get; }
        /// <summary> The template hash. </summary>
        public string TemplateHash { get; }
    }
}
