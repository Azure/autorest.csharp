// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental.Core.Serialization;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateFineTuningJobRequest : IUtf8JsonWriteable
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
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model.ToString());
            if (OptionalProperty.IsDefined(Hyperparameters))
            {
                writer.WritePropertyName("hyperparameters"u8);
                writer.WriteObjectValue(Hyperparameters);
            }
            if (OptionalProperty.IsDefined(Suffix))
            {
                if (Suffix != null)
                {
                    writer.WritePropertyName("suffix"u8);
                    writer.WriteStringValue(Suffix);
                }
                else
                {
                    writer.WriteNull("suffix");
                }
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
