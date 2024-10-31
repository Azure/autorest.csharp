import "@azure-tools/typespec-azure-core";
import "@typespec/http";
import "@typespec/rest";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.Core;

@service({
    title: "SimplePost",
})
  

namespace SimplePost;

op create(@body content: string): string;