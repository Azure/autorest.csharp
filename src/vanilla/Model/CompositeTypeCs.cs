// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.Core.Utilities.Collections;
using AutoRest.Extensions;
using Newtonsoft.Json;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Model
{
    public class CompositeTypeCs : CompositeType, IExtendedModelType
    {
        private readonly ConstructorModel _constructorModel = null;

        public CompositeTypeCs()
        {
            _constructorModel = new ConstructorModel(this);
        }

        public CompositeTypeCs(string name) : base(name)
        {
            _constructorModel = new ConstructorModel(this);
        }

        [JsonIgnore]
        public string EffectiveDocumentation =>
            (string.IsNullOrEmpty(Summary) ? Documentation : Summary)?.EscapeXmlComment() +
            (string.IsNullOrEmpty(ExternalDocsUrl) ? "" : $"\n<see href=\"{ExternalDocsUrl}\" />");

        // the following two properties should be disjoint and their union equal to `Properties`
        [JsonIgnore]
        public IEnumerable<PropertyCs> InstanceProperties => Properties.OfType<PropertyCs>().Where(p => !p.IsConstant);
        [JsonIgnore]
        public IEnumerable<PropertyCs> ClassProperties => Properties.OfType<PropertyCs>().Where(p => p.IsConstant);

        [JsonIgnore]
        public string MethodQualifier => (BaseModelType.ShouldValidateChain()) ? "override" : "virtual";

        [JsonIgnore]
        public bool NeedsPolymorphicConverter => BaseIsPolymorphic && Name != SerializedName;

        [JsonIgnore]
        public bool NeedsTransformationConverter => Properties.Any(p => p.WasFlattened());

        [JsonIgnore]
        public string ConstructorParameters => _constructorModel.Signature;

        [JsonIgnore]
        public IEnumerable<string> ConstructorParametersDocumentation => _constructorModel.SignatureDocumentation;
        
        [JsonIgnore]
        public string BaseConstructorCall => _constructorModel.BaseCall;

        [JsonIgnore]
        public virtual string ExceptionTypeDefinitionName
        {
            get
            {
                if (Extensions.ContainsKey(SwaggerExtensions.NameOverrideExtension))
                {
                    var ext = Extensions[SwaggerExtensions.NameOverrideExtension] as Newtonsoft.Json.Linq.JContainer;
                    if (ext != null && ext["name"] != null)
                    {
                        return ext["name"].ToString();
                    }
                }
                return Name + "Exception";
            }
        }

        public virtual IEnumerable<string> Usings => Enumerable.Empty<string>();

        /// <summary>
        /// Returns properties for this type and all ancestor types, including information on which level of ancestry
        /// the property comes from (0 for top-level base class that has properties, 1 for a class derived from that
        /// top-level class, etc.).
        /// </summary>
        private IEnumerable<InheritedPropertyInfo> AllPropertyTemplateModels
        {
            get
            {
                var baseProperties =((BaseModelType as CompositeTypeCs)?.AllPropertyTemplateModels ??
                    Enumerable.Empty<InheritedPropertyInfo>()).ReEnumerable();

                int depth = baseProperties.Any() ? baseProperties.Max(p => p.Depth) : 0;
                return baseProperties.Concat(Properties.Select(p => new InheritedPropertyInfo(p, depth)));
            }
        }

        private class InheritedPropertyInfo
        {
            public InheritedPropertyInfo(Property property, int depth)
            {
                Property = property;
                Depth = depth;
            }

            public Property Property { get; private set; }

            public int Depth { get; private set; }
        }

        private class ConstructorParameterModel
        {
            public ConstructorParameterModel(Property underlyingProperty)
            {
                UnderlyingProperty = underlyingProperty;
            }

            public Property UnderlyingProperty { get; private set; }

            public string Name => CodeNamer.Instance.CamelCase(UnderlyingProperty.Name);
        }

        private class ConstructorModel
        {
            private readonly CompositeTypeCs _model;
            public ConstructorModel(CompositeTypeCs model)
            {
                _model = model;
            }

            // TODO: this could just be the "required" parameters instead of required and all the optional ones
            // with defaults if we wanted a bit cleaner constructors
            public IEnumerable<ConstructorParameterModel> Parameters => _model.AllPropertyTemplateModels
                .Where(p => (p.Property as PropertyCs).IsEffectivelyRequired || Singleton<GeneratorSettingsCs>.Instance.HaveOptionalPropertiesOnConstructors)
                .OrderBy(p => !(p.Property as PropertyCs).IsEffectivelyRequired)
                .ThenBy(p => p.Depth)
                .Select(p => new ConstructorParameterModel(p.Property));

            public IEnumerable<string> SignatureDocumentation
            {
                get
                {
                   IEnumerable<Property> parametersWithDocumentation =
                   Parameters.Where(p => !(string.IsNullOrEmpty(p.UnderlyingProperty.Summary) &&
                   string.IsNullOrEmpty(p.UnderlyingProperty.Documentation)) &&
                   !p.UnderlyingProperty.IsConstant).Select(p => p.UnderlyingProperty);

                    foreach (var property in parametersWithDocumentation)
                    {
                        var documentationInnerText = string.IsNullOrEmpty(property.Summary) ? property.Documentation.EscapeXmlComment() : property.Summary.EscapeXmlComment();

                        yield return string.Format(
                            CultureInfo.InvariantCulture,
                            "<param name=\"{0}\">{1}</param>",
                            char.ToLower(property.Name.CharAt(0)) + property.Name.Substring(1),
                            documentationInnerText);
                    }
                }
            }

            public string Signature
            {
                get
                {
                    var declarations = new List<string>();
                    foreach (PropertyCs property in Parameters.Select(p => p.UnderlyingProperty))
                    {
                        var paramType = property.ModelTypeName;
                        var paramName = CodeNamer.Instance.CamelCase(property.Name);
                        var effectiveDefault = property.DefaultValue ?? $"default({paramType})"; // for people who really want defaults to properties (be aware of the PATCH operation consequences!)
                        declarations.Add(property.IsEffectivelyRequired
                            ? $"{paramType} {paramName}"
                            : $"{paramType} {paramName} = {effectiveDefault}");
                    }

                    return string.Join(", ", declarations);
                }
            }

            public string BaseCall => CreateBaseCall(_model);

            private static string CreateBaseCall(CompositeTypeCs model)
            {
                if (model.BaseModelType != null)
                {
                    IEnumerable<ConstructorParameterModel> parameters = (model.BaseModelType as CompositeTypeCs)._constructorModel.Parameters;
                    if (parameters.Any())
                    {
                        return $": base({string.Join(", ", parameters.Select(p => p.Name))})";
                    }
                }

                return string.Empty;
            }
        }

        public bool IsValueType => false;

    }
}