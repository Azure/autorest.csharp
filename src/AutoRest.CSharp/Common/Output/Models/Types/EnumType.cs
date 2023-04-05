// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class EnumType : TypeProvider
    {
        private readonly IEnumerable<InputEnumTypeValue> _allowedValues;
        private readonly ModelTypeMapping? _typeMapping;
        private readonly TypeFactory _typeFactory;
        private IList<EnumTypeValue>? _values;
        public EnumType(InputEnumType enumType, Schema schema, BuildContext context)
            : this(enumType, GetDefaultNamespace(schema.Extensions?.Namespace, context), GetAccessibility(schema, context.SchemaUsageProvider), context.TypeFactory, context.SourceInputModel)
        {
        }

        public EnumType(InputEnumType input, string defaultNamespace, string defaultAccessibility, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            _allowedValues = input.AllowedValues;
            _typeFactory = typeFactory;
            _deprecated = input.Deprecated;

            DefaultName = input.Name.ToCleanName();
            DefaultAccessibility = input.Accessibility ?? defaultAccessibility;

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

            Description = input.Description;
            IsExtensible = isExtensible;
            ValueType = typeFactory.CreateType(input.EnumValueType);
            IsStringValueType = ValueType.Equals(typeof(string));
            IsIntValueType = ValueType.Equals(typeof(int)) || ValueType.Equals(typeof(long));

            SerializationMethod = IsStringValueType ? null : IsExtensible ? CreateExtensibleSerializationMethod(this) : CreateSerializationMethod(this);
        }

        public CSharpType ValueType { get; }
        public bool IsExtensible { get; }
        public bool IsStringValueType { get; }
        public bool IsIntValueType { get; }
        public Method? SerializationMethod { get; }
        public string? Description { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        protected override TypeKind TypeKind => IsExtensible ? TypeKind.Struct : TypeKind.Enum;

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
                    BuilderHelpers.ParseConstant(value.Value, ValueType)));
            }

            return values;
        }

        private static Method CreateExtensibleSerializationMethod(EnumType enumType)
        {
            var signature = new MethodSignature(GetSerializationMethodName(enumType), null, null, Internal, enumType.ValueType, null, Array.Empty<Parameter>());
            return new Method(signature, new MemberReference(null, "_value"));
        }

        private static Method CreateSerializationMethod(EnumType enumType)
        {
            var valueParameter = new Parameter("value", null, enumType.Type, null, Validation.None, null);
            var signature = new MethodSignature(GetSerializationMethodName(enumType), null, null, Public | Static | Extension, enumType.ValueType, null, new[]{valueParameter});

            var bodyExpression = new SwitchExpression(valueParameter, CreateSwitchCases(enumType, valueParameter).ToArray());

            return new Method(signature, bodyExpression);

            static IEnumerable<SwitchCaseExpression> CreateSwitchCases(EnumType enumType, Parameter valueParameter)
            {
                foreach (var enumTypeValue in enumType.Values)
                {
                    yield return new SwitchCaseExpression
                    (
                        EnumValue(enumType, enumTypeValue),
                        new FormattableStringToExpression(enumTypeValue.Value.GetConstantFormattable())
                    );
                }

                yield return new SwitchCaseExpression(Dash, ThrowNewArgumentOutOfRangeException(valueParameter.Name, valueParameter, $"Unknown {enumType.Declaration.Name} value."));
            }
        }

        private static string GetSerializationMethodName(EnumType enumType) => $"ToSerial{enumType.ValueType.Name.FirstCharToUpperCase()}";

        private static string CreateDescription(InputEnumTypeValue value)
        {
            var description = string.IsNullOrWhiteSpace(value.Description)
                ? value.GetValueString()
                : value.Description;
            return BuilderHelpers.EscapeXmlDescription(description);
        }

        public static string GetAccessibility(Schema schema, SchemaUsageProvider schemaUsageProvider)
        {
            var usage = schemaUsageProvider.GetUsage(schema);
            var hasUsage = usage.HasFlag(SchemaTypeUsage.Model);
            return schema.Extensions?.Accessibility ?? (hasUsage ? "public" : "internal");
        }
    }
}
