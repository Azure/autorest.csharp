// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformableItem
    {
        private TransformSection _transformSection;
        public TransformableItem(string fullSerializedName, TransformSection transformSection)
        {
            this.FullSerializedName = fullSerializedName;
            this._transformSection = transformSection;
        }

        public string FullSerializedName { get; set; }
        protected virtual List<string>? TransformTypeWhiteList { get { return null; } }

        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public List<string> TransformLogs
        {
            get
            {
                return _transformSection.GetAppliedTransformLogs(
                    this.FullSerializedName, this.TransformTypeWhiteList)
                    .OrderBy(item => item.Log.Index)
                    .Select(item => $"[{item.Log.Index}][{item.Transfom}] {item.Log.LogMessage}").ToList();
            }
        }
    }
}
