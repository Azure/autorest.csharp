// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class Node
    {
        public System.Type type;
        public List<Node> children;
        public Node(System.Type type)
        {
            this.type = type;
            this.children = new List<Node>();
        }
    }
}
