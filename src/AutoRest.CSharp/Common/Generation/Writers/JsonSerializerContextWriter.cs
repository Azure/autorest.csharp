// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class JsonSerializerContextWriter
    {
        public void Write(CodeWriter writer, IEnumerable<TypeProvider> types)
        {
            using (writer.Namespace($"{Configuration.HelperNamespace}"))
            {
                writer.Line($"[{typeof(JsonSourceGenerationOptionsAttribute)}(WriteIndented = false)]");
                foreach (var type in types)
                {
                    writer.Line($"[{typeof(JsonSerializableAttribute)}(typeof({type.Type}))]");
                }
                using (writer.Scope($"internal partial class {Name} : {typeof(ModelReaderWriterContext)}"))
                {
                }
            }
        }

        public static string Name => $"{Configuration.Namespace.RemovePeriods()}JsonContext";
    }
}
