// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Response of getting a model. </summary>
    public partial class AnomalyDetectionModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AnomalyDetectionModel"/>. </summary>
        /// <param name="createdTime"> Date and time (UTC) when the model was created. </param>
        /// <param name="lastUpdatedTime"> Date and time (UTC) when the model was last updated. </param>
        internal AnomalyDetectionModel(DateTimeOffset createdTime, DateTimeOffset lastUpdatedTime)
        {
            CreatedTime = createdTime;
            LastUpdatedTime = lastUpdatedTime;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="AnomalyDetectionModel"/>. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="createdTime"> Date and time (UTC) when the model was created. </param>
        /// <param name="lastUpdatedTime"> Date and time (UTC) when the model was last updated. </param>
        /// <param name="modelInfo">
        /// Training result of a model including its status, errors and diagnostics
        /// information.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AnomalyDetectionModel(Guid modelId, DateTimeOffset createdTime, DateTimeOffset lastUpdatedTime, ModelInfo modelInfo, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ModelId = modelId;
            CreatedTime = createdTime;
            LastUpdatedTime = lastUpdatedTime;
            ModelInfo = modelInfo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AnomalyDetectionModel"/> for deserialization. </summary>
        internal AnomalyDetectionModel()
        {
        }

        /// <summary> Model identifier. </summary>
        public Guid ModelId { get; }
        /// <summary> Date and time (UTC) when the model was created. </summary>
        public DateTimeOffset CreatedTime { get; }
        /// <summary> Date and time (UTC) when the model was last updated. </summary>
        public DateTimeOffset LastUpdatedTime { get; }
        /// <summary>
        /// Training result of a model including its status, errors and diagnostics
        /// information.
        /// </summary>
        public ModelInfo ModelInfo { get; }
    }
}
