// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class ModelGenerationTestBase
    {
        // common usages definitions
        internal static readonly InputModelProperty RequiredStringProperty = new InputModelProperty("requiredString", "requiredString", "Required string, illustrating a reference type property.", InputPrimitiveType.String, true, false, false);

        internal static readonly InputModelProperty RequiredIntProperty = new InputModelProperty("requiredInt", "requiredInt", "Required int, illustrating a value type property.", InputPrimitiveType.Int32, true, false, false);

        internal static readonly InputModelProperty RequiredStringListProperty = new InputModelProperty("requiredStringList", "requiredStringList", "Required collection of strings, illustrating a collection of reference types.", new InputListType("requiredStringList", InputPrimitiveType.String), true, false, false);

        internal static readonly InputModelProperty RequiredIntListProperty = new InputModelProperty("requiredIntList", "requiredIntList", "Required collection of ints, illustrating a collection of value types.", new InputListType("requiredIntList", InputPrimitiveType.Int32), true, false, false);

        internal static TypeFactory CadlTypeFactory => new TypeFactory(null);

        internal static readonly InputModelType ElementModelType = new InputModelType("SimpleModel", "Cadl.TestServer.ModelCollectionProperties.Models", "public",
            "Simple model that will appear in a collection.", InputModelTypeUsage.RoundTrip,
            new List<InputModelProperty> { RequiredStringProperty, RequiredIntProperty },
            null, new List<InputModelType>(), null);

        internal void ValidateGeneratedCodes(string modelName, string expectedModelCodes, string expectedSerializationCodes, DpgOutputLibrary library)
        {
            Assert.True(library.Models.Any(m => m.Declaration.Name == modelName));
            foreach (var m in library.Models)
            {
                if (m.Declaration.Name == modelName)
                {
                    ValidateGeneratedCodes(m, expectedModelCodes, expectedSerializationCodes);
                }
            }
        }

        internal void ValidateGeneratedCodes(ModelTypeProvider model, string expectedModelCodes, string expectedSerializationCodes)
        {
            ValidateGeneratedModelCodes(model, expectedModelCodes);
            ValidateGeneratedSerializationCodes(model, expectedSerializationCodes);
        }

        internal void ValidateGeneratedModelCodes(ModelTypeProvider model, string expected)
        {
            var codeWriter = new CodeWriter();
            LowLevelModelWriter.WriteType(codeWriter, model);
            var codes = codeWriter.ToString();
            Assert.AreEqual(expected, codes);
        }

        internal void ValidateGeneratedSerializationCodes(ModelTypeProvider model, string expected)
        {
            var codeWriter = new CodeWriter();
            SerializationWriter.WriteModelSerialization(codeWriter, model);
            var codes = codeWriter.ToString();
            Assert.AreEqual(expected, codes);
        }
    }
}
