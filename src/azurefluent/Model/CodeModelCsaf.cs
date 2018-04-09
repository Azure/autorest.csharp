// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Collections.Generic;
using AutoRest.Core.Model;
using AutoRest.CSharp.Model;
using AutoRest.CSharp.Azure.Model;
using static AutoRest.Core.Utilities.DependencyInjection;
using AutoRest.Extensions.Azure;

namespace AutoRest.CSharp.Azure.Fluent.Model
{
    public class CodeModelCsaf : CodeModelCsa
    {
        internal HashSet<CompositeTypeCsaf> _innerTypes;
        internal CompositeTypeCsaf _resourceType;
        internal CompositeTypeCsaf _resourceTypeNoValidate;
        internal CompositeTypeCsaf _proxyResourceType;
        internal CompositeTypeCsaf _subResourceType;

        public CodeModelCsaf()
        {
            _innerTypes = new HashSet<CompositeTypeCsaf>();

            var stringType = New<PrimaryType>(KnownPrimaryType.String, new
            {
                Name = "string"
            });

            _proxyResourceType = New<CompositeTypeCsaf>(new
            {
                SerializedName = "ProxyResource"
            });
            _proxyResourceType.Name.FixedValue = "Microsoft.Azure.Management.ResourceManager.Fluent.Resource";
            _proxyResourceType.Add(new PropertyCsaf { Name = "id", SerializedName = "id", ModelType = stringType, IsReadOnly = true });
            _proxyResourceType.Add(new PropertyCsaf { Name = "name", SerializedName = "name", ModelType = stringType, IsReadOnly = true });
            _proxyResourceType.Add(new PropertyCsaf { Name = "type", SerializedName = "type", ModelType = stringType, IsReadOnly = true });
            _proxyResourceType.Extensions[AzureExtensions.AzureResourceExtension] = true;

            _resourceType = New<CompositeTypeCsaf>(new
            {
                SerializedName = "Resource",
            });
            _resourceType.Name.FixedValue = "Microsoft.Azure.Management.ResourceManager.Fluent.Resource";
            _resourceType.BaseModelType = _proxyResourceType;
            _resourceType.Add(new PropertyCsaf { Name = "location", SerializedName = "location", ModelType = stringType, IsRequired = true });
            _resourceType.Add(new PropertyCsaf { Name = "tags", SerializedName = "tags", ModelType = New<DictionaryType>(new { ValueType = stringType, NameFormat = "System.Collections.Generic.IDictionary<string, {0}>" }) });
            _resourceType.Extensions[AzureExtensions.AzureResourceExtension] = true;

            _resourceTypeNoValidate = New<CompositeTypeCsaf>(new
            {
                SerializedName = "Resource",
            });
            _resourceTypeNoValidate.Name.FixedValue = "Microsoft.Azure.Management.ResourceManager.Fluent.Resource";
            _resourceTypeNoValidate.Add(new PropertyCsaf { Name = "location", SerializedName = "location", ModelType = stringType });
            _resourceTypeNoValidate.Add(new PropertyCsaf { Name = "id", SerializedName = "id", ModelType = stringType, IsReadOnly = true });
            _resourceTypeNoValidate.Add(new PropertyCsaf { Name = "name", SerializedName = "name", ModelType = stringType, IsReadOnly = true });
            _resourceTypeNoValidate.Add(new PropertyCsaf { Name = "type", SerializedName = "type", ModelType = stringType, IsReadOnly = true });
            _resourceTypeNoValidate.Add(new PropertyCsaf { Name = "tags", SerializedName = "tags", ModelType = New<DictionaryType>(new { ValueType = stringType, NameFormat = "System.Collections.Generic.IDictionary<string, {0}>" }) });
            _resourceTypeNoValidate.Extensions[AzureExtensions.AzureResourceExtension] = true;

            _subResourceType = New<CompositeTypeCsaf>(new
            {
                SerializedName = "SubResource"
            });
            _subResourceType.Name.FixedValue = "Microsoft.Azure.Management.ResourceManager.Fluent.SubResource";
            _subResourceType.Add(new PropertyCsaf { Name = "id", SerializedName = "id", ModelType = stringType, IsReadOnly = true });
            _subResourceType.Extensions[AzureExtensions.AzureResourceExtension] = true;
        }
    }
}