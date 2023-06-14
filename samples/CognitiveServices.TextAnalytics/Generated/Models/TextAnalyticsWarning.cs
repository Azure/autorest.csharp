// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The TextAnalyticsWarning. </summary>
    public partial class TextAnalyticsWarning
    {
        /// <summary> Initializes a new instance of TextAnalyticsWarning. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Warning message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal TextAnalyticsWarning(WarningCodeValue code, string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary> Initializes a new instance of TextAnalyticsWarning. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Warning message. </param>
        /// <param name="targetRef"> A JSON pointer reference indicating the target object. </param>
        internal TextAnalyticsWarning(WarningCodeValue code, string message, string targetRef)
        {
            Code = code;
            Message = message;
            TargetRef = targetRef;
        }

        /// <summary> Error code. </summary>
        public WarningCodeValue Code { get; }
        /// <summary> Warning message. </summary>
        public string Message { get; }
        /// <summary> A JSON pointer reference indicating the target object. </summary>
        public string TargetRef { get; }
    }
}
