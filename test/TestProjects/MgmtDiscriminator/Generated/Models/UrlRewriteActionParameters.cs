// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the url rewrite action. </summary>
    public partial class UrlRewriteActionParameters
    {
        /// <summary> Initializes a new instance of UrlRewriteActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="sourcePattern"> define a request URI pattern that identifies the type of requests that may be rewritten. If value is blank, all strings are matched. </param>
        /// <param name="destination"> Define the relative URL to which the above requests will be rewritten by. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourcePattern"/> or <paramref name="destination"/> is null. </exception>
        public UrlRewriteActionParameters(UrlRewriteActionParametersTypeName typeName, string sourcePattern, string destination)
        {
            Argument.AssertNotNull(sourcePattern, nameof(sourcePattern));
            Argument.AssertNotNull(destination, nameof(destination));

            TypeName = typeName;
            SourcePattern = sourcePattern;
            Destination = destination;
        }

        /// <summary> Initializes a new instance of UrlRewriteActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="sourcePattern"> define a request URI pattern that identifies the type of requests that may be rewritten. If value is blank, all strings are matched. </param>
        /// <param name="destination"> Define the relative URL to which the above requests will be rewritten by. </param>
        /// <param name="preserveUnmatchedPath"> Whether to preserve unmatched path. Default value is true. </param>
        internal UrlRewriteActionParameters(UrlRewriteActionParametersTypeName typeName, string sourcePattern, string destination, bool? preserveUnmatchedPath)
        {
            TypeName = typeName;
            SourcePattern = sourcePattern;
            Destination = destination;
            PreserveUnmatchedPath = preserveUnmatchedPath;
        }

        /// <summary> Gets or sets the type name. </summary>
        public UrlRewriteActionParametersTypeName TypeName { get; set; }
        /// <summary> define a request URI pattern that identifies the type of requests that may be rewritten. If value is blank, all strings are matched. </summary>
        public string SourcePattern { get; set; }
        /// <summary> Define the relative URL to which the above requests will be rewritten by. </summary>
        public string Destination { get; set; }
        /// <summary> Whether to preserve unmatched path. Default value is true. </summary>
        public bool? PreserveUnmatchedPath { get; set; }
    }
}
