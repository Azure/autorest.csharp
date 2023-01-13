// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Input
{
    internal class MgmtTestConfiguration
    {
        private const string TestGenOptionsRoot = "testgen";
        private const string TestGenOptionsFormat = $"{TestGenOptionsRoot}.{{0}}";

        public string? SourceCodePath { get; }
        public bool Mock { get; }
        public bool Sample { get; }
        public ImmutableHashSet<string> SkippedOperations { get; }

        public MgmtTestConfiguration(
            IReadOnlyList<string> skippedOperations,
            JsonElement? sourceCodePath = default,
            JsonElement? mock = default,
            JsonElement? sample = default)
        {
            SkippedOperations = skippedOperations.ToImmutableHashSet();
            SourceCodePath = !Configuration.IsValidJsonElement(sourceCodePath) ? null : sourceCodePath.ToString();
            Mock = Configuration.DeserializeBoolean(mock, false);
            Sample = Configuration.DeserializeBoolean(sample, false);
        }

        internal static MgmtTestConfiguration? LoadConfiguration(JsonElement root)
        {
            if (root.TryGetProperty(TestGenOptionsRoot, out var testGenRoot))
                return null;
            if (testGenRoot.ValueKind != JsonValueKind.Object)
                return null;

            testGenRoot.TryGetProperty(nameof(SkippedOperations), out var skippedOperationsElement);
            testGenRoot.TryGetProperty(nameof(SourceCodePath), out var sourceCodePath);
            testGenRoot.TryGetProperty(nameof(Mock), out var mock);
            testGenRoot.TryGetProperty(nameof(Sample), out var sample);

            var skippedOperations = Configuration.DeserializeArray(skippedOperationsElement);

            return new MgmtTestConfiguration(
                skippedOperations,
                sourceCodePath: sourceCodePath,
                mock: mock,
                sample: sample);
        }

        internal static MgmtTestConfiguration? GetConfiguration(IPluginCommunication autoRest)
        {
            var testGen = autoRest.GetValue<JsonElement?>(TestGenOptionsRoot).GetAwaiter().GetResult();
            if (!Configuration.IsValidJsonElement(testGen))
            {
                return null;
            }
            return new MgmtTestConfiguration(
                skippedOperations: autoRest.GetValue<string[]?>(string.Format(TestGenOptionsFormat, "skipped-operations")).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                sourceCodePath: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "source-path")).GetAwaiter().GetResult(),
                mock: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "mock")).GetAwaiter().GetResult(),
                sample: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "sample")).GetAwaiter().GetResult());
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            writer.WriteStartObject(TestGenOptionsRoot);

            WriteNonEmptySettings(writer, nameof(SkippedOperations), SkippedOperations.ToArray());

            if (SourceCodePath is not null)
                writer.WriteString(nameof(SourceCodePath), SourceCodePath);

            if (Mock)
                writer.WriteBoolean(nameof(Mock), Mock);

            if (Sample)
                writer.WriteBoolean(nameof(Sample), Sample);

            writer.WriteEndObject();
        }

        private static void WriteNonEmptySettings(
            Utf8JsonWriter writer,
            string settingName,
            IReadOnlyList<string> settings)
        {
            if (settings.Count() > 0)
            {
                writer.WriteStartArray(settingName);
                foreach (var s in settings)
                {
                    writer.WriteStringValue(s);
                }

                writer.WriteEndArray();
            }
        }
    }
}
