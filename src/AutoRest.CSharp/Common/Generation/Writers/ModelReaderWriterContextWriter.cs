// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class ModelReaderWriterContextWriter
    {
        public void Write(CodeWriter writer, IReadOnlyList<CSharpType> buildableTypes = null)
        {
            // Write assembly-level attributes if buildable types are provided
            if (buildableTypes != null && buildableTypes.Any())
            {
                writer.Line("using System.ClientModel.Primitives;");
                writer.Line();
                
                // Write assembly-level attributes
                foreach (var type in buildableTypes.OrderBy(t => t.Name))
                {
                    writer.Line($"[assembly: ModelReaderWriterBuildableAttribute(typeof({type}))]");
                }
                writer.Line();
            }

            using (writer.Namespace($"{Configuration.Namespace}"))
            {
                writer.Line($"/// <summary>");
                writer.Line($"/// Context class which will be filled in by the System.ClientModel.SourceGeneration.");
                writer.Line($"/// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'");
                writer.Line($"/// </summary>");
                using (writer.Scope($"public partial class {Name} : {typeof(ModelReaderWriterContext)}"))
                {
                }
            }
        }

        public static string Name => $"{Configuration.Namespace.RemovePeriods()}Context";
    }
}
