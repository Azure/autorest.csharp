// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Describes an error condition for the Azure Cognitive Search API. </summary>
    internal partial class SearchServiceError
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SearchServiceError"/>. </summary>
        /// <param name="message"> A human-readable representation of the error. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal SearchServiceError(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
            Details = new ChangeTrackingList<SearchServiceError>();
        }

        /// <summary> Initializes a new instance of <see cref="SearchServiceError"/>. </summary>
        /// <param name="code"> One of a server-defined set of error codes. </param>
        /// <param name="message"> A human-readable representation of the error. </param>
        /// <param name="details"> An array of details about specific errors that led to this reported error. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SearchServiceError(string code, string message, IReadOnlyList<SearchServiceError> details, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Message = message;
            Details = details;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="SearchServiceError"/> for deserialization. </summary>
        internal SearchServiceError()
        {
        }

        /// <summary> One of a server-defined set of error codes. </summary>
        public string Code { get; }
        /// <summary> A human-readable representation of the error. </summary>
        public string Message { get; }
        /// <summary> An array of details about specific errors that led to this reported error. </summary>
        public IReadOnlyList<SearchServiceError> Details { get; }
    }
}
