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
    internal class EnumType : TypeProvider
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

        private EnumType(Schema schema, BuildContext context, Schema baseType, IEnumerable<ChoiceValue> choices, bool isExtendable) : base(context)
        {
            _context = context;
            _choices = choices;

            DefaultName = schema.CSharpName();
            var usage = context.SchemaUsageProvider.GetUsage(schema);
            var hasUsage = usage.HasFlag(SchemaTypeUsage.Model);
            DefaultAccessibility = schema.Extensions?.Accessibility ?? (hasUsage ? "public" : "internal");

            if (schema.Extensions?.Namespace is string namespaceExtension)
            {
                DefaultNamespace = namespaceExtension;
            }
            else if (context.Configuration.ModelNamespace)
            {
                DefaultNamespace = $"{context.DefaultNamespace}.Models";
            }
            else
            {
                DefaultNamespace = context.DefaultNamespace;
            }

            if (ExistingType != null)
            {
                isExtendable = ExistingType.TypeKind switch
                {
                    TypeKind.Enum => false,
                    TypeKind.Struct => true,
                    _ => throw new InvalidOperationException(
                        $"{ExistingType.ToDisplayString()} cannot be mapped to enum," +
                        $" expected enum or struct got {ExistingType.TypeKind}")
                };

                _typeMapping = context.SourceInputModel.CreateForModel(ExistingType);
            }

            BaseType = context.TypeFactory.CreateType(baseType, false);
            Description = BuilderHelpers.CreateDescription(schema);
            IsExtendable = isExtendable;
        }

        public CSharpType BaseType { get; }
        public bool IsExtendable { get; }
        public string? Description { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        protected override string DefaultNamespace { get; }
        protected override TypeKind TypeKind => IsExtendable ? TypeKind.Struct : TypeKind.Enum;

        public IList<EnumTypeValue> Values => _values ??= BuildValues();

        private List<EnumTypeValue> BuildValues()
        {
            var values = new List<EnumTypeValue>();
            foreach (var c in _choices)
            {
                var name = BuilderHelpers.DisambiguateName(Type, c.CSharpName());
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