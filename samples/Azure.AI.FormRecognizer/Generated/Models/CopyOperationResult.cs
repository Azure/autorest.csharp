// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Status and result of the queued copy operation. </summary>
    public partial class CopyOperationResult
    {
        /// <summary> Initializes a new instance of CopyOperationResult. </summary>
        /// <param name="status"> Operation status. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the copy operation was submitted. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        internal CopyOperationResult(OperationStatus status, DateTimeOffset createdDateTime, DateTimeOffset lastUpdatedDateTime)
        {
            Status = status;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
        }

        /// <summary> Initializes a new instance of CopyOperationResult. </summary>
        /// <param name="status"> Operation status. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the copy operation was submitted. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="copyResult"> Results of the copy operation. </param>
        internal CopyOperationResult(OperationStatus status, DateTimeOffset createdDateTime, DateTimeOffset lastUpdatedDateTime, CopyResult copyResult)
        {
            Status = status;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            CopyResult = copyResult;
        }

        /// <summary> Operation status. </summary>
        public OperationStatus Status { get; }
        /// <summary> Date and time (UTC) when the copy operation was submitted. </summary>
        public DateTimeOffset CreatedDateTime { get; }
        /// <summary> Date and time (UTC) when the status was last updated. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; }
        /// <summary> Results of the copy operation. </summary>
        public CopyResult CopyResult { get; }
    }
}
