// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental.Core.Serialization;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateFineTuneRequest : IUtf8JsonWriteable
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("training_file"u8);
            writer.WriteStringValue(TrainingFile);
            if (OptionalProperty.IsDefined(ValidationFile))
            {
                if (ValidationFile != null)
                {
                    writer.WritePropertyName("validation_file"u8);
                    writer.WriteStringValue(ValidationFile);
                }
                else
                {
                    writer.WriteNull("validation_file");
                }
            }
            if (OptionalProperty.IsDefined(Model))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.Value.ToString());
            }
            if (OptionalProperty.IsDefined(NEpochs))
            {
                if (NEpochs != null)
                {
                    writer.WritePropertyName("n_epochs"u8);
                    writer.WriteNumberValue(NEpochs.Value);
                }
                else
                {
                    writer.WriteNull("n_epochs");
                }
            }
            if (OptionalProperty.IsDefined(BatchSize))
            {
                if (BatchSize != null)
                {
                    writer.WritePropertyName("batch_size"u8);
                    writer.WriteNumberValue(BatchSize.Value);
                }
                else
                {
                    writer.WriteNull("batch_size");
                }
            }
            if (OptionalProperty.IsDefined(LearningRateMultiplier))
            {
                if (LearningRateMultiplier != null)
                {
                    writer.WritePropertyName("learning_rate_multiplier"u8);
                    writer.WriteNumberValue(LearningRateMultiplier.Value);
                }
                else
                {
                    writer.WriteNull("learning_rate_multiplier");
                }
            }
            if (OptionalProperty.IsDefined(PromptLossRate))
            {
                if (PromptLossRate != null)
                {
                    writer.WritePropertyName("prompt_loss_rate"u8);
                    writer.WriteNumberValue(PromptLossRate.Value);
                }
                else
                {
                    writer.WriteNull("prompt_loss_rate");
                }
            }
            if (OptionalProperty.IsDefined(ComputeClassificationMetrics))
            {
                if (ComputeClassificationMetrics != null)
                {
                    writer.WritePropertyName("compute_classification_metrics"u8);
                    writer.WriteBooleanValue(ComputeClassificationMetrics.Value);
                }
                else
                {
                    writer.WriteNull("compute_classification_metrics");
                }
            }
            if (OptionalProperty.IsDefined(ClassificationNClasses))
            {
                if (ClassificationNClasses != null)
                {
                    writer.WritePropertyName("classification_n_classes"u8);
                    writer.WriteNumberValue(ClassificationNClasses.Value);
                }
                else
                {
                    writer.WriteNull("classification_n_classes");
                }
            }
            if (OptionalProperty.IsDefined(ClassificationPositiveClass))
            {
                if (ClassificationPositiveClass != null)
                {
                    writer.WritePropertyName("classification_positive_class"u8);
                    writer.WriteStringValue(ClassificationPositiveClass);
                }
                else
                {
                    writer.WriteNull("classification_positive_class");
                }
            }
            if (OptionalProperty.IsCollectionDefined(ClassificationBetas))
            {
                if (ClassificationBetas != null)
                {
                    writer.WritePropertyName("classification_betas"u8);
                    writer.WriteStartArray();
                    foreach (var item in ClassificationBetas)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("classification_betas");
                }
            }
            if (Suffix != null)
            {
                writer.WritePropertyName("suffix"u8);
                writer.WriteStringValue(Suffix);
            }
            else
            {
                writer.WriteNull("suffix");
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            var content = new Utf8JsonRequestBody();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
