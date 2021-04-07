# TenantOnly
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: TenantOnly
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/TenantOnly.json
namespace: Azure.TenantOnly
operation-group-to-resource-type:
   Agreements: "Microsoft.Billing/billingAccounts/agreements"
operation-group-to-resource:
   BillingAccounts: BillingAccount
   Agreements: Agreement
```
