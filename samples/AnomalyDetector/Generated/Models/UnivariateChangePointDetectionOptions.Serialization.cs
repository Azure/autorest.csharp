// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class UnivariateChangePointDetectionOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("series");
            writer.WriteStartArray();
            foreach (var item in Series)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("granularity");
            writer.WriteStringValue(Granularity.ToSerialString());
            if (Optional.IsDefined(CustomInterval))
            {
                if (CustomInterval != null)
                {
                    writer.WritePropertyName("customInterval");
                    writer.WriteNumberValue(CustomInterval.Value);
                }
                else
                {
                    writer.WriteNull("customInterval");
                }
            }
            if (Optional.IsDefined(Period))
            {
                if (Period != null)
                {
                    writer.WritePropertyName("period");
                    writer.WriteNumberValue(Period.Value);
                }
                else
                {
                    writer.WriteNull("period");
                }
            }
            if (Optional.IsDefined(StableTrendWindow))
            {
                if (StableTrendWindow != null)
                {
                    writer.WritePropertyName("stableTrendWindow");
                    writer.WriteNumberValue(StableTrendWindow.Value);
                }
                else
                {
                    writer.WriteNull("stableTrendWindow");
                }
            }
            if (Optional.IsDefined(Threshold))
            {
                if (Threshold != null)
                {
                    writer.WritePropertyName("threshold");
                    writer.WriteNumberValue(Threshold.Value);
                }
                else
                {
                    writer.WriteNull("threshold");
                }
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
