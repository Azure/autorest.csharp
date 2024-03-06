// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using CognitiveServices.TextAnalytics;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The TextAnalyticsError. </summary>
    public partial class TextAnalyticsError
    {
        /// <summary> Initializes a new instance of <see cref="TextAnalyticsError"/>. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Error message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal TextAnalyticsError(ErrorCodeValue code, string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Code = code;
            Message = message;
            Details = new ChangeTrackingList<TextAnalyticsError>();
        }

        /// <summary> Initializes a new instance of <see cref="TextAnalyticsError"/>. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Error message. </param>
        /// <param name="target"> Error target. </param>
        /// <param name="innererror"> Inner error contains more specific information. </param>
        /// <param name="details"> Details about specific errors that led to this reported error. </param>
        internal TextAnalyticsError(ErrorCodeValue code, string message, string target, InnerError innererror, IReadOnlyList<TextAnalyticsError> details)
        {
            Code = code;
            Message = message;
            Target = target;
            Innererror = innererror;
            Details = details;
        }

        /// <summary> Error code. </summary>
        public ErrorCodeValue Code { get; }
        /// <summary> Error message. </summary>
        public string Message { get; }
        /// <summary> Error target. </summary>
        public string Target { get; }
        /// <summary> Inner error contains more specific information. </summary>
        public InnerError Innererror { get; }
        /// <summary> Details about specific errors that led to this reported error. </summary>
        public IReadOnlyList<TextAnalyticsError> Details { get; }
    }
}
