// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Model status. </summary>
    public partial class ModelState
    {
        /// <summary> Initializes a new instance of ModelState. </summary>
        public ModelState()
        {
            EpochIds = new ChangeTrackingList<int>();
            TrainLosses = new ChangeTrackingList<float>();
            ValidationLosses = new ChangeTrackingList<float>();
            LatenciesInSeconds = new ChangeTrackingList<float>();
        }

        /// <summary> Initializes a new instance of ModelState. </summary>
        /// <param name="epochIds">
        /// This indicates the number of passes of the entire training dataset the
        /// algorithm has completed.
        /// </param>
        /// <param name="trainLosses">
        /// List of metrics used to assess how the model fits the training data for each
        /// epoch.
        /// </param>
        /// <param name="validationLosses">
        /// List of metrics used to assess how the model fits the validation set for each
        /// epoch.
        /// </param>
        /// <param name="latenciesInSeconds"> Latency for each epoch. </param>
        internal ModelState(IList<int> epochIds, IList<float> trainLosses, IList<float> validationLosses, IList<float> latenciesInSeconds)
        {
            EpochIds = epochIds;
            TrainLosses = trainLosses;
            ValidationLosses = validationLosses;
            LatenciesInSeconds = latenciesInSeconds;
        }

        /// <summary>
        /// This indicates the number of passes of the entire training dataset the
        /// algorithm has completed.
        /// </summary>
        public IList<int> EpochIds { get; }
        /// <summary>
        /// List of metrics used to assess how the model fits the training data for each
        /// epoch.
        /// </summary>
        public IList<float> TrainLosses { get; }
        /// <summary>
        /// List of metrics used to assess how the model fits the validation set for each
        /// epoch.
        /// </summary>
        public IList<float> ValidationLosses { get; }
        /// <summary> Latency for each epoch. </summary>
        public IList<float> LatenciesInSeconds { get; }
    }
}
