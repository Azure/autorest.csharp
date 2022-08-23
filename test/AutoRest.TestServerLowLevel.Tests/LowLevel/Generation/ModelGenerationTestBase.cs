using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class ModelGenerationTestBase
    {
        // common usaged definitions
        internal static readonly InputModelProperty RequiredStringProperty = new InputModelProperty("requiredString", "requiredString", "Required string, illustrating a reference type property.", InputPrimitiveType.String, true, false, false);

        internal static readonly InputModelProperty RequiredInitProperty = new InputModelProperty("requiredInt", "requiredInt", "Required int, illustrating a value type property.", InputPrimitiveType.Int32, true, false, false);

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
