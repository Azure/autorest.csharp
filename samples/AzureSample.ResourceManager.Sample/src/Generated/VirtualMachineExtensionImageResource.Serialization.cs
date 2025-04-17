// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace AzureSample.ResourceManager.Sample
{
    public partial class VirtualMachineExtensionImageResource : IJsonModel<VirtualMachineExtensionImageData>
    {
        void IJsonModel<VirtualMachineExtensionImageData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<VirtualMachineExtensionImageData>)Data).Write(writer, options);

        VirtualMachineExtensionImageData IJsonModel<VirtualMachineExtensionImageData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<VirtualMachineExtensionImageData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<VirtualMachineExtensionImageData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<VirtualMachineExtensionImageData>(Data, options, AzureSampleResourceManagerSampleContext.Default);

        VirtualMachineExtensionImageData IPersistableModel<VirtualMachineExtensionImageData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<VirtualMachineExtensionImageData>(data, options, AzureSampleResourceManagerSampleContext.Default);

        string IPersistableModel<VirtualMachineExtensionImageData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<VirtualMachineExtensionImageData>)Data).GetFormatFromOptions(options);
    }
}
