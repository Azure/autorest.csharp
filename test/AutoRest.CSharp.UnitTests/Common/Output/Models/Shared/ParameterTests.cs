using System;
using System.Collections.Generic;
using System.Globalization;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.InputTypes;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Moq;
using NUnit.Framework;

namespace AutoRest.CSharp.Tests.Common.Output.Models.Shared
{
    public class ParameterTests
    {
        private TypeFactory typeFactory;
        private Mock<OutputLibrary> library;
        private Mock<TypeProvider> typeProvider;

        [SetUp]
        public void TestSetup()
        {
            library = new Mock<OutputLibrary>();
            typeFactory = new TypeFactory(library.Object, typeof(BinaryData));
            typeProvider = new Mock<TypeProvider>("test", null);
        }

        // Validates that the parameter description is constructed correctly using the default description.
        [Test]
        public void TestCreateDescription_DefaultDescription()
        {
            IReadOnlyList<InputModelProperty> modelProps = new List<InputModelProperty>();
            var derivedModels = new List<InputModelType>();
            InputModelType inputModel = new InputModelType(
                Name: "testInputModel",
                CrossLanguageDefinitionId: "ns.testInputModel",
                Access: "accessibility",
                Deprecation: "test",
                Description: "sample",
                DiscriminatorValue: null,
                DiscriminatorProperty: null,
                DiscriminatedSubtypes: null,
                Usage: new InputModelTypeUsage(),
                Properties: modelProps,
                BaseModel: null,
                DerivedModels: derivedModels,
                AdditionalProperties: null);
            InputParameter opParam = new InputParameter(
                Name: "testParam",
                NameInRequest: "testParam",
                Description: "default",
                Type: inputModel,
                Location: new RequestLocation(),
                DefaultValue: null,
                GroupedBy: null,
                FlattenedBodyProperty: null,
                Kind: InputOperationParameterKind.Method,
                IsRequired: false,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsEndpoint: false,
                SkipUrlEncoding: false,
                Explode: false,
                ArraySerializationDelimiter: null,
                HeaderCollectionPrefix: null);
            // mock the type
            var type = new Mock<CSharpType>(typeProvider.Object, null, true);
            type.Setup(t => t.Namespace).Returns("ns");
            type.Setup(t => t.Name).Returns(inputModel.Name);
            type.Setup(t => t.WithNullable(It.IsAny<bool>())).Returns(type.Object);

            // mock ResolveModel
            library.Setup(l => l.ResolveModel(inputModel)).Returns(type.Object);

            CSharpType cSharpType = typeFactory.CreateType(inputModel);

            FormattableString result = Parameter.CreateDescription(opParam, cSharpType, null, null);
            FormattableString expectedResult = $"default";

            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

        // Validates that the parameter description is constructed correctly for a given input model type
        [Test]
        public void TestCreateDescription_InputModelType()
        {
            IReadOnlyList<InputModelProperty> modelProps = new List<InputModelProperty>();
            var derivedModels = new List<InputModelType>();
            InputModelType inputModel = new InputModelType(
                Name: "testInputModel",
                CrossLanguageDefinitionId: "ns.testInputModel",
                Access: "accessibility",
                Deprecation: "test",
                Description: "sample",
                DiscriminatorValue: null,
                DiscriminatorProperty: null,
                DiscriminatedSubtypes: null,
                Usage: new InputModelTypeUsage(),
                Properties: modelProps,
                BaseModel: null,
                DerivedModels: derivedModels,
                AdditionalProperties: null);
            InputNullableType nullableInputModel = new InputNullableType(inputModel);
            InputParameter opParam = new InputParameter(
                Name: "testParam",
                NameInRequest: "testParam",
                Description: string.Empty,
                Type: nullableInputModel,
                Location: new RequestLocation(),
                DefaultValue: null,
                GroupedBy: null,
                FlattenedBodyProperty: null,
                Kind: InputOperationParameterKind.Method,
                IsRequired: false,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsEndpoint: false,
                SkipUrlEncoding: false,
                Explode: false,
                ArraySerializationDelimiter: null,
                HeaderCollectionPrefix: null);
            // mock the type
            var type = new Mock<CSharpType>(typeProvider.Object, null, true);
            type.Setup(t => t.Namespace).Returns("ns");
            type.Setup(t => t.Name).Returns(inputModel.Name);
            // because `WithNullable` returns a new instance of CSharpType when nullability is different, we have to mock it so that we always use this instance
            type.Setup(t => t.WithNullable(It.IsAny<bool>())).Returns(type.Object);

            // mock ResolveModel
            library.Setup(l => l.ResolveModel(inputModel)).Returns(type.Object);

            CSharpType cSharpType = typeFactory.CreateType(nullableInputModel);

            FormattableString result = Parameter.CreateDescription(opParam, cSharpType, null, null);
            var writer = new CodeWriter();
            writer.AppendXmlDocumentation($"<test>", $"</test>", result);
            var r = writer.ToString(false).Trim();
            var expected = $"/// <test> The <see cref=\"global::ns.{inputModel.Name}\"/> to use. </test>";

            Assert.AreEqual(expected, r);
        }

        // Validates that the input parameter description is constructed correctly for a given type that is not a model
        [Test]
        public void TestCreateDescription_NonInputModelType()
        {
            InputType literalValueType = InputPrimitiveType.Int32;
            InputLiteralType literalType = new InputLiteralType(literalValueType, 21);
            InputParameter opParam = new InputParameter(
                Name: "testParam",
                NameInRequest: "testParam",
                Description: string.Empty,
                Type: literalType,
                Location: new RequestLocation(),
                DefaultValue: null,
                GroupedBy: null,
                FlattenedBodyProperty: null,
                Kind: InputOperationParameterKind.Method,
                IsRequired: false,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsEndpoint: false,
                SkipUrlEncoding: false,
                Explode: false,
                ArraySerializationDelimiter: null,
                HeaderCollectionPrefix: null);

            CSharpType cSharpType = typeFactory.CreateType(literalType);

            FormattableString result = Parameter.CreateDescription(opParam, cSharpType, null, null);
            FormattableString expectedResult = $"The int to use.";

            bool areStringsEqual = string.Compare(result.ToString(), expectedResult.ToString(), CultureInfo.CurrentCulture,
               CompareOptions.IgnoreSymbols) == 0;

            Assert.True(areStringsEqual);
        }

        // Validates that the parameter object is constructed correctly for a given input model type
        [Test]
        public void TestFromInputParameter_InputModelType()
        {
            IReadOnlyList<InputModelProperty> modelProps = new List<InputModelProperty>();
            var derivedModels = new List<InputModelType>();
            InputModelType inputModel = new InputModelType(
                Name: "testInputModel",
                CrossLanguageDefinitionId: "ns.testInputModel",
                Access: "accessibility",
                Deprecation: "test",
                Description: "sample",
                DiscriminatorValue: null,
                DiscriminatorProperty: null,
                DiscriminatedSubtypes: null,
                Usage: new InputModelTypeUsage(),
                Properties: modelProps,
                BaseModel: null,
                DerivedModels: derivedModels,
                AdditionalProperties: null);
            InputNullableType nullableInputModel = new InputNullableType(inputModel);
            InputParameter inputParam = new InputParameter(
                Name: "testParam",
                NameInRequest: "testParam",
                Description: "sampleDescription",
                Type: nullableInputModel,
                Location: new RequestLocation(),
                DefaultValue: null,
                GroupedBy: null,
                FlattenedBodyProperty: null,
                Kind: InputOperationParameterKind.Method,
                IsRequired: false,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsEndpoint: false,
                SkipUrlEncoding: false,
                Explode: false,
                ArraySerializationDelimiter: null,
                HeaderCollectionPrefix: null);
            // mock the type
            var type = new Mock<CSharpType>(typeProvider.Object, null, true);
            type.Setup(t => t.Namespace).Returns("ns");
            type.Setup(t => t.Name).Returns(inputModel.Name);
            type.Setup(t => t.WithNullable(It.IsAny<bool>())).Returns(type.Object);

            // mock ResolveModel
            library.Setup(l => l.ResolveModel(inputModel)).Returns(type.Object);

            CSharpType cSharpType = typeFactory.CreateType(nullableInputModel);

            var parameter = Parameter.FromInputParameter(inputParam, cSharpType, typeFactory);
            Assert.IsNotNull(parameter);

            var result = parameter.Name;
            string expectedResult = inputParam.Name.ToVariableName();

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the parameter object is constructed correctly for a given type that is not a model
        [Test]
        public void TestFromInputParameter_NonInputModelType()
        {
            InputType literalValueType = InputPrimitiveType.Int32;
            InputLiteralType literalType = new InputLiteralType(literalValueType, 21);
            InputParameter inputParam = new InputParameter(
                Name: "testParam",
                NameInRequest: "testParam",
                Description: "sampleDescription",
                Type: literalType,
                Location: new RequestLocation(),
                DefaultValue: null,
                GroupedBy: null,
                FlattenedBodyProperty: null,
                Kind: InputOperationParameterKind.Method,
                IsRequired: false,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsEndpoint: false,
                SkipUrlEncoding: false,
                Explode: false,
                ArraySerializationDelimiter: null,
                HeaderCollectionPrefix: null);

            CSharpType cSharpType = typeFactory.CreateType(literalType);

            var parameter = Parameter.FromInputParameter(inputParam, cSharpType, typeFactory);
            Assert.IsNotNull(parameter);

            var result = parameter.Name;
            string expectedResult = inputParam.Name.ToVariableName();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
