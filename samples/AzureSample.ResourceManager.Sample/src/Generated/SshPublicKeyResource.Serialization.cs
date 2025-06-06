// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace AzureSample.ResourceManager.Sample
{
    public partial class SshPublicKeyResource : IJsonModel<SshPublicKeyData>
    {
        private static SshPublicKeyData s_dataDeserializationInstance;
        private static SshPublicKeyData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<SshPublicKeyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SshPublicKeyData>)Data).Write(writer, options);

        SshPublicKeyData IJsonModel<SshPublicKeyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<SshPublicKeyData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<SshPublicKeyData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<SshPublicKeyData>(Data, options, AzureSampleResourceManagerSampleContext.Default);

        SshPublicKeyData IPersistableModel<SshPublicKeyData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<SshPublicKeyData>(data, options, AzureSampleResourceManagerSampleContext.Default);

        string IPersistableModel<SshPublicKeyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<SshPublicKeyData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}
