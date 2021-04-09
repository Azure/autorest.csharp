// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class InheritanceChoser
    {
        public static IList<System.Type> ReferenceClassCollection = GetReferenceClassCollection();

        private static IList<System.Type> GetReferenceClassCollection()
        {
            var assembly = Assembly.GetAssembly(typeof(AzureResourceManagerClient));
            if (assembly is null)
            {
                return new List<System.Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType() == typeof(ReferenceTypeAttribute)).Count() > 0).ToList();
        }

        public static void RebuildModelInheritance(Dictionary<Schema, TypeProvider> schemaMap, Dictionary<Schema, TypeProvider> resourceSchemaMap)
        {
            var typeOverrideMap = new Dictionary<CSharpType, CSharpType>();

            RebuildExactModelInheritance(schemaMap);
            RebuildExactModelInheritance(resourceSchemaMap);
        }

        private static void RebuildExactModelInheritance(Dictionary<Schema, TypeProvider> map)
        {
            foreach (var kval in map)
            {
                if (kval.Key is ObjectSchema objectSchema)
                {
                    var childObjectType = (MgmtObjectType)kval.Value;
                    var typeToReplace = childObjectType?.Inherits?.Implementation as ObjectType;
                    if (typeToReplace is null)
                    {
                        continue;
                    }

                    var parent = GetExactMatch(typeToReplace.Type);
                    if (parent != null)
                    {
                        childObjectType?.OverrideInherits(parent);
                    }
                }
            }
        }

        private static CSharpType? GetExactMatch(CSharpType childType)
        {
            foreach (System.Type parentType in ReferenceClassCollection)
            {
                if (IsEqual(childType, parentType))
                {
                    return parentType;
                }
            }
            return null;
        }

        private static bool IsEqual(CSharpType childType, System.Type parentType)
        {
            var childProperties = ((MgmtObjectType)(childType.Implementation)).Properties.ToList();
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            if (parentProperties.Count > childProperties.Count)
            {
                return false;
            }

            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                PropertyInfo? parentProperty;
                CSharpType childPropertyType = childProperty.Declaration.Type;
                if (parentDict.TryGetValue(childProperty.Declaration.Name, out parentProperty))
                {
                    if (parentProperty.PropertyType.IsGenericType)
                    {
                        if (!childPropertyType.Equals(new CSharpType(parentProperty.PropertyType)))
                            return false;
                    }
                    else if (parentProperty.PropertyType.FullName != $"{childPropertyType.Namespace}.{childPropertyType.Name}" &&
                        !IsAssignable(parentProperty.PropertyType, childPropertyType))
                    {
                        //TODO(ADO item 5712): deal with protected setter
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsAssignable(System.Type parentPropertyType, CSharpType childPropertyType)
        {
            return parentPropertyType.GetMethods().Where(m => m.Name == "op_Implicit" &&
                m.ReturnType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}" &&
                m.GetParameters().First().ParameterType == parentPropertyType).Count() > 0;
        }
    }
}
