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
    internal class ArgumentProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ArgumentProvider> _instance = new(() => new ArgumentProvider(Configuration.Namespace, null));

        private class Template<T> { }

        private const string AssertNotNullMethodName = "AssertNotNull";
        private const string AssertNotNullOrEmptyMethodName = "AssertNotNullOrEmpty";

        private readonly CSharpType _t = typeof(Template<>).GetGenericArguments()[0];
        private readonly Parameter _nameParam = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
        private readonly CSharpType _nullableT;
        private readonly ParameterReference _nameParamRef;

        public static ArgumentProvider Instance => _instance.Value;

        private ArgumentProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Public | TypeSignatureModifiers.Static;
            _nameParamRef = new ParameterReference(_nameParam);
            _nullableT = _t.WithNullable(true);
        }

        protected override string DefaultName => "Argument";

        private MethodSignature GetSignature(
            string name,
            IReadOnlyList<Parameter> parameters,
            IReadOnlyList<CSharpType>? genericArguments = null,
            IReadOnlyDictionary<CSharpType, FormattableString>? genericArgumentConstraints = null,
            CSharpType? returnType = null)
        {
            return new MethodSignature(
                name,
                null,
                null,
                MethodSignatureModifiers.Static | MethodSignatureModifiers.Public,
                returnType,
                null,
                parameters,
                GenericArguments: genericArguments,
                GenericParameterConstraints: genericArgumentConstraints);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildAssertNotNull();
            yield return BuildAssertNotNullStruct();
            yield return BuildAssertNotNullOrEmptyCollection();
            yield return BuildAssertNotNullOrEmptyString();
            yield return BuildAssertNotNullOrWhiteSpace();
            yield return BuildAssertNotDefault();
            yield return BuildAssertInRange();
            yield return BuildAssertEnumDefined();
            yield return BuildCheckNotNull();
            yield return BuildCheckNotNullOrEmptyString();
            yield return BuildAssertNull();
        }

        private Method BuildAssertNull()
        {
            var valueParam = new Parameter("value", null, _t, null, ValidationType.None, null);
            var messageParam = new Parameter("message", null, typeof(string), Constant.Default(new CSharpType(typeof(string), true)), ValidationType.None, null);
            var signature = GetSignature("AssertNull", new[] { valueParam, _nameParam, messageParam }, new[] { _t });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(NotEqual(new ParameterReference(valueParam), Null))
                {
                    ThrowArgumentException(NullCoalescing(new ParameterReference(messageParam), Literal("Value must be null.")))
                }
            });
        }

        private Method BuildCheckNotNullOrEmptyString()
        {
            var valueParam = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var signature = GetSignature("CheckNotNull", new[] { valueParam, _nameParam }, returnType: typeof(string));
            var valueParamRef = new ParameterReference(valueParam);
            return new Method(signature, new MethodBodyStatement[]
            {
                AssertNotNullOrEmpty(valueParamRef, _nameParam),
                Return(valueParamRef)
            });
        }


        private Method BuildCheckNotNull()
        {
            var valueParam = new Parameter("value", null, _t, null, ValidationType.None, null);
            var signature = GetSignature("CheckNotNull", new[] { valueParam, _nameParam }, new[] { _t }, new Dictionary<CSharpType, FormattableString>() { { _t, $"class" } }, _t);
            var valueParamRef = new ParameterReference(valueParam);
            return new Method(signature, new MethodBodyStatement[]
            {
                AssertNotNull(valueParamRef, _nameParam),
                Return(valueParamRef)
            });
        }

        private Method BuildAssertEnumDefined()
        {
            var valueParam = new Parameter("value", null, typeof(object), null, ValidationType.None, null);
            var enumTypeParam = new Parameter("enumType", null, typeof(Type), null, ValidationType.None, null);
            var signature = GetSignature("AssertEnumDefined", new[] { enumTypeParam, valueParam, _nameParam });
            var enumTypeParamRef = new ParameterReference(enumTypeParam);
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(Not(new BoolExpression(new InvokeStaticMethodExpression(typeof(Enum), "IsDefined", new[] { enumTypeParamRef, new ParameterReference(valueParam) }))))
                {
                    ThrowArgumentException(new FormattableStringExpression("Value not defined for {0}.", new MemberExpression(enumTypeParamRef, "FullName")))
                }
            });
        }

        private Method BuildAssertInRange()
        {
            var valueParam = new Parameter("value", null, _t, null, ValidationType.None, null);
            var minParam = new Parameter("minimum", null, _t, null, ValidationType.None, null);
            var maxParam = new Parameter("maximum", null, _t, null, ValidationType.None, null);
            var argConstraints = new Dictionary<CSharpType, FormattableString>()
            {
                { _t, $"notnull, {typeof(IComparable<>)}" }
            };
            var signature = GetSignature("AssertInRange", new[] { valueParam, minParam, maxParam, _nameParam }, new[] { _t }, argConstraints);
            var valueParamRef = new ParameterReference(valueParam);
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(GreaterThan(GetCompareToExpression(new ParameterReference(minParam), valueParamRef), Literal(0)))
                {
                    Throw(New.ArgumentOutOfRangeException(_nameParamRef, "Value is less than the minimum allowed.", false))
                },
                new IfStatement(LessThan(GetCompareToExpression(new ParameterReference(maxParam), valueParamRef), Literal(0)))
                {
                    Throw(New.ArgumentOutOfRangeException(_nameParamRef, "Value is greater than the maximum allowed.", false))
                }
            });
        }

        private ValueExpression GetCompareToExpression(ValueExpression left, ValueExpression right)
        {
            return left.Invoke("CompareTo", right);
        }

        private Method BuildAssertNotDefault()
        {
            var valueParam = new Parameter("value", null, _t, null, ValidationType.None, null);
            var argConstraints = new Dictionary<CSharpType, FormattableString>()
            {
                { _t, $"struct, {typeof(IEquatable<>)}" }
            };
            var signature = GetSignature("AssertNotDefault", new[] { valueParam.WithRef(), _nameParam }, new[] { _t }, argConstraints);
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new ParameterReference(valueParam).Invoke("Equals", Default)))
                {
                    ThrowArgumentException("Value cannot be empty.")
                }
            });
        }

        private Method BuildAssertNotNullOrWhiteSpace()
        {
            var valueParam = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var signature = GetSignature("AssertNotNullOrWhiteSpace", new[] { valueParam, _nameParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                AssertNotNullSnippet(valueParam),
                new IfStatement(new BoolExpression(new InvokeStaticMethodExpression(typeof(string), "IsNullOrWhiteSpace", new[] { new ParameterReference(valueParam) })))
                {
                    ThrowArgumentException("Value cannot be empty or contain only white-space characters.")
                }
            });
        }

        private Method BuildAssertNotNullOrEmptyString()
        {
            var valueParam = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var signature = GetSignature(AssertNotNullOrEmptyMethodName, new[] { valueParam, _nameParam });
            return new Method(signature, new MethodBodyStatement[]
            {
                AssertNotNullSnippet(valueParam),
                new IfStatement(Equal(new MemberExpression(new ParameterReference(valueParam), "Length"), Literal(0)))
                {
                    ThrowArgumentException("Value cannot be an empty string.")
                }
            });
        }

        private Method BuildAssertNotNullOrEmptyCollection()
        {
            const string throwMessage = "Value cannot be an empty collection.";
            var valueParam = new Parameter("value", null, new CSharpType(typeof(IEnumerable<>), _t), null, ValidationType.None, null);
            var signature = GetSignature(AssertNotNullOrEmptyMethodName, new[] { valueParam, _nameParam }, new[] { _t });
            return new Method(signature, new MethodBodyStatement[]
            {
                AssertNotNullSnippet(valueParam),
                new IfStatement(IsCollectionEmpty(valueParam, new VariableReference(new CSharpType(typeof(ICollection<>), _t), new CodeWriterDeclaration("collectionOfT"))))
                {
                    ThrowArgumentException(throwMessage)
                },
                new IfStatement(IsCollectionEmpty(valueParam, new VariableReference(typeof(ICollection), new CodeWriterDeclaration("collection"))))
                {
                    ThrowArgumentException(throwMessage)
                },
                UsingDeclare("e", new CSharpType(typeof(IEnumerator<>), _t), new ParameterReference(valueParam).Invoke("GetEnumerator"), out var eVar),
                new IfStatement(Not(new BoolExpression(eVar.Invoke("MoveNext"))))
                {
                    ThrowArgumentException(throwMessage)
                }
            });
        }

        private static BoolExpression IsCollectionEmpty(Parameter valueParam, VariableReference collection)
        {
            return BoolExpression.Is(valueParam, new DeclarationExpression(collection, false)).And(Equal(new MemberExpression(collection, "Count"), Literal(0)));
        }

        private MethodBodyStatement ThrowArgumentException(ValueExpression expression)
        {
            return Throw(New.ArgumentException(_nameParamRef, expression, false));
        }

        private MethodBodyStatement ThrowArgumentException(string message) => ThrowArgumentException(Literal(message));

        private Method BuildAssertNotNullStruct()
        {
            var valueParam = new Parameter("value", null, _nullableT, null, ValidationType.None, null);
            var signature = GetSignature(AssertNotNullMethodName, new[] { valueParam, _nameParam }, new[] { _t }, new Dictionary<CSharpType, FormattableString>() { { _t, $"struct" } });
            return new Method(signature, new MethodBodyStatement[]
            {
                new IfStatement(Not(new BoolExpression(new MemberExpression(new ParameterReference(valueParam), "HasValue"))))
                {
                Throw(New.ArgumentNullException(_nameParamRef, false))
                }
            });
        }

        private Method BuildAssertNotNull()
        {
            var valueParam = new Parameter("value", null, _t, null, ValidationType.None, null);
            var signature = GetSignature(AssertNotNullMethodName, new[] { valueParam, _nameParam }, new[] { _t });
            return new Method(signature, new MethodBodyStatement[]
            {
                AssertNotNullSnippet(valueParam)
            });
        }

        private IfStatement AssertNotNullSnippet(Parameter valueParam)
        {
            return new IfStatement(Is(new ParameterReference(valueParam), Null))
            {
                Throw(New.ArgumentNullException(_nameParamRef, false))
            };
        }

        internal MethodBodyStatement AssertNotNull(ValueExpression variable, ValueExpression? name = null)
        {
            return new InvokeStaticMethodStatement(Type, AssertNotNullMethodName, variable, name ?? Nameof(variable));
        }

        internal MethodBodyStatement AssertNotNullOrEmpty(ValueExpression variable, ValueExpression? name = null)
        {
            return new InvokeStaticMethodStatement(Type, AssertNotNullOrEmptyMethodName, variable, name ?? Nameof(variable));
        }
    }
}
