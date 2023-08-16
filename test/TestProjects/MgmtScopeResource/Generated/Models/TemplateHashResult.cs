// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtScopeResource.Models
{
    /// <summary> Result of the request to calculate template hash. It contains a string of minified template and its hash. </summary>
    public partial class TemplateHashResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtScopeResource.Models.TemplateHashResult
        ///
        /// </summary>
        internal TemplateHashResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtScopeResource.Models.TemplateHashResult
        ///
        /// </summary>
        /// <param name="minifiedTemplate"> The minified template string. </param>
        /// <param name="templateHash"> The template hash. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal TemplateHashResult(string minifiedTemplate, string templateHash, Dictionary<string, BinaryData> rawData)
        {
            MinifiedTemplate = minifiedTemplate;
            TemplateHash = templateHash;
            _rawData = rawData;
        }

        /// <summary> The minified template string. </summary>
        public string MinifiedTemplate { get; }
        /// <summary> The template hash. </summary>
        public string TemplateHash { get; }
    }
}
