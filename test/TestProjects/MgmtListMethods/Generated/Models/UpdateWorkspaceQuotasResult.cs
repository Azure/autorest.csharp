// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtListMethods.Models
{
    /// <summary> The result of update workspace quota. </summary>
    internal partial class UpdateWorkspaceQuotasResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="UpdateWorkspaceQuotasResult"/>. </summary>
        internal UpdateWorkspaceQuotasResult()
        {
            Value = new ChangeTrackingList<UpdateWorkspaceQuotas>();
        }

        /// <summary> Initializes a new instance of <see cref="UpdateWorkspaceQuotasResult"/>. </summary>
        /// <param name="value"> The list of workspace quota update result. </param>
        /// <param name="nextLink"> The URI to fetch the next page of workspace quota update result. Call ListNext() with this to fetch the next page of Workspace Quota update result. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UpdateWorkspaceQuotasResult(IReadOnlyList<UpdateWorkspaceQuotas> value, string nextLink, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The list of workspace quota update result. </summary>
        public IReadOnlyList<UpdateWorkspaceQuotas> Value { get; }
        /// <summary> The URI to fetch the next page of workspace quota update result. Call ListNext() with this to fetch the next page of Workspace Quota update result. </summary>
        public string NextLink { get; }
    }
}
