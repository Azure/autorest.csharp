﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;
using AutoRest.CSharp.V3.Output.Builders;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class EnumType : ISchemaType
    {
        private readonly BuildContext _context;
        private readonly IEnumerable<ChoiceValue> _choices;
        private readonly ModelTypeMapping? _typeMapping;
        private IList<EnumTypeValue>? _values;

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
            _context = context;
            _choices = choices;

            var name = schema.CSharpName();
            _typeMapping = context.SourceInputModel.FindForModel($"{context.DefaultNamespace}.Models", name);
            if (_typeMapping != null)
            {
                isStringBased = _typeMapping.ExistingType.TypeKind switch
                {
                    TypeKind.Enum => false,
                    TypeKind.Struct => true,
                    _ => throw new InvalidOperationException(
                        $"{_typeMapping.ExistingType.ToDisplayString()} cannot be mapped to enum," +
                        $" expected enum or struct got {_typeMapping.ExistingType.TypeKind}")
                };
            }

            bool existingTypeOverrides = !isStringBased;

            Schema = schema;
            Declaration = BuilderHelpers.CreateTypeAttributes(
                name,
                $"{context.DefaultNamespace}.Models",
                "public",
                _typeMapping?.ExistingType,
                existingTypeOverrides
                );

            Type = new CSharpType(this, Declaration.Namespace, Declaration.Name, isValueType: true);
            Description = BuilderHelpers.CreateDescription(schema);
            IsStringBased = isStringBased;
        }


        public bool IsStringBased { get; }
        public Schema Schema { get; }
        public TypeDeclarationOptions Declaration { get; }
        public string? Description { get; }
        public IList<EnumTypeValue> Values => _values ??= BuildValues();
        public CSharpType Type { get; }

        private List<EnumTypeValue> BuildValues()
        {
            var values = new List<EnumTypeValue>();
            foreach (var c in _choices)
            {
                var name = c.CSharpName();
                var memberMapping = _typeMapping?.GetForMember(name);
                values.Add(new EnumTypeValue(
                    BuilderHelpers.CreateMemberDeclaration(name, Type, "public", memberMapping?.ExistingMember, _context.TypeFactory),
                    CreateDescription(c),
                    BuilderHelpers.StringConstant(c.Value)));
            }

            return values;
        }

        private static string CreateDescription(ChoiceValue choiceValue)
        {
            return string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description) ? choiceValue.Value : BuilderHelpers.EscapeXmlDescription(choiceValue.Language.Default.Description);
        }
    }
}