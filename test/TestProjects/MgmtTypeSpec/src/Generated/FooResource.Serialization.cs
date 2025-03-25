// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace MgmtTypeSpec
{
    public partial class FooResource : IJsonModel<FooData>
    {
        void IJsonModel<FooData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FooData>)Data).Write(writer, options);

        FooData IJsonModel<FooData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<FooData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<FooData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        FooData IPersistableModel<FooData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<FooData>(data, options);

        string IPersistableModel<FooData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<FooData>)Data).GetFormatFromOptions(options);
    }
}
