﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        public static ObjectTypeProperty? GetExactMatch(ObjectTypeProperty originalType, MgmtObjectType typeToReplace, ObjectTypeProperty[] properties, BuildContext<MgmtOutputLibrary> context)
        {
            var referenceTypes = GetReferenceClassCollection();

            foreach (System.Type replacementType in GetReferenceClassCollection())
            {
                // flatten properties
                List<PropertyInfo> replacementTypeProperties = replacementType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
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

                var attributeObj = replacementType.GetCustomAttributes()?.First();
                var propertiesToSkip = attributeObj?.GetType().GetProperty("SkipTypes")?.GetValue(attributeObj) as Type[];
                List<ObjectTypeProperty> typeToReplaceProperties = new List<ObjectTypeProperty>();
                foreach (var property in properties)
                {
                    if (propertiesToSkip != null && !propertiesToSkip.Any(p => p.Name == property.ValueType.Name))
                    {
                        typeToReplaceProperties.Add(property);
                    }
                }

                if (PropertyMatchDetection.IsEqual(flattenedReplacementTypeProperties, typeToReplaceProperties))
                {
                    SchemaMatchTracker.SetExactMatch(typeToReplace.ObjectSchema);
                    return GetObjectTypeProperty(originalType, replacementType, typeToReplace.Context);
                }
            }

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
            return new ObjectTypeProperty(
                    new MemberDeclarationOptions(originalType.Declaration.Accessibility, originalType.Declaration.Name, CSharpType.FromSystemType(context, replacementType)),
                    originalType.Description,
                    originalType.IsReadOnly,
                    originalType.SchemaProperty
                    );
        }
    }
}
