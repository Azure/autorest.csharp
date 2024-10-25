// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Common.Input;

namespace AutoRest.CSharp.Input
{
    internal class MgmtTestConfiguration
    {
        internal const string TestGenOptionsRoot = "sample-gen";
        private const string TestGenOptionsFormat = $"{TestGenOptionsRoot}.{{0}}";

        public string? SourceCodePath { get; }
        public string? OutputFolder { get; }
        public bool Sample { get; }
        public IReadOnlyList<string> SkippedOperations { get; }
        public bool ClearOutputFolder { get; }

        public MgmtTestConfiguration(
            IReadOnlyList<string> skippedOperations,
            JsonElement? sourceCodePath = default,
            JsonElement? sample = default,
            JsonElement? outputFolder = default,
            JsonElement? clearOutputFolder = default)
        {
            SkippedOperations = skippedOperations;
            SourceCodePath = !Configuration.IsValidJsonElement(sourceCodePath) ? null : sourceCodePath.ToString();
            Sample = Configuration.DeserializeBoolean(sample, true);
            OutputFolder = !Configuration.IsValidJsonElement(outputFolder) ? null : Configuration.TrimFileSuffix(outputFolder.ToString() ?? "");
            ClearOutputFolder = Configuration.DeserializeBoolean(clearOutputFolder, false);
        }

        internal static MgmtTestConfiguration? LoadConfiguration(JsonElement root)
        {
            if (!root.TryGetProperty(TestGenOptionsRoot, out var testGenRoot))
                return null;
            if (testGenRoot.ValueKind != JsonValueKind.Object)
                return null;

            testGenRoot.TryGetProperty(Options.SkippedOperations, out var skippedOperationsElement);
            testGenRoot.TryGetProperty(Options.SourcePath, out var sourceCodePath);
            testGenRoot.TryGetProperty(Options.Sample, out var sample);
            testGenRoot.TryGetProperty(Options.OutputFolder, out var testGenOutputFolder);
            testGenRoot.TryGetProperty(Options.ClearOutputFolder, out var testGenClearOutputFolder);

            var skippedOperations = Configuration.DeserializeArray(skippedOperationsElement);

            return new MgmtTestConfiguration(
                skippedOperations,
                sourceCodePath: sourceCodePath,
                sample: sample,
                outputFolder: testGenOutputFolder,
                clearOutputFolder: testGenClearOutputFolder);
        }

        internal static MgmtTestConfiguration? GetConfiguration(IPluginCommunication autoRest)
        {
            if (!HasMgmtTestConfiguration(autoRest))
                return null;

            return new MgmtTestConfiguration(
                skippedOperations: autoRest.GetValue<string[]?>(string.Format(TestGenOptionsFormat, "skipped-operations")).GetAwaiter().GetResult() ?? Array.Empty<string>(),
                sourceCodePath: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "source-path")).GetAwaiter().GetResult(),
                sample: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "sample")).GetAwaiter().GetResult(),
                outputFolder: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "output-folder")).GetAwaiter().GetResult(),
                clearOutputFolder: autoRest.GetValue<JsonElement?>(string.Format(TestGenOptionsFormat, "clear-output-folder")).GetAwaiter().GetResult());
        }

        private static class Options
        {
            internal const string SkippedOperations = "skipped-operations";

            internal const string SourcePath = "source-path";

            internal const string Sample = "sample";

            internal const string OutputFolder = "output-folder";

            internal const string ClearOutputFolder = "clear-output-folder";
        }

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            writer.WriteStartObject(TestGenOptionsRoot);

            WriteNonEmptySettings(writer, Options.SkippedOperations, SkippedOperations);

            if (SourceCodePath is not null)
                writer.WriteString(Options.SourcePath, SourceCodePath);

            if (Sample)
                writer.WriteBoolean(Options.Sample, Sample);

            if (OutputFolder is not null)
                writer.WriteString(Options.OutputFolder, Path.GetRelativePath(Configuration.OutputFolder, OutputFolder));

            if (!ClearOutputFolder)
                writer.WriteBoolean(Options.ClearOutputFolder, ClearOutputFolder);

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

        internal static bool HasMgmtTestConfiguration(IPluginCommunication autoRest)
        {
            var testGen = autoRest.GetValue<JsonElement?>(TestGenOptionsRoot).GetAwaiter().GetResult();
            return Configuration.IsValidJsonElement(testGen);
        }
    }
}
