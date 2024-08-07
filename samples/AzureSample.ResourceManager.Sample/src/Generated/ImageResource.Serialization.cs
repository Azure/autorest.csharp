// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace AzureSample.ResourceManager.Sample
{
    public partial class ImageResource : IJsonModel<ImageData>
    {
        void IJsonModel<ImageData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<ImageData>)Data).Write(writer, options);

        ImageData IJsonModel<ImageData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<ImageData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<ImageData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        ImageData IPersistableModel<ImageData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<ImageData>(data, options);

        string IPersistableModel<ImageData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<ImageData>)Data).GetFormatFromOptions(options);
    }
}
