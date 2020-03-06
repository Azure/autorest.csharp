# Azure.Storage.Tables

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Azure.Storage.Tables
require: $(this-folder)/../readme.samples.md
# https://github.com/shurd/azure-rest-api-specs/tree/tablesSwagger/specification/cosmos-db/data-plane/Microsoft.TablesStorage/preview/2018-10-10
input-file:
    -  $(this-folder)/table.json
namespace: Azure.Storage.Tables
include-csproj: disable
```