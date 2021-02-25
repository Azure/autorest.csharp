# ModelNamespace
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: OperationGroupMappings
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/TenantOnly.json
namespace: Azure.OperationGroupMappings
operation-group-to-resource-type:
   AvailableBalances : Microsoft.Billing/billingAccounts/availableBalance
   Agreements: "Microsoft.Billing/billingAccounts/agreements"
operation-group-to-resource:
   BillingAccounts: BillingAccount
   AvailableBalances: AvailableBalance
   Agreements: Agreement
```
