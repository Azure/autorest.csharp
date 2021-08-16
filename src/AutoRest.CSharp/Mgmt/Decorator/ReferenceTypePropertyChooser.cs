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

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ReferenceTypePropertyChooser
    {
        internal const string PropertyReferenceAttributeName = "PropertyReferenceTypeAttribute";

        private static ConcurrentDictionary<MgmtObjectType, CSharpType?> _valueCache = new ConcurrentDictionary<MgmtObjectType, CSharpType?>();

        private static IList<System.Type> GetReferenceClassCollection()
        {
            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly == null)
            {
                return new List<System.Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType().Name == PropertyReferenceAttributeName).Count() > 0).ToList();
        }

        public static CSharpType? GetExactMatch(MgmtObjectType typeToReplace)
        {
            if (_valueCache.TryGetValue(typeToReplace, out var result))
                return result;
            foreach (System.Type replacementType in GetReferenceClassCollection())
            {
                // Quick match for models in Resources SDK with models in the same namespace of Core package through the full name of "Namespace.Name"
                if ($"{typeToReplace.Type.Namespace}.{typeToReplace.Type.Name}" == $"{replacementType.Namespace}.{replacementType.Name}")
                {
                    result = CSharpType.FromSystemType(typeToReplace.Context, replacementType);
                    _valueCache.TryAdd(typeToReplace, result);
                    return result;
                }
                var attributeObj = replacementType.GetCustomAttributes()?.Where(a => a.GetType().Name == PropertyReferenceAttributeName).First();
                var propertiesToSkipArray = attributeObj?.GetType().GetProperty("SkipTypes")?.GetValue(attributeObj) as Type[];
                var propertiesToSkip = propertiesToSkipArray.Select(p => p.Name).ToHashSet();
                List<PropertyInfo> replacementTypeProperties = replacementType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !propertiesToSkip.Contains(p.PropertyType.Name)).ToList();
                List<ObjectTypeProperty> typeToReplaceProperties = typeToReplace.MyProperties.Where(p => !propertiesToSkip.Contains(p.ValueType.Name)).ToList();

                if (PropertyMatchDetection.IsEqual(replacementTypeProperties, typeToReplaceProperties))
                {
                    result = CSharpType.FromSystemType(typeToReplace.Context, replacementType);
                    _valueCache.TryAdd(typeToReplace, result);
                    return result;
                }
            }
            _valueCache.TryAdd(typeToReplace, null);
            return null;
        }

        public static ObjectTypeProperty GetObjectTypeProperty(ObjectTypeProperty originalType, CSharpType replacementCSharpType)
        {
            return new ObjectTypeProperty(
                    new MemberDeclarationOptions(originalType.Declaration.Accessibility, replacementCSharpType.Name, replacementCSharpType),
                    originalType.Description,
                    originalType.IsReadOnly,
                    originalType.SchemaProperty
                    );
        }
    }
}
