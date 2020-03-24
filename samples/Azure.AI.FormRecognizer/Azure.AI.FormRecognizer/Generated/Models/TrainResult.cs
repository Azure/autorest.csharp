// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Custom model training result. </summary>
    public partial class TrainResult
    {
        /// <summary> Initializes a new instance of TrainResult. </summary>
        /// <param name="trainingDocuments"> List of the documents used to train the model and any errors reported in each document. </param>
        internal TrainResult(IReadOnlyList<TrainingDocumentInfo> trainingDocuments)
        {
            if (trainingDocuments == null)
            {
                throw new ArgumentNullException(nameof(trainingDocuments));
            }

            TrainingDocuments = trainingDocuments;
        }

        /// <summary> Initializes a new instance of TrainResult. </summary>
        /// <param name="trainingDocuments"> List of the documents used to train the model and any errors reported in each document. </param>
        /// <param name="fields"> List of fields used to train the model and the train operation error reported by each. </param>
        /// <param name="averageModelAccuracy"> Average accuracy. </param>
        /// <param name="errors"> Errors returned during the training operation. </param>
        internal TrainResult(IReadOnlyList<TrainingDocumentInfo> trainingDocuments, IReadOnlyList<FormFieldsReport> fields, float? averageModelAccuracy, IReadOnlyList<ErrorInformation> errors)
        {
            TrainingDocuments = trainingDocuments;
            Fields = fields;
            AverageModelAccuracy = averageModelAccuracy;
            Errors = errors;
        }

        /// <summary> List of the documents used to train the model and any errors reported in each document. </summary>
        public IReadOnlyList<TrainingDocumentInfo> TrainingDocuments { get; }
        /// <summary> List of fields used to train the model and the train operation error reported by each. </summary>
        public IReadOnlyList<FormFieldsReport> Fields { get; }
        /// <summary> Average accuracy. </summary>
        public float? AverageModelAccuracy { get; }
        /// <summary> Errors returned during the training operation. </summary>
        public IReadOnlyList<ErrorInformation> Errors { get; }
    }
}
