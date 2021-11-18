// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ReferenceTypePropertyChooser
    {
        internal const string PropertyReferenceAttribute = "PropertyReferenceType";
        internal const string PropertyReferenceAttributeName = "PropertyReferenceTypeAttribute";

        private static ConcurrentDictionary<Schema, CSharpType?> _valueCache = new ConcurrentDictionary<Schema, CSharpType?>();

        private static readonly Type _locationType = typeof(Location);
        private static readonly Type _resourceIdentifierType = typeof(ResourceIdentifier);
        private static readonly Type _resourceTypeType = typeof(ResourceType);

        private static IList<System.Type> GetReferenceClassCollection()
        {
            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly == null)
            {
                return new List<System.Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType().Name == PropertyReferenceAttributeName).Count() > 0).ToList();
        }

        public static ObjectTypeProperty? GetExactMatchForReferenceType(ObjectTypeProperty originalType, Type frameworkType, BuildContext context)
        {
            return FindSimpleReplacements(originalType, frameworkType, context);
        }

        public static bool TryGetCachedExactMatch(Schema schema, out CSharpType? result)
        {
            return _valueCache.TryGetValue(schema, out result);
        }

        public static CSharpType? GetExactMatch(MgmtObjectType typeToReplace, BuildContext<MgmtOutputLibrary> context)
        {
            if (_valueCache.TryGetValue(typeToReplace.ObjectSchema, out var result))
                return result;

            if (!typeToReplace.ShouldNotReplaceForProperty())
            {
                foreach (System.Type replacementType in GetReferenceClassCollection())
                {
                    var attributeObj = replacementType.GetCustomAttributes()?.Where(a => a.GetType().Name == PropertyReferenceAttributeName).First();
                    var propertiesToSkipArray = attributeObj?.GetType().GetProperty("SkipTypes")?.GetValue(attributeObj) as Type[];
                    var propertiesToSkip = propertiesToSkipArray.Select(p => p.Name).ToHashSet();
                    List<PropertyInfo> replacementTypeProperties = replacementType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !propertiesToSkip.Contains(p.PropertyType.Name)).ToList();
                    List<ObjectTypeProperty> typeToReplaceProperties = typeToReplace.MyProperties.Where(p => !propertiesToSkip.Contains(p.ValueType.Name)).ToList();

                    if (replacementType == typeof(ResourceIdentity))
                    {
                        List<PropertyInfo> flattenedReplacementTypeProperties = new List<PropertyInfo>();
                        foreach (var parentProperty in replacementTypeProperties)
                        {
                            if (parentProperty.PropertyType.IsClass && parentProperty.PropertyType != typeof(string))
                            {
                                flattenedReplacementTypeProperties.AddRange(parentProperty.PropertyType.GetProperties());
                            }
                            else
                            {
                                flattenedReplacementTypeProperties.Add(parentProperty);
                            }
                        }
                        replacementTypeProperties = flattenedReplacementTypeProperties;
                    }
                    if (PropertyMatchDetection.IsEqual(replacementTypeProperties, typeToReplaceProperties, new Dictionary<Type, CSharpType> { { replacementType, typeToReplace.Type } }))
                    {
                        result = CSharpType.FromSystemType(typeToReplace.Context, replacementType);
                        _valueCache.TryAdd(typeToReplace.ObjectSchema, result);
                        return result;
                    }
                }
            }
            _valueCache.TryAdd(typeToReplace.ObjectSchema, null);
            return null;
        }

        private static ObjectTypeProperty? FindSimpleReplacements(ObjectTypeProperty originalType, Type frameworkType, BuildContext context)
        {
            //TODO for core generation this list is small enough we can simply define each of them here.
            //eventually we might want to come up with a more robust way of doing this

            bool isString = frameworkType == typeof(string);

            if (originalType.Declaration.Name == "Location" && (isString || frameworkType.Name == _locationType.Name))
                return GetObjectTypeProperty(originalType, _locationType, context);

            if (originalType.Declaration.Name == "Type" && (isString || frameworkType.Name == _resourceTypeType.Name))
                return GetObjectTypeProperty(originalType, _resourceTypeType, context);

            if (originalType.Declaration.Name == "Id" && (isString || frameworkType.Name == _resourceIdentifierType.Name))
                return GetObjectTypeProperty(originalType, _resourceIdentifierType, context);

            return null;
        }

        private static ObjectTypeProperty GetObjectTypeProperty(ObjectTypeProperty originalType, Type replacementType, BuildContext context)
        {
            var replacementCSharpType = CSharpType.FromSystemType(context, replacementType);
            return GetObjectTypeProperty(originalType, replacementCSharpType);
        }

        public static ObjectTypeProperty GetObjectTypeProperty(ObjectTypeProperty originalType, CSharpType replacementCSharpType)
        {
            return new ObjectTypeProperty(
                    new MemberDeclarationOptions(originalType.Declaration.Accessibility, originalType.Declaration.Name, replacementCSharpType),
                    originalType.Description,
                    originalType.IsReadOnly,
                    originalType.SchemaProperty
                    );
        }
    }
}
