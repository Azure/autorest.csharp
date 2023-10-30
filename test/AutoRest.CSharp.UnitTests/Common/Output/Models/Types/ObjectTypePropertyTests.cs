using AutoRest.CSharp.Common.Input;
using NUnit.Framework;
using AutoRest.CSharp.Output.Models.Types;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Tests.Common.Output.Models.Types
{
    public class ObjectTypePropertyTests
    {
        // Validates that the type string is constructed correctly for a given primitive type
        [Test]
        public void TestConstructTypeStringForNestedProp_PrimitiveType()
        {
            bool isNullable = false;
            InputPrimitiveType type = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);

            string result = ObjectTypeProperty.ConstructTypeStringForNestedProp(type);
            string expectedResult = "bool";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the type string is constructed correctly for a given list type
        [Test]
        public void TestConstructTypeStringForNestedProp_ListType()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputListType type = new InputListType("InputListType", elementType, isNullable);

            string result = ObjectTypeProperty.ConstructTypeStringForNestedProp(type);
            string expectedResult = "IList<bool>";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the type string is constructed correctly for a given nested list type
        [Test]
        public void TestConstructTypeStringForNestedProp_NestedListType()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputType listElementType = new InputListType("InputListType1", elementType, isNullable);
            InputListType type = new InputListType("InputListType2", listElementType, isNullable);

            string result = ObjectTypeProperty.ConstructTypeStringForNestedProp(type);
            string expectedResult = "IList<IList<bool>>";

            Assert.AreEqual(expectedResult, result);
        }

        // Validates that the summary description string is constructed correctly for several types
        [Test]
        public void TestGetUnionTypesDescriptions()
        {
            bool isNullable = false;
            InputType elementType = new InputPrimitiveType(InputTypeKind.Boolean, isNullable);
            InputListType listType = new InputListType("InputListType", elementType, isNullable);

            IReadOnlyList<InputType> unionItems = new List<InputType>()
            {
                new InputPrimitiveType(InputTypeKind.Boolean, false),
                listType,
                new InputPrimitiveType(InputTypeKind.Int32, false),
            };

            var descriptions = ObjectTypeProperty.GetUnionTypesDescriptions(unionItems);

            Assert.AreEqual(3, descriptions.Count);
            Assert.AreEqual("bool", descriptions[0]);
            var expectedListDescription = BuilderHelpers.EscapeXmlDocDescription("IList<bool>");
            Assert.AreEqual(expectedListDescription, descriptions[1]);
            Assert.AreEqual("int", descriptions[2]);
        }
    }
}
