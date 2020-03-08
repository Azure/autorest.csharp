// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class EnumType : ISchemaType
    {
        public EnumType(ChoiceSchema schema, BuildContext context)
            : this(schema, context, schema.Choices, true)
        {
        }

        public EnumType(SealedChoiceSchema schema, BuildContext context)
            : this(schema, context, schema.Choices, false)
        {
        }

        private EnumType(Schema schema, BuildContext context, IEnumerable<ChoiceValue> choices, bool isStringBased)
        {
            var typeMapping = context.SourceInputModel.FindForSchema(schema.Name);
            if (typeMapping != null)
            {
                isStringBased = typeMapping.ExistingType.TypeKind switch
                {
                    TypeKind.Enum => false,
                    TypeKind.Struct => true,
                    _ => throw new InvalidOperationException(
                        $"{typeMapping.ExistingType.ToDisplayString()} cannot be mapped to enum," +
                        $" expected enum or struct got {typeMapping.ExistingType.TypeKind}")
                };
            }

            bool existingTypeOverrides = !isStringBased;

            Schema = schema;
            Declaration = BuilderHelpers.CreateTypeAttributes(
                schema.CSharpName(),
                $"{context.DefaultNamespace}.Models",
                "public",
                typeMapping?.ExistingType,
                existingTypeOverrides
                );

            Type = new CSharpType(this, Declaration.Namespace, Declaration.Name, isValueType: true);
            Description = BuilderHelpers.CreateDescription(schema);

            var values = new List<EnumTypeValue>();
            foreach (var c in choices)
            {
                var memberMapping = typeMapping?.GetMemberForSchema(c.Language.Default.Name);
                values.Add(new EnumTypeValue(
                    BuilderHelpers.CreateMemberDeclaration(c.CSharpName(), Type, "public", memberMapping?.ExistingMember),
                    CreateDescription(c),
                    BuilderHelpers.StringConstant(c.Value)));
            }

            Values = values;
            IsStringBased = isStringBased;
        }

        public bool IsStringBased { get; }
        public Schema Schema { get; }
        public TypeDeclarationOptions Declaration { get; }
        public string? Description { get; }
        public IList<EnumTypeValue> Values { get; }
        public CSharpType Type { get; }

        private static string CreateDescription(ChoiceValue choiceValue)
        {
            return string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description) ? choiceValue.Value : BuilderHelpers.EscapeXmlDescription(choiceValue.Language.Default.Description);
        }
    }
}