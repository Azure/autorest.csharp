using AutoRest.CSharp.Common.Input;
using NUnit.Framework;
using AutoRest.CSharp.Output.Models.Types;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Tests.Common.Output.Models.Types
{
    public class ObjectTypePropertyTests
    {
        private TypeFactory typeFactory;
        [SetUp]
        public void TestSetup()
        {
            typeFactory = new TypeFactory(null);
        }

        // Validates that the type string is constructed correctly for a given primitive type
        [Test]
        public void TestConstructDetailsForListType_PrimitiveType()
        {
            bool isNullable = false;
            InputPrimitiveType type = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            CSharpType cSharpType = typeFactory.CreateType(type);

            string result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType);
            string expectedResult = "bool";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the type string is constructed correctly for a given list type
        [Test]
        public void TestConstructDetailsForListTypep_ListType()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputListType type = new InputListType("InputListType", elementType, isNullable);

            CSharpType cSharpType = typeFactory.CreateType(type);

            string result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType);
            string expectedResult = "IList{bool}";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the type string is constructed correctly for a given nested list type
        [Test]
        public void TestConstructDetailsForListType_NestedListType()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputType listElementType = new InputListType("InputListType1", elementType, isNullable);
            InputListType type = new InputListType("InputListType2", listElementType, isNullable);

            CSharpType cSharpType = typeFactory.CreateType(type);

            string result = ObjectTypeProperty.ConstructDetailsForListType(cSharpType);
            string expectedResult = "IList{IList{bool}}";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the type description summary string is constructed correctly for a given dictionary type
        [Test]
        public void TestConstructTypeStringForCollection_DictionaryType()
        {
            bool isNullable = false;
            InputType keyType = new InputPrimitiveType(InputTypeKind.String, isNullable);
            InputType valueType = new InputPrimitiveType(InputTypeKind.Int32, isNullable);
            InputType type = new InputDictionaryType("InputDictionaryType", keyType, valueType, isNullable);

            CSharpType cSharpType = typeFactory.CreateType(type);

            string result = ObjectTypeProperty.ConstructTypeStringForCollection(cSharpType);
            string expectedResult = $"<description><see cref=\"IDictionary{{TKey, TValue}}\"/></description>";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the type description summary string is constructed correctly for a given list type
        [Test]
        public void TestConstructTypeStringForCollection_ListType()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputType listElementType = new InputListType("InputListType1", elementType, isNullable);
            InputListType type = new InputListType("InputListType2", listElementType, isNullable);

            CSharpType cSharpType = typeFactory.CreateType(type);

            string result = ObjectTypeProperty.ConstructTypeStringForCollection(cSharpType);
            string expectedResult = $"<description><see cref=\"IList{{T}}\"/> Where <c>T</c> is of type <c>IList{{bool}}</c></description>";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the summary description string is constructed correctly for several types
        [Test]
        public void TestGetUnionTypesDescriptions()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputListType listType = new InputListType("InputListType", elementType, isNullable);

            // dictionary type
            InputType keyType = new InputPrimitiveType(InputTypeKind.String, isNullable);
            InputType valueType = new InputPrimitiveType(InputTypeKind.Int32, isNullable);
            InputType dictionaryType = new InputDictionaryType("InputDictionaryType", keyType, valueType, isNullable);

            // literal type
            InputType literalValueType = new InputPrimitiveType(InputTypeKind.Int32, isNullable);
            InputLiteralType literalType = new InputLiteralType("InputLiteralType", literalValueType, 21, isNullable);

            IList<CSharpType> unionItems = new List<CSharpType>()
            {
                typeFactory.CreateType(new InputPrimitiveType(InputTypeKind.Boolean, false)),
                typeFactory.CreateType(listType),
                typeFactory.CreateType(new InputPrimitiveType(InputTypeKind.Int32, false)),
                typeFactory.CreateType(dictionaryType),
                typeFactory.CreateType(literalType),
            };

            IReadOnlyList<string> descriptions = ObjectTypeProperty.GetUnionTypesDescriptions(unionItems);

            Assert.AreEqual(5, descriptions.Count);
            var expectedDescription = "<description><see cref=\"bool\"/></description>";
            Assert.AreEqual(expectedDescription, descriptions[0]);
            var expectedListDescription = $"<description><see cref=\"IList{{T}}\"/> Where <c>T</c> is of type <c>bool</c></description>";
            Assert.AreEqual(expectedListDescription, descriptions[1]);
            expectedDescription = "<description><see cref=\"int\"/></description>";
            Assert.AreEqual(expectedDescription, descriptions[2]);
            var expectedDictionaryDescription = $"<description><see cref=\"IDictionary{{TKey, TValue}}\"/></description>";
            Assert.AreEqual(expectedDictionaryDescription, descriptions[3]);
            var expectedLiteralDescription = $"<description>\"21\"</description>";
            Assert.AreEqual(expectedLiteralDescription, descriptions[4]);
        }
    }
}
