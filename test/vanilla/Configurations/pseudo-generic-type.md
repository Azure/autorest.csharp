# Generating "Generic" Model Types

> see https://aka.ms/autorest

``` YAML
input-file: ../Swagger/zapappi.json
csharp: # just having a 'csharp' node enables the use of the csharp generator.
  add-credentials: true
  override-client-name: ZapappiClient
  namespace: Zapappi.Client #override the namespace 
  directive:
  - from: code-model-v1
    where: $..[?(@.name.raw.startsWith('PagedResponse_'))]
    transform: >-
      $.name.raw = $.name.raw.replace('_', '<').replace('_', '>');    /* C#-ify generic name */
      $.name.fixed = true;                                            /* prevent sanitizing that name */
      if ($.name.raw.includes("<ContactsModel>"))
      {
        $.name.raw = $.name.raw.replace('<ContactsModel>', 'Generic');
      }
      else
      {
        $.extensions = { "x-ms-external": true };                       /* don't generate the class definitions */
      }
  - from: Models/PagedResponseGeneric.cs
    where: $
    transform: >-
        $ = $.replace("PagedResponseGeneric", "PagedResponse<T>");
        $ = $.replace(/PagedResponseGeneric/g, "PagedResponse");
        $ = $.replace(/ContactsModel/g, "T");
  - from: source-file-csharp
    where: $
    transform: >-
        $ = $.replace(/PagedResponseGeneric/g, "PagedResponse<ContactsModel>");
```