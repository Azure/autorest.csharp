﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;

namespace AutoRest.CSharp.MgmtTest.Extensions
{
    internal static class CodeWriterExtensions
    {
        /// <summary>
        /// Write an ExampleValue, using the given type as a hint.
        /// If the type is not provided, a type will be created from TypeFactory instead
        /// In a case that a property's type is replaced, we will have to provide the actual type otherwise the type from TypeFactory will always be the one that is replaced.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="exampleValue"></param>
        /// <param name="type"></param>
        /// <param name="includeCollectionInitialization"></param>
        /// <returns></returns>
        public static CodeWriter AppendExampleValue(this CodeWriter writer, InputExampleValue exampleValue, CSharpType? type = null, bool includeCollectionInitialization = true)
        {
            // get the type of this schema in the type factory if the type is not specified
            // get the type from TypeFactory cannot get the replaced types, therefore we need to put an argument in the signature as a hint in case this might happen in the replaced type case
            type ??= MgmtContext.Context.TypeFactory.CreateType(exampleValue.Type);

            if (exampleValue.Type != null && ReferenceTypePropertyChooser.TryGetCachedExactMatch(exampleValue.Type, out CSharpType? replaceType) && replaceType != null)
                type = replaceType;

            return type!.IsFrameworkType ?
                writer.AppendFrameworkTypeValue(type, exampleValue, includeCollectionInitialization) :
                writer.AppendTypeProviderValue(type, exampleValue);
        }

        public static CodeWriter AppendExampleParameterValue(this CodeWriter writer, Parameter parameter, ExampleParameterValue exampleParameterValue)
        {
            // for optional parameter, we write the parameter name here
            if (parameter.DefaultValue != null)
                writer.Append($"{parameter.Name}: ");

            return writer.AppendExampleParameterValue(exampleParameterValue);
        }

        public static CodeWriter AppendExamplePropertyBagParamValue(this CodeWriter writer, Parameter parameter, Dictionary<string, ExampleParameterValue> exampleParameterValue)
        {
            writer.Append($"new {parameter.Type}(");
            var mgmtObject = parameter.Type.Implementation as ModelTypeProvider;
            var requiredProperties = mgmtObject!.Properties.Where(p => p.IsRequired);
            var nonRequiredProperties = mgmtObject!.Properties.Where(p => !p.IsRequired);
            foreach (var property in requiredProperties)
            {
                var parameterName = property.Declaration.Name.ToVariableName();
                if (exampleParameterValue.TryGetValue(parameterName, out ExampleParameterValue? value))
                {
                    writer.Append($"{parameterName}: ");
                    writer.AppendExampleParameterValue(value);
                    writer.Append($", ");
                }
            }
            writer.RemoveTrailingComma();
            writer.Append($"){{ ");
            foreach (var property in nonRequiredProperties)
            {
                var parameterName = property.Declaration.Name.ToVariableName();
                if (exampleParameterValue.TryGetValue(parameterName, out ExampleParameterValue? value))
                {
                    writer.Append($"{property.Declaration.Name} = ");
                    writer.AppendExampleParameterValue(value);
                    writer.Append($", ");
                }
            }
            writer.RemoveTrailingComma();
            return writer.Append($"}}");
        }

        public static CodeWriter AppendExampleParameterValue(this CodeWriter writer, ExampleParameterValue exampleParameterValue)
        {
            if (exampleParameterValue.Value != null)
                return writer.AppendExampleValue(exampleParameterValue.Value, exampleParameterValue.Type);
            else
                return writer.Append(exampleParameterValue.Expression!);
        }

        private static CodeWriter AppendFrameworkTypeValue(this CodeWriter writer, CSharpType type, InputExampleValue exampleValue, bool includeCollectionInitialization = true)
        {
            if (type.IsList)
                return writer.AppendListValue(type, exampleValue as InputExampleListValue, includeCollectionInitialization);

            if (type.IsDictionary)
                return writer.AppendDictionaryValue(type, exampleValue as InputExampleObjectValue, includeCollectionInitialization);

            if (type.FrameworkType == typeof(BinaryData))
            {
                switch (exampleValue)
                {
                    case InputExampleObjectValue objectValue:
                        return writer.AppendBinaryData(objectValue);
                    case InputExampleRawValue rawValue:
                        return writer.AppendBinaryData(rawValue);
                    default:
                        throw new InvalidOperationException("Unhandled BinaryData example value type");
                }
            }

            if (type.FrameworkType == typeof(DataFactoryElement<>))
                return writer.AppendDataFactoryElementValue(type, exampleValue);

            if (exampleValue.Type is InputModelType)
                return writer.AppendComplexFrameworkTypeValue(type.FrameworkType, exampleValue);

            return writer.AppendRawValue((exampleValue as InputExampleRawValue)?.RawValue, type.FrameworkType, exampleValue.Type);
        }

        private static CodeWriter AppendDataFactoryElementValue(this CodeWriter writer, CSharpType type, InputExampleValue exampleValue)
        {
            if (type.FrameworkType != typeof(DataFactoryElement<>))
                throw new ArgumentException("DataFactoryElement<> is expected but got: " + type.ToString());

            const string DFE_OBJECT_SCHEMA_PREFIX = "DataFactoryElement";

            if (exampleValue.Type is InputModelType inputModel && inputModel.Name.Equals(DFE_OBJECT_SCHEMA_PREFIX))
            {
                const string DFE_OBJECT_PROPERTY_TYPE = "type";
                const string DFE_OBJECT_PROPERTY_VALUE = "value";

                var exampleObjectValue = exampleValue as InputExampleObjectValue;
                string dfeType = (string)(exampleObjectValue?.Values![DFE_OBJECT_PROPERTY_TYPE] as InputExampleRawValue)?.RawValue!;
                InputExampleValue dfeValue = exampleObjectValue?.Values![DFE_OBJECT_PROPERTY_VALUE]!;
                string createMethodName = dfeType switch
                {
                    "Expression" => nameof(DataFactoryElement<string>.FromExpression),
                    "SecureString" => nameof(DataFactoryElement<string>.FromSecretString),
                    "AzureKeyVaultSecretReference" => nameof(DataFactoryElement<string>.FromKeyVaultSecret),
                    _ => throw new InvalidOperationException("Unknown DataFactoryElement type: " + dfeType)
                };

                writer.Append($"{type: L}.{createMethodName}(");
                writer.AppendExampleValue(dfeValue, typeof(DataFactoryKeyVaultSecret));
                writer.AppendRaw(")");
            }
            else
            {
                CSharpType literlType = type.Arguments.First();
                writer.AppendExampleValue(exampleValue, literlType);
            }
            return writer;
        }

        private static CodeWriter AppendListValue(this CodeWriter writer, CSharpType type, InputExampleListValue? exampleValue, bool includeInitialization = true)
        {
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            var elements = exampleValue?.Values ?? Enumerable.Empty<InputExampleValue>();
            // since this is a list, we take the first generic argument (and it should always has this first argument)
            var elementType = type.Arguments.First();
            var initialization = includeInitialization ? (FormattableString)$"new {elementType}[]" : (FormattableString)$"";
            using (writer.Scope(initialization, newLine: false))
            {
                foreach (var itemValue in elements)
                {
                    // TODO -- bad formatting will happen in collection initializer because roslyn formatter ignores things in these places: https://github.com/dotnet/roslyn/issues/8269
                    writer.AppendExampleValue(itemValue, elementType);
                    if (type.IsFrameworkType)
                        writer.AppendRaw(",");
                    else
                        writer.LineRaw(",");
                }
                writer.RemoveTrailingComma();
                writer.Line();
            }
            return writer;
        }

        private static CodeWriter AppendDictionaryValue(this CodeWriter writer, CSharpType type, InputExampleObjectValue? exampleValue, bool includeInitialization = true)
        {
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            var keyValues = exampleValue?.Values ?? new Dictionary<string, InputExampleValue>();
            // since this is a dictionary, we take the first generic argument as the key type
            // this is important because in our SDK, the key of a dictionary is not always a string. It could be a string-like type, for instance, a ResourceIdentifier
            var keyType = type.Arguments[0];
            // the second as the value type
            var valueType = type.Arguments[1];
            // the type of dictionary in our generated SDK is usually an interface `IDictionary<>` or `IReadOnlyDictionary<>`, here we just use `Dictionary` as its proper initialization
            var concreteDictType = new CSharpType(typeof(Dictionary<,>), type.Arguments);
            var initialization = includeInitialization ? (FormattableString)$"new {concreteDictType}()" : (FormattableString)$"";
            using (writer.Scope(initialization, newLine: false))
            {
                foreach ((var key, var value) in keyValues)
                {
                    // write key
                    writer.AppendRaw("[");
                    writer.AppendExampleValue(new InputExampleRawValue(InputPrimitiveType.String, key), keyType);
                    writer.AppendRaw("] = ");
                    writer.AppendExampleValue(value, valueType);
                    writer.LineRaw(", ");
                }
            }
            return writer;
        }

        private static CodeWriter AppendBinaryData(this CodeWriter writer, InputExampleObjectValue exampleValue)
        {
            var method = "FromObjectAsJson";
            writer.Append($"{typeof(BinaryData)}.{method}(");
            writer.AppendAnonymousObject(exampleValue);
            return writer.AppendRaw(")");
        }

        private static CodeWriter AppendBinaryData(this CodeWriter writer, InputExampleRawValue exampleValue)
        {
            // determine which method on BinaryData we want to use to serialize this BinaryData
            if (exampleValue.RawValue != null && exampleValue.RawValue is string strValue)
            {
                var method = "FromString";
                return writer.Append($"{typeof(BinaryData)}.{method}({"\"" + strValue + "\"":L})");
            }
            else
            {
                var method = "FromObjectAsJson";
                writer.Append($"{typeof(BinaryData)}.{method}(");
                writer.AppendAnonymousObject(exampleValue);
                return writer.AppendRaw(")");
            }
        }

        private static CodeWriter AppendComplexFrameworkTypeValue(this CodeWriter writer, Type type, InputExampleValue exampleValue)
        {
            if (exampleValue is not InputExampleObjectValue exampleObjectValue)
            {
                writer.AppendRaw(type.IsValueType ? "default" : "null");
                return writer;
            }
            var propertyMetadataDict = ReferenceClassFinder.GetPropertyMetadata(type);
            // get the first constructor
            var publicCtor = type.GetConstructors().Where(c => c.IsPublic).OrderBy(c => c.GetParameters().Count()).First();
            // find the required parameters and put it into the constructor
            writer.Append($"new {type}(");
            foreach (var parameter in publicCtor.GetParameters())
            {
                // we here assume the parameter name is the same as the serialized name of the property.
                if (exampleObjectValue.Values.TryGetValue(parameter.Name!, out var value))
                {
                    writer.AppendExampleValue(value, parameter.ParameterType);
                    writer.AppendRaw(",");
                }
                else
                {
                    // when there is nothing matched, we could not do much but write a `default` as placeholder here.
                    writer.AppendRaw("default,");
                }
            }
            writer.RemoveTrailingComma();
            writer.AppendRaw(")");
            // assign values to the optional parameters
            var optionalProperties = new Dictionary<string, InputExampleValue>();
            foreach ((var propertyName, var metadata) in propertyMetadataDict)
            {
                if (metadata.Required)
                    continue;
                // find if we have a value for this property
                if (exampleObjectValue.Values.TryGetValue(propertyName, out var value))
                {
                    optionalProperties.Add(propertyName, value);
                }
            }
            if (optionalProperties.Count > 0)
            {
                using (writer.Scope($"", newLine: false))
                {
                    foreach ((var propertyName, var value) in optionalProperties)
                    {
                        writer.Append($"{propertyName} = ");
                        writer.AppendExampleValue(value);
                        writer.LineRaw(",");
                    }
                    writer.RemoveTrailingComma();
                }
            }

            return writer;
        }

        private static CodeWriter AppendAnonymousObject(this CodeWriter writer, InputExampleValue exampleValue)
        {
            // check if this is simple type
            if (exampleValue is InputExampleRawValue exampleRawValue)
            {
                return writer.AppendRawValue(exampleRawValue.RawValue, exampleRawValue.Type.GetType());
            }
            // check if this is an array
            if (exampleValue is InputExampleListValue exampleListValue)
            {
                return writer.AppendListValue(typeof(List<object>), exampleListValue);
            }
            // fallback to complex object
            if (exampleValue is InputExampleObjectValue exampleObjectValue)
            {
                using (writer.Scope($"new {typeof(Dictionary<string, object>)}()"))
                {
                    foreach ((var key, var value) in exampleObjectValue.Values)
                    {
                        writer.Append($"[{key:L}] = ");
                        writer.AppendAnonymousObject(value);
                    }
                }
            }
            else
            {
                writer.LineRaw("null");
            }

            return writer;
        }

        private static CodeWriter AppendRawList(this CodeWriter writer, List<object?> list)
        {
            writer.Append($"new {typeof(object)}[] {{ ");
            foreach (var item in list)
            {
                writer.AppendRawValue(item, item?.GetType() ?? typeof(object));
                writer.AppendRaw(", ");
            }
            writer.RemoveTrailingComma();
            writer.AppendRaw(" }");
            return writer;
        }

        private static CodeWriter AppendRawDictionary(this CodeWriter writer, Dictionary<object, object?> dict)
        {
            using (writer.Scope($"new {typeof(Dictionary<string, object>)}()", newLine: false))
            {
                foreach ((var key, var value) in dict)
                {
                    writer.Append($"[{key.ToString():L}] = ");
                    writer.AppendRawValue(value, value?.GetType() ?? typeof(object));
                    writer.LineRaw(",");
                }
                writer.RemoveTrailingComma();
            }

            return writer;
        }

        private static CodeWriter AppendRawValue(this CodeWriter writer, object? rawValue, Type type, InputType? inputType = null) => rawValue switch
        {
            string str => writer.AppendStringValue(type, str, inputType), // we need this function to convert the string to real type. There might be a bug that some literal types (like bool and int) are deserialized to string
            null => writer.AppendRaw("null"),
            List<object?> list => writer.AppendRawList(list),
            Dictionary<object, object?> dict => writer.AppendRawDictionary(dict),
            _ when type == rawValue.GetType() => writer.Append($"{rawValue:L}"),
            _ => writer.Append($"({type}){rawValue:L}")
        };

        private static CodeWriter AppendStringValue(this CodeWriter writer, Type type, string value, InputType? inputType) => type switch
        {
            _ when inputType is InputDurationType { Encode: DurationKnownEncoding.Iso8601 } => writer.Append($"{typeof(XmlConvert)}.ToTimeSpan({value:L})"),
            _ when _newInstanceInitializedTypes.Contains(type) => writer.Append($"new {type}({value:L})"),
            _ when _parsableInitializedTypes.Contains(type) => writer.Append($"{type}.Parse({value:L})"),
            _ when type == typeof(byte[]) => writer.Append($"{typeof(Convert)}.FromBase64String({value:L})"),
            _ => writer.Append($"{value:L}"),
        };

        private static bool IsStringLikeType(CSharpType type) => type.IsFrameworkType && (_newInstanceInitializedTypes.Contains(type.FrameworkType) || _parsableInitializedTypes.Contains(type.FrameworkType)) || type.Equals(typeof(string));

        private static readonly HashSet<Type> _newInstanceInitializedTypes = new()
        {
            typeof(ResourceIdentifier),
            typeof(ResourceType),
            typeof(Uri),
            typeof(AzureLocation), typeof(AzureLocation?),
            typeof(RequestMethod), typeof(RequestMethod?),
            typeof(ContentType), typeof(ContentType?),
            typeof(ETag), typeof(ETag?)
        };

        private static readonly HashSet<Type> _parsableInitializedTypes = new()
        {
            typeof(DateTimeOffset),
            typeof(Guid), typeof(Guid?),
            typeof(TimeSpan), typeof(TimeSpan?),
            typeof(IPAddress)
        };

        private static CodeWriter AppendTypeProviderValue(this CodeWriter writer, CSharpType type, InputExampleValue exampleValue)
        {
            switch (type.Implementation)
            {
                case ObjectType objectType:
                    return writer.AppendObjectTypeValue(objectType, (exampleValue as InputExampleObjectValue)?.Values);
                case EnumType enumType:
                    return writer.AppendEnumTypeValue(enumType, (exampleValue as InputExampleRawValue)?.RawValue!);
            }
            return writer.AppendRaw("default");
        }

        private static ObjectType GetActualImplementation(ObjectType objectType, IReadOnlyDictionary<string, InputExampleValue> valueDict)
        {
            var discriminator = objectType.Discriminator;
            // check if this has a discriminator
            if (discriminator == null || !discriminator.HasDescendants)
                return objectType;
            var discriminatorPropertyName = discriminator.SerializedName;
            // get value of this in the valueDict and we should always has a discriminator value in the example
            if (!valueDict.TryGetValue(discriminatorPropertyName, out var exampleValue) || exampleValue is not InputExampleRawValue exampleRawValue)
            {
                throw new InvalidOperationException($"Attempting to get the discriminator value for property `{discriminatorPropertyName}` on object type {objectType.Type.Name} but got none or non-primitive type");
            }
            // the discriminator should always be a primitive type
            var actualDiscriminatorValue = exampleRawValue.RawValue;
            var implementation = discriminator.Implementations.FirstOrDefault(info => info.Key.Equals(actualDiscriminatorValue));
            if (implementation == null)
                throw new InvalidOperationException($"Cannot find an implementation corresponding to the discriminator value {actualDiscriminatorValue} for object model type {objectType.Type.Name}");

            return (ObjectType)implementation.Type.Implementation;
        }

        private static CodeWriter AppendObjectTypeValue(this CodeWriter writer, ObjectType objectType, IReadOnlyDictionary<string, InputExampleValue>? valueDict)
        {
            if (valueDict == null)
            {
                writer.AppendRaw("null");
                return writer;
            }
            // need to get the actual ObjectType if this type has a discrinimator
            objectType = GetActualImplementation(objectType, valueDict);
            // get all the properties on this type, including the properties from its base type. Distinct is needed when the type is replaced with additional property included
            var properties = new HashSet<ObjectTypeProperty>(objectType.EnumerateHierarchy().SelectMany(objectType => objectType.Properties).DistinctBy(p => p.Declaration.Name));
            var constructor = objectType.InitializationConstructor;
            writer.Append($"new {objectType.Type}(");
            // build a map from parameter name to property
            var propertyDict = properties.ToDictionary(
                property => property.Declaration.Name.ToVariableName(), property => property);
            // find the corresponding properties in the parameters
            foreach (var parameter in constructor.Signature.Parameters)
            {
                // try every property, convert them to variable name and see if there are some of them matching
                var property = propertyDict[parameter.Name];
                InputExampleValue? exampleValue;
                if (!valueDict.TryGetValue(property.InputModelProperty!.SerializedName, out exampleValue))
                {
                    // we could only stand the case that the missing property here is a collection, in this case, we pass an empty collection
                    if (property.Declaration.Type.IsCollection)
                    {
                        exampleValue = new InputExampleRawValue(property.InputModelProperty!.Type, null);
                    }
                    else if (IsStringLikeType(property.Declaration.Type))
                    {
                        // this is a patch that some parameter is not marked as required, but in our generated code, it inherits from ResourceData, in which location is in the constructor and our code will recognize it as required
                        exampleValue = new InputExampleRawValue(InputPrimitiveType.String, "placeholder");
                    }
                    else
                        throw new InvalidOperationException($"Example value for required property {property.InputModelProperty.SerializedName} in class {objectType.Type.Name} is not found");
                }
                properties.Remove(property);
                writer.AppendExampleValue(exampleValue, type: property.Declaration.Type).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.AppendRaw(")");
            var propertiesToWrite = GetPropertiesToWrite(properties, valueDict);
            if (propertiesToWrite.Count > 0) // only write the property initializers when there are properties to write
            {
                using (writer.Scope($"", newLine: false))
                {
                    foreach ((var propertyName, (var propertyType, var exampleValue)) in propertiesToWrite)
                    {
                        writer.Append($"{propertyName} = ");
                        // we need to pass in the current type of this property to make sure its initialization is correct
                        writer.AppendExampleValue(exampleValue, type: propertyType, includeCollectionInitialization: false);
                        writer.LineRaw(",");
                    }
                }
            }
            return writer;
        }

        private static Dictionary<string, (CSharpType PropertyType, InputExampleValue ExampleValue)> GetPropertiesToWrite(IEnumerable<ObjectTypeProperty> properties, IReadOnlyDictionary<string, InputExampleValue> valueDict)
        {
            var propertiesToWrite = new Dictionary<string, (CSharpType PropertyType, InputExampleValue ExampleValue)>();
            foreach (var property in properties)
            {
                var propertyToDeal = property;
                var inputModelProperty = propertyToDeal.InputModelProperty;
                if (inputModelProperty == null)
                    continue; // now we explicitly ignore all the AdditionalProperties

                if (!valueDict.TryGetValue(inputModelProperty.SerializedName, out var exampleValue))
                    continue; // skip the property that does not have a value

                // check if this property is safe-flattened
                var flattenedProperty = propertyToDeal.FlattenedProperty;
                if (flattenedProperty != null)
                {
                    // unwrap the single property object
                    exampleValue = UnwrapExampleValueFromSinglePropertySchema(exampleValue, flattenedProperty);
                    if (exampleValue == null)
                        continue;
                    propertyToDeal = flattenedProperty;
                }

                if (!IsPropertyAssignable(propertyToDeal))
                    continue; // now we explicitly ignore all the AdditionalProperties

                propertiesToWrite.Add(propertyToDeal.Declaration.Name, (propertyToDeal.Declaration.Type, exampleValue));
            }

            return propertiesToWrite;
        }

        private static InputExampleValue? UnwrapExampleValueFromSinglePropertySchema(InputExampleValue exampleValue, FlattenedObjectTypeProperty flattenedProperty)
        {
            var hierarchyStack = flattenedProperty.BuildHierarchyStack();
            // reverse the stack because it is a stack, iterating it will start from the innerest property
            // skip the first because this stack include the property we are handling here right now
            foreach (var property in hierarchyStack.Reverse().Skip(1))
            {
                var inputModelProperty = property.InputModelProperty;
                if (exampleValue is not InputExampleObjectValue exampleObjectValue || !exampleObjectValue.Values.TryGetValue(inputModelProperty!.SerializedName, out var inner))
                    return null;
                // get the value of this layer
                exampleValue = inner;
            }
            return exampleValue;
        }

        private static bool IsPropertyAssignable(ObjectTypeProperty property)
            => property.Declaration.Accessibility == "public" && (property.Declaration.Type.IsReadWriteDictionary || property.Declaration.Type.IsReadWriteList || !property.IsReadOnly);

        private static CodeWriter AppendEnumTypeValue(this CodeWriter writer, EnumType enumType, object value)
        {
            // find value in one of the choices.
            // Here we convert the values to string then compare, because the raw value has the "primitive types are deserialized into strings" issue
            var choice = enumType.Values.FirstOrDefault(c => StringComparer.Ordinal.Equals(value.ToString(), c.Value.Value?.ToString()));
            writer.UseNamespace(enumType.Type.Namespace);
            if (choice != null)
                return writer.Append($"{enumType.Type.Name}.{choice.Declaration.Name}");
            // if we did not find a match, check if this is a SealedChoice, if so, we throw exceptions
            if (!enumType.IsExtensible)
                throw new InvalidOperationException($"Enum value `{value}` in example does not find in type {enumType.Type.Name}");
            var underlyingType = enumType.ValueType.FrameworkType; // the underlying type of an extensible enum should always be a primitive type which is a framework type
            return writer.Append($"new {enumType.Type}(")
                .AppendRawValue(value, underlyingType)
                .AppendRaw(")");
        }

        public static CodeWriter AppendDeclaration(this CodeWriter writer, CodeWriterVariableDeclaration declaration)
        {
            return writer.Append($"{declaration.Type} {declaration.Declaration:D}");
        }
    }
}
