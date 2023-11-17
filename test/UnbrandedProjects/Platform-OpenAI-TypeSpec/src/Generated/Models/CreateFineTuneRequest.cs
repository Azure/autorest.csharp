// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel.Internal;

namespace OpenAI.Models
{
    /// <summary> The CreateFineTuneRequest. </summary>
    public partial class CreateFineTuneRequest
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
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CreateFineTuneRequest"/>. </summary>
        /// <param name="trainingFile">
        /// The ID of an uploaded file that contains training data.
        ///
        /// See [upload file](/docs/api-reference/files/upload) for how to upload a file.
        ///
        /// Your dataset must be formatted as a JSONL file, where each training example is a JSON object
        /// with the keys "prompt" and "completion". Additionally, you must upload your file with the
        /// purpose `fine-tune`.
        ///
        /// See the [fine-tuning guide](/docs/guides/legacy-fine-tuning/creating-training-data) for more
        /// details.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trainingFile"/> is null. </exception>
        public CreateFineTuneRequest(string trainingFile)
        {
            ClientUtilities.AssertNotNull(trainingFile, nameof(trainingFile));

            TrainingFile = trainingFile;
            ClassificationBetas = new OptionalList<double>();
            _serializedAdditionalRawData = new OptionalDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="CreateFineTuneRequest"/>. </summary>
        /// <param name="trainingFile">
        /// The ID of an uploaded file that contains training data.
        ///
        /// See [upload file](/docs/api-reference/files/upload) for how to upload a file.
        ///
        /// Your dataset must be formatted as a JSONL file, where each training example is a JSON object
        /// with the keys "prompt" and "completion". Additionally, you must upload your file with the
        /// purpose `fine-tune`.
        ///
        /// See the [fine-tuning guide](/docs/guides/legacy-fine-tuning/creating-training-data) for more
        /// details.
        /// </param>
        /// <param name="validationFile">
        /// The ID of an uploaded file that contains validation data.
        ///
        /// If you provide this file, the data is used to generate validation metrics periodically during
        /// fine-tuning. These metrics can be viewed in the
        /// [fine-tuning results file](/docs/guides/legacy-fine-tuning/analyzing-your-fine-tuned-model).
        /// Your train and validation data should be mutually exclusive.
        ///
        /// Your dataset must be formatted as a JSONL file, where each validation example is a JSON object
        /// with the keys "prompt" and "completion". Additionally, you must upload your file with the
        /// purpose `fine-tune`.
        ///
        /// See the [fine-tuning guide](/docs/guides/legacy-fine-tuning/creating-training-data) for more
        /// details.
        /// </param>
        /// <param name="model">
        /// The name of the base model to fine-tune. You can select one of "ada", "babbage", "curie",
        /// "davinci", or a fine-tuned model created after 2022-04-21 and before 2023-08-22. To learn more
        /// about these models, see the [Models](/docs/models) documentation.
        /// </param>
        /// <param name="nEpochs">
        /// The number of epochs to train the model for. An epoch refers to one full cycle through the
        /// training dataset.
        /// </param>
        /// <param name="batchSize">
        /// The batch size to use for training. The batch size is the number of training examples used to
        /// train a single forward and backward pass.
        ///
        /// By default, the batch size will be dynamically configured to be ~0.2% of the number of examples
        /// in the training set, capped at 256 - in general, we've found that larger batch sizes tend to
        /// work better for larger datasets.
        /// </param>
        /// <param name="learningRateMultiplier">
        /// The learning rate multiplier to use for training. The fine-tuning learning rate is the original
        /// learning rate used for pretraining multiplied by this value.
        ///
        /// By default, the learning rate multiplier is the 0.05, 0.1, or 0.2 depending on final
        /// `batch_size` (larger learning rates tend to perform better with larger batch sizes). We
        /// recommend experimenting with values in the range 0.02 to 0.2 to see what produces the best
        /// results.
        /// </param>
        /// <param name="promptLossRate">
        /// The weight to use for loss on the prompt tokens. This controls how much the model tries to
        /// learn to generate the prompt (as compared to the completion which always has a weight of 1.0),
        /// and can add a stabilizing effect to training when completions are short.
        ///
        /// If prompts are extremely long (relative to completions), it may make sense to reduce this
        /// weight so as to avoid over-prioritizing learning the prompt.
        /// </param>
        /// <param name="computeClassificationMetrics">
        /// If set, we calculate classification-specific metrics such as accuracy and F-1 score using the
        /// validation set at the end of every epoch. These metrics can be viewed in the
        /// [results file](/docs/guides/legacy-fine-tuning/analyzing-your-fine-tuned-model).
        ///
        /// In order to compute classification metrics, you must provide a `validation_file`. Additionally,
        /// you must specify `classification_n_classes` for multiclass classification or
        /// `classification_positive_class` for binary classification.
        /// </param>
        /// <param name="classificationNClasses">
        /// The number of classes in a classification task.
        ///
        /// This parameter is required for multiclass classification.
        /// </param>
        /// <param name="classificationPositiveClass">
        /// The positive class in binary classification.
        ///
        /// This parameter is needed to generate precision, recall, and F1 metrics when doing binary
        /// classification.
        /// </param>
        /// <param name="classificationBetas">
        /// If this is provided, we calculate F-beta scores at the specified beta values. The F-beta score
        /// is a generalization of F-1 score. This is only used for binary classification.
        ///
        /// With a beta of 1 (i.e. the F-1 score), precision and recall are given the same weight. A larger
        /// beta score puts more weight on recall and less on precision. A smaller beta score puts more
        /// weight on precision and less on recall.
        /// </param>
        /// <param name="suffix">
        /// A string of up to 18 characters that will be added to your fine-tuned model name.
        ///
        /// For example, a `suffix` of "custom-model-name" would produce a model name like
        /// `ada:ft-your-org:custom-model-name-2022-02-15-04-21-04`.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateFineTuneRequest(string trainingFile, string validationFile, CreateFineTuneRequestModel? model, long? nEpochs, long? batchSize, double? learningRateMultiplier, double? promptLossRate, bool? computeClassificationMetrics, long? classificationNClasses, string classificationPositiveClass, IList<double> classificationBetas, string suffix, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TrainingFile = trainingFile;
            ValidationFile = validationFile;
            Model = model;
            NEpochs = nEpochs;
            BatchSize = batchSize;
            LearningRateMultiplier = learningRateMultiplier;
            PromptLossRate = promptLossRate;
            ComputeClassificationMetrics = computeClassificationMetrics;
            ClassificationNClasses = classificationNClasses;
            ClassificationPositiveClass = classificationPositiveClass;
            ClassificationBetas = classificationBetas;
            Suffix = suffix;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateFineTuneRequest"/> for deserialization. </summary>
        internal CreateFineTuneRequest()
        {
        }

        /// <summary>
        /// The ID of an uploaded file that contains training data.
        ///
        /// See [upload file](/docs/api-reference/files/upload) for how to upload a file.
        ///
        /// Your dataset must be formatted as a JSONL file, where each training example is a JSON object
        /// with the keys "prompt" and "completion". Additionally, you must upload your file with the
        /// purpose `fine-tune`.
        ///
        /// See the [fine-tuning guide](/docs/guides/legacy-fine-tuning/creating-training-data) for more
        /// details.
        /// </summary>
        public string TrainingFile { get; }
        /// <summary>
        /// The ID of an uploaded file that contains validation data.
        ///
        /// If you provide this file, the data is used to generate validation metrics periodically during
        /// fine-tuning. These metrics can be viewed in the
        /// [fine-tuning results file](/docs/guides/legacy-fine-tuning/analyzing-your-fine-tuned-model).
        /// Your train and validation data should be mutually exclusive.
        ///
        /// Your dataset must be formatted as a JSONL file, where each validation example is a JSON object
        /// with the keys "prompt" and "completion". Additionally, you must upload your file with the
        /// purpose `fine-tune`.
        ///
        /// See the [fine-tuning guide](/docs/guides/legacy-fine-tuning/creating-training-data) for more
        /// details.
        /// </summary>
        public string ValidationFile { get; set; }
        /// <summary>
        /// The name of the base model to fine-tune. You can select one of "ada", "babbage", "curie",
        /// "davinci", or a fine-tuned model created after 2022-04-21 and before 2023-08-22. To learn more
        /// about these models, see the [Models](/docs/models) documentation.
        /// </summary>
        public CreateFineTuneRequestModel? Model { get; set; }
        /// <summary>
        /// The number of epochs to train the model for. An epoch refers to one full cycle through the
        /// training dataset.
        /// </summary>
        public long? NEpochs { get; set; }
        /// <summary>
        /// The batch size to use for training. The batch size is the number of training examples used to
        /// train a single forward and backward pass.
        ///
        /// By default, the batch size will be dynamically configured to be ~0.2% of the number of examples
        /// in the training set, capped at 256 - in general, we've found that larger batch sizes tend to
        /// work better for larger datasets.
        /// </summary>
        public long? BatchSize { get; set; }
        /// <summary>
        /// The learning rate multiplier to use for training. The fine-tuning learning rate is the original
        /// learning rate used for pretraining multiplied by this value.
        ///
        /// By default, the learning rate multiplier is the 0.05, 0.1, or 0.2 depending on final
        /// `batch_size` (larger learning rates tend to perform better with larger batch sizes). We
        /// recommend experimenting with values in the range 0.02 to 0.2 to see what produces the best
        /// results.
        /// </summary>
        public double? LearningRateMultiplier { get; set; }
        /// <summary>
        /// The weight to use for loss on the prompt tokens. This controls how much the model tries to
        /// learn to generate the prompt (as compared to the completion which always has a weight of 1.0),
        /// and can add a stabilizing effect to training when completions are short.
        ///
        /// If prompts are extremely long (relative to completions), it may make sense to reduce this
        /// weight so as to avoid over-prioritizing learning the prompt.
        /// </summary>
        public double? PromptLossRate { get; set; }
        /// <summary>
        /// If set, we calculate classification-specific metrics such as accuracy and F-1 score using the
        /// validation set at the end of every epoch. These metrics can be viewed in the
        /// [results file](/docs/guides/legacy-fine-tuning/analyzing-your-fine-tuned-model).
        ///
        /// In order to compute classification metrics, you must provide a `validation_file`. Additionally,
        /// you must specify `classification_n_classes` for multiclass classification or
        /// `classification_positive_class` for binary classification.
        /// </summary>
        public bool? ComputeClassificationMetrics { get; set; }
        /// <summary>
        /// The number of classes in a classification task.
        ///
        /// This parameter is required for multiclass classification.
        /// </summary>
        public long? ClassificationNClasses { get; set; }
        /// <summary>
        /// The positive class in binary classification.
        ///
        /// This parameter is needed to generate precision, recall, and F1 metrics when doing binary
        /// classification.
        /// </summary>
        public string ClassificationPositiveClass { get; set; }
        /// <summary>
        /// If this is provided, we calculate F-beta scores at the specified beta values. The F-beta score
        /// is a generalization of F-1 score. This is only used for binary classification.
        ///
        /// With a beta of 1 (i.e. the F-1 score), precision and recall are given the same weight. A larger
        /// beta score puts more weight on recall and less on precision. A smaller beta score puts more
        /// weight on precision and less on recall.
        /// </summary>
        public IList<double> ClassificationBetas { get; set; }
        /// <summary>
        /// A string of up to 18 characters that will be added to your fine-tuned model name.
        ///
        /// For example, a `suffix` of "custom-model-name" would produce a model name like
        /// `ada:ft-your-org:custom-model-name-2022-02-15-04-21-04`.
        /// </summary>
        public string Suffix { get; set; }
    }
}
