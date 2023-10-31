// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class ReplaceStringUnionTypesWithEnums : InputNamespaceVisitor
    {
        private readonly Dictionary<InputUnionType, InputEnumType> _replacements;

        private ReplaceStringUnionTypesWithEnums()
        {
            _replacements = new Dictionary<InputUnionType, InputEnumType>();
        }

        protected override InputNamespace VisitNamespace(InputNamespace inputNamespace)
        {
            inputNamespace = base.VisitNamespace(inputNamespace);

            return _replacements.Any()
                ? inputNamespace with {Enums = inputNamespace.Enums.Concat(_replacements.Values).ToList()}
                : inputNamespace;
        }

        protected override InputModelProperty VisitModelProperty(InputModelType model, InputModelProperty property, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            if (property.Type is not InputUnionType union || !union.IsAllLiteralString() && !union.IsAllLiteralStringPlusString())
            {
                return base.VisitModelProperty(model, property, typesMap);
            }

            var enumType = new InputEnumType
            (
                $"{model.Name}{property.Name.FirstCharToUpperCase()}",
                model.Namespace,
                model.Accessibility,
                null,
                $"Enum for {property.Name} in {model.Name}",
                model.Usage,
                InputPrimitiveType.String,
                union.GetEnum(),
                true,
                union.IsNullable
            );

            _replacements[union] = enumType;
            return property with {Type = enumType};
        }

        public static InputNamespace Visit(InputNamespace rootNamespace) =>
            new ReplaceStringUnionTypesWithEnums().VisitNamespace(rootNamespace);
    }
}
