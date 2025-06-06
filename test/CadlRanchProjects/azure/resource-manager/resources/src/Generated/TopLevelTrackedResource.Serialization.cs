// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace _Azure.ResourceManager.Resources
{
    public partial class TopLevelTrackedResource : IJsonModel<TopLevelTrackedResourceData>
    {
        private static TopLevelTrackedResourceData s_dataDeserializationInstance;
        private static TopLevelTrackedResourceData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<TopLevelTrackedResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<TopLevelTrackedResourceData>)Data).Write(writer, options);

        TopLevelTrackedResourceData IJsonModel<TopLevelTrackedResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<TopLevelTrackedResourceData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<TopLevelTrackedResourceData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<TopLevelTrackedResourceData>(Data, options, _AzureResourceManagerResourcesContext.Default);

        TopLevelTrackedResourceData IPersistableModel<TopLevelTrackedResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<TopLevelTrackedResourceData>(data, options, _AzureResourceManagerResourcesContext.Default);

        string IPersistableModel<TopLevelTrackedResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<TopLevelTrackedResourceData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}
