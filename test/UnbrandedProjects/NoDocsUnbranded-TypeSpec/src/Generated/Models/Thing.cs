// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace NoDocsUnbrandedTypeSpec.Models
{
    public partial class Thing
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal Thing(string name, BinaryData requiredUnion, string requiredBadDescription, IEnumerable<int> requiredNullableList)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(requiredUnion, nameof(requiredUnion));
            Argument.AssertNotNull(requiredBadDescription, nameof(requiredBadDescription));

            Name = name;
            RequiredUnion = requiredUnion;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = new ChangeTrackingList<int>();
            RequiredNullableList = requiredNullableList?.ToList();
        }

        internal Thing(string name, BinaryData requiredUnion, ThingRequiredLiteralString requiredLiteralString, ThingRequiredLiteralInt requiredLiteralInt, ThingRequiredLiteralFloat requiredLiteralFloat, bool requiredLiteralBool, ThingOptionalLiteralString? optionalLiteralString, ThingOptionalLiteralInt? optionalLiteralInt, ThingOptionalLiteralFloat? optionalLiteralFloat, bool? optionalLiteralBool, string requiredBadDescription, IReadOnlyList<int> optionalNullableList, IReadOnlyList<int> requiredNullableList, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            RequiredUnion = requiredUnion;
            RequiredLiteralString = requiredLiteralString;
            RequiredLiteralInt = requiredLiteralInt;
            RequiredLiteralFloat = requiredLiteralFloat;
            RequiredLiteralBool = requiredLiteralBool;
            OptionalLiteralString = optionalLiteralString;
            OptionalLiteralInt = optionalLiteralInt;
            OptionalLiteralFloat = optionalLiteralFloat;
            OptionalLiteralBool = optionalLiteralBool;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = optionalNullableList;
            RequiredNullableList = requiredNullableList;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal Thing()
        {
        }

        public string Name { get; }
        public BinaryData RequiredUnion { get; }
        public ThingRequiredLiteralString RequiredLiteralString { get; } = ThingRequiredLiteralString.Accept;

        public ThingRequiredLiteralInt RequiredLiteralInt { get; } = ThingRequiredLiteralInt._123;

        public ThingRequiredLiteralFloat RequiredLiteralFloat { get; } = ThingRequiredLiteralFloat._123;

        public bool RequiredLiteralBool { get; } = false;

        public ThingOptionalLiteralString? OptionalLiteralString { get; }
        public ThingOptionalLiteralInt? OptionalLiteralInt { get; }
        public ThingOptionalLiteralFloat? OptionalLiteralFloat { get; }
        public bool? OptionalLiteralBool { get; }
        public string RequiredBadDescription { get; }
        public IReadOnlyList<int> OptionalNullableList { get; }
        public IReadOnlyList<int> RequiredNullableList { get; }
    }
}
