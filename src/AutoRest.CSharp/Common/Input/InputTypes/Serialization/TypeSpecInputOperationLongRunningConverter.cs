// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputOperationLongRunningConverter : JsonConverter<InputOperationLongRunning>
    {
        public TypeSpecInputOperationLongRunningConverter()
        {
        }

        public override InputOperationLongRunning? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => CreateOperationLongRunning(ref reader, options);

        public override void Write(Utf8JsonWriter writer, InputOperationLongRunning value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputOperationLongRunning CreateOperationLongRunning(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            int finalStateVia = default;
            InputOperationResponse? finalResponse = null;
            string? resultPath = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadInt32("finalStateVia", ref finalStateVia)
                    || reader.TryReadComplexType("finalResponse", options, ref finalResponse)
                    || reader.TryReadString("resultPath", ref resultPath);

                if (!isKnownProperty)
                {
                    continue;
                }
            }

            var result = new InputOperationLongRunning((OperationFinalStateVia)finalStateVia, finalResponse ?? new InputOperationResponse(), resultPath);

            return result;
        }
    }
}
