// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    public class ReferenceClassFinder
    {
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

        public static IList<Type> ReferenceClassCollection = GetOrderedList(GetReferenceClassCollection());

        private static IList<Type> GetReferenceClassCollection()
        {
            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly == null)
            {
                return new List<Type>();
            }
            return assembly.GetTypes().Where(t => t.GetCustomAttributes(false).Where(a => a.GetType() == typeof(ReferenceTypeAttribute)).Count() > 0).ToList();
        }

        internal static List<Type> GetOrderedList(IList<Type> referenceTypes)
        {
            var referenceClasses = ConvertGenericType(referenceTypes);
            var rootNodes = GetRootNodes(referenceClasses);
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
                        }
                    }
                }
            }
            return output;
        }

        internal static IList<Type> ConvertGenericType(IList<Type> referenceClassCollection)
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
                                rootHash.Add(baseType, new List<Node>() { node });
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
