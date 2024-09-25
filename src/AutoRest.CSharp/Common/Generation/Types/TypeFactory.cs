// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.InputTypes;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Generation.Types
{
    internal class TypeFactory
    {
        private readonly OutputLibrary _library;
        public Type UnknownType { get; }

        public TypeFactory(OutputLibrary library, Type unknownType)
        {
            _library = library;
            UnknownType = unknownType;
        }

        private static readonly Type _azureResponseErrorType = typeof(ResponseError);
        private static readonly Type _managedIdentity = typeof(ManagedServiceIdentity);
        private static readonly Type _userAssignedIdentity = typeof(UserAssignedIdentity);
        private static readonly Type _extendedLocation = typeof(ExtendedLocation);

        /// <summary>
        /// This method will attempt to retrieve the <see cref="CSharpType"/> of the input type.
        /// </summary>
        /// <param name="inputType">The input type to convert.</param>
        /// <returns>The <see cref="CSharpType"/> of the input type.</returns>
        public CSharpType CreateType(InputType inputType) => inputType switch
        {
            InputLiteralType literalType => CSharpType.FromLiteral(CreateType(literalType.ValueType), literalType.Value),
            InputUnionType unionType => CSharpType.FromUnion(unionType.VariantTypes.Select(CreateType).ToArray()),
            InputListType { CrossLanguageDefinitionId: "Azure.Core.EmbeddingVector" } listType => new CSharpType(typeof(ReadOnlyMemory<>), CreateType(listType.ValueType)),
            InputListType listType => new CSharpType(typeof(IList<>), CreateType(listType.ValueType)),
            InputDictionaryType dictionaryType => new CSharpType(typeof(IDictionary<,>), typeof(string), CreateType(dictionaryType.ValueType)),
            InputEnumType enumType => _library.ResolveEnum(enumType),
            InputModelType model => CreateModelType(model),
            InputNullableType nullableType => CreateType(nullableType.Type).WithNullable(true),
            InputPrimitiveType primitiveType => CreatePrimitiveType(primitiveType),
            InputDateTimeType dateTimeType => new CSharpType(typeof(DateTimeOffset)),
            InputDurationType durationType => new CSharpType(typeof(TimeSpan)),
            _ => throw new InvalidOperationException($"Unknown type: {inputType}")
        };

        private CSharpType CreatePrimitiveType(in InputPrimitiveType inputType)
        {
            InputPrimitiveType? primitiveType = inputType;
            while (primitiveType != null)
            {
                if (_knownAzurePrimitiveTypes.TryGetValue(primitiveType.CrossLanguageDefinitionId, out var knownType))
                {
                    return knownType;
                }

                primitiveType = primitiveType.BaseType;
            }

            return inputType.Kind switch
            {
                InputPrimitiveTypeKind.Boolean => new CSharpType(typeof(bool)),
                InputPrimitiveTypeKind.Bytes => Configuration.ShouldTreatBase64AsBinaryData ? new CSharpType(typeof(BinaryData)) : new CSharpType(typeof(byte[])),
                InputPrimitiveTypeKind.PlainDate => new CSharpType(typeof(DateTimeOffset)),
                InputPrimitiveTypeKind.Decimal => new CSharpType(typeof(decimal)),
                InputPrimitiveTypeKind.Decimal128 => new CSharpType(typeof(decimal)),
                InputPrimitiveTypeKind.PlainTime => new CSharpType(typeof(TimeSpan)),
                InputPrimitiveTypeKind.Float32 => new CSharpType(typeof(float)),
                InputPrimitiveTypeKind.Float64 => new CSharpType(typeof(double)),
                InputPrimitiveTypeKind.Int8 => new CSharpType(typeof(sbyte)),
                InputPrimitiveTypeKind.UInt8 => new CSharpType(typeof(byte)),
                InputPrimitiveTypeKind.Int32 => new CSharpType(typeof(int)),
                InputPrimitiveTypeKind.Int64 => new CSharpType(typeof(long)),
                InputPrimitiveTypeKind.SafeInt => new CSharpType(typeof(long)),
                InputPrimitiveTypeKind.Integer => new CSharpType(typeof(long)), // in typespec, integer is the base type of int related types, see type relation: https://typespec.io/docs/language-basics/type-relations
                InputPrimitiveTypeKind.Float => new CSharpType(typeof(double)), // in typespec, float is the base type of float32 and float64, see type relation: https://typespec.io/docs/language-basics/type-relations
                InputPrimitiveTypeKind.Numeric => new CSharpType(typeof(double)), // in typespec, numeric is the base type of number types, see type relation: https://typespec.io/docs/language-basics/type-relations
                InputPrimitiveTypeKind.Stream => new CSharpType(typeof(Stream)),
                InputPrimitiveTypeKind.String => new CSharpType(typeof(string)),
                InputPrimitiveTypeKind.Url => new CSharpType(typeof(Uri)),
                InputPrimitiveTypeKind.Unknown => UnknownType,
                _ => new CSharpType(typeof(object)),
            };
        }

        private static readonly IReadOnlyDictionary<string, CSharpType> _knownAzurePrimitiveTypes = new Dictionary<string, CSharpType>
        {
            [InputPrimitiveType.UuidId] = typeof(Guid),
            [InputPrimitiveType.IPv4AddressId] = typeof(IPAddress),
            [InputPrimitiveType.IPv6AddressId] = typeof(IPAddress),
            [InputPrimitiveType.ETagId] = typeof(ETag),
            [InputPrimitiveType.AzureLocationId] = typeof(AzureLocation),
            [InputPrimitiveType.ArmIdId] = typeof(ResourceIdentifier),

            [InputPrimitiveType.CharId] = typeof(char),
            [InputPrimitiveType.ContentTypeId] = typeof(ContentType),
            [InputPrimitiveType.ResourceTypeId] = typeof(ResourceType),

            [InputPrimitiveType.ObjectId] = typeof(object),
            [InputPrimitiveType.RequestMethodId] = typeof(RequestMethod),
            [InputPrimitiveType.IPAddressId] = typeof(IPAddress),
        };

        private IReadOnlyDictionary<string, CSharpType>? _knownAzureModelTypes;
        private IReadOnlyDictionary<string, CSharpType> KnownAzureModelTypes => _knownAzureModelTypes ??= new Dictionary<string, CSharpType>
        {
            ["Azure.Core.Foundations.Error"] = SystemObjectType.Create(_azureResponseErrorType, _azureResponseErrorType.Namespace!, null).Type,
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = SystemObjectType.Create(_managedIdentity, _managedIdentity.Namespace!, null).Type,
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = SystemObjectType.Create(_userAssignedIdentity, _userAssignedIdentity.Namespace!, null).Type,
            ["Azure.ResourceManager.CommonTypes.ExtendedLocation"] = SystemObjectType.Create(_extendedLocation, _extendedLocation.Namespace!, null).Type,
        };

        private CSharpType CreateModelType(in InputModelType model)
        {
            // special handling data factory element
            if (model.CrossLanguageDefinitionId == "Azure.Core.Resources.DataFactoryElement")
            {
                return new CSharpType(typeof(DataFactoryElement<>), CreateTypeForDataFactoryElement(model.ArgumentTypes![0]));
            }
            // handle other known model types
            if (KnownAzureModelTypes.TryGetValue(model.CrossLanguageDefinitionId, out var type))
            {
                return type;
            }
            return _library.ResolveModel(model);
        }

        /// <summary>
        /// This method is a shimming layer for HLC specially in DFE. In DFE, we always have `BinaryData` instead of `object` therefore we need to escape the `Any` to always return `BinaryData`.
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        private CSharpType CreateTypeForDataFactoryElement(InputType inputType) => inputType switch
        {
            InputPrimitiveType { Kind: InputPrimitiveTypeKind.Unknown } => typeof(BinaryData),
            _ => CreateType(inputType)
        };

        internal static Type? ToXMsFormatType(string? format) => format switch
        {
            XMsFormat.ArmId => typeof(ResourceIdentifier),
            XMsFormat.AzureLocation => typeof(AzureLocation),
            XMsFormat.DateTime => typeof(DateTimeOffset),
            XMsFormat.DateTimeRFC1123 => typeof(DateTimeOffset),
            XMsFormat.DateTimeUnix => typeof(DateTimeOffset),
            XMsFormat.DurationConstant => typeof(TimeSpan),
            XMsFormat.ETag => typeof(ETag),
            XMsFormat.ResourceType => typeof(ResourceType),
            XMsFormat.Object => typeof(object),
            XMsFormat.IPAddress => typeof(IPAddress),
            XMsFormat.ContentType => typeof(ContentType),
            XMsFormat.RequestMethod => typeof(RequestMethod),
            XMsFormat.DataFactoryElementOfString => typeof(DataFactoryElement<string>),
            XMsFormat.DataFactoryElementOfInt => typeof(DataFactoryElement<int>),
            XMsFormat.DataFactoryElementOfDouble => typeof(DataFactoryElement<double>),
            XMsFormat.DataFactoryElementOfBool => typeof(DataFactoryElement<bool>),
            XMsFormat.DataFactoryElementOfDateTime => typeof(DataFactoryElement<DateTimeOffset>),
            XMsFormat.DataFactoryElementOfDuration => typeof(DataFactoryElement<TimeSpan>),
            XMsFormat.DataFactoryElementOfUri => typeof(DataFactoryElement<Uri>),
            XMsFormat.DataFactoryElementOfObject => typeof(DataFactoryElement<BinaryData>),
            XMsFormat.DataFactoryElementOfListOfString => typeof(DataFactoryElement<IList<string>>),
            XMsFormat.DataFactoryElementOfKeyValuePairs => typeof(DataFactoryElement<IDictionary<string, string>>),
            XMsFormat.DataFactoryElementOfKeyObjectValuePairs => typeof(DataFactoryElement<IDictionary<string, BinaryData>>),
            _ => null
        };

        public CSharpType CreateType(ITypeSymbol symbol)
        {
            if (!TryCreateType(symbol, out var type))
            {
                throw new InvalidOperationException($"Unable to find a model or framework type that corresponds to {symbol}");
            }

            return type;
        }

        private static bool NoTypeValidator(System.Type type) => true;

        public bool TryCreateType(ITypeSymbol symbol, [NotNullWhen(true)] out CSharpType? type)
            => TryCreateType(symbol, NoTypeValidator, out type);

        public CSharpType? GetLibraryTypeByName(string name) => _library.FindTypeByName(name);

        public bool TryCreateType(ITypeSymbol symbol, Func<System.Type, bool> validator, [NotNullWhen(true)] out CSharpType? type)
        {
            type = null;
            return symbol switch
            {
                IArrayTypeSymbol arrayTypeSymbol => TryCreateTypeForIArrayTypeSymbol(arrayTypeSymbol, validator, out type),
                INamedTypeSymbol namedTypeSymbol => TryCreateTypeForINamedTypeSymbol(namedTypeSymbol, validator, out type),

                // We can only handle IArrayTypeSymbol of framework type and INamedTypeSymbol for now since CSharpType can't represent other types such as IArrayTypeSymbol of user types
                // Instead of throwing an exception, which causes more side effects, we just return false and let the caller handle it.
                _ => false
            };
        }

        private bool TryCreateTypeForINamedTypeSymbol(INamedTypeSymbol namedTypeSymbol, Func<Type, bool> validator, [NotNullWhen(true)] out CSharpType? type)
        {
            type = null;
            if (namedTypeSymbol.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T)
            {
                if (!TryCreateType(namedTypeSymbol.TypeArguments[0], validator, out type))
                {
                    return false;
                }
                type = type.WithNullable(true);
                return true;
            }

            Type? existingType = TryGetFrameworkType(namedTypeSymbol);

            if (existingType is not null && validator(existingType))
            {
                if (!TryPopulateArguments(namedTypeSymbol.TypeArguments, validator, out var arguments))
                {
                    return false;
                }
                type = new CSharpType(existingType, arguments, isNullable: false);
            }
            else
            {
                type = _library.FindTypeByName(namedTypeSymbol.Name);
            }

            if (type is null)
            {
                return false;
            }

            if (!type.IsValueType &&
                namedTypeSymbol.NullableAnnotation != NullableAnnotation.NotAnnotated)
            {
                type = type.WithNullable(true);
            }

            return true;
        }

        private bool TryCreateTypeForIArrayTypeSymbol(IArrayTypeSymbol symbol, Func<Type, bool> validator, [NotNullWhen(true)] out CSharpType? type)
        {
            type = null;
            if (symbol is not IArrayTypeSymbol arrayTypeSymbol)
            {
                return false;
            }

            // For IArrayTypeSymbol, we can only handle it when the element type is a framework type.
            var arrayType = TryGetFrameworkType(arrayTypeSymbol);
            if (arrayType is not null && validator(arrayType))
            {
                type = new CSharpType(arrayType, arrayType.IsValueType && symbol.NullableAnnotation != NullableAnnotation.NotAnnotated);
                return true;
            }
            return false;
        }

        private Type? TryGetFrameworkType(ISymbol namedTypeSymbol)
        {
            var fullMetadataName = GetFullMetadataName(namedTypeSymbol);
            var fullyQualifiedName = $"{fullMetadataName}, {namedTypeSymbol.ContainingAssembly?.Name}";
            return Type.GetType(fullMetadataName) ?? Type.GetType(fullyQualifiedName);
        }

        // There can be argument type missing
        private bool TryPopulateArguments(ImmutableArray<ITypeSymbol> typeArguments, Func<Type, bool> validator, [NotNullWhen(true)] out IReadOnlyList<CSharpType>? arguments)
        {
            arguments = null;
            var result = new List<CSharpType>();
            foreach (var typeArgument in typeArguments)
            {
                if (!TryCreateType(typeArgument, validator, out CSharpType? type))
                {
                    return false;
                }
                result.Add(type);
            }
            arguments = result;
            return true;
        }

        private string GetFullMetadataName(ISymbol namedTypeSymbol)
        {
            StringBuilder builder = new StringBuilder();

            BuildFullMetadataName(builder, namedTypeSymbol);

            return builder.ToString();
        }

        private void BuildFullMetadataName(StringBuilder builder, ISymbol symbol)
        {
            if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                BuildFullMetadataName(builder, arrayTypeSymbol.ElementType);
                builder.Append("[]");
                return;
            }

            if (symbol.ContainingNamespace != null &&
                !symbol.ContainingNamespace.IsGlobalNamespace)
            {
                BuildFullMetadataName(builder, symbol.ContainingNamespace);
                builder.Append(".");
            }

            builder.Append(symbol.MetadataName);
        }
    }
}
