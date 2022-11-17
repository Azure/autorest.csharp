// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using Humanizer;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ModelWriter
    {
        internal delegate void MethodBodyImplementation(CodeWriter codeWriter, ObjectType objectType);

        public void WriteModel(CodeWriter writer, TypeProvider model)
        {
            switch (model)
            {
                case ObjectType objectSchema:
                    WriteObjectSchema(writer, objectSchema);
                    break;
                case EnumType e when e.IsExtensible:
                    WriteExtendableEnum(writer, e);
                    break;
                case EnumType e when !e.IsExtensible:
                    WriteEnum(writer, e);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void WriteObjectSchema(CodeWriter writer, ObjectType schema)
        {
            using (writer.Namespace(schema.Declaration.Namespace))
            {
                List<CSharpType> implementsTypes = new List<CSharpType>();
                if (schema.Inherits != null)
                {
                    implementsTypes.Add(schema.Inherits);
                }

                writer.WriteXmlDocumentationSummary($"{schema.Description}");
                AddClassAttributes(writer, schema);

                if (schema.IsStruct)
                {
                    writer.Append($"{schema.Declaration.Accessibility} readonly partial struct {schema.Declaration.Name}");
                }
                else
                {
                    writer.Append($"{schema.Declaration.Accessibility} {GetAbstract(schema)}partial class {schema.Declaration.Name}");
                }

                if (implementsTypes.Any())
                {
                    writer.AppendRaw(" : ");
                    foreach (var type in implementsTypes)
                    {
                        writer.Append($"{type} ,");
                    }
                    writer.RemoveTrailingComma();
                }

                writer.Line();
                using (writer.Scope())
                {
                    WriteConstructor(writer, schema);

                    WriteProperties(writer, schema);
                }
            }
        }

        protected virtual void WriteProperties(CodeWriter writer, ObjectType schema)
        {
            foreach (var property in schema.Properties)
            {
                Stack<ObjectTypeProperty> hierarchyStack = property.GetHeirarchyStack();
                if (Configuration.AzureArm && hierarchyStack.Count > 1)
                {
                    var innerProperty = hierarchyStack.Pop();
                    var immediateParentProperty = hierarchyStack.Pop();

                    string myPropertyName = innerProperty.GetCombinedPropertyName(immediateParentProperty);
                    string childPropertyName = property.Equals(immediateParentProperty) ? innerProperty.Declaration.Name : myPropertyName;
                    WriteProperty(writer, property, "internal");
                    bool isOverridenValueType = innerProperty.Declaration.Type.IsValueType && !innerProperty.Declaration.Type.IsNullable;
                    var nullable = isOverridenValueType ? "?" : String.Empty;
                    writer.WriteXmlDocumentationSummary(CreatePropertyDescription(innerProperty, myPropertyName));
                    using (writer.Scope($"{innerProperty.Declaration.Accessibility} {innerProperty.Declaration.Type}{nullable} {myPropertyName:D}"))
                    {
                        if (!property.IsReadOnly && innerProperty.IsReadOnly)
                        {
                            if (HasDefaultPublicCtor(property))
                            {
                                if (innerProperty.Declaration.Type.Arguments.Length > 0)
                                {
                                    WriteGetWithNullCheck(writer, property, childPropertyName);
                                }
                                else
                                {
                                    WriteGetWithDefault(writer, property, innerProperty, childPropertyName, isOverridenValueType);
                                }
                            }
                            else if (HasCtorWithSingleParam(property, innerProperty))
                            {
                                WriteGetWithDefault(writer, property, innerProperty, childPropertyName, isOverridenValueType);
                                WriteSetWithSingleParamCtor(writer, property, isOverridenValueType);
                            }
                            else
                            {
                                throw new InvalidOperationException($"Unsupported parameter access combination for {schema.Type.Name}, Property {property.Declaration.Name}, ChildProperty {innerProperty.Declaration.Name}");
                            }
                        }
                        else if (!property.IsReadOnly && !innerProperty.IsReadOnly)
                        {
                            WriteGetWithDefault(writer, property, innerProperty, childPropertyName, isOverridenValueType);
                            if (HasDefaultPublicCtor(property))
                            {
                                WriteSetWithNullCheck(writer, property, childPropertyName, isOverridenValueType);
                            }
                            else if (HasCtorWithSingleParam(property, innerProperty))
                            {
                                WriteSetWithSingleParamCtor(writer, property, isOverridenValueType);
                            }
                            else
                            {
                                throw new InvalidOperationException($"Unsupported parameter access combination for {schema.Type.Name}, Property {property.Declaration.Name}, ChildProperty {innerProperty.Declaration.Name}");
                            }
                        }
                        else
                        {
                            nullable = property.IsReadOnly ? "?" : String.Empty;
                            writer.Line($"get => {property.Declaration.Name:D}{nullable}.{childPropertyName};");
                            if (!property.IsReadOnly && !innerProperty.IsReadOnly)
                                writer.Line($"set => {property.Declaration.Name:D}.{childPropertyName} = value;");
                        }
                    }
                    writer.Line();
                }
                else
                {
                    WriteProperty(writer, property);
                }
            }
        }

        private static void WriteSetWithNullCheck(CodeWriter writer, ObjectTypeProperty property, string childPropertyName, bool isOverridenValueType)
        {
            using (writer.Scope($"set"))
            {
                if (isOverridenValueType)
                {
                    using (writer.Scope($"if (value.HasValue)"))
                    {
                        writer.Line($"if ({property.Declaration.Name:D} is null)");
                        writer.Line($"{property.Declaration.Name:D} = new {property.Declaration.Type}();");
                        writer.Line($"{property.Declaration.Name:D}.{childPropertyName} = value.Value;");
                    }
                    using (writer.Scope($"else"))
                    {
                        writer.Line($"{property.Declaration.Name:D} = null;");
                    }
                }
                else
                {
                    writer.Line($"if ({property.Declaration.Name:D} is null)");
                    writer.Line($"{property.Declaration.Name:D} = new {property.Declaration.Type}();");
                    writer.Line($"{property.Declaration.Name:D}.{childPropertyName} = value;");
                }
            }
        }

        private static void WriteGetWithNullCheck(CodeWriter writer, ObjectTypeProperty property, string childPropertyName)
        {
            using (writer.Scope($"get"))
            {
                writer.Line($"if ({property.Declaration.Name:D} is null)");
                writer.Line($"{property.Declaration.Name:D} = new {property.Declaration.Type}();");
                writer.Line($"return {property.Declaration.Name:D}.{childPropertyName};");
            }
        }

        private static void WriteGetWithDefault(CodeWriter writer, ObjectTypeProperty property, ObjectTypeProperty innerProperty, string childPropertyName, bool isOverridenValueType)
        {
            FormattableString defaultType = isOverridenValueType ? (FormattableString)$"{innerProperty.Declaration.Type}?" : (FormattableString)$"{innerProperty.Declaration.Type}";
            writer.Line($"get => {property.Declaration.Name:D} is null ? default({defaultType}) : {property.Declaration.Name:D}.{childPropertyName};");
        }

        private static void WriteSetWithSingleParamCtor(CodeWriter writer, ObjectTypeProperty property, bool isOverridenValueType)
        {
            if (isOverridenValueType)
            {
                using (writer.Scope($"set"))
                {
                    writer.Line($"{property.Declaration.Name:D} = value.HasValue ? new {property.Declaration.Type}(value.Value) : null;");
                }
            }
            else
            {
                writer.Line($"set => {property.Declaration.Name:D} = new {property.Declaration.Type}(value);");
            }
        }

        private static bool AllCtorsContainMyProperty(ObjectType enclosingType, ObjectTypeProperty property)
        {
            foreach (var ctor in enclosingType.Constructors)
            {
                if (!ctor.Signature.Parameters.Any(p => p.Name == property.Declaration.Name.Camelize() && p.Type.Equals(property.Declaration.Type)))
                    return false;
            }

            return true;
        }

        internal static bool HasCtorWithSingleParam(ObjectTypeProperty property, ObjectTypeProperty innerProperty)
        {
            var type = property.Declaration.Type;
            if (type.IsFrameworkType)
                return false;

            if (type.Implementation is not ObjectType objType)
                return false;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    ctor.Signature.Parameters.Count == 1)
                {
                    var paramType = ctor.Signature.Parameters[0].Type;
                    var propertyType = innerProperty.Declaration.Type;
                    if (paramType.Arguments.Length == 0 && paramType.Equals(propertyType))
                        return true;

                    if (paramType.Arguments.Length == 1 && propertyType.Arguments.Length == 1 && paramType.Arguments[0].Equals(propertyType.Arguments[0]))
                        return true;
                }
            }

            return false;
        }

        private static bool HasDefaultPublicCtor(ObjectTypeProperty objectTypeProperty)
        {
            var type = objectTypeProperty.Declaration.Type;
            if (type.IsFrameworkType)
                return true;

            if (type.Implementation is not ObjectType objType)
                return true;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !ctor.Signature.Parameters.Any())
                    return true;
            }

            return false;
        }

        private void WriteProperty(CodeWriter writer, ObjectTypeProperty property, string? overrideAccessibility = null)
        {
            writer.WriteXmlDocumentationSummary(CreatePropertyDescription(property));
            var accessibility = overrideAccessibility ?? property.Declaration.Accessibility;
            CSharpType propertyType = property.Declaration.Type;
            writer.Append($"{accessibility} {propertyType} {property.Declaration.Name:D}");
            writer.AppendRaw(property.IsReadOnly ? "{ get; }" : "{ get; set; }");

            writer.Line();
        }

        private FormattableString CreatePropertyDescription(ObjectTypeProperty property, string? overrideName = null)
        {
            FormattableString binaryDataExtraDescription = CreateBinaryDataExtraDescription(property.Declaration.Type);
            if (!string.IsNullOrWhiteSpace(property.PropertyDescription))
            {
                return $"{property.PropertyDescription}{binaryDataExtraDescription}";
            }
            return $"{ObjectTypeProperty.CreateDefaultPropertyDescription(overrideName ?? property.Declaration.Name, property.IsReadOnly)}{binaryDataExtraDescription}";
        }

        private FormattableString CreateBinaryDataExtraDescription(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (type.FrameworkType == typeof(BinaryData))
                {
                    return ConstructBinaryDataDescription("this property");
                }
                if (TypeFactory.IsList(type) &&
                    type.Arguments[0].IsFrameworkType &&
                    type.Arguments[0].FrameworkType == typeof(BinaryData))
                {
                    return ConstructBinaryDataDescription("the element of this property");
                }
                if (TypeFactory.IsDictionary(type) &&
                    type.Arguments[1].IsFrameworkType &&
                    type.Arguments[1].FrameworkType == typeof(BinaryData))
                {
                    return ConstructBinaryDataDescription("the value of this property");
                }
            }
            return $"";
        }

        private FormattableString ConstructBinaryDataDescription(string typeSpecificDesc)
        {
            return $@"
<para>
To assign an object to {typeSpecificDesc} use <see cref=""{typeof(BinaryData)}.FromObjectAsJson{{T}}(T, System.Text.Json.JsonSerializerOptions?)""/>.
</para>
<para>
To assign an already formated json string to this property use <see cref=""{typeof(BinaryData)}.FromString(string)""/>.
</para>
<para>
Examples:
<list type=""bullet"">
<item>
<term>BinaryData.FromObjectAsJson(""foo"")</term>
<description>Creates a payload of ""foo"".</description>
</item>
<item>
<term>BinaryData.FromString(""\""foo\"""")</term>
<description>Creates a payload of ""foo"".</description>
</item>
<item>
<term>BinaryData.FromObjectAsJson(new {{ key = ""value"" }})</term>
<description>Creates a payload of {{ ""key"": ""value"" }}.</description>
</item>
<item>
<term>BinaryData.FromString(""{{\""key\"": \""value\""}}"")</term>
<description>Creates a payload of {{ ""key"": ""value"" }}.</description>
</item>
</list>
</para>";
        }
        private string GetAbstract(ObjectType schema)
        {
            // Limit this change to management plane to avoid data plane affected
            return schema.Declaration.IsAbstract ? "abstract " : string.Empty;
        }

        protected virtual void AddClassAttributes(CodeWriter writer, ObjectType schema)
        {
        }

        protected virtual void AddCtorAttribute(CodeWriter writer, ObjectType schema, ObjectTypeConstructor constructor)
        {
        }

        public void WriteConstructor(CodeWriter writer, ObjectType schema)
        {
            foreach (var constructor in schema.Constructors)
            {
                writer.WriteMethodDocumentation(constructor.Signature);
                AddCtorAttribute(writer, schema, constructor);
                using (writer.WriteMethodDeclaration(constructor.Signature))
                {
                    writer.WriteParametersValidation(constructor.Signature.Parameters);

                    foreach (var initializer in constructor.Initializers)
                    {
                        writer.Append($"{initializer.Property.Declaration.Name} = ")
                            .WriteReferenceOrConstant(initializer.Value)
                            .WriteConversion(initializer.Value.Type, initializer.Property.Declaration.Type);

                        if (initializer.DefaultValue != null && (!initializer.Value.Type.IsValueType || initializer.Value.Type.IsNullable))
                        {
                            writer.Append($"?? ").WriteReferenceOrConstant(initializer.DefaultValue.Value);
                        }

                        writer.Line($";");
                    }

                    //TODO make the proper initializer here instead
                    if (schema is ModelTypeProvider modelTypeProvider)
                    {
                        foreach (var parameter in constructor.Signature.Parameters)
                        {
                            if (modelTypeProvider.Fields.TryGetFieldByParameter(parameter, out var field))
                            {
                                if (!field.IsField)
                                    continue;
                                writer
                                    .Append($"{field.Name:I} = {parameter.Name:I}")
                                    .WriteConversion(parameter.Type, field.Type)
                                    .LineRaw(";");
                            }
                        }
                    }
                }
                writer.Line();
            }
        }

        public static void WriteEnum(CodeWriter writer, EnumType schema)
        {
            if (schema.Declaration.IsUserDefined)
            {
                return;
            }

            using (writer.Namespace(schema.Declaration.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{schema.Description}");

                using (writer.Scope($"{schema.Declaration.Accessibility} enum {schema.Declaration.Name}"))
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        writer.WriteXmlDocumentationSummary($"{value.Description}");
                        if (schema.IsIntValueType)
                        {
                            writer.Line($"{value.Declaration.Name} = {value.Value.Value},");
                        }
                        else
                        {
                            writer.Line($"{value.Declaration.Name},");
                        }
                    }
                    writer.RemoveTrailingComma();
                }
            }
        }

        public static void WriteExtendableEnum(CodeWriter writer, EnumType enumType)
        {
            var cs = enumType.Type;
            string name = enumType.Declaration.Name;
            var isString = enumType.ValueType.FrameworkType == typeof(string);

            using (writer.Namespace(enumType.Declaration.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{enumType.Description}");

                var implementType = new CSharpType(typeof(IEquatable<>), cs);
                using (writer.Scope($"{enumType.Declaration.Accessibility} readonly partial struct {name}: {implementType}"))
                {
                    writer.Line($"private readonly {enumType.ValueType} _value;");
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of <see cref=\"{name}\"/>.");

                    if (isString)
                    {
                        writer.WriteXmlDocumentationException(typeof(ArgumentNullException), $"<paramref name=\"value\"/> is null.");
                    }

                    using (writer.Scope($"public {name}({enumType.ValueType} value)"))
                    {
                        writer.Append($"_value = value");
                        if (isString)
                        {
                            writer.Append($"?? throw new {typeof(ArgumentNullException)}(nameof(value))");
                        }
                        writer.Line($";");
                    }
                    writer.Line();

                    foreach (var choice in enumType.Values)
                    {
                        var fieldName = GetValueFieldName(name, choice.Declaration.Name, enumType.Values);
                        writer.Line($"private const {enumType.ValueType} {fieldName} = {choice.Value.Value:L};");
                    }
                    writer.Line();

                    foreach (var choice in enumType.Values)
                    {
                        writer.WriteXmlDocumentationSummary($"{choice.Description}");
                        var fieldName = GetValueFieldName(name, choice.Declaration.Name, enumType.Values);
                        writer.Append($"public static {cs} {choice.Declaration.Name}").AppendRaw("{ get; }").Append($" = new {cs}({fieldName});").Line();
                    }

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are the same.");
                    writer.Line($"public static bool operator ==({cs} left, {cs} right) => left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Determines if two <see cref=\"{name}\"/> values are not the same.");
                    writer.Line($"public static bool operator !=({cs} left, {cs} right) => !left.Equals(right);");

                    writer.WriteXmlDocumentationSummary($"Converts a string to a <see cref=\"{name}\"/>.");
                    writer.Line($"public static implicit operator {cs}({enumType.ValueType} value) => new {cs}(value);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Line($"public override bool Equals({typeof(object)} obj) => obj is {cs} other && Equals(other);");

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Append($"public bool Equals({cs} other) => ");
                    if (isString)
                    {
                        writer.Line($"{enumType.ValueType}.Equals(_value, other._value, {typeof(StringComparison)}.InvariantCultureIgnoreCase);");
                    }
                    else
                    {
                        writer.Line($"{enumType.ValueType}.Equals(_value, other._value);");
                    }
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    WriteEditorBrowsableFalse(writer);
                    writer.Append($"public override int GetHashCode() => ");
                    if (isString)
                    {
                        writer.Line($"_value?.GetHashCode() ?? 0;");
                    }
                    else
                    {
                        writer.Line($"_value.GetHashCode();");
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Append($"public override {typeof(string)} ToString() => ");

                    if (isString)
                    {
                        writer.Line($"_value;");
                    }
                    else
                    {
                        writer.Line($"_value.ToString({typeof(CultureInfo)}.InvariantCulture);");
                    }
                }
            }
        }

        private static string GetValueFieldName(string enumName, string enumValue, IList<EnumTypeValue> enumValues)
        {
            if (enumName != $"{enumValue}Value")
            {
                return $"{enumValue}Value";
            }

            int index = 1;
            foreach (var value in enumValues)
            {
                if (value.Declaration.Name == $"{enumValue}Value{index}")
                {
                    index++;
                }
            }
            return $"{enumValue}Value{index}";
        }

        private static void WriteEditorBrowsableFalse(CodeWriter writer)
        {
            writer.Line($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]");
        }
    }
}
