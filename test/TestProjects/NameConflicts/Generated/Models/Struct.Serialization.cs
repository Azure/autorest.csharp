// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace NameConflicts.Models
{
    public partial class Struct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(One))
            {
                writer.WritePropertyName("1"u8);
                writer.WriteStringValue(One);
            }
            if (Optional.IsDefined(Abstract))
            {
                writer.WritePropertyName("abstract"u8);
                writer.WriteStringValue(Abstract);
            }
            if (Optional.IsDefined(Add))
            {
                writer.WritePropertyName("add"u8);
                writer.WriteStringValue(Add);
            }
            if (Optional.IsDefined(Alias))
            {
                writer.WritePropertyName("alias"u8);
                writer.WriteStringValue(Alias);
            }
            if (Optional.IsDefined(As))
            {
                writer.WritePropertyName("as"u8);
                writer.WriteStringValue(As);
            }
            if (Optional.IsDefined(Ascending))
            {
                writer.WritePropertyName("ascending"u8);
                writer.WriteStringValue(Ascending);
            }
            if (Optional.IsDefined(Async))
            {
                writer.WritePropertyName("async"u8);
                writer.WriteStringValue(Async);
            }
            if (Optional.IsDefined(Await))
            {
                writer.WritePropertyName("await"u8);
                writer.WriteStringValue(Await);
            }
            if (Optional.IsDefined(Base))
            {
                writer.WritePropertyName("base"u8);
                writer.WriteStringValue(Base);
            }
            if (Optional.IsDefined(Bool))
            {
                writer.WritePropertyName("bool"u8);
                writer.WriteStringValue(Bool);
            }
            if (Optional.IsDefined(Break))
            {
                writer.WritePropertyName("break"u8);
                writer.WriteStringValue(Break);
            }
            if (Optional.IsDefined(By))
            {
                writer.WritePropertyName("by"u8);
                writer.WriteStringValue(By);
            }
            if (Optional.IsDefined(Byte))
            {
                writer.WritePropertyName("byte"u8);
                writer.WriteStringValue(Byte);
            }
            if (Optional.IsDefined(Catch))
            {
                writer.WritePropertyName("catch"u8);
                writer.WriteStringValue(Catch);
            }
            if (Optional.IsDefined(Char))
            {
                writer.WritePropertyName("char"u8);
                writer.WriteStringValue(Char);
            }
            if (Optional.IsDefined(Checked))
            {
                writer.WritePropertyName("checked"u8);
                writer.WriteStringValue(Checked);
            }
            if (Optional.IsDefined(Const))
            {
                writer.WritePropertyName("const"u8);
                writer.WriteStringValue(Const);
            }
            if (Optional.IsDefined(Continue))
            {
                writer.WritePropertyName("continue"u8);
                writer.WriteStringValue(Continue);
            }
            if (Optional.IsDefined(ClassValue))
            {
                writer.WritePropertyName("class"u8);
                writer.WriteStringValue(ClassValue);
            }
            if (Optional.IsDefined(Decimal))
            {
                writer.WritePropertyName("decimal"u8);
                writer.WriteStringValue(Decimal);
            }
            if (Optional.IsDefined(Default))
            {
                writer.WritePropertyName("default"u8);
                writer.WriteStringValue(Default);
            }
            if (Optional.IsDefined(Delegate))
            {
                writer.WritePropertyName("delegate"u8);
                writer.WriteStringValue(Delegate);
            }
            if (Optional.IsDefined(Descending))
            {
                writer.WritePropertyName("descending"u8);
                writer.WriteStringValue(Descending);
            }
            if (Optional.IsDefined(Do))
            {
                writer.WritePropertyName("do"u8);
                writer.WriteStringValue(Do);
            }
            if (Optional.IsDefined(Double))
            {
                writer.WritePropertyName("double"u8);
                writer.WriteStringValue(Double);
            }
            if (Optional.IsDefined(Dynamic))
            {
                writer.WritePropertyName("dynamic"u8);
                writer.WriteStringValue(Dynamic);
            }
            if (Optional.IsDefined(Else))
            {
                writer.WritePropertyName("else"u8);
                writer.WriteStringValue(Else);
            }
            if (Optional.IsDefined(Enum))
            {
                writer.WritePropertyName("enum"u8);
                writer.WriteStringValue(Enum);
            }
            if (Optional.IsDefined(Event))
            {
                writer.WritePropertyName("event"u8);
                writer.WriteStringValue(Event);
            }
            if (Optional.IsDefined(Explicit))
            {
                writer.WritePropertyName("explicit"u8);
                writer.WriteStringValue(Explicit);
            }
            if (Optional.IsDefined(Extern))
            {
                writer.WritePropertyName("extern"u8);
                writer.WriteStringValue(Extern);
            }
            if (Optional.IsDefined(False))
            {
                writer.WritePropertyName("false"u8);
                writer.WriteStringValue(False);
            }
            if (Optional.IsDefined(Finally))
            {
                writer.WritePropertyName("finally"u8);
                writer.WriteStringValue(Finally);
            }
            if (Optional.IsDefined(Fixed))
            {
                writer.WritePropertyName("fixed"u8);
                writer.WriteStringValue(Fixed);
            }
            if (Optional.IsDefined(Float))
            {
                writer.WritePropertyName("float"u8);
                writer.WriteStringValue(Float);
            }
            if (Optional.IsDefined(For))
            {
                writer.WritePropertyName("for"u8);
                writer.WriteStringValue(For);
            }
            if (Optional.IsDefined(Foreach))
            {
                writer.WritePropertyName("foreach"u8);
                writer.WriteStringValue(Foreach);
            }
            if (Optional.IsDefined(From))
            {
                writer.WritePropertyName("from"u8);
                writer.WriteStringValue(From);
            }
            if (Optional.IsDefined(Get))
            {
                writer.WritePropertyName("get"u8);
                writer.WriteStringValue(Get);
            }
            if (Optional.IsDefined(Global))
            {
                writer.WritePropertyName("global"u8);
                writer.WriteStringValue(Global);
            }
            if (Optional.IsDefined(Goto))
            {
                writer.WritePropertyName("goto"u8);
                writer.WriteStringValue(Goto);
            }
            if (Optional.IsDefined(Group))
            {
                writer.WritePropertyName("group"u8);
                writer.WriteStringValue(Group);
            }
            if (Optional.IsDefined(If))
            {
                writer.WritePropertyName("if"u8);
                writer.WriteStringValue(If);
            }
            if (Optional.IsDefined(Implicit))
            {
                writer.WritePropertyName("implicit"u8);
                writer.WriteStringValue(Implicit);
            }
            if (Optional.IsDefined(In))
            {
                writer.WritePropertyName("in"u8);
                writer.WriteStringValue(In);
            }
            if (Optional.IsDefined(Int))
            {
                writer.WritePropertyName("int"u8);
                writer.WriteStringValue(Int);
            }
            if (Optional.IsDefined(Interface))
            {
                writer.WritePropertyName("interface"u8);
                writer.WriteStringValue(Interface);
            }
            if (Optional.IsDefined(Internal))
            {
                writer.WritePropertyName("internal"u8);
                writer.WriteStringValue(Internal);
            }
            if (Optional.IsDefined(Into))
            {
                writer.WritePropertyName("into"u8);
                writer.WriteStringValue(Into);
            }
            if (Optional.IsDefined(Is))
            {
                writer.WritePropertyName("is"u8);
                writer.WriteStringValue(Is);
            }
            if (Optional.IsDefined(Join))
            {
                writer.WritePropertyName("join"u8);
                writer.WriteStringValue(Join);
            }
            if (Optional.IsDefined(Let))
            {
                writer.WritePropertyName("let"u8);
                writer.WriteStringValue(Let);
            }
            if (Optional.IsDefined(Lock))
            {
                writer.WritePropertyName("lock"u8);
                writer.WriteStringValue(Lock);
            }
            if (Optional.IsDefined(Long))
            {
                writer.WritePropertyName("long"u8);
                writer.WriteStringValue(Long);
            }
            if (Optional.IsDefined(Nameof))
            {
                writer.WritePropertyName("nameof"u8);
                writer.WriteStringValue(Nameof);
            }
            if (Optional.IsDefined(Namespace))
            {
                writer.WritePropertyName("namespace"u8);
                writer.WriteStringValue(Namespace);
            }
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new"u8);
                writer.WriteStringValue(New);
            }
            if (Optional.IsDefined(NullProperty))
            {
                writer.WritePropertyName("null"u8);
                writer.WriteStringValue(NullProperty);
            }
            if (Optional.IsDefined(Object))
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object);
            }
            if (Optional.IsDefined(On))
            {
                writer.WritePropertyName("on"u8);
                writer.WriteStringValue(On);
            }
            if (Optional.IsDefined(Operator))
            {
                writer.WritePropertyName("operator"u8);
                writer.WriteStringValue(Operator);
            }
            if (Optional.IsDefined(Orderby))
            {
                writer.WritePropertyName("orderby"u8);
                writer.WriteStringValue(Orderby);
            }
            if (Optional.IsDefined(Out))
            {
                writer.WritePropertyName("out"u8);
                writer.WriteStringValue(Out);
            }
            if (Optional.IsDefined(Override))
            {
                writer.WritePropertyName("override"u8);
                writer.WriteStringValue(Override);
            }
            if (Optional.IsDefined(Params))
            {
                writer.WritePropertyName("params"u8);
                writer.WriteStringValue(Params);
            }
            if (Optional.IsDefined(Partial))
            {
                writer.WritePropertyName("partial"u8);
                writer.WriteStringValue(Partial);
            }
            if (Optional.IsDefined(Private))
            {
                writer.WritePropertyName("private"u8);
                writer.WriteStringValue(Private);
            }
            if (Optional.IsDefined(Protected))
            {
                writer.WritePropertyName("protected"u8);
                writer.WriteStringValue(Protected);
            }
            if (Optional.IsDefined(Public))
            {
                writer.WritePropertyName("public"u8);
                writer.WriteStringValue(Public);
            }
            if (Optional.IsDefined(Readonly))
            {
                writer.WritePropertyName("readonly"u8);
                writer.WriteStringValue(Readonly);
            }
            if (Optional.IsDefined(Ref))
            {
                writer.WritePropertyName("ref"u8);
                writer.WriteStringValue(Ref);
            }
            if (Optional.IsDefined(Remove))
            {
                writer.WritePropertyName("remove"u8);
                writer.WriteStringValue(Remove);
            }
            if (Optional.IsDefined(Return))
            {
                writer.WritePropertyName("return"u8);
                writer.WriteStringValue(Return);
            }
            if (Optional.IsDefined(Sbyte))
            {
                writer.WritePropertyName("sbyte"u8);
                writer.WriteStringValue(Sbyte);
            }
            if (Optional.IsDefined(Sealed))
            {
                writer.WritePropertyName("sealed"u8);
                writer.WriteStringValue(Sealed);
            }
            if (Optional.IsDefined(Select))
            {
                writer.WritePropertyName("select"u8);
                writer.WriteStringValue(Select);
            }
            if (Optional.IsDefined(Set))
            {
                writer.WritePropertyName("set"u8);
                writer.WriteStringValue(Set);
            }
            if (Optional.IsDefined(Short))
            {
                writer.WritePropertyName("short"u8);
                writer.WriteStringValue(Short);
            }
            if (Optional.IsDefined(Sizeof))
            {
                writer.WritePropertyName("sizeof"u8);
                writer.WriteStringValue(Sizeof);
            }
            if (Optional.IsDefined(Stackalloc))
            {
                writer.WritePropertyName("stackalloc"u8);
                writer.WriteStringValue(Stackalloc);
            }
            if (Optional.IsDefined(Static))
            {
                writer.WritePropertyName("static"u8);
                writer.WriteStringValue(Static);
            }
            if (Optional.IsDefined(String))
            {
                writer.WritePropertyName("string"u8);
                writer.WriteStringValue(String);
            }
            if (Optional.IsDefined(Struct))
            {
                writer.WritePropertyName("struct"u8);
                writer.WriteStringValue(Struct);
            }
            if (Optional.IsDefined(Switch))
            {
                writer.WritePropertyName("switch"u8);
                writer.WriteStringValue(Switch);
            }
            if (Optional.IsDefined(This))
            {
                writer.WritePropertyName("this"u8);
                writer.WriteStringValue(This);
            }
            if (Optional.IsDefined(Throw))
            {
                writer.WritePropertyName("throw"u8);
                writer.WriteStringValue(Throw);
            }
            if (Optional.IsDefined(True))
            {
                writer.WritePropertyName("true"u8);
                writer.WriteStringValue(True);
            }
            if (Optional.IsDefined(Try))
            {
                writer.WritePropertyName("try"u8);
                writer.WriteStringValue(Try);
            }
            if (Optional.IsDefined(Typeof))
            {
                writer.WritePropertyName("typeof"u8);
                writer.WriteStringValue(Typeof);
            }
            if (Optional.IsDefined(Uint))
            {
                writer.WritePropertyName("uint"u8);
                writer.WriteStringValue(Uint);
            }
            if (Optional.IsDefined(Ulong))
            {
                writer.WritePropertyName("ulong"u8);
                writer.WriteStringValue(Ulong);
            }
            if (Optional.IsDefined(Unchecked))
            {
                writer.WritePropertyName("unchecked"u8);
                writer.WriteStringValue(Unchecked);
            }
            if (Optional.IsDefined(Unmanaged))
            {
                writer.WritePropertyName("unmanaged"u8);
                writer.WriteStringValue(Unmanaged);
            }
            if (Optional.IsDefined(Unsafe))
            {
                writer.WritePropertyName("unsafe"u8);
                writer.WriteStringValue(Unsafe);
            }
            if (Optional.IsDefined(Ushort))
            {
                writer.WritePropertyName("ushort"u8);
                writer.WriteStringValue(Ushort);
            }
            if (Optional.IsDefined(Using))
            {
                writer.WritePropertyName("using"u8);
                writer.WriteStringValue(Using);
            }
            if (Optional.IsDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(Value);
            }
            if (Optional.IsDefined(Var))
            {
                writer.WritePropertyName("var"u8);
                writer.WriteStringValue(Var);
            }
            if (Optional.IsDefined(Virtual))
            {
                writer.WritePropertyName("virtual"u8);
                writer.WriteStringValue(Virtual);
            }
            if (Optional.IsDefined(Void))
            {
                writer.WritePropertyName("void"u8);
                writer.WriteStringValue(Void);
            }
            if (Optional.IsDefined(Volatile))
            {
                writer.WritePropertyName("volatile"u8);
                writer.WriteStringValue(Volatile);
            }
            if (Optional.IsDefined(When))
            {
                writer.WritePropertyName("when"u8);
                writer.WriteStringValue(When);
            }
            if (Optional.IsDefined(Where))
            {
                writer.WritePropertyName("where"u8);
                writer.WriteStringValue(Where);
            }
            if (Optional.IsDefined(While))
            {
                writer.WritePropertyName("while"u8);
                writer.WriteStringValue(While);
            }
            if (Optional.IsDefined(Yield))
            {
                writer.WritePropertyName("yield"u8);
                writer.WriteStringValue(Yield);
            }
            if (Optional.IsDefined(System))
            {
                writer.WritePropertyName("System"u8);
                writer.WriteStringValue(System.Value.ToString());
            }
            if (Optional.IsDefined(ToStringValue))
            {
                writer.WritePropertyName("ToString"u8);
                writer.WriteStringValue(ToStringValue);
            }
            if (Optional.IsDefined(EqualsValue))
            {
                writer.WritePropertyName("Equals"u8);
                writer.WriteStringValue(EqualsValue);
            }
            if (Optional.IsDefined(GetHashCodeValue))
            {
                writer.WritePropertyName("GetHashCode"u8);
                writer.WriteStringValue(GetHashCodeValue);
            }
            writer.WriteEndObject();
        }

        internal static Struct DeserializeStruct(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> _1 = default;
            Optional<string> @abstract = default;
            Optional<string> @add = default;
            Optional<string> @alias = default;
            Optional<string> @as = default;
            Optional<string> @ascending = default;
            Optional<string> @async = default;
            Optional<string> @await = default;
            Optional<string> @base = default;
            Optional<string> @bool = default;
            Optional<string> @break = default;
            Optional<string> @by = default;
            Optional<string> @byte = default;
            Optional<string> @catch = default;
            Optional<string> @char = default;
            Optional<string> @checked = default;
            Optional<string> @const = default;
            Optional<string> @continue = default;
            Optional<string> @class = default;
            Optional<string> @decimal = default;
            Optional<string> @default = default;
            Optional<string> @delegate = default;
            Optional<string> @descending = default;
            Optional<string> @do = default;
            Optional<string> @double = default;
            Optional<string> @dynamic = default;
            Optional<string> @else = default;
            Optional<string> @enum = default;
            Optional<string> @event = default;
            Optional<string> @explicit = default;
            Optional<string> @extern = default;
            Optional<string> @false = default;
            Optional<string> @finally = default;
            Optional<string> @fixed = default;
            Optional<string> @float = default;
            Optional<string> @for = default;
            Optional<string> @foreach = default;
            Optional<string> @from = default;
            Optional<string> @get = default;
            Optional<string> @global = default;
            Optional<string> @goto = default;
            Optional<string> group = default;
            Optional<string> @if = default;
            Optional<string> @implicit = default;
            Optional<string> @in = default;
            Optional<string> @int = default;
            Optional<string> @interface = default;
            Optional<string> @internal = default;
            Optional<string> @into = default;
            Optional<string> @is = default;
            Optional<string> @join = default;
            Optional<string> @let = default;
            Optional<string> @lock = default;
            Optional<string> @long = default;
            Optional<string> @nameof = default;
            Optional<string> @namespace = default;
            Optional<string> @new = default;
            Optional<string> @null = default;
            Optional<string> @object = default;
            Optional<string> @on = default;
            Optional<string> @operator = default;
            Optional<string> orderby = default;
            Optional<string> @out = default;
            Optional<string> @override = default;
            Optional<string> @params = default;
            Optional<string> @partial = default;
            Optional<string> @private = default;
            Optional<string> @protected = default;
            Optional<string> @public = default;
            Optional<string> @readonly = default;
            Optional<string> @ref = default;
            Optional<string> @remove = default;
            Optional<string> @return = default;
            Optional<string> @sbyte = default;
            Optional<string> @sealed = default;
            Optional<string> select = default;
            Optional<string> @set = default;
            Optional<string> @short = default;
            Optional<string> @sizeof = default;
            Optional<string> @stackalloc = default;
            Optional<string> @static = default;
            Optional<string> @string = default;
            Optional<string> @struct = default;
            Optional<string> @switch = default;
            Optional<string> @this = default;
            Optional<string> @throw = default;
            Optional<string> @true = default;
            Optional<string> @try = default;
            Optional<string> @typeof = default;
            Optional<string> @uint = default;
            Optional<string> @ulong = default;
            Optional<string> @unchecked = default;
            Optional<string> @unmanaged = default;
            Optional<string> @unsafe = default;
            Optional<string> @ushort = default;
            Optional<string> @using = default;
            Optional<string> value = default;
            Optional<string> @var = default;
            Optional<string> @virtual = default;
            Optional<string> @void = default;
            Optional<string> @volatile = default;
            Optional<string> @when = default;
            Optional<string> @where = default;
            Optional<string> @while = default;
            Optional<string> @yield = default;
            Optional<SystemEnum> system = default;
            Optional<string> toString = default;
            Optional<string> @equals = default;
            Optional<string> getHashCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("1"u8))
                {
                    _1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("abstract"u8))
                {
                    @abstract = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("add"u8))
                {
                    @add = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("alias"u8))
                {
                    @alias = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("as"u8))
                {
                    @as = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ascending"u8))
                {
                    @ascending = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("async"u8))
                {
                    @async = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("await"u8))
                {
                    @await = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("base"u8))
                {
                    @base = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bool"u8))
                {
                    @bool = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("break"u8))
                {
                    @break = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("by"u8))
                {
                    @by = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("byte"u8))
                {
                    @byte = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("catch"u8))
                {
                    @catch = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("char"u8))
                {
                    @char = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("checked"u8))
                {
                    @checked = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("const"u8))
                {
                    @const = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("continue"u8))
                {
                    @continue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("class"u8))
                {
                    @class = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("decimal"u8))
                {
                    @decimal = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("default"u8))
                {
                    @default = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("delegate"u8))
                {
                    @delegate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("descending"u8))
                {
                    @descending = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("do"u8))
                {
                    @do = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("double"u8))
                {
                    @double = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dynamic"u8))
                {
                    @dynamic = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("else"u8))
                {
                    @else = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("enum"u8))
                {
                    @enum = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("event"u8))
                {
                    @event = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("explicit"u8))
                {
                    @explicit = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("extern"u8))
                {
                    @extern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("false"u8))
                {
                    @false = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finally"u8))
                {
                    @finally = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fixed"u8))
                {
                    @fixed = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("float"u8))
                {
                    @float = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("for"u8))
                {
                    @for = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("foreach"u8))
                {
                    @foreach = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("from"u8))
                {
                    @from = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("get"u8))
                {
                    @get = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("global"u8))
                {
                    @global = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("goto"u8))
                {
                    @goto = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("group"u8))
                {
                    group = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("if"u8))
                {
                    @if = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("implicit"u8))
                {
                    @implicit = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("in"u8))
                {
                    @in = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("int"u8))
                {
                    @int = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("interface"u8))
                {
                    @interface = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("internal"u8))
                {
                    @internal = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("into"u8))
                {
                    @into = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("is"u8))
                {
                    @is = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("join"u8))
                {
                    @join = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("let"u8))
                {
                    @let = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lock"u8))
                {
                    @lock = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("long"u8))
                {
                    @long = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nameof"u8))
                {
                    @nameof = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("namespace"u8))
                {
                    @namespace = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("new"u8))
                {
                    @new = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("null"u8))
                {
                    @null = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("on"u8))
                {
                    @on = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("operator"u8))
                {
                    @operator = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("orderby"u8))
                {
                    orderby = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("out"u8))
                {
                    @out = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("override"u8))
                {
                    @override = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("params"u8))
                {
                    @params = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("partial"u8))
                {
                    @partial = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("private"u8))
                {
                    @private = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("protected"u8))
                {
                    @protected = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("public"u8))
                {
                    @public = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("readonly"u8))
                {
                    @readonly = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ref"u8))
                {
                    @ref = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("remove"u8))
                {
                    @remove = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("return"u8))
                {
                    @return = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sbyte"u8))
                {
                    @sbyte = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sealed"u8))
                {
                    @sealed = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("select"u8))
                {
                    select = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("set"u8))
                {
                    @set = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("short"u8))
                {
                    @short = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sizeof"u8))
                {
                    @sizeof = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("stackalloc"u8))
                {
                    @stackalloc = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("static"u8))
                {
                    @static = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("string"u8))
                {
                    @string = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("struct"u8))
                {
                    @struct = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("switch"u8))
                {
                    @switch = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("this"u8))
                {
                    @this = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("throw"u8))
                {
                    @throw = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("true"u8))
                {
                    @true = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("try"u8))
                {
                    @try = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("typeof"u8))
                {
                    @typeof = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("uint"u8))
                {
                    @uint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ulong"u8))
                {
                    @ulong = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("unchecked"u8))
                {
                    @unchecked = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("unmanaged"u8))
                {
                    @unmanaged = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("unsafe"u8))
                {
                    @unsafe = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ushort"u8))
                {
                    @ushort = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("using"u8))
                {
                    @using = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("var"u8))
                {
                    @var = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("virtual"u8))
                {
                    @virtual = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("void"u8))
                {
                    @void = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("volatile"u8))
                {
                    @volatile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("when"u8))
                {
                    @when = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("where"u8))
                {
                    @where = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("while"u8))
                {
                    @while = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("yield"u8))
                {
                    @yield = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("System"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    system = new SystemEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("ToString"u8))
                {
                    toString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Equals"u8))
                {
                    @equals = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("GetHashCode"u8))
                {
                    getHashCode = property.Value.GetString();
                    continue;
                }
            }
            return new Struct(@abstract.Value, @add.Value, @alias.Value, @as.Value, @ascending.Value, @async.Value, @await.Value, @base.Value, @bool.Value, @break.Value, @by.Value, @byte.Value, @catch.Value, @char.Value, @checked.Value, @const.Value, @continue.Value, @class.Value, @decimal.Value, @default.Value, @delegate.Value, @descending.Value, @do.Value, @double.Value, @dynamic.Value, @else.Value, @enum.Value, @event.Value, @explicit.Value, @extern.Value, @false.Value, @finally.Value, @fixed.Value, @float.Value, @for.Value, @foreach.Value, @from.Value, @get.Value, @global.Value, @goto.Value, group.Value, @if.Value, @implicit.Value, @in.Value, @int.Value, @interface.Value, @internal.Value, @into.Value, @is.Value, @join.Value, @let.Value, @lock.Value, @long.Value, @nameof.Value, @namespace.Value, @new.Value, @null.Value, @object.Value, @on.Value, @operator.Value, orderby.Value, @out.Value, @override.Value, @params.Value, @partial.Value, @private.Value, @protected.Value, @public.Value, @readonly.Value, @ref.Value, @remove.Value, @return.Value, @sbyte.Value, @sealed.Value, select.Value, @set.Value, @short.Value, @sizeof.Value, @stackalloc.Value, @static.Value, @string.Value, @struct.Value, @switch.Value, @this.Value, @throw.Value, @true.Value, @try.Value, @typeof.Value, @uint.Value, @ulong.Value, @unchecked.Value, @unmanaged.Value, @unsafe.Value, @ushort.Value, @using.Value, value.Value, @var.Value, @virtual.Value, @void.Value, @volatile.Value, @when.Value, @where.Value, @while.Value, @yield.Value, Optional.ToNullable(system), toString.Value, @equals.Value, getHashCode.Value, _1.Value);
        }
    }
}
