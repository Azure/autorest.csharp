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
        // common usaged definitions
        internal static readonly InputModelProperty RequiredStringProperty = new InputModelProperty("requiredString", "requiredString", "Required string, illustrating a reference type property.", InputPrimitiveType.String, true, false, false);

        internal static readonly InputModelProperty RequiredInitProperty = new InputModelProperty("requiredInt", "requiredInt", "Required int, illustrating a value type property.", InputPrimitiveType.Int32, true, false, false);

        internal static TypeFactory CadlTypeFactory => new TypeFactory(null);

        internal static readonly InputModelType ElementModelType = new InputModelType("SimpleModel", "Cadl.TestServer.ModelCollectionProperties.Models", "public",
            "Simple model that will appear in a collection.", InputModelTypeUsage.RoundTrip,
            new List<InputModelProperty> { RequiredStringProperty, RequiredInitProperty },
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
