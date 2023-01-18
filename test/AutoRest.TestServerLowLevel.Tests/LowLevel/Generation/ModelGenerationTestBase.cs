// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
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

        internal static readonly InputModelType ElementModelType = new InputModelType("SimpleModel", "Cadl.TestServer.ModelCollectionProperties.Models", null, "public",
            "Simple model that will appear in a collection.", InputModelTypeUsage.RoundTrip,
            new List<InputModelProperty> { RequiredStringProperty, RequiredIntProperty },
            null, new List<InputModelType>(), null, null);

        [OneTimeSetUp]
        public void init()
        {
            Configuration.Initialize("Generated", "", "", new string[] { }, false, false, true, false, false, false, false, false, false, false, false, Configuration.UnreferencedTypesHandlingOption.RemoveOrInternalize, ".", new string[] { }, new List<string>(), null, null);
        }


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
            //TODO this is an inefficient way to manage expected results since any tiny change in formatting results in hundreds (thousands in the future) of places
            //that now need to be updated.  We should convert this into asserts about shape using reflection and leave the formatting to reviews / roslyn

            //var codeWriter = new CodeWriter();
            //var modelWriter = new ModelWriter();
            //modelWriter.WriteModel(codeWriter, model);
            //var codes = codeWriter.ToString();
            //Assert.AreEqual(expected, codes);
        }

        internal void ValidateGeneratedSerializationCodes(ModelTypeProvider model, string expected)
        {
            //TODO this is an inefficient way to manage expected results since any tiny change in formatting results in hundreds (thousands in the future) of places
            //that now need to be updated.  We should convert this into asserts about shape using reflection and leave the formatting to reviews / roslyn

            //var codeWriter = new CodeWriter();
            //SerializationWriter serializationWriter = new SerializationWriter();
            //serializationWriter.WriteSerialization(codeWriter, model);
            //var codes = codeWriter.ToString();
            //Assert.AreEqual(expected, codes);
        }
    }
}
