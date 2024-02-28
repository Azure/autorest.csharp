// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Sample
{
    public partial class DedicatedHostResource : IJsonModel<DedicatedHostData>
    {
        void IJsonModel<DedicatedHostData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DedicatedHostData>)Data).Write(writer, options);

        DedicatedHostData IJsonModel<DedicatedHostData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<DedicatedHostData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<DedicatedHostData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        DedicatedHostData IPersistableModel<DedicatedHostData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DedicatedHostData>(data, options);

        string IPersistableModel<DedicatedHostData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<DedicatedHostData>)Data).GetFormatFromOptions(options);
    }
}
