// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal static class InheritanceChoser
    {
        public static IList<System.Type> ReferenceClassCollection = GetOrderedList();

        private static IList<System.Type> GetReferenceClassCollection()
        {
            var assembly = Assembly.GetAssembly(typeof(AzureResourceManagerClient));
            if (assembly is null)
            {
                return new List<System.Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType() == typeof(ReferenceTypeAttribute)).Count() > 0).ToList();
        }

        private static List<System.Type> GetOrderedList()
        {
            var trees = GetTrees(GetReferenceClassCollection());
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

        public static CSharpType? GetExactMatch(MgmtObjectType childType)
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

        public static CSharpType? GetSupersetMatch(MgmtObjectType originalType)
        {
            foreach (System.Type parentType in ReferenceClassCollection)
            {
                if (IsSuperset(originalType, parentType))
                {
                    return parentType;
                }
            }
            return null;
        }

        private static bool IsEqual(MgmtObjectType childType, System.Type parentType)
        {
            var childProperties = childType.MyProperties.ToList();
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

        private static bool IsSuperset(MgmtObjectType childType, System.Type parentType)
        {
            var childProperties = childType.MyProperties.ToList();
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            if (parentProperties.Count >= childProperties.Count)
            {
                return false;
            }

            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            int matchCount = 0;
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                if (parentProperties.Count == matchCount)
                {
                    break;
                }

                PropertyInfo? parentProperty;
                CSharpType childPropertyType = childProperty.Declaration.Type;
                if (parentDict.TryGetValue(childProperty.Declaration.Name, out parentProperty))
                {
                    if (parentProperty.PropertyType.IsGenericType)
                    {
                        if (childPropertyType.Equals(new CSharpType(parentProperty.PropertyType)))
                        {
                            matchCount++;
                        }
                    }
                    else if (parentProperty.PropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}" ||
                        IsAssignable(parentProperty.PropertyType, childPropertyType))
                    {
                        //TODO(ADO item 5712): deal with protected setter
                        matchCount++;
                    }
                }
            }
            return parentProperties.Count == matchCount;
        }
    }
}
