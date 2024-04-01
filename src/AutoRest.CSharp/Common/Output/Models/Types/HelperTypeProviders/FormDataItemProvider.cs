// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using System.Text.Json;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class FormDataItemProvider: ExpressionTypeProvider
    {
        private static readonly Lazy<FormDataItemProvider> _instance = new(() => new FormDataItemProvider());
        private class FormDataItemTemplate<T> { }
        public static FormDataItemProvider Instance => _instance.Value;
        /*
        private FieldDeclaration _nameField;
        private FieldDeclaration _contentField;
        private FieldDeclaration _contentTypeField;
        private FieldDeclaration _fileNameField;
        private VariableReference _name;
        private VariableReference _content;
        private VariableReference _contentType;
        private VariableReference _fileName;
        */
        private readonly PropertyDeclaration _nameProperty;
        private const string _namePropertyName = "Name";
        private readonly PropertyDeclaration _contentProperty;
        private const string _contentPropertyName = "Content";
        private readonly PropertyDeclaration _contentTypeProperty;
        private const string _contentTypePropertyName = "ContentType";
        private readonly PropertyDeclaration _fileNameProperty;
        private const string _fileNamePropertyName = "FileName";
        private FormDataItemProvider() : base(Configuration.HelperNamespace, null)
        {
            /*
            _nameField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(PipelineResponse), "_name");
            _contentField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientResultException), "_content");
            _contentTypeField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientResultException), "_contentType");
            _fileNameField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientResultException), "_fileName");
            _name = new VariableReference(_nameField.Type, _nameField.Declaration);
            _content = new VariableReference(_contentField.Type, _contentField.Declaration);
            _contentType = new VariableReference(_contentTypeField.Type, _contentTypeField.Declaration);
            _fileName = new VariableReference(_fileNameField.Type, _fileNameField.Declaration);
            */
            _nameProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(string),
                name: _namePropertyName,
                propertyBody: new AutoPropertyBody(false));
            _contentProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(BinaryContent),
                name: _contentPropertyName,
                propertyBody: new AutoPropertyBody(false));
            _contentTypeProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(string),
                name: _contentTypePropertyName,
                propertyBody: new AutoPropertyBody(false));
            _fileNameProperty = new PropertyDeclaration(
                description: null,
                modifiers: MethodSignatureModifiers.Public,
                propertyType: typeof(string),
                name: _fileNamePropertyName,
                propertyBody: new AutoPropertyBody(false));
        }
        protected override string DefaultName => "FormDataItem";
        protected override IEnumerable<Method> BuildConstructors()
        {
            yield return new Method(new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, Array.Empty<Parameter>()), EmptyStatement);
            var nameParam = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var contentParam = new Parameter("content", null, typeof(BinaryContent), null, ValidationType.None, null);
            var name = new ParameterReference(nameParam);
            var content = new ParameterReference(contentParam);
            var nameProperty = (ValueExpression)_nameProperty;
            var contentProperty = (ValueExpression)_contentProperty;
            yield return new Method(new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, new[] { nameParam, contentParam }), new MethodBodyStatement[]
            {
                Assign(nameProperty, name),
                Assign(contentProperty, content),
            });
        }
        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return _nameProperty;
            yield return _contentProperty;
            yield return _contentTypeProperty;
            yield return _fileNameProperty;
        }
        public StringExpression NameProperty(ValueExpression instance)
            => new(instance.Property(_namePropertyName));
        public ValueExpression NamePropertyValue(ValueExpression instance)
            => instance.Property(_namePropertyName);
        public ValueExpression ContentPropertyValue(ValueExpression instance)
            => instance.Property((_contentPropertyName));
        public ValueExpression ConentTypePropertyValue(ValueExpression instance)
            => instance.Property(_contentTypePropertyName);
        public ValueExpression FileNamePropertyValue(ValueExpression instance)
            => instance.Property(_fileNamePropertyName);
    }
}
