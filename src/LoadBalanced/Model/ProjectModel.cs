﻿using System.Collections.Generic;

namespace AutoRest.CSharp.LoadBalanced.Model
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            FilePaths = new List<string>();
        }

        public string RootNameSpace { get; set; }

        public List<string> FilePaths { get; }
    }
}
