// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ChangeTrackingDictionaryProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ChangeTrackingDictionaryProvider> _instance = new(() => new ChangeTrackingDictionaryProvider(Configuration.HelperNamespace, null));
        public static ChangeTrackingDictionaryProvider Instance => _instance.Value;

        private class ChangeTrackingDictionaryTemplate<TKey, TValue> { }
        private readonly CSharpType _tKey = typeof(ChangeTrackingDictionaryTemplate<,>).GetGenericArguments()[0];
        private readonly CSharpType _tValue = typeof(ChangeTrackingDictionaryTemplate<,>).GetGenericArguments()[1];

        private readonly Parameter _indexParam;
        private readonly CSharpType _dictionary;
        private readonly CSharpType _IDictionary;
        private readonly CSharpType _IReadOnlyDictionary;
        private readonly CSharpType _IEnumerator;
        private readonly CSharpType _keyValuePair;
        private readonly FieldDeclaration _innerDictionaryField;
        private readonly DictionaryExpression _innerDictionary;
        private readonly MethodSignature _ensureDictionarySignature;

        private InvokeInstanceMethodExpression EnsureDictionary { get; init; }
        private BoolExpression IsUndefined { get; } = new BoolExpression(new MemberExpression(This, "IsUndefined"));

        private ChangeTrackingDictionaryProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal;
            WhereClause = Where.NotNull(_tKey);
            _indexParam = new Parameter("key", null, _tKey, null, ValidationType.None, null);
            _IDictionary = new CSharpType(typeof(IDictionary<,>), _tKey, _tValue);
            _dictionary = new CSharpType(typeof(Dictionary<,>), _tKey, _tValue);
            _IReadOnlyDictionary = new CSharpType(typeof(IReadOnlyDictionary<,>), _tKey, _tValue);
            _IEnumerator = new CSharpType(typeof(IEnumerator<>), new CSharpType(typeof(KeyValuePair<,>), _tKey, _tValue));
            _keyValuePair = new CSharpType(typeof(KeyValuePair<,>), _tKey, _tValue);
            _innerDictionaryField = new FieldDeclaration(FieldModifiers.Private, new CSharpType(typeof(IDictionary<,>), _tKey, _tValue), "_innerDictionary");
            _innerDictionary = new DictionaryExpression(_tKey, _tValue, new VariableReference(_IDictionary, _innerDictionaryField.Declaration));
            _ensureDictionarySignature = new MethodSignature("EnsureDictionary", null, null, MethodSignatureModifiers.Public, _IDictionary, null, Array.Empty<Parameter>());
            EnsureDictionary = This.Invoke(_ensureDictionarySignature);
        }

        protected override string DefaultName => "ChangeTrackingDictionary";

        protected override IEnumerable<CSharpType> BuildTypeArguments()
        {
            yield return _tKey;
            yield return _tValue;
        }

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _innerDictionaryField;
        }

        protected override IEnumerable<CSharpType> BuildImplements()
        {
            yield return _IDictionary;
            yield return _IReadOnlyDictionary;
        }

        protected override IEnumerable<Method> BuildConstructors()
        {
            yield return DefaultConstructor();
            yield return ConstructorWithDictionary();
            yield return ConstructorWithReadOnlyDictionary();
        }

        private Method ConstructorWithReadOnlyDictionary()
        {
            var dicationaryParam = new Parameter("dictionary", null, _IReadOnlyDictionary, null, ValidationType.None, null);
            var dictionary = new DictionaryExpression(_tKey, _tValue, dicationaryParam);
            var signature = new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, new[] { dicationaryParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(Equal(dictionary, Null))
                {
                    Return()
                },
                Assign(_innerDictionary, New.Instance(_dictionary)),
                new ForeachStatement("pair", dictionary, out var pair)
                {
                    _innerDictionary.Add(pair)
                }
            });
        }

        private Method ConstructorWithDictionary()
        {
            var dicationaryParam = new Parameter("dictionary", null, _IDictionary, null, ValidationType.None, null);
            var dictionary = new ParameterReference(dicationaryParam);
            var signature = new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, new[] { dicationaryParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(Equal(dictionary, Null))
                {
                    Return()
                },
                Assign(_innerDictionary, New.Instance(_dictionary, dictionary))
            });
        }

        private Method DefaultConstructor()
        {
            var signature = new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, Array.Empty<Parameter>());
            return new Method(signature, Array.Empty<MethodBodyStatement>());
        }

        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return BuildIsUndefined();
            yield return BuildCount();
            yield return BuildIsReadOnly();
            yield return BuildKeys();
            yield return BuildValues();
            yield return BuildIndexer();
            yield return BuildEnumerableKeys();
            yield return BuildEnumerableValues();
        }

        private PropertyDeclaration BuildEnumerableValues()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.None, new CSharpType(typeof(IEnumerable<>), _tValue), "Values", new ExpressionPropertyBody(
                new MemberExpression(This, "Values")),
                null,
                _IReadOnlyDictionary);
        }

        private PropertyDeclaration BuildEnumerableKeys()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.None, new CSharpType(typeof(IEnumerable<>), _tKey), "Keys", new ExpressionPropertyBody(
                new MemberExpression(This, "Keys")),
                null,
                _IReadOnlyDictionary);
        }

        private PropertyDeclaration BuildIndexer()
        {
            var indexParam = new Parameter("key", null, _tKey, null, ValidationType.None, null);
            return new IndexerDeclaration(null, MethodSignatureModifiers.Public, _tValue, "this", indexParam, new MethodPropertyBody(
                new MethodBodyStatement[]
                {
                    new IfStatement(IsUndefined)
                    {
                        Throw(New.Instance(typeof(KeyNotFoundException), Nameof(new ParameterReference(_indexParam))))
                    },
                    Return(new ArrayElementExpression(EnsureDictionary, new ParameterReference(_indexParam))),
                },
                new MethodBodyStatement[]
                {
                    Assign(
                        new ArrayElementExpression(EnsureDictionary, new ParameterReference(_indexParam)),
                        new KeywordExpression("value", null))
                }));
        }

        private PropertyDeclaration BuildValues()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, new CSharpType(typeof(ICollection<>), _tValue), "Values",
                new ExpressionPropertyBody(new TernaryConditionalOperator(
                    IsUndefined,
                    new InvokeStaticMethodExpression(typeof(Array), "Empty", Array.Empty<ValueExpression>(), new[] { _tValue }),
                    new MemberExpression(EnsureDictionary, "Values"))));
        }

        private PropertyDeclaration BuildKeys()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, new CSharpType(typeof(ICollection<>), _tKey), "Keys",
                new ExpressionPropertyBody(new TernaryConditionalOperator(
                    IsUndefined,
                    new InvokeStaticMethodExpression(typeof(Array), "Empty", Array.Empty<ValueExpression>(), new[] { _tKey }),
                    new MemberExpression(EnsureDictionary, "Keys"))));
        }

        private PropertyDeclaration BuildIsReadOnly()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, typeof(bool), "IsReadOnly",
                new ExpressionPropertyBody(new TernaryConditionalOperator(
                    IsUndefined,
                    False,
                    new MemberExpression(EnsureDictionary, "IsReadOnly"))));
        }

        private PropertyDeclaration BuildCount()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, typeof(int), "Count",
                new ExpressionPropertyBody(new TernaryConditionalOperator(
                    IsUndefined,
                    Literal(0),
                    new MemberExpression(EnsureDictionary, "Count"))));
        }

        private PropertyDeclaration BuildIsUndefined()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, typeof(bool), "IsUndefined", new ExpressionPropertyBody(Equal(_innerDictionary, Null)));
        }

        private MethodSignature GetSignature(
            string name,
            CSharpType? returnType,
            MethodSignatureModifiers modifiers = MethodSignatureModifiers.Public,
            IReadOnlyList<Parameter>? parameters = null,
            CSharpType? explicitImpl = null)
        {
            return new MethodSignature(name, null, null, modifiers, returnType, null, parameters ?? Array.Empty<Parameter>(), ExplicitInterface: explicitImpl);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildGetEnumeratorGeneric();
            yield return BuildGetEnumerator();
            yield return BuildAddPair();
            yield return BuildClear();
            yield return BuildContains();
            yield return BuildCopyTo();
            yield return BuildRemovePair();
            yield return BuildAdd();
            yield return BuildContainsKey();
            yield return BuildRemoveKey();
            yield return BuildTryGetValue();
            yield return BuildEnsureDictionary();
        }

        private Method BuildTryGetValue()
        {
            var keyParam = new Parameter("key", null, _tKey, null, ValidationType.None, null);
            var valueParam = new Parameter("value", null, _tValue, null, ValidationType.None, null, IsOut: true);
            var value = new ParameterReference(valueParam);
            var signature = GetSignature("TryGetValue", typeof(bool), parameters: new[] { keyParam, valueParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    Assign(value, Default),
                    Return(False)
                },
                Return(EnsureDictionary.Invoke("TryGetValue", new ParameterReference(keyParam), new KeywordExpression("out", value)))
            });
        }

        private Method BuildRemoveKey()
        {
            var keyParam = new Parameter("key", null, _tKey, null, ValidationType.None, null);
            var signature = GetSignature("Remove", typeof(bool), parameters: new[] { keyParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    Return(False)
                },
                Return(EnsureDictionary.Invoke("Remove", new ParameterReference(keyParam)))
            });
        }

        private Method BuildContainsKey()
        {
            var keyParam = new Parameter("key", null, _tKey, null, ValidationType.None, null);
            var signature = GetSignature("ContainsKey", typeof(bool), parameters: new[] { keyParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    Return(False)
                },
                Return(EnsureDictionary.Invoke("ContainsKey", new ParameterReference(keyParam)))
            });
        }

        private Method BuildAdd()
        {
            var keyParam = new Parameter("key", null, _tKey, null, ValidationType.None, null);
            var valueParam = new Parameter("value", null, _tValue, null, ValidationType.None, null);
            var signature = GetSignature("Add", null, parameters: new[] { keyParam, valueParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                EnsureDictionary.Invoke("Add", new ParameterReference(keyParam), new ParameterReference(valueParam)).ToStatement()
            });
        }

        private Method BuildRemovePair()
        {
            var itemParam = new Parameter("item", null, _keyValuePair, null, ValidationType.None, null);
            var item = new ParameterReference(itemParam);
            var signature = GetSignature("Remove", typeof(bool), parameters: new[] { itemParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    Return(False)
                },
                Return(EnsureDictionary.Invoke("Remove", item))
            });
        }

        private Method BuildCopyTo()
        {
            //TODO: This line will not honor the generic type of the array
            var arrayParam = new Parameter("array", null, typeof(KeyValuePair<,>).MakeArrayType(), null, ValidationType.None, null);
            var array = new ParameterReference(arrayParam);
            var indexParam = new Parameter("index", null, typeof(int), null, ValidationType.None, null);
            var index = new ParameterReference(indexParam);
            var signature = GetSignature("CopyTo", null, parameters: new[] { arrayParam, indexParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    Return()
                },
                EnsureDictionary.Invoke("CopyTo", array, index).ToStatement()
            });
        }

        private Method BuildContains()
        {
            var itemParam = new Parameter("item", null, _keyValuePair, null, ValidationType.None, null);
            var item = new ParameterReference(itemParam);
            var signature = GetSignature("Contains", typeof(bool), parameters: new[] { itemParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    Return(False)
                },
                Return(EnsureDictionary.Invoke("Contains", item))
            });
        }

        private Method BuildClear()
        {
            var signature = GetSignature("Clear", null);
            return new Method(signature, new MethodBodyStatement[]
            {
                EnsureDictionary.Invoke("Clear").ToStatement()
            });
        }

        private Method BuildAddPair()
        {
            var itemParam = new Parameter("item", null, _keyValuePair, null, ValidationType.None, null);
            var item = new ParameterReference(itemParam);
            var signature = GetSignature("Add", null, parameters: new[] { itemParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                EnsureDictionary.Invoke("Add", item).ToStatement()
            });
        }

        private Method BuildGetEnumerator()
        {
            var signature = GetSignature("GetEnumerator", typeof(IEnumerator), MethodSignatureModifiers.None, explicitImpl: typeof(IEnumerable));
            return new Method(signature, new MethodBodyStatement[]
            {
                Return(This.Invoke("GetEnumerator"))
            });
        }

        private Method BuildGetEnumeratorGeneric()
        {
            var signature = GetSignature("GetEnumerator", _IEnumerator);
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(IsUndefined)
                {
                    new DeclareLocalFunctionStatement(new CodeWriterDeclaration("enumerateEmpty"), Array.Empty<Parameter>(), _IEnumerator, new KeywordStatement("yield", new KeywordExpression("break", null))),
                    Return(new InvokeStaticMethodExpression(null, "enumerateEmpty", Array.Empty<ValueExpression>()))
                },
                Return(EnsureDictionary.Invoke("GetEnumerator"))
            });
        }

        private Method BuildEnsureDictionary()
        {
            return new Method(_ensureDictionarySignature, new MethodBodyStatement[]
            {
                Return(new BinaryOperatorExpression("??=", _innerDictionary, New.Instance(_dictionary)))
            });
        }
    }
}
