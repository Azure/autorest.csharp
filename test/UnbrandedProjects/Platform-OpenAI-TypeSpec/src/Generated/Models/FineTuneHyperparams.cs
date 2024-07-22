// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The FineTuneHyperparams. </summary>
    public partial class FineTuneHyperparams
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        /// <summary> Initializes a new instance of <see cref="FineTuneHyperparams"/>. </summary>
        /// <param name="nEpochs">
        /// The number of epochs to train the model for. An epoch refers to one full cycle through the
        /// training dataset.
        /// </param>
        /// <param name="batchSize">
        /// The batch size to use for training. The batch size is the number of training examples used to
        /// train a single forward and backward pass.
        /// </param>
        /// <param name="promptLossWeight"> The weight to use for loss on the prompt tokens. </param>
        /// <param name="learningRateMultiplier"> The learning rate multiplier to use for training. </param>
        internal FineTuneHyperparams(long nEpochs, long batchSize, double promptLossWeight, double learningRateMultiplier)
        {
            NEpochs = nEpochs;
            BatchSize = batchSize;
            PromptLossWeight = promptLossWeight;
            LearningRateMultiplier = learningRateMultiplier;
        }

        /// <summary> Initializes a new instance of <see cref="FineTuneHyperparams"/>. </summary>
        /// <param name="nEpochs">
        /// The number of epochs to train the model for. An epoch refers to one full cycle through the
        /// training dataset.
        /// </param>
        /// <param name="batchSize">
        /// The batch size to use for training. The batch size is the number of training examples used to
        /// train a single forward and backward pass.
        /// </param>
        /// <param name="promptLossWeight"> The weight to use for loss on the prompt tokens. </param>
        /// <param name="learningRateMultiplier"> The learning rate multiplier to use for training. </param>
        /// <param name="computeClassificationMetrics"> The classification metrics to compute using the validation dataset at the end of every epoch. </param>
        /// <param name="classificationPositiveClass"> The positive class to use for computing classification metrics. </param>
        /// <param name="classificationNClasses"> The number of classes to use for computing classification metrics. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FineTuneHyperparams(long nEpochs, long batchSize, double promptLossWeight, double learningRateMultiplier, bool? computeClassificationMetrics, string classificationPositiveClass, long? classificationNClasses, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NEpochs = nEpochs;
            BatchSize = batchSize;
            PromptLossWeight = promptLossWeight;
            LearningRateMultiplier = learningRateMultiplier;
            ComputeClassificationMetrics = computeClassificationMetrics;
            ClassificationPositiveClass = classificationPositiveClass;
            ClassificationNClasses = classificationNClasses;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="FineTuneHyperparams"/> for deserialization. </summary>
        internal FineTuneHyperparams()
        {
        }

        /// <summary>
        /// The number of epochs to train the model for. An epoch refers to one full cycle through the
        /// training dataset.
        /// </summary>
        public long NEpochs { get; }
        /// <summary>
        /// The batch size to use for training. The batch size is the number of training examples used to
        /// train a single forward and backward pass.
        /// </summary>
        public long BatchSize { get; }
        /// <summary> The weight to use for loss on the prompt tokens. </summary>
        public double PromptLossWeight { get; }
        /// <summary> The learning rate multiplier to use for training. </summary>
        public double LearningRateMultiplier { get; }
        /// <summary> The classification metrics to compute using the validation dataset at the end of every epoch. </summary>
        public bool? ComputeClassificationMetrics { get; }
        /// <summary> The positive class to use for computing classification metrics. </summary>
        public string ClassificationPositiveClass { get; }
        /// <summary> The number of classes to use for computing classification metrics. </summary>
        public long? ClassificationNClasses { get; }
    }
}
