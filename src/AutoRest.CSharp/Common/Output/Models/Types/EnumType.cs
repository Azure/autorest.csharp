// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
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
        public EnumType(InputEnumType enumType, BuildContext context)
            : this(enumType, GetDefaultModelNamespace(null, context.DefaultNamespace), enumType.Accessibility ?? "public", context.TypeFactory, context.SourceInputModel)
        {
        }

        public EnumType(InputEnumType input, string defaultNameSpace, string defaultAccessibility, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
            : base(defaultNameSpace, sourceInputModel)
        {
            IsEnum = true;
            _allowedValues = input.Values;
            _typeFactory = typeFactory;
            _deprecation = input.Deprecated;

            DefaultName = input.Name.ToCleanName();
            DefaultAccessibility = input.Accessibility ?? defaultAccessibility;
            IsAccessibilityOverridden = input.Accessibility != null;

            var isExtensible = input.IsExtensible;
            if (ExistingType != null)
            {
                isExtensible = ExistingType.TypeKind switch
                {
                    TypeKind.Enum => false,
                    TypeKind.Struct => true,
                    _ => throw new InvalidOperationException(
                        $"{ExistingType.ToDisplayString()} cannot be mapped to enum," +
                        $" expected enum or struct got {ExistingType.TypeKind}")
                };

                _typeMapping = sourceInputModel?.CreateForModel(ExistingType);
            }

            Description = string.IsNullOrWhiteSpace(input.Description) ? $"The {input.Name}." : input.Description;
            IsExtensible = isExtensible;
            ValueType = typeFactory.CreateType(input.ValueType);
            IsStringValueType = ValueType.Equals(typeof(string));
            IsIntValueType = ValueType.Equals(typeof(int)) || ValueType.Equals(typeof(long));
            IsFloatValueType = ValueType.Equals(typeof(float)) || ValueType.Equals(typeof(double));
            IsNumericValueType = IsIntValueType || IsFloatValueType;
            SerializationMethodName = IsStringValueType && IsExtensible ? "ToString" : $"ToSerial{ValueType.Name.FirstCharToUpperCase()}";
        }

        public CSharpType ValueType { get; }
        public bool IsExtensible { get; }
        public bool IsIntValueType { get; }
        public bool IsFloatValueType { get; }
        public bool IsStringValueType { get; }
        public bool IsNumericValueType { get; }
        public string SerializationMethodName { get; }

        public string? Description { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        protected override TypeKind TypeKind => IsExtensible ? TypeKind.Struct : TypeKind.Enum;
        public bool IsAccessibilityOverridden { get; }

        public IList<EnumTypeValue> Values => _values ??= BuildValues();

        private List<EnumTypeValue> BuildValues()
        {
            var values = new List<EnumTypeValue>();
            foreach (var value in _allowedValues)
            {
                var name = BuilderHelpers.DisambiguateName(Type.Name, value.Name.ToCleanName(), "Value");
                var existingMember = _typeMapping?.GetMemberByOriginalName(name);
                values.Add(new EnumTypeValue(
                    BuilderHelpers.CreateMemberDeclaration(name, Type, "public", existingMember, _typeFactory),
                    CreateDescription(value),
                    BuilderHelpers.ParseConstant(value.Value, ValueType)));
            }

            return values;
        }

        private static string CreateDescription(InputEnumTypeValue value)
        {
            var description = string.IsNullOrWhiteSpace(value.Description)
                ? value.GetValueString()
                : value.Description;
            return BuilderHelpers.EscapeXmlDocDescription(description);
        }
    }
}
