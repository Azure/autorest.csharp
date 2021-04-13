// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Generation;
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
            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly is null)
            {
                return new List<System.Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType() == typeof(ReferenceTypeAttribute)).Count() > 0).ToList();
        }

        public static void RebuildModelInheritance(Dictionary<Schema, TypeProvider> schemaMap, Dictionary<Schema, TypeProvider> resourceSchemaMap, CodeModel codeModel)
        {
            var typeOverrideMap = new Dictionary<CSharpType, CSharpType>();

            RebuildExactModelInheritance(schemaMap, codeModel);
            RebuildExactModelInheritance(resourceSchemaMap, codeModel);
        }

        private static void RebuildExactModelInheritance(Dictionary<Schema, TypeProvider> map, CodeModel codeModel)
        {
            foreach (var kval in map)
            {
                if (kval.Key is ObjectSchema objectSchema)
                {
                    var childObjectType = (MgmtObjectType)kval.Value;
                    var typeToReplace = childObjectType?.Inherits?.Implementation as ObjectType;
                    if (childObjectType is null || typeToReplace is null)
                    {
                        continue;
                    }

                    var parent = GetExactMatch(childObjectType.Type, typeToReplace.Type, codeModel);
                    if (parent != null)
                    {
                        childObjectType?.OverrideInherits(parent);
                    }
                }
            }
        }

        private static CSharpType? GetExactMatch(CSharpType childObjectType, CSharpType childType, CodeModel codeModel)
        {
            foreach (System.Type parentType in ReferenceClassCollection)
            {
                if (IsEqual(childType, parentType))
                {
                    // // RollingUpgradeStatusInfo does not have an operation group, why?
                    // // if (childObjectType.Name == "RollingUpgradeStatusInfo") {
                    // //     return parentType.MakeGenericType(typeof(ResourceGroupResourceIdentifier));
                    // // }

                    // // if parentType contains generic parameters we need to fill in the concret types
                    // if (parentType.ContainsGenericParameters && parentType.GetTypeInfo().GenericTypeParameters.First()?.BaseType == typeof(TenantResourceIdentifier))
                    // {
                    //     // find corresponding operation group and get identifier type
                    //     // todo: how not to hard code "Data"?
                    //     var operationGroup = codeModel.OperationGroups.FirstOrDefault(operationGroup => $"{operationGroup.Resource}Data".Equals(childObjectType.Name));
                    //     return (operationGroup == null) ?
                    //         parentType :
                    //         parentType.MakeGenericType(operationGroup.ResourceIdentifierType);
                    // }
                    // else
                    // {
                    //     return parentType;
                    // }
                    return parentType.MakeGenericType(childType.GetResourceIdentifierType());
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
                        !IsAssignable(parentProperty.PropertyType, childPropertyType) &&
                        !(parentProperty.PropertyType.IsGenericParameter && IsAssignable(parentProperty.PropertyType.BaseType!, childPropertyType)))
                    {
                        if (parentProperty.PropertyType.ContainsGenericParameters && parentProperty.PropertyType.BaseType != null && IsAssignable(parentProperty.PropertyType.BaseType, childPropertyType))
                        {
                            // Generic property, but base type is assignable => good to go
                            // For example `TIdentifier where TIdentifier : TenantResourceIdentifier`
                        }
                        else
                        {
                            //TODO(ADO item 5712): deal with protected setter
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tells if <paramref name="childPropertyType" /> can be assigned to <paramref name="parentPropertyType" />
        /// by checking if there's an implicit type convertor in <paramref name="parentPropertyType" />.
        /// Todo: should we check childPropertyType as well since an implicit can be defined in either classes?
        /// </summary>
        /// <param name="parentPropertyType">The type to be assigned to.</param>
        /// <param name="childPropertyType">The type to assign.</param>
        /// <returns></returns>
        private static bool IsAssignable(System.Type parentPropertyType, CSharpType childPropertyType)
        {
            return parentPropertyType.GetMethods().Where(m => m.Name == "op_Implicit" &&
                m.ReturnType == parentPropertyType &&
                m.GetParameters().First().ParameterType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}").Count() > 0;
        }
    }
}
