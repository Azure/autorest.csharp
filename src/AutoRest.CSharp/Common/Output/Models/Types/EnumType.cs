// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class EnumType : TypeProvider
    {
        private readonly IEnumerable<InputEnumTypeValue> _allowedValues;
        private readonly ModelTypeMapping? _typeMapping;
        private readonly TypeFactory _typeFactory;
        private IList<EnumTypeValue>? _values;

        public EnumType(ChoiceSchema schema, BuildContext context)
            : this(CodeModelConverter.CreateEnumType(schema, schema.ChoiceType, schema.Choices, true), context.DefaultNamespace, GetAccessibility(schema, context), context.TypeFactory, context.SourceInputModel)
        {
        }

        public EnumType(SealedChoiceSchema schema, BuildContext context)
            : this(CodeModelConverter.CreateEnumType(schema, schema.ChoiceType, schema.Choices, false), context.DefaultNamespace, GetAccessibility(schema, context), context.TypeFactory, context.SourceInputModel)
        {
        }

        public EnumType(InputEnumType input, string defaultNamespace, string defaultAccessibility, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
            : base(GetDefaultNamespace(input.Namespace, defaultNamespace), sourceInputModel)
        {
            _allowedValues = input.AllowedValues;
            _typeFactory = typeFactory;

            DefaultName = input.Name.ToCleanName();
            DefaultAccessibility = input.Accessibility ?? defaultAccessibility;

            var isExtendable = input.IsExtensible;
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

                _typeMapping = sourceInputModel?.CreateForModel(ExistingType);
            }

            BaseType = typeFactory.CreateType(input.EnumValueType);
            Description = input.Description;
            IsExtendable = isExtendable;
        }

        private static string GetDefaultNamespace(string? ns, string defaultNamespace)
            => ns ?? (Configuration.ModelNamespace ? $"{defaultNamespace}.Models" : defaultNamespace);

        public CSharpType BaseType { get; }
        public bool IsExtendable { get; }
        public string? Description { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        protected override TypeKind TypeKind => IsExtendable ? TypeKind.Struct : TypeKind.Enum;

        public IList<EnumTypeValue> Values => _values ??= BuildValues();

        private List<EnumTypeValue> BuildValues()
        {
            var values = new List<EnumTypeValue>();
            foreach (var value in _allowedValues)
            {
                var name = BuilderHelpers.DisambiguateName(Type, value.Name.ToCleanName());
                var memberMapping = _typeMapping?.GetForMember(name);
                values.Add(new EnumTypeValue(
                    BuilderHelpers.CreateMemberDeclaration(name, Type, "public", memberMapping?.ExistingMember, _typeFactory),
                    CreateDescription(value),
                    BuilderHelpers.ParseConstant(value.Value, BaseType)));
            }

            return values;
        }

        private static string CreateDescription(InputEnumTypeValue value)
        {
            var description = string.IsNullOrWhiteSpace(value.Description)
                ? value.Value
                : value.Description;
            return BuilderHelpers.EscapeXmlDescription(description);
        }

        public static string GetAccessibility(Schema schema, BuildContext context)
        {
            var usage = context.SchemaUsageProvider.GetUsage(schema);
            var hasUsage = usage.HasFlag(SchemaTypeUsage.Model);
            return schema.Extensions?.Accessibility ?? (hasUsage ? "public" : "internal");
        }
    }
}
