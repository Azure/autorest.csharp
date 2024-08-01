using AutoRest.CSharp.Common.Input;
using NUnit.Framework;
using AutoRest.CSharp.Output.Models.Types;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using System;
using System.Globalization;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Tests.Common.Output.Models.Types
{
    public class ObjectTypePropertyTests
    {
        private TypeFactory typeFactory;
        [SetUp]
        public void TestSetup()
        {
            typeFactory = new TypeFactory(null, typeof(BinaryData));
        }

        // Validates that the type string is constructed correctly for a given primitive type
        [Test]
        public void TestConstructDetailsForListType_PrimitiveType()
        {
            bool isBaseElement = true;
            InputPrimitiveType type = InputPrimitiveType.Boolean;
            CSharpType cSharpType = typeFactory.CreateType(type);

            FormattableString result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType, isBaseElement);
            FormattableString expectedResult = $"<see cref=\"bool\"/>";

            bool areStringsEqual = string.Compare(result.ToString(), expectedResult.ToString(), CultureInfo.CurrentCulture,
                CompareOptions.IgnoreSymbols) == 0;

            Assert.True(areStringsEqual);
        }

        // Validates that the type string is constructed correctly for a given list type
        [Test]
        public void TestConstructDetailsForListType_ListType()
        {
            bool isBaseElement = true;
            InputType elementType = InputPrimitiveType.Boolean;
            InputListType type = new InputListType("InputListType", "TypeSpec.Array", elementType);

            CSharpType cSharpType = typeFactory.CreateType(type);

            FormattableString result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType, isBaseElement);
            FormattableString expectedResult = $"<c>IList{{bool}}</c>";

            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

        // Validates that the type string is constructed correctly for a given nested list type
        [Test]
        public void TestConstructDetailsForListType_NestedListType()
        {
            bool isBaseElement = true;
            InputType elementType = InputPrimitiveType.Boolean;
            InputType listElementType = new InputListType("InputListType1", "TypeSpec.Array", elementType);
            InputListType type = new InputListType("InputListType2", "TypeSpec.Array", listElementType);

            CSharpType cSharpType = typeFactory.CreateType(type);

            FormattableString result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType, isBaseElement);
            FormattableString expectedResult = $"<c>IList{{IList{{bool}}}}</c>";

            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

        // Validates that the type string is constructed correctly for a list of dictionary type
        [Test]
        public void TestConstructDetailsForListType_ListOfDictType()
        {
            bool isBaseElement = true;
            InputType keyType = InputPrimitiveType.String;
            InputType valueType = InputPrimitiveType.Int32;
            InputDictionaryType dictionaryType = new InputDictionaryType("InputDictionaryType", keyType, valueType);
            InputType listElementType = new InputListType("InputListType1", "TypeSpec.Array", dictionaryType);

            CSharpType cSharpType = typeFactory.CreateType(listElementType);

            FormattableString result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType, isBaseElement);
            FormattableString expectedResult = $"<c>IList{{IDictionary{{TKey, TValue}}}}</c>";

            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

        // Validates that the summary description string is constructed correctly for several types
        [Test]
        public void TestGetUnionTypesDescriptions()
        {
            // dictionary type
            InputType keyType = InputPrimitiveType.String;
            InputType valueType = InputPrimitiveType.Int32;
            InputType dictionaryType = new InputDictionaryType("InputDictionaryType", keyType, valueType);

            // literal types
            InputType literalValueType = InputPrimitiveType.Int32;
            InputLiteralType literalType = new InputLiteralType(literalValueType, 21);

            InputType stringLiteralValueType = InputPrimitiveType.String;
            InputLiteralType stringLiteralType = new InputLiteralType(stringLiteralValueType, "test");

            InputType boolLiteralValueType = InputPrimitiveType.Boolean;
            InputLiteralType boolLiteralType = new InputLiteralType(boolLiteralValueType, true);

            var unionItems = new List<CSharpType>
            {
                typeFactory.CreateType(InputPrimitiveType.Boolean),
                typeFactory.CreateType(InputPrimitiveType.Int32),
                typeFactory.CreateType(dictionaryType),
                typeFactory.CreateType(literalType),
                typeFactory.CreateType(stringLiteralType),
                typeFactory.CreateType(boolLiteralType),
            };

            IReadOnlyList<FormattableString> descriptions = ObjectTypeProperty.GetUnionTypesDescriptions(unionItems);

            Assert.AreEqual(6, descriptions.Count);

            var codeWriter = new CodeWriter();
            codeWriter.AppendXmlDocumentation($"<test>", $"</test>", descriptions.ToList().Join(Environment.NewLine));
            var actual = codeWriter.ToString(false);

            var expected = string.Join(Environment.NewLine,
                "/// <test>",
                "/// <description><see cref=\"bool\"/></description>",
                "/// <description><see cref=\"int\"/></description>",
                "/// <description><see cref=\"global::System.Collections.Generic.IDictionary{TKey,TValue}\"/> where <c>TKey</c> is of type <see cref=\"string\"/>, where <c>TValue</c> is of type <see cref=\"int\"/></description>",
                "/// <description>21</description>",
                "/// <description>\"test\"</description>",
                "/// <description>True</description>",
                "/// </test>") + Environment.NewLine;

            Assert.AreEqual(expected, actual);
        }
    }

}
