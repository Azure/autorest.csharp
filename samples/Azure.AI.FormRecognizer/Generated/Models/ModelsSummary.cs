// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Summary of all trained custom models. </summary>
    public partial class ModelsSummary
    {
        /// <summary> Initializes a new instance of ModelsSummary. </summary>
        /// <param name="count"> Current count of trained custom models. </param>
        /// <param name="limit"> Max number of models that can be trained for this account. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the summary was last updated. </param>
        internal ModelsSummary(int count, int limit, DateTimeOffset lastUpdatedDateTime)
        {
            Count = count;
            Limit = limit;
            LastUpdatedDateTime = lastUpdatedDateTime;
        }

        /// <summary> Current count of trained custom models. </summary>
        public int Count { get; }
        /// <summary> Max number of models that can be trained for this account. </summary>
        public int Limit { get; }
        /// <summary> Date and time (UTC) when the summary was last updated. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; }
    }
}
