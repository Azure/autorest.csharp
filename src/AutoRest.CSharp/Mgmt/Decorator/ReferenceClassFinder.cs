// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    public class ReferenceClassFinder
    {
        internal const string InitializationCtorAttribute = "InitializationConstructor";
        internal const string SerializationCtorAttribute = "SerializationConstructor";
        internal const string ReferenceTypeAttribute = "ReferenceType";

        internal const string InitializationCtorAttributeName = $"{InitializationCtorAttribute}Attribute";
        internal const string SerializationCtorAttributeName = $"{SerializationCtorAttribute}Attribute";
        internal const string ReferenceTypeAttributeName = $"{ReferenceTypeAttribute}Attribute";

        private static IList<Type>? _referenceTypes;

        internal class Node
        {
            public Type Type { get; }
            public List<Node> Children { get; }

            public Node(Type type)
            {
                Type = type;
                Children = new List<Node>();
            }
        }

        internal static IList<Type> GetReferenceClassCollection(BuildContext<MgmtOutputLibrary> context) => _referenceTypes ??= GetOrderedList(GetReferenceClassCollectionInternal(context));

        private static IList<Type> GetReferenceClassCollectionInternal(BuildContext<MgmtOutputLibrary> context)
        {
            if (context.Configuration.MgmtConfiguration.IsArmCore)
                return new List<Type>();

            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly == null)
            {
                return new List<Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType().Name == ReferenceTypeAttributeName).Count() > 0).ToList();
        }

        internal static List<Type> GetOrderedList(IList<Type> referenceTypes)
        {
            var rootNodes = GetRootNodes(referenceTypes);
            var output = new List<Type>();
            foreach (var root in rootNodes)
            {
                var treeNodes = new List<Type>();
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count != 0)
                {
                    Node tempNode = queue.Dequeue();
                    treeNodes.Add(tempNode.Type);
                    List<Node> tempChilren = tempNode.Children;
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
                output.AddRange(PromoteGenericType(treeNodes));
            }
            return output;
        }

        private static List<Type> PromoteGenericType(List<Type> output)
        {
            bool swapped = false;
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i].IsGenericType)
                {
                    // since we need to ensure the base generic type is before
                    // any other inheritors we just need to search behind
                    for (int j = i - 1; j > -1; j--)
                    {
                        if (output[j].IsGenericType == false
                            && output[j].BaseType == output[i])
                        {

                            System.Type temp = output[j];
                            output[j] = output[i];
                            output[i] = temp;
                            swapped = true;
                        }
                    }
                }
            }
            if (swapped)
                return PromoteGenericType(output);

            return output;
        }

        internal static List<Node> GetRootNodes(IList<Type> referenceClassCollection)
        {
            List<Node> rootNodes = new List<Node>();
            var added = new Dictionary<Type, Node>();
            var rootHash = new Dictionary<Type, List<Node>>();
            foreach (System.Type reference in referenceClassCollection)
            {
                if (!added.ContainsKey(reference))
                {
                    Node node = new Node(reference);
                    System.Type baseType = reference.BaseType ?? typeof(object);
                    if (baseType != typeof(object) && added.ContainsKey(baseType))
                    {
                        added[baseType].Children.Add(node);
                    }
                    else
                    {
                        if (rootHash.ContainsKey(node.Type))
                        {
                            foreach (var child in rootHash[node.Type])
                            {
                                node.Children.Add(child);
                                rootNodes.Remove(child);
                            }
                            rootHash.Remove(baseType);
                        }
                        else
                        {
                            if (baseType != typeof(object))
                            {
                                List<Node>? list;
                                if (!rootHash.TryGetValue(baseType, out list))
                                {
                                    list = new List<Node>();
                                    rootHash.Add(baseType, list);
                                }
                                list.Add(node);
                            }
                        }
                        rootNodes.Add(node);
                    }
                    added.Add(reference, node);
                }
            }
            return rootNodes;
        }
    }
}
