// Copyright (c) Microsoft Corporation. All rights reserved.
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
            : this(schema, context, schema.ChoiceType, schema.Choices, true)
        {
        }

        public EnumType(SealedChoiceSchema schema, BuildContext context)
            : this(schema, context, schema.ChoiceType, schema.Choices, false)
        {
        }

        private EnumType(Schema schema, BuildContext context, Schema baseType, IEnumerable<ChoiceValue> choices, bool isExtendable)
        {
            _context = context;
            _choices = choices;

            var name = schema.CSharpName();
            _typeMapping = context.SourceInputModel.FindForModel($"{context.DefaultNamespace}.Models", name);
            if (_typeMapping != null)
            {
                isExtendable = _typeMapping.ExistingType.TypeKind switch
                {
                    TypeKind.Enum => false,
                    TypeKind.Struct => true,
                    _ => throw new InvalidOperationException(
                        $"{_typeMapping.ExistingType.ToDisplayString()} cannot be mapped to enum," +
                        $" expected enum or struct got {_typeMapping.ExistingType.TypeKind}")
                };
            }

            bool existingTypeOverrides = !isExtendable;

            Schema = schema;
            Declaration = BuilderHelpers.CreateTypeAttributes(
                name,
                $"{context.DefaultNamespace}.Models",
                "public",
                _typeMapping?.ExistingType,
                existingTypeOverrides
                );

            Type = new CSharpType(this, Declaration.Namespace, Declaration.Name, isValueType: true);
            BaseType = context.TypeFactory.CreateType(baseType, false);
            if (BaseType.FrameworkType == typeof(object))
            {
                // https://github.com/Azure/autorest.modelerfour/issues/256
                BaseType = typeof(string);
            }

            Description = BuilderHelpers.CreateDescription(schema);
            IsExtendable = isExtendable;
        }

        public CSharpType BaseType { get; }
        public bool IsExtendable { get; }
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
                    BuilderHelpers.ParseConstant(c.Value, BaseType)));
            }

            return values;
        }

        private static string CreateDescription(ChoiceValue choiceValue)
        {
            return string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description) ? choiceValue.Value : BuilderHelpers.EscapeXmlDescription(choiceValue.Language.Default.Description);
        }
    }
}