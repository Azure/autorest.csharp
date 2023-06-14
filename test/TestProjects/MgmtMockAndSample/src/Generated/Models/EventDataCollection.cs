// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Represents collection of events. </summary>
    internal partial class EventDataCollection
    {
        /// <summary> Initializes a new instance of EventDataCollection. </summary>
        /// <param name="value"> this list that includes the Azure audit logs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal EventDataCollection(IEnumerable<EventData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of EventDataCollection. </summary>
        /// <param name="value"> this list that includes the Azure audit logs. </param>
        /// <param name="nextLink"> Provides the link to retrieve the next set of events. </param>
        internal EventDataCollection(IReadOnlyList<EventData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> this list that includes the Azure audit logs. </summary>
        public IReadOnlyList<EventData> Value { get; }
        /// <summary> Provides the link to retrieve the next set of events. </summary>
        public string NextLink { get; }
    }
}
