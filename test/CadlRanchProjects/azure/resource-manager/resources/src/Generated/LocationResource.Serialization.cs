// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace _Azure.ResourceManager.Resources
{
    public partial class LocationResource : IJsonModel<LocationResourceData>
    {
        void IJsonModel<LocationResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<LocationResourceData>)Data).Write(writer, options);

        LocationResourceData IJsonModel<LocationResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<LocationResourceData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<LocationResourceData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        LocationResourceData IPersistableModel<LocationResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<LocationResourceData>(data, options);

        string IPersistableModel<LocationResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<LocationResourceData>)Data).GetFormatFromOptions(options);
    }
}
