// Copyright (c) Microsoft Corporation. All rights reserved.
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
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class InheritanceChooser
    {
        public static IList<System.Type> ReferenceClassCollection = GetOrderedList();

        private static IList<System.Type> GetReferenceClassCollection()
        {
            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly == null)
            {
                return new List<System.Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType() == typeof(ReferenceTypeAttribute)).Count() > 0).ToList();
        }

        private static List<System.Type> GetOrderedList()
        {
            var referenceClasses = ConvertGenericType(GetReferenceClassCollection());
            var trees = GetTrees(referenceClasses);
            var output = new List<System.Type>();
            foreach (var root in trees)
            {
                var treeNodes = new List<System.Type>();
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count != 0)
                {
                    Node tempNode = queue.Dequeue();
                    treeNodes.Add(tempNode.type);
                    List<Node> tempChilren = tempNode.children;
                    if (tempChilren != null)
                    {
                        int childNum = tempChilren.Count;
                        while (childNum > 0)
                        {
                            queue.Enqueue(tempChilren[childNum - 1]);
                            childNum--;
                        }
                    }
                }
                treeNodes.Reverse();
                output.AddRange(treeNodes);
            }
            return output;
        }

        private static IList<System.Type> ConvertGenericType(IList<System.Type> referenceClassCollection)
        {
            for (int i = 0; i < referenceClassCollection.Count; i++)
            {
                if (referenceClassCollection[i].IsGenericType)
                {
                    var attributeObj = referenceClassCollection[i].GetCustomAttributes().First() as ReferenceTypeAttribute;
                    referenceClassCollection[i] = referenceClassCollection[i].MakeGenericType(attributeObj!.GenericType);
                }
            }
            return referenceClassCollection;
        }

        private static List<Node> GetTrees(IList<System.Type> referenceClassCollection)
        {
            List<Node> trees = new List<Node>();
            var added = new Dictionary<System.Type, Node>();
            foreach (System.Type reference in referenceClassCollection)
            {
                if (!added.ContainsKey(reference))
                {
                    Node node = new Node(reference);
                    if (reference.BaseType != null && added.ContainsKey(reference.BaseType))
                    {
                        added[reference.BaseType].children.Add(node);
                    }
                    else
                    {
                        trees.Add(node);
                    }
                    added.Add(reference, node);
                }
            }
            return trees;
        }

        public static CSharpType? GetExactMatch(OperationGroup? operationGroup, MgmtObjectType childType, ObjectTypeProperty[] properties)
        {
            foreach (System.Type parentType in ReferenceClassCollection)
            {
                if (IsEqual(parentType, properties))
                {
                    return GetCSharpType(operationGroup, childType, parentType);
                }
            }
            return null;
        }

        public static CSharpType? GetSupersetMatch(OperationGroup? operationGroup, MgmtObjectType originalType, ObjectTypeProperty[] properties)
        {
            foreach (System.Type parentType in ReferenceClassCollection)
            {
                if (IsSuperset(parentType, properties))
                {
                    return GetCSharpType(operationGroup, originalType, parentType);
                }
            }
            return null;
        }

        private static CSharpType GetCSharpType(OperationGroup? operationGroup, MgmtObjectType originalType, Type parentType)
        {
            var newParentType = operationGroup == null || !parentType.IsGenericType
                ? parentType
                : parentType.GetGenericTypeDefinition().MakeGenericType(operationGroup.GetResourceIdentifierType(originalType, originalType.Context.Configuration.MgmtConfiguration, true));
            return CSharpType.FromSystemType(originalType.Context, newParentType);
        }

        private static bool IsEqual(System.Type parentType, ObjectTypeProperty[] properties)
        {
            var childProperties = properties.ToList();
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            if (parentProperties.Count != childProperties.Count)
                return false;

            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                if (!DoesPropertyExistInParent(childProperty, parentDict))
                    return false;
            }

            return true;
        }

        private static bool DoesPropertyExistInParent(ObjectTypeProperty childProperty, Dictionary<string, PropertyInfo> parentDict)
        {
            PropertyInfo? parentProperty;
            CSharpType childPropertyType = childProperty.Declaration.Type;

            if (!parentDict.TryGetValue(childProperty.Declaration.Name, out parentProperty))
                return false;

            if (parentProperty.PropertyType.IsGenericType)
            {
                if (!childPropertyType.Equals(new CSharpType(parentProperty.PropertyType)))
                    return false;
            }
            else if (parentProperty.PropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}" ||
                IsAssignable(parentProperty.PropertyType, childPropertyType))
            {
                if (childProperty.IsReadOnly != (parentProperty.GetSetMethod() == null))
                    return false;
            }
            else if (!(parentProperty.PropertyType.IsGenericParameter && IsAssignable(parentProperty.PropertyType.BaseType!, childPropertyType)))
            {
                return false;
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

        private static bool IsSuperset(System.Type parentType, ObjectTypeProperty[] properties)
        {
            var childProperties = properties.ToList();
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            if (parentProperties.Count >= childProperties.Count)
                return false;

            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            int matchCount = 0;
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                if (parentProperties.Count == matchCount)
                    break;

                if (DoesPropertyExistInParent(childProperty, parentDict))
                    matchCount++;
            }

            return parentProperties.Count == matchCount;
        }

        private class Node
        {
            public System.Type type;
            public List<Node> children;
            public Node(System.Type type)
            {
                this.type = type;
                this.children = new List<Node>();
            }
        }

        /// <summary>
        /// Tells if a [Resource]Data is a resource by checking if it inherits any of:
        /// Resource, TrackedResource, SubResource, or SubResourceReadOnly.
        /// </summary>
        /// <param name="resourceData"></param>
        /// <returns></returns>
        internal static bool IsResource(this ResourceData resourceData)
        {
            return resourceData
                .EnumerateHierarchy()
                .Where(t => t.Inherits != null)
                .Select(t => t.Inherits!)
                .Any(csharpType =>
                    csharpType.Namespace == "Azure.ResourceManager.Core" && (csharpType.Name == "Resource" || csharpType.Name == "TrackedResource" || csharpType.Name == "SubResource" || csharpType.Name == "SubResourceReadOnly"));
        }
    }
}
