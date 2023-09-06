// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// LogAnalytics output properties
    /// Serialized Name: LogAnalyticsOutput
    /// </summary>
    internal partial class LogAnalyticsOutput
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="LogAnalyticsOutput"/>. </summary>
        internal LogAnalyticsOutput()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LogAnalyticsOutput"/>. </summary>
        /// <param name="output">
        /// Output file Uri path to blob container.
        /// Serialized Name: LogAnalyticsOutput.output
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal LogAnalyticsOutput(string output, Dictionary<string, BinaryData> rawData)
        {
            Output = output;
            _rawData = rawData;
        }

        /// <summary>
        /// Output file Uri path to blob container.
        /// Serialized Name: LogAnalyticsOutput.output
        /// </summary>
        public string Output { get; }
    }
}
